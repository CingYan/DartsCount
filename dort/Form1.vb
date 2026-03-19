Public Class Form1

    ' ========================================================================
    ' 遊戲模式選擇
    ' ========================================================================
    Private Sub Countup_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Countup.Click
        GameSettings.CurrentMode = GameMode.CountUp
        HighlightMode(Countup)
    End Sub

    Private Sub ZeroOne_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ZeroOne.Click
        GameSettings.CurrentMode = GameMode.ZeroOne
        HighlightMode(ZeroOne)
    End Sub

    Private Sub Button10_Click_Cricket(ByVal sender As Object, ByVal e As EventArgs) Handles Button10.Click
        GameSettings.CurrentMode = GameMode.Cricket
        HighlightMode(Button10)
    End Sub

    Private Sub HighlightMode(ByVal selected As Button)
        ' 重設所有模式按鈕
        Countup.BackColor = SystemColors.Control
        ZeroOne.BackColor = SystemColors.Control
        Button10.BackColor = SystemColors.Control
        ' 高亮選中的
        selected.BackColor = Color.LightGreen

        ' 顯示/隱藏 x01 設定
        If GrpX01Settings IsNot Nothing Then
            GrpX01Settings.Visible = (GameSettings.CurrentMode = GameMode.ZeroOne)
        End If
    End Sub

    ' ========================================================================
    ' x01 設定
    ' ========================================================================
    Private Sub Score301_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Score301.Click
        GameSettings.StartScore = 301
        HighlightScore(Score301)
    End Sub

    Private Sub Score501_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Score501.Click
        GameSettings.StartScore = 501
        HighlightScore(Score501)
    End Sub

    Private Sub Score701_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Score701.Click
        GameSettings.StartScore = 701
        HighlightScore(Score701)
    End Sub

    Private Sub Score901_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Score901.Click
        GameSettings.StartScore = 901
        HighlightScore(Score901)
    End Sub

    Private Sub HighlightScore(ByVal selected As Button)
        Score301.BackColor = SystemColors.Control
        Score501.BackColor = SystemColors.Control
        Score701.BackColor = SystemColors.Control
        Score901.BackColor = SystemColors.Control
        selected.BackColor = Color.LightBlue
    End Sub

    ' In 規則
    Private Sub InOpen_Click(ByVal sender As Object, ByVal e As EventArgs) Handles InOpen.Click
        GameSettings.RuleIn = InOutRule.Open
        HighlightIn(InOpen)
    End Sub

    Private Sub InMaster_Click(ByVal sender As Object, ByVal e As EventArgs) Handles InMaster.Click
        GameSettings.RuleIn = InOutRule.Master
        HighlightIn(InMaster)
    End Sub

    Private Sub InDouble_Click(ByVal sender As Object, ByVal e As EventArgs) Handles InDouble.Click
        GameSettings.RuleIn = InOutRule.Double
        HighlightIn(InDouble)
    End Sub

    Private Sub HighlightIn(ByVal selected As Button)
        InOpen.BackColor = SystemColors.Control
        InMaster.BackColor = SystemColors.Control
        InDouble.BackColor = SystemColors.Control
        selected.BackColor = Color.LightCoral
    End Sub

    ' Out 規則
    Private Sub OutOpen_Click(ByVal sender As Object, ByVal e As EventArgs) Handles OutOpen.Click
        GameSettings.RuleOut = InOutRule.Open
        HighlightOut(OutOpen)
    End Sub

    Private Sub OutMaster_Click(ByVal sender As Object, ByVal e As EventArgs) Handles OutMaster.Click
        GameSettings.RuleOut = InOutRule.Master
        HighlightOut(OutMaster)
    End Sub

    Private Sub OutDouble_Click(ByVal sender As Object, ByVal e As EventArgs) Handles OutDouble.Click
        GameSettings.RuleOut = InOutRule.Double
        HighlightOut(OutDouble)
    End Sub

    Private Sub HighlightOut(ByVal selected As Button)
        OutOpen.BackColor = SystemColors.Control
        OutMaster.BackColor = SystemColors.Control
        OutDouble.BackColor = SystemColors.Control
        selected.BackColor = Color.LightCoral
    End Sub

    ' 經典模式一鍵設定
    Private Sub ClassicMode_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ClassicMode.Click
        GameSettings.CurrentMode = GameMode.ZeroOne
        GameSettings.StartScore = 501
        GameSettings.RuleIn = InOutRule.Double
        GameSettings.RuleOut = InOutRule.Double
        HighlightMode(ZeroOne)
        HighlightScore(Score501)
        HighlightIn(InDouble)
        HighlightOut(OutDouble)
        MsgBox("經典模式：501 / Double In / Double Out", 64, "飛鏢計分程式")
    End Sub

    ' ========================================================================
    ' 人數選擇 → 開始遊戲
    ' ========================================================================
    Private Sub Button_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _
        Button1.Click, Button2.Click, Button3.Click, Button4.Click, _
        Button5.Click, Button6.Click, Button7.Click, Button8.Click
        Dim peoButton As Button = sender
        GameSettings.PlayerCount = CInt(peoButton.Tag)
        Form2.Show()
        Me.Close()
    End Sub

    Private Sub Button9_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button9.Click
        Form3.Show()
        Me.Close()
    End Sub

    ' ========================================================================
    ' Form Load — 預設值
    ' ========================================================================
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        ' 預設 Count-Up
        HighlightMode(Countup)
        ' 預設 501
        HighlightScore(Score501)
        ' 預設 Open In / Open Out
        HighlightIn(InOpen)
        HighlightOut(OutOpen)
    End Sub
End Class
