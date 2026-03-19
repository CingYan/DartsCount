<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.GameType = New System.Windows.Forms.GroupBox()
        Me.ZeroOne = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Countup = New System.Windows.Forms.Button()
        ' x01 設定
        Me.GrpX01Settings = New System.Windows.Forms.GroupBox()
        Me.LblScore = New System.Windows.Forms.Label()
        Me.Score301 = New System.Windows.Forms.Button()
        Me.Score501 = New System.Windows.Forms.Button()
        Me.Score701 = New System.Windows.Forms.Button()
        Me.Score901 = New System.Windows.Forms.Button()
        Me.LblIn = New System.Windows.Forms.Label()
        Me.InOpen = New System.Windows.Forms.Button()
        Me.InMaster = New System.Windows.Forms.Button()
        Me.InDouble = New System.Windows.Forms.Button()
        Me.LblOut = New System.Windows.Forms.Label()
        Me.OutOpen = New System.Windows.Forms.Button()
        Me.OutMaster = New System.Windows.Forms.Button()
        Me.OutDouble = New System.Windows.Forms.Button()
        Me.ClassicMode = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GameType.SuspendLayout()
        Me.GrpX01Settings.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(6, 23)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Tag = "1"
        Me.Button1.Text = "Player 1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(87, 23)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 1
        Me.Button2.Tag = "2"
        Me.Button2.Text = "Player 2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(6, 52)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 2
        Me.Button3.Tag = "3"
        Me.Button3.Text = "Player 3"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(87, 52)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 3
        Me.Button4.Tag = "4"
        Me.Button4.Text = "Player 4"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(6, 81)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 23)
        Me.Button5.TabIndex = 4
        Me.Button5.Tag = "5"
        Me.Button5.Text = "Player 5"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(87, 81)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(75, 23)
        Me.Button6.TabIndex = 5
        Me.Button6.Tag = "6"
        Me.Button6.Text = "Player 6"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(6, 110)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(75, 23)
        Me.Button7.TabIndex = 6
        Me.Button7.Tag = "7"
        Me.Button7.Text = "Player 7"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(87, 110)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 23)
        Me.Button8.TabIndex = 7
        Me.Button8.Tag = "8"
        Me.Button8.Text = "Player 8"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.Button8)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.Button7)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.Button6)
        Me.GroupBox1.Controls.Add(Me.Button4)
        Me.GroupBox1.Controls.Add(Me.Button5)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 118)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(170, 153)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "選擇人數"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button9)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 490)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(170, 58)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "其他"
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(6, 21)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(75, 23)
        Me.Button9.TabIndex = 0
        Me.Button9.Text = "作者廢言"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'GameType
        '
        Me.GameType.Controls.Add(Me.ZeroOne)
        Me.GameType.Controls.Add(Me.Button10)
        Me.GameType.Controls.Add(Me.Countup)
        Me.GameType.Location = New System.Drawing.Point(12, 12)
        Me.GameType.Name = "GameType"
        Me.GameType.Size = New System.Drawing.Size(170, 100)
        Me.GameType.TabIndex = 10
        Me.GameType.TabStop = False
        Me.GameType.Text = "遊戲模式選擇"
        '
        'ZeroOne
        '
        Me.ZeroOne.Location = New System.Drawing.Point(6, 50)
        Me.ZeroOne.Name = "ZeroOne"
        Me.ZeroOne.Size = New System.Drawing.Size(75, 23)
        Me.ZeroOne.TabIndex = 2
        Me.ZeroOne.Text = "01"
        Me.ZeroOne.UseVisualStyleBackColor = True
        '
        'Button10 (Cricket)
        '
        Me.Button10.Location = New System.Drawing.Point(87, 21)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(75, 23)
        Me.Button10.TabIndex = 1
        Me.Button10.Text = "Cricket"
        Me.Button10.UseVisualStyleBackColor = True
        '
        'Countup
        '
        Me.Countup.Location = New System.Drawing.Point(6, 21)
        Me.Countup.Name = "Countup"
        Me.Countup.Size = New System.Drawing.Size(75, 23)
        Me.Countup.TabIndex = 0
        Me.Countup.Text = "Count-Up"
        Me.Countup.UseVisualStyleBackColor = True
        '
        ' === GrpX01Settings ===
        '
        Me.GrpX01Settings.Controls.Add(Me.LblScore)
        Me.GrpX01Settings.Controls.Add(Me.Score301)
        Me.GrpX01Settings.Controls.Add(Me.Score501)
        Me.GrpX01Settings.Controls.Add(Me.Score701)
        Me.GrpX01Settings.Controls.Add(Me.Score901)
        Me.GrpX01Settings.Controls.Add(Me.LblIn)
        Me.GrpX01Settings.Controls.Add(Me.InOpen)
        Me.GrpX01Settings.Controls.Add(Me.InMaster)
        Me.GrpX01Settings.Controls.Add(Me.InDouble)
        Me.GrpX01Settings.Controls.Add(Me.LblOut)
        Me.GrpX01Settings.Controls.Add(Me.OutOpen)
        Me.GrpX01Settings.Controls.Add(Me.OutMaster)
        Me.GrpX01Settings.Controls.Add(Me.OutDouble)
        Me.GrpX01Settings.Controls.Add(Me.ClassicMode)
        Me.GrpX01Settings.Location = New System.Drawing.Point(12, 277)
        Me.GrpX01Settings.Name = "GrpX01Settings"
        Me.GrpX01Settings.Size = New System.Drawing.Size(170, 210)
        Me.GrpX01Settings.TabIndex = 11
        Me.GrpX01Settings.TabStop = False
        Me.GrpX01Settings.Text = "01 設定"
        Me.GrpX01Settings.Visible = False
        '
        'LblScore
        '
        Me.LblScore.AutoSize = True
        Me.LblScore.Location = New System.Drawing.Point(6, 20)
        Me.LblScore.Name = "LblScore"
        Me.LblScore.Size = New System.Drawing.Size(41, 12)
        Me.LblScore.Text = "起始分:"
        '
        'Score301
        '
        Me.Score301.Location = New System.Drawing.Point(6, 35)
        Me.Score301.Name = "Score301"
        Me.Score301.Size = New System.Drawing.Size(38, 23)
        Me.Score301.Text = "301"
        Me.Score301.UseVisualStyleBackColor = True
        '
        'Score501
        '
        Me.Score501.Location = New System.Drawing.Point(46, 35)
        Me.Score501.Name = "Score501"
        Me.Score501.Size = New System.Drawing.Size(38, 23)
        Me.Score501.Text = "501"
        Me.Score501.UseVisualStyleBackColor = True
        '
        'Score701
        '
        Me.Score701.Location = New System.Drawing.Point(86, 35)
        Me.Score701.Name = "Score701"
        Me.Score701.Size = New System.Drawing.Size(38, 23)
        Me.Score701.Text = "701"
        Me.Score701.UseVisualStyleBackColor = True
        '
        'Score901
        '
        Me.Score901.Location = New System.Drawing.Point(126, 35)
        Me.Score901.Name = "Score901"
        Me.Score901.Size = New System.Drawing.Size(38, 23)
        Me.Score901.Text = "901"
        Me.Score901.UseVisualStyleBackColor = True
        '
        'LblIn
        '
        Me.LblIn.AutoSize = True
        Me.LblIn.Location = New System.Drawing.Point(6, 65)
        Me.LblIn.Name = "LblIn"
        Me.LblIn.Size = New System.Drawing.Size(17, 12)
        Me.LblIn.Text = "In:"
        '
        'InOpen
        '
        Me.InOpen.Location = New System.Drawing.Point(6, 80)
        Me.InOpen.Name = "InOpen"
        Me.InOpen.Size = New System.Drawing.Size(50, 23)
        Me.InOpen.Text = "Open"
        Me.InOpen.UseVisualStyleBackColor = True
        '
        'InMaster
        '
        Me.InMaster.Location = New System.Drawing.Point(58, 80)
        Me.InMaster.Name = "InMaster"
        Me.InMaster.Size = New System.Drawing.Size(54, 23)
        Me.InMaster.Text = "Master"
        Me.InMaster.UseVisualStyleBackColor = True
        '
        'InDouble
        '
        Me.InDouble.Location = New System.Drawing.Point(114, 80)
        Me.InDouble.Name = "InDouble"
        Me.InDouble.Size = New System.Drawing.Size(50, 23)
        Me.InDouble.Text = "Double"
        Me.InDouble.UseVisualStyleBackColor = True
        '
        'LblOut
        '
        Me.LblOut.AutoSize = True
        Me.LblOut.Location = New System.Drawing.Point(6, 110)
        Me.LblOut.Name = "LblOut"
        Me.LblOut.Size = New System.Drawing.Size(24, 12)
        Me.LblOut.Text = "Out:"
        '
        'OutOpen
        '
        Me.OutOpen.Location = New System.Drawing.Point(6, 125)
        Me.OutOpen.Name = "OutOpen"
        Me.OutOpen.Size = New System.Drawing.Size(50, 23)
        Me.OutOpen.Text = "Open"
        Me.OutOpen.UseVisualStyleBackColor = True
        '
        'OutMaster
        '
        Me.OutMaster.Location = New System.Drawing.Point(58, 125)
        Me.OutMaster.Name = "OutMaster"
        Me.OutMaster.Size = New System.Drawing.Size(54, 23)
        Me.OutMaster.Text = "Master"
        Me.OutMaster.UseVisualStyleBackColor = True
        '
        'OutDouble
        '
        Me.OutDouble.Location = New System.Drawing.Point(114, 125)
        Me.OutDouble.Name = "OutDouble"
        Me.OutDouble.Size = New System.Drawing.Size(50, 23)
        Me.OutDouble.Text = "Double"
        Me.OutDouble.UseVisualStyleBackColor = True
        '
        'ClassicMode
        '
        Me.ClassicMode.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ClassicMode.Location = New System.Drawing.Point(6, 158)
        Me.ClassicMode.Name = "ClassicMode"
        Me.ClassicMode.Size = New System.Drawing.Size(158, 40)
        Me.ClassicMode.Text = "經典模式" & vbCrLf & "501 / Double In+Out"
        Me.ClassicMode.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(194, 560)
        Me.Controls.Add(Me.GrpX01Settings)
        Me.Controls.Add(Me.GameType)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "飛鏢計分程式"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GameType.ResumeLayout(False)
        Me.GrpX01Settings.ResumeLayout(False)
        Me.GrpX01Settings.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents GameType As System.Windows.Forms.GroupBox
    Friend WithEvents ZeroOne As System.Windows.Forms.Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Countup As System.Windows.Forms.Button
    ' x01 設定控件
    Friend WithEvents GrpX01Settings As System.Windows.Forms.GroupBox
    Friend WithEvents LblScore As System.Windows.Forms.Label
    Friend WithEvents Score301 As System.Windows.Forms.Button
    Friend WithEvents Score501 As System.Windows.Forms.Button
    Friend WithEvents Score701 As System.Windows.Forms.Button
    Friend WithEvents Score901 As System.Windows.Forms.Button
    Friend WithEvents LblIn As System.Windows.Forms.Label
    Friend WithEvents InOpen As System.Windows.Forms.Button
    Friend WithEvents InMaster As System.Windows.Forms.Button
    Friend WithEvents InDouble As System.Windows.Forms.Button
    Friend WithEvents LblOut As System.Windows.Forms.Label
    Friend WithEvents OutOpen As System.Windows.Forms.Button
    Friend WithEvents OutMaster As System.Windows.Forms.Button
    Friend WithEvents OutDouble As System.Windows.Forms.Button
    Friend WithEvents ClassicMode As System.Windows.Forms.Button
End Class
