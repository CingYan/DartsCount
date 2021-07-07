Public Class Form2
    ' Dim p1, p2, p3, p4, p5, p6, p7, p8, d As String '玩家 上限8人
    ' Public sc(8, 8) As String  '玩家八局 八人 若未達便空白 (最後print) f為局數用數
    Dim a As String = 0 'a 計算三支鏢
    Dim b As String = 0 '局內分數暫存
    Dim c As Integer = 1 '局數
    Dim d As String = 0 '局間分數暫存
    Dim i As Integer = 1 '玩家計數
    Dim x As Integer
    Public peo As Integer = Form1.peo '從form1接收人數

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim playerlab As Label() = {p1, p2, p3, p4, p5, p6, p7, p8}
        Dim playerSc As Label() = {Label1, Label2, Label3, Label4, Label5, Label6, Label7, Label8}
        For x = 0 To peo - 1
            playerlab(x).Visible = 1
            playerSc(x).Visible = 1
        Next
        Timer1.Enabled = True
        MsgBox("靶上的按鈕顯示完之前切莫操作，避免出問題", 0, "飛鏢計分程式")
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        '由timer紀錄 0.1秒更新
        If (c >= 2) And (a = 0) Then
            Call ax()
        End If

        Call ax2()

        If a = 3 Then
            i = i + 1 '下一個玩家
            a = 0 '鏢數清空
            If i > peo Then '如果大於玩家數 重置
                c = c + 1 '局數+1 
                If c > 8 Then
                    MsgBox("遊戲結束", 64 + 0, "飛鏢計分程式")
                    Call high()
                    'Dim but As Control
                    ' For Each but In Me.Controls
                    'If TypeOf but Is Button Then but.Enabled = False
                    ' Next
                    Form1.Show()
                    Me.Close()
                Else
                    i = 1
                    MsgBox("第" & c & "回合", 0, "飛鏢計分程式")
                End If
            Else
                b = 0     '清空分數
                MsgBox("請拔標，換下一位玩家", 48 + 0, "飛鏢計分程式")
            End If
            scb.Text = ""
        End If

    End Sub
    Sub ax()
        Select Case i
            Case 1
                b = p1.Text
                Exit Select
            Case 2
                d = p2.Text
                b = d
                Exit Select
            Case 3
                d = p3.Text
                b = d
                Exit Select
            Case 4
                d = p4.Text
                b = d
                Exit Select
            Case 5
                d = p5.Text
                b = d
                Exit Select
            Case 6
                d = p6.Text
                b = d
                Exit Select
            Case 7
                d = p7.Text
                b = d
                Exit Select
            Case 8
                d = p8.Text
                b = d
                Exit Select
        End Select

    End Sub '第二局(含)後分數繼承
    Sub ax2()
        Select Case i
            Case 1 : p1.Text = b
            Case 2 : p2.Text = b
            Case 3 : p3.Text = b
            Case 4 : p4.Text = b
            Case 5 : p5.Text = b
            Case 6 : p6.Text = b
            Case 7 : p7.Text = b
            Case 8 : p8.Text = b
        End Select
    End Sub '分數託管
    Sub high()
        Dim v(2, 8), te, te2 As String
        v(1, 1) = "player1"
        v(2, 1) = p1.Text

        v(1, 2) = "player2"
        v(2, 2) = p2.Text

        v(1, 3) = "player3"
        v(2, 3) = p3.Text

        v(1, 4) = "player4"
        v(2, 4) = p4.Text

        v(1, 5) = "player5"
        v(2, 5) = p5.Text

        v(1, 6) = "player6"
        v(2, 6) = p6.Text

        v(1, 7) = "player7"
        v(2, 7) = p7.Text

        v(1, 8) = "player8"
        v(2, 8) = p8.Text
        For f = 1 To 8
            For j = 1 To 8
                If v(2, f) > v(2, j) Then
                    te = v(2, j)
                    te2 = v(1, j)
                    v(2, j) = v(2, f)
                    v(1, j) = v(1, f)
                    v(2, f) = te
                    v(1, f) = te2
                End If
            Next
        Next
        For xx = 1 To peo
            MsgBox("第" & xx & "名是" & v(1, xx) & vbCrLf & "分數為:" & v(2, xx), 64 + 0, "飛鏢計分程式")
        Next
        MsgBox("將跳回選人數頁面", 64 + 0, "飛鏢計分程式")
    End Sub
    Private Sub Bull_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Bull.Click
        a = a + 1
        b = b + 50
        scb.Text = scb.Text & " " & "Bull"
    End Sub

    Private Sub s11one_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles s11one.Click
        a = a + 1
        b = b + 11
        scb.Text = scb.Text & " " & "S11"
    End Sub
    Private Sub d11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles d11.Click
        a = a + 1
        b = b + 22
        scb.Text = scb.Text & " " & "D11"
    End Sub
    Private Sub t11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles t11.Click
        a = a + 1
        b = b + 33
        scb.Text = scb.Text & " " & "T11"
    End Sub
    Private Sub s11two_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles s11two.Click
        a = a + 1
        b = b + 11
        scb.Text = scb.Text & " " & "S11"
    End Sub

    Private Sub s14one_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles s14one.Click
        a = a + 1
        b = b + 14
        scb.Text = scb.Text & " " & "S14"
    End Sub
    Private Sub t14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles t14.Click
        a = a + 1
        b = b + 42
        scb.Text = scb.Text & " " & "T14"
    End Sub
    Private Sub s14two_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles s14two.Click
        a = a + 1
        b = b + 14
        scb.Text = scb.Text & " " & "S14"
    End Sub
    Private Sub d14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles d14.Click
        a = a + 1
        b = b + 28
        scb.Text = scb.Text & " " & "D14"
    End Sub

    Private Sub s20one_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles s20one.Click
        a = a + 1
        b = b + 20
        scb.Text = scb.Text & " " & "S20"
    End Sub
    Private Sub t20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles t20.Click
        a = a + 1
        b = b + 60
        scb.Text = scb.Text & " " & "T20"
    End Sub
    Private Sub s20two_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles s20two.Click
        a = a + 1
        b = b + 20
        scb.Text = scb.Text & " " & "S20"
    End Sub
    Private Sub d20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles d20.Click
        a = a + 1
        b = b + 40
        scb.Text = scb.Text & " " & "D20"
    End Sub

    Private Sub s3one_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles s3one.Click
        a = a + 1
        b = b + 3
        scb.Text = scb.Text & " " & "S3"
    End Sub
    Private Sub t3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles t3.Click
        a = a + 1
        b = b + 9
        scb.Text = scb.Text & " " & "T3"
    End Sub
    Private Sub s3two_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles s3two.Click
        a = a + 1
        b = b + 3
        scb.Text = scb.Text & " " & "S3"
    End Sub
    Private Sub d3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles d3.Click
        a = a + 1
        b = b + 6
        scb.Text = scb.Text & " " & "D3"
    End Sub

    Private Sub s9one_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles s9one.Click
        a = a + 1
        b = b + 9
        scb.Text = scb.Text & " " & "S9"
    End Sub
    Private Sub t9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles t9.Click
        a = a + 1
        b = b + 27
        scb.Text = scb.Text & " " & "T9"
    End Sub
    Private Sub s9two_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles s9two.Click
        a = a + 1
        b = b + 9
        scb.Text = scb.Text & " " & "S9"
    End Sub
    Private Sub d9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles d9.Click
        a = a + 1
        b = b + 19
        scb.Text = scb.Text & " " & "D9"
    End Sub

    Private Sub s12one_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles s12one.Click
        a = a + 1
        b = b + 12
        scb.Text = scb.Text & " " & "S12"
    End Sub
    Private Sub t12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles t12.Click
        a = a + 1
        b = b + 36
        scb.Text = scb.Text & " " & "T12"
    End Sub
    Private Sub s12two_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles s12two.Click
        a = a + 1
        b = b + 12
        scb.Text = scb.Text & " " & "S12"
    End Sub
    Private Sub d12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles d12.Click
        a = a + 1
        b = b + 24
        scb.Text = scb.Text & " " & "D12"
    End Sub

    Private Sub s5one_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles s5one.Click
        a = a + 1
        b = b + 5
        scb.Text = scb.Text & " " & "S5"
    End Sub
    Private Sub t5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles t5.Click
        a = a + 1
        b = b + 15
        scb.Text = scb.Text & " " & "T5"
    End Sub
    Private Sub s5two_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles s5two.Click
        a = a + 1
        b = b + 5
        scb.Text = scb.Text & " " & "S5"
    End Sub
    Private Sub d5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles d5.Click
        a = a + 1
        b = b + 10
        scb.Text = scb.Text & " " & "D5"
    End Sub

    Private Sub d8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles d8.Click
        a = a + 1
        b = b + 16
        scb.Text = scb.Text & " " & "D5"
    End Sub
    Private Sub s8two_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles s8two.Click
        a = a + 1
        b = b + 8
        scb.Text = scb.Text & " " & "S5"
    End Sub
    Private Sub t8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles t8.Click
        a = a + 1
        b = b + 24
        scb.Text = scb.Text & " " & "T8"
    End Sub
    Private Sub s8one_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles s8one.Click
        a = a + 1
        b = b + 8
        scb.Text = scb.Text & " " & "S8"
    End Sub

    Private Sub d16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles d16.Click
        a = a + 1
        b = b + 32
        scb.Text = scb.Text & " " & "D16"
    End Sub
    Private Sub s16two_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles s16two.Click
        a = a + 1
        b = b + 16
        scb.Text = scb.Text & " " & "S16"
    End Sub
    Private Sub s16one_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles s16one.Click
        a = a + 1
        b = b + 16
        scb.Text = scb.Text & " " & "S16"
    End Sub
    Private Sub t16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles t16.Click
        a = a + 1
        b = b + 48
        scb.Text = scb.Text & " " & "T16"
    End Sub

    Private Sub d19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles d19.Click
        a = a + 1
        b = b + 38
        scb.Text = scb.Text & " " & "S19"
    End Sub
    Private Sub t19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles t19.Click
        a = a + 1
        b = b + 57
        scb.Text = scb.Text & " " & "S19"
    End Sub
    Private Sub s19two_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles s19two.Click
        a = a + 1
        b = b + 19
        scb.Text = scb.Text & " " & "S19"
    End Sub
    Private Sub s19one_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles s19one.Click
        a = a + 1
        b = b + 19
        scb.Text = scb.Text & " " & "S19"
    End Sub

    Private Sub t7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles t7.Click
        a = a + 1
        b = b + 21
        scb.Text = scb.Text & " " & "T7"
    End Sub
    Private Sub d7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles d7.Click
        a = a + 1
        b = b + 14
        scb.Text = scb.Text & " " & "D7"
    End Sub
    Private Sub s7two_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles s7two.Click
        a = a + 1
        b = b + 7
        scb.Text = scb.Text & " " & "S7"
    End Sub
    Private Sub s7one_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles s7one.Click
        a = a + 1
        b = b + 7
        scb.Text = scb.Text & " " & "S7"
    End Sub

    Private Sub t6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles t6.Click
        a = a + 1
        b = b + 18
        scb.Text = scb.Text & " " & "T6"
    End Sub
    Private Sub s6one_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles s6one.Click
        a = a + 1
        b = b + 6
        scb.Text = scb.Text & " " & "S6"
    End Sub
    Private Sub s6two_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles s6two.Click
        a = a + 1
        b = b + 6
        scb.Text = scb.Text & " " & "S6"
    End Sub
    Private Sub d6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles d6.Click
        a = a + 1
        b = b + 12
        scb.Text = scb.Text & " " & "D2"
    End Sub

    Private Sub s1one_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles s1one.Click
        a = a + 1
        b = b + 1
        scb.Text = scb.Text & " " & "S1"
    End Sub
    Private Sub s1two_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles s1two.Click
        a = a + 1
        b = b + 1
        scb.Text = scb.Text & " " & "S1"
    End Sub
    Private Sub t1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles t1.Click
        a = a + 1
        b = b + 3
        scb.Text = scb.Text & " " & "T1"
    End Sub
    Private Sub d1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles d1.Click
        a = a + 1
        b = b + 2
        scb.Text = scb.Text & " " & "D1"
    End Sub

    Private Sub d18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles d18.Click
        a = a + 1
        b = b + 36
        scb.Text = scb.Text & " " & "D18"
    End Sub
    Private Sub s18two_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles s18two.Click
        a = a + 1
        b = b + 18
        scb.Text = scb.Text & " " & "S18"
    End Sub
    Private Sub s18one_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles s18one.Click
        a = a + 1
        b = b + 18
        scb.Text = scb.Text & " " & "S18"
    End Sub
    Private Sub t18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles t18.Click
        a = a + 1
        b = b + 54
        scb.Text = scb.Text & " " & "T18"
    End Sub

    Private Sub s17one_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles s17one.Click
        a = a + 1
        b = b + 17
        scb.Text = scb.Text & " " & "S17"
    End Sub
    Private Sub s17two_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles s17two.Click
        a = a + 1
        b = b + 17
        scb.Text = scb.Text & " " & "S17"
    End Sub
    Private Sub t17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles t17.Click
        a = a + 1
        b = b + 51
        scb.Text = scb.Text & " " & "T17"
    End Sub
    Private Sub d17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles d17.Click
        a = a + 1
        b = b + 34
        scb.Text = scb.Text & " " & "D17"
    End Sub

    Private Sub s2one_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles s2one.Click
        a = a + 1
        b = b + 2
        scb.Text = scb.Text & " " & "S2"
    End Sub
    Private Sub s2two_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles s2two.Click
        a = a + 1
        b = b + 2
        scb.Text = scb.Text & " " & "S2"
    End Sub
    Private Sub t2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles t2.Click
        a = a + 1
        b = b + 6
        scb.Text = scb.Text & " " & "T2"
    End Sub
    Private Sub d2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles d2.Click
        a = a + 1
        b = b + 4
        scb.Text = scb.Text & " " & "D2"
    End Sub

    Private Sub s15one_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles s15one.Click
        a = a + 1
        b = b + 15
        scb.Text = scb.Text & " " & "S15"
    End Sub
    Private Sub s15two_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles s15two.Click
        a = a + 1
        b = b + 15
        scb.Text = scb.Text & " " & "S15"
    End Sub
    Private Sub t15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles t15.Click
        a = a + 1
        b = b + 45
        scb.Text = scb.Text & " " & "T15"
    End Sub
    Private Sub d15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles d15.Click
        a = a + 1
        b = b + 30
        scb.Text = scb.Text & " " & "D15"
    End Sub

    Private Sub s10one_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles s10one.Click
        a = a + 1
        b = b + 10
        scb.Text = scb.Text & " " & "S10"
    End Sub
    Private Sub s10two_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles s10two.Click
        a = a + 1
        b = b + 10
        scb.Text = scb.Text & " " & "S10"
    End Sub
    Private Sub d10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles d10.Click
        a = a + 1
        b = b + 20
        scb.Text = scb.Text & " " & "D10"
    End Sub
    Private Sub t10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles t10.Click
        a = a + 1
        b = b + 30
        scb.Text = scb.Text & " " & "T10"
    End Sub

    Private Sub s13one_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles s13one.Click
        a = a + 1
        b = b + 13
        scb.Text = scb.Text & " " & "S13"
    End Sub
    Private Sub s13two_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles s13two.Click
        a = a + 1
        b = b + 13
        scb.Text = scb.Text & " " & "S13"
    End Sub
    Private Sub t13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles t13.Click
        a = a + 1
        b = b + 39
        scb.Text = scb.Text & " " & "T13"
    End Sub
    Private Sub d13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles d13.Click
        a = a + 1
        b = b + 26
        scb.Text = scb.Text & " " & "D13"
    End Sub

    Private Sub s4one_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles s4one.Click
        a = a + 1
        b = b + 4
        scb.Text = scb.Text & " " & "S4"
    End Sub
    Private Sub s4two_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles s4two.Click
        a = a + 1
        b = b + 4
        scb.Text = scb.Text & " " & "S4"
    End Sub
    Private Sub d4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles d4.Click
        a = a + 1
        b = b + 8
        scb.Text = scb.Text & " " & "D4"
    End Sub
    Private Sub t4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles t4.Click
        a = a + 1
        b = b + 12
        scb.Text = scb.Text & " " & "T4"
    End Sub

    Private Sub out_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles out.Click
        a = a + 1
        b = b + 0
        scb.Text = scb.Text & " " & "OUT"
    End Sub
End Class
