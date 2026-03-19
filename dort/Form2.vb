Public Class Form2
    ' === 共用狀態 ===
    Private dartCount As Integer = 0       ' 本輪已投鏢數 (0-3)
    Private currentPlayer As Integer = 1   ' 當前玩家 (1-based)
    Private roundNum As Integer = 1        ' 回合數
    Private peo As Integer                 ' 玩家人數

    ' 玩家 UI
    Private playerNameLabels() As Label    ' p1~p8
    Private playerScoreLabels() As Label   ' Label1~Label8

    ' === x01 專用 ===
    Private playerScores() As Integer      ' 每位玩家剩餘分數
    Private roundStartScore As Integer     ' 本輪開始前的分數（用於 Bust 回滾）
    Private playerOpened() As Boolean      ' 是否已 "開局"（Double In / Master In）
    Private lastDartIsDouble As Boolean    ' 最後一鏢是否為 Double
    Private lastDartIsMaster As Boolean    ' 最後一鏢是否為 Double 或 Triple

    ' === Cricket 專用 ===
    ' 目標: 20,19,18,17,16,15,Bull (索引 0-6)
    Private ReadOnly cricketNumbers() As Integer = {20, 19, 18, 17, 16, 15, 25}
    Private cricketMarks(,) As Integer     ' (player, target) marks count
    Private cricketPoints() As Integer     ' 每位玩家的得分
    Private cricketLabels(,) As Label      ' 動態建立的 Cricket 計分板 labels

    ' ========================================================================
    ' Form Load
    ' ========================================================================
    Private Sub Form2_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        peo = GameSettings.PlayerCount

        playerNameLabels = New Label() {p1, p2, p3, p4, p5, p6, p7, p8}
        playerScoreLabels = New Label() {Label1, Label2, Label3, Label4, Label5, Label6, Label7, Label8}

        For x = 0 To peo - 1
            playerNameLabels(x).Visible = True
            playerScoreLabels(x).Visible = True
        Next

        SetupDartButtons()
        Timer1.Enabled = True

        Select Case GameSettings.CurrentMode
            Case GameMode.CountUp
                InitCountUp()
            Case GameMode.ZeroOne
                InitZeroOne()
            Case GameMode.Cricket
                InitCricket()
        End Select

        MsgBox("靶上的按鈕顯示完之前切莫操作，避免出問題", 0, "飛鏢計分程式")
    End Sub

    ' ========================================================================
    ' 飛鏢按鈕設定（共用）
    ' ========================================================================
    Private Sub SetupDartButtons()
        ' Tag 格式: "分數,顯示名稱,類型"
        ' 類型: S=Single, D=Double, T=Triple, B=Bull, SB=SingleBull, O=Out
        Dim dartMap As New Dictionary(Of Button, String) From {
            {Bull, "50,D-Bull,B"},
            {SBull, "25,S-Bull,SB"},
            {s1one, "1,S1,S"}, {s1two, "1,S1,S"}, {d1, "2,D1,D"}, {t1, "3,T1,T"},
            {s2one, "2,S2,S"}, {s2two, "2,S2,S"}, {d2, "4,D2,D"}, {t2, "6,T2,T"},
            {s3one, "3,S3,S"}, {s3two, "3,S3,S"}, {d3, "6,D3,D"}, {t3, "9,T3,T"},
            {s4one, "4,S4,S"}, {s4two, "4,S4,S"}, {d4, "8,D4,D"}, {t4, "12,T4,T"},
            {s5one, "5,S5,S"}, {s5two, "5,S5,S"}, {d5, "10,D5,D"}, {t5, "15,T5,T"},
            {s6one, "6,S6,S"}, {s6two, "6,S6,S"}, {d6, "12,D6,D"}, {t6, "18,T6,T"},
            {s7one, "7,S7,S"}, {s7two, "7,S7,S"}, {d7, "14,D7,D"}, {t7, "21,T7,T"},
            {s8one, "8,S8,S"}, {s8two, "8,S8,S"}, {d8, "16,D8,D"}, {t8, "24,T8,T"},
            {s9one, "9,S9,S"}, {s9two, "9,S9,S"}, {d9, "18,D9,D"}, {t9, "27,T9,T"},
            {s10one, "10,S10,S"}, {s10two, "10,S10,S"}, {d10, "20,D10,D"}, {t10, "30,T10,T"},
            {s11one, "11,S11,S"}, {s11two, "11,S11,S"}, {d11, "22,D11,D"}, {t11, "33,T11,T"},
            {s12one, "12,S12,S"}, {s12two, "12,S12,S"}, {d12, "24,D12,D"}, {t12, "36,T12,T"},
            {s13one, "13,S13,S"}, {s13two, "13,S13,S"}, {d13, "26,D13,D"}, {t13, "39,T13,T"},
            {s14one, "14,S14,S"}, {s14two, "14,S14,S"}, {d14, "28,D14,D"}, {t14, "42,T14,T"},
            {s15one, "15,S15,S"}, {s15two, "15,S15,S"}, {d15, "30,D15,D"}, {t15, "45,T15,T"},
            {s16one, "16,S16,S"}, {s16two, "16,S16,S"}, {d16, "32,D16,D"}, {t16, "48,T16,T"},
            {s17one, "17,S17,S"}, {s17two, "17,S17,S"}, {d17, "34,D17,D"}, {t17, "51,T17,T"},
            {s18one, "18,S18,S"}, {s18two, "18,S18,S"}, {d18, "36,D18,D"}, {t18, "54,T18,T"},
            {s19one, "19,S19,S"}, {s19two, "19,S19,S"}, {d19, "38,D19,D"}, {t19, "57,T19,T"},
            {s20one, "20,S20,S"}, {s20two, "20,S20,S"}, {d20, "40,D20,D"}, {t20, "60,T20,T"},
            {out, "0,OUT,O"}
        }

        For Each kvp In dartMap
            kvp.Key.Tag = kvp.Value
            AddHandler kvp.Key.Click, AddressOf DartButton_Click
        Next
    End Sub

    ' ========================================================================
    ' 共用 Click Handler（分流到各模式）
    ' ========================================================================
    Private Sub DartButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        If dartCount >= 3 Then Return

        Dim btn As Button = DirectCast(sender, Button)
        Dim parts() As String = btn.Tag.ToString().Split(","c)
        Dim score As Integer = CInt(parts(0))
        Dim label As String = parts(1)
        Dim dartType As String = parts(2)  ' S/D/T/B/SB/O

        ' 取得原始數字（用於 Cricket）
        Dim baseNumber As Integer = GetBaseNumber(score, dartType)
        Dim marks As Integer = GetMarksCount(dartType)

        Select Case GameSettings.CurrentMode
            Case GameMode.CountUp
                HandleCountUp(score, label)
            Case GameMode.ZeroOne
                HandleZeroOne(score, label, dartType)
            Case GameMode.Cricket
                HandleCricket(baseNumber, marks, score, label, dartType)
        End Select
    End Sub

    ''' <summary>從分數和類型還原原始數字</summary>
    Private Function GetBaseNumber(score As Integer, dartType As String) As Integer
        Select Case dartType
            Case "D" : Return score \ 2
            Case "T" : Return score \ 3
            Case "B" : Return 25   ' D-Bull → 25 (inner)
            Case "SB" : Return 25  ' S-Bull → 25 (outer)
            Case "O" : Return 0
            Case Else : Return score  ' Single
        End Select
    End Function

    ''' <summary>此鏢計幾個 mark（Cricket 用）</summary>
    Private Function GetMarksCount(dartType As String) As Integer
        Select Case dartType
            Case "S", "SB" : Return 1
            Case "D", "B" : Return 2   ' D-Bull = 2 marks
            Case "T" : Return 3
            Case Else : Return 0
        End Select
    End Function

    ' ========================================================================
    ' COUNT-UP 模式
    ' ========================================================================
    Private Sub InitCountUp()
        For x = 0 To peo - 1
            playerScoreLabels(x).Text = "0"
        Next
    End Sub

    Private Sub HandleCountUp(score As Integer, label As String)
        dartCount += 1
        scb.Text = scb.Text & " " & label

        ' 即時加分
        Dim cur As Integer = CInt(playerScoreLabels(currentPlayer - 1).Text)
        playerScoreLabels(currentPlayer - 1).Text = CStr(cur + score)
    End Sub

    ' ========================================================================
    ' x01 模式
    ' ========================================================================
    Private Sub InitZeroOne()
        ReDim playerScores(peo - 1)
        ReDim playerOpened(peo - 1)

        For x = 0 To peo - 1
            playerScores(x) = GameSettings.StartScore
            playerScoreLabels(x).Text = CStr(GameSettings.StartScore)
            ' Open In 模式直接開局
            playerOpened(x) = (GameSettings.RuleIn = InOutRule.Open)
        Next
    End Sub

    Private Sub HandleZeroOne(score As Integer, label As String, dartType As String)
        Dim pi As Integer = currentPlayer - 1

        ' 記錄本輪開始前分數（第一鏢時）
        If dartCount = 0 Then
            roundStartScore = playerScores(pi)
        End If

        ' 檢查 In 規則（尚未開局）
        If Not playerOpened(pi) Then
            Dim opened As Boolean = False
            Select Case GameSettings.RuleIn
                Case InOutRule.Double
                    opened = (dartType = "D" OrElse dartType = "B")
                Case InOutRule.Master
                    opened = (dartType = "D" OrElse dartType = "T" OrElse dartType = "B")
            End Select

            If Not opened Then
                ' 此鏢不計分
                dartCount += 1
                scb.Text = scb.Text & " (" & label & ")"
                Return
            End If
            playerOpened(pi) = True
        End If

        ' 記錄最後一鏢類型（Out 判斷用）
        lastDartIsDouble = (dartType = "D" OrElse dartType = "B")
        lastDartIsMaster = (dartType = "D" OrElse dartType = "T" OrElse dartType = "B")

        Dim newScore As Integer = playerScores(pi) - score

        ' Bust 檢查
        If newScore < 0 Then
            ' 扣超過 → Bust
            dartCount = 3  ' 強制結束本輪
            playerScores(pi) = roundStartScore
            playerScoreLabels(pi).Text = CStr(roundStartScore)
            scb.Text = scb.Text & " " & label & " BUST!"
            Return
        End If

        If newScore = 1 Then
            ' 剩 1 分無法 Double 結束 → Bust
            dartCount = 3
            playerScores(pi) = roundStartScore
            playerScoreLabels(pi).Text = CStr(roundStartScore)
            scb.Text = scb.Text & " " & label & " BUST!"
            Return
        End If

        If newScore = 0 Then
            ' 檢查 Out 規則
            Dim validOut As Boolean = False
            Select Case GameSettings.RuleOut
                Case InOutRule.Open
                    validOut = True
                Case InOutRule.Double
                    validOut = lastDartIsDouble
                Case InOutRule.Master
                    validOut = lastDartIsMaster
            End Select

            If Not validOut Then
                ' 歸零但不是正確的 Out → Bust
                dartCount = 3
                playerScores(pi) = roundStartScore
                playerScoreLabels(pi).Text = CStr(roundStartScore)
                scb.Text = scb.Text & " " & label & " BUST! (需 " & GetOutRuleName() & " Out)"
                Return
            End If

            ' 勝利！
            playerScores(pi) = 0
            playerScoreLabels(pi).Text = "0"
            dartCount += 1
            scb.Text = scb.Text & " " & label & " ★OUT!"
            MsgBox("Player " & currentPlayer & " 獲勝！" & vbCrLf & "用了 " & roundNum & " 回合", 64, "飛鏢計分程式 — 01")
            Form1.Show()
            Me.Close()
            Return
        End If

        ' 正常扣分
        dartCount += 1
        playerScores(pi) = newScore
        playerScoreLabels(pi).Text = CStr(newScore)
        scb.Text = scb.Text & " " & label
    End Sub

    Private Function GetOutRuleName() As String
        Select Case GameSettings.RuleOut
            Case InOutRule.Double : Return "Double"
            Case InOutRule.Master : Return "Master"
            Case Else : Return "Open"
        End Select
    End Function

    ' ========================================================================
    ' CRICKET 模式
    ' ========================================================================
    Private Sub InitCricket()
        ReDim cricketMarks(peo - 1, 6)
        ReDim cricketPoints(peo - 1)

        ' 隱藏原本的分數 label（改用 Cricket 計分板）
        For x = 0 To peo - 1
            playerScoreLabels(x).Text = "0"
        Next

        ' 動態建立 Cricket 計分板
        BuildCricketBoard()
    End Sub

    Private Sub BuildCricketBoard()
        ' 在靶面右側建立 Cricket 顯示區
        Dim startX As Integer = 560
        Dim startY As Integer = 60
        Dim colW As Integer = 45
        Dim rowH As Integer = 25

        ReDim cricketLabels(peo - 1, 6)

        ' 標題列 — 數字
        For t = 0 To 6
            Dim hdr As New Label()
            hdr.Text = If(t = 6, "Bull", cricketNumbers(t).ToString())
            hdr.Location = New System.Drawing.Point(startX + (t + 1) * colW, startY)
            hdr.AutoSize = True
            hdr.Font = New System.Drawing.Font("新細明體", 9, System.Drawing.FontStyle.Bold)
            Me.Controls.Add(hdr)
        Next

        ' 每位玩家一行
        For p = 0 To peo - 1
            ' 玩家名
            Dim pLbl As New Label()
            pLbl.Text = "P" & (p + 1)
            pLbl.Location = New System.Drawing.Point(startX, startY + (p + 1) * rowH)
            pLbl.AutoSize = True
            pLbl.Font = New System.Drawing.Font("新細明體", 9, System.Drawing.FontStyle.Bold)
            Me.Controls.Add(pLbl)

            ' 每個目標數字的 marks
            For t = 0 To 6
                Dim cLbl As New Label()
                cLbl.Text = ""
                cLbl.Location = New System.Drawing.Point(startX + (t + 1) * colW, startY + (p + 1) * rowH)
                cLbl.AutoSize = True
                cLbl.Font = New System.Drawing.Font("新細明體", 10)
                Me.Controls.Add(cLbl)
                cricketLabels(p, t) = cLbl
            Next
        Next
    End Sub

    Private Sub HandleCricket(baseNumber As Integer, marks As Integer, score As Integer, label As String, dartType As String)
        ' 找到目標索引
        Dim targetIdx As Integer = -1
        For t = 0 To 6
            If cricketNumbers(t) = baseNumber Then
                targetIdx = t
                Exit For
            End If
        Next

        dartCount += 1
        scb.Text = scb.Text & " " & label

        ' 不是 Cricket 目標數字（1-14）或 OUT → 不計分
        If targetIdx = -1 Then Return

        Dim pi As Integer = currentPlayer - 1
        Dim oldMarks As Integer = cricketMarks(pi, targetIdx)

        If oldMarks >= 3 Then
            ' 已關閉 → 對未關閉此數字的對手加分
            For opp = 0 To peo - 1
                If opp = pi Then Continue For
                If cricketMarks(opp, targetIdx) < 3 Then
                    cricketPoints(pi) += score
                    playerScoreLabels(pi).Text = CStr(cricketPoints(pi))
                    Exit For  ' 計分一次就好（多人時只要有人沒關就加分）
                End If
            Next
        Else
            ' 尚未關閉 → 累加 marks
            Dim newMarks As Integer = Math.Min(oldMarks + marks, 3)
            Dim overflow As Integer = (oldMarks + marks) - 3

            cricketMarks(pi, targetIdx) = newMarks
            UpdateCricketLabel(pi, targetIdx)

            ' 超過 3 的 marks → 對手未關閉則得分
            If overflow > 0 Then
                Dim overflowScore As Integer = baseNumber * overflow
                If baseNumber = 25 AndAlso dartType = "B" Then
                    ' D-Bull 原始 50 分，溢出 marks 按 25 計
                    overflowScore = 25 * overflow
                End If
                For opp = 0 To peo - 1
                    If opp = pi Then Continue For
                    If cricketMarks(opp, targetIdx) < 3 Then
                        cricketPoints(pi) += overflowScore
                        playerScoreLabels(pi).Text = CStr(cricketPoints(pi))
                        Exit For
                    End If
                Next
            End If

            ' 檢查勝利
            If CheckCricketWin(pi) Then
                MsgBox("Player " & currentPlayer & " 獲勝！" & vbCrLf & _
                       "得分: " & cricketPoints(pi), 64, "飛鏢計分程式 — Cricket")
                Form1.Show()
                Me.Close()
                Return
            End If
        End If
    End Sub

    Private Sub UpdateCricketLabel(player As Integer, target As Integer)
        Dim m As Integer = cricketMarks(player, target)
        Select Case m
            Case 0 : cricketLabels(player, target).Text = ""
            Case 1 : cricketLabels(player, target).Text = "/"
            Case 2 : cricketLabels(player, target).Text = "X"
            Case Else : cricketLabels(player, target).Text = "⊗"
        End Select
    End Sub

    Private Function CheckCricketWin(player As Integer) As Boolean
        ' 全部 7 個目標都關閉
        For t = 0 To 6
            If cricketMarks(player, t) < 3 Then Return False
        Next
        ' 且得分不低於所有對手
        For opp = 0 To peo - 1
            If opp = player Then Continue For
            If cricketPoints(player) < cricketPoints(opp) Then Return False
        Next
        Return True
    End Function

    ' ========================================================================
    ' Timer — 換人邏輯（共用）
    ' ========================================================================
    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer1.Tick
        ' 三鏢投完 → 換人
        If dartCount >= 3 Then
            currentPlayer += 1
            dartCount = 0

            If currentPlayer > peo Then
                roundNum += 1

                ' Count-Up 模式限制 8 回合
                If GameSettings.CurrentMode = GameMode.CountUp AndAlso roundNum > 8 Then
                    MsgBox("遊戲結束", 64, "飛鏢計分程式")
                    ShowRanking()
                    Form1.Show()
                    Me.Close()
                    Return
                End If

                currentPlayer = 1
                MsgBox("第" & roundNum & "回合", 0, "飛鏢計分程式")
            Else
                MsgBox("請拔標，換下一位玩家", 48, "飛鏢計分程式")
            End If
            scb.Text = ""
        End If
    End Sub

    ' ========================================================================
    ' Count-Up 排名（降序）
    ' ========================================================================
    Private Sub ShowRanking()
        Dim names(peo - 1) As String
        Dim scores(peo - 1) As Integer

        For idx = 0 To peo - 1
            names(idx) = "Player" & (idx + 1)
            scores(idx) = CInt(playerScoreLabels(idx).Text)
        Next

        For f = 0 To peo - 2
            For j = 0 To peo - 2 - f
                If scores(j) < scores(j + 1) Then
                    Dim ts As Integer = scores(j)
                    scores(j) = scores(j + 1)
                    scores(j + 1) = ts
                    Dim tn As String = names(j)
                    names(j) = names(j + 1)
                    names(j + 1) = tn
                End If
            Next
        Next

        For idx = 0 To peo - 1
            MsgBox("第" & (idx + 1) & "名是" & names(idx) & vbCrLf & "分數為:" & scores(idx), 64, "飛鏢計分程式")
        Next
        MsgBox("將跳回選人數頁面", 64, "飛鏢計分程式")
    End Sub
End Class
