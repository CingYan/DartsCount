Public Class Form1
    Public peo As Integer  '這行要放在最頂
    Private Sub Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
        Button1.Click, Button2.Click, Button3.Click, Button4.Click, Button5.Click, Button6.Click, Button7.Click, Button8.Click
        Dim peoButton As Button = sender
        peo = peoButton.Tag
        Form2.Show()
        Me.Close()
    End Sub
    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Form3.Show()
        Me.Close()
    End Sub
End Class
