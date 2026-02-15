Public Class Form2
    Dim a As Integer = 0        ' 計算三支鏢
    Dim b As Integer = 0        ' 局內分數暫存
    Dim c As Integer = 1        ' 局數
    Dim i As Integer = 1        ' 玩家計數
    Public peo As Integer = Form1.peo ' 從 Form1 接收人數

    ' 玩家 Label 陣列
    Private playerLab() As Label
    Private playerSc() As Label

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        playerLab = New Label() {p1, p2, p3, p4, p5, p6, p7, p8}
        playerSc = New Label() {Label1, Label2, Label3, Label4, Label5, Label6, Label7, Label8}

        For x = 0 To peo - 1
            playerLab(x).Visible = True
            playerSc(x).Visible = True
        Next

        ' 用 Tag 存分數資料，統一綁定 click handler
        SetupDartButtons()

        Timer1.Enabled = True
        MsgBox("靶上的按鈕顯示完之前切莫操作，避免出問題", 0, "飛鏢計分程式")
    End Sub

    ''' <summary>
    ''' 統一設定所有飛鏢按鈕的 Tag（分數值 & 顯示名稱）並綁定共用 handler
    ''' </summary>
    Private Sub SetupDartButtons()
        ' 格式: "分數,顯示名稱"
        Dim dartMap As Dictionary(Of Button, String) = New Dictionary(Of Button, String) From {
            {Bull, "50,Bull"},
            {s1one, "1,S1"}, {s1two, "1,S1"}, {d1, "2,D1"}, {t1, "3,T1"},
            {s2one, "2,S2"}, {s2two, "2,S2"}, {d2, "4,D2"}, {t2, "6,T2"},
            {s3one, "3,S3"}, {s3two, "3,S3"}, {d3, "6,D3"}, {t3, "9,T3"},
            {s4one, "4,S4"}, {s4two, "4,S4"}, {d4, "8,D4"}, {t4, "12,T4"},
            {s5one, "5,S5"}, {s5two, "5,S5"}, {d5, "10,D5"}, {t5, "15,T5"},
            {s6one, "6,S6"}, {s6two, "6,S6"}, {d6, "12,D6"}, {t6, "18,T6"},
            {s7one, "7,S7"}, {s7two, "7,S7"}, {d7, "14,D7"}, {t7, "21,T7"},
            {s8one, "8,S8"}, {s8two, "8,S8"}, {d8, "16,D8"}, {t8, "24,T8"},
            {s9one, "9,S9"}, {s9two, "9,S9"}, {d9, "18,D9"}, {t9, "27,T9"},
            {s10one, "10,S10"}, {s10two, "10,S10"}, {d10, "20,D10"}, {t10, "30,T10"},
            {s11one, "11,S11"}, {s11two, "11,S11"}, {d11, "22,D11"}, {t11, "33,T11"},
            {s12one, "12,S12"}, {s12two, "12,S12"}, {d12, "24,D12"}, {t12, "36,T12"},
            {s13one, "13,S13"}, {s13two, "13,S13"}, {d13, "26,D13"}, {t13, "39,T13"},
            {s14one, "14,S14"}, {s14two, "14,S14"}, {d14, "28,D14"}, {t14, "42,T14"},
            {s15one, "15,S15"}, {s15two, "15,S15"}, {d15, "30,D15"}, {t15, "45,T15"},
            {s16one, "16,S16"}, {s16two, "16,S16"}, {d16, "32,D16"}, {t16, "48,T16"},
            {s17one, "17,S17"}, {s17two, "17,S17"}, {d17, "34,D17"}, {t17, "51,T17"},
            {s18one, "18,S18"}, {s18two, "18,S18"}, {d18, "36,D18"}, {t18, "54,T18"},
            {s19one, "19,S19"}, {s19two, "19,S19"}, {d19, "38,D19"}, {t19, "57,T19"},
            {s20one, "20,S20"}, {s20two, "20,S20"}, {d20, "40,D20"}, {t20, "60,T20"},
            {out, "0,OUT"}
        }

        For Each kvp In dartMap
            kvp.Key.Tag = kvp.Value
            AddHandler kvp.Key.Click, AddressOf DartButton_Click
        Next
    End Sub

    ''' <summary>
    ''' 所有飛鏢按鈕共用的 Click Handler
    ''' </summary>
    Private Sub DartButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        Dim parts() As String = btn.Tag.ToString().Split(","c)
        Dim score As Integer = CInt(parts(0))
        Dim label As String = parts(1)

        a += 1
        b += score
        scb.Text = scb.Text & " " & label
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ' 第二局起，繼承上一局分數
        If c >= 2 AndAlso a = 0 Then
            b = CInt(playerLab(i - 1).Text)
        End If

        ' 即時更新分數顯示
        playerLab(i - 1).Text = CStr(b)

        ' 三鏢投完 → 換人
        If a = 3 Then
            i += 1
            a = 0

            If i > peo Then
                c += 1
                If c > 8 Then
                    MsgBox("遊戲結束", 64 + 0, "飛鏢計分程式")
                    ShowRanking()
                    Form1.Show()
                    Me.Close()
                Else
                    i = 1
                    MsgBox("第" & c & "回合", 0, "飛鏢計分程式")
                End If
            Else
                b = 0
                MsgBox("請拔標，換下一位玩家", 48 + 0, "飛鏢計分程式")
            End If
            scb.Text = ""
        End If
    End Sub

    ''' <summary>
    ''' 遊戲結束排名（用 Integer 正確排序）
    ''' </summary>
    Private Sub ShowRanking()
        Dim names(peo - 1) As String
        Dim scores(peo - 1) As Integer

        For idx = 0 To peo - 1
            names(idx) = "Player" & (idx + 1)
            scores(idx) = CInt(playerLab(idx).Text)
        Next

        ' Bubble sort（降序）
        For f = 0 To peo - 2
            For j = 0 To peo - 2 - f
                If scores(j) < scores(j + 1) Then
                    ' swap scores
                    Dim ts As Integer = scores(j)
                    scores(j) = scores(j + 1)
                    scores(j + 1) = ts
                    ' swap names
                    Dim tn As String = names(j)
                    names(j) = names(j + 1)
                    names(j + 1) = tn
                End If
            Next
        Next

        For idx = 0 To peo - 1
            MsgBox("第" & (idx + 1) & "名是" & names(idx) & vbCrLf & "分數為:" & scores(idx), 64 + 0, "飛鏢計分程式")
        Next
        MsgBox("將跳回選人數頁面", 64 + 0, "飛鏢計分程式")
    End Sub
End Class
