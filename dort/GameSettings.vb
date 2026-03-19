''' <summary>
''' 全域遊戲設定 — 在 Form 間傳遞遊戲參數
''' </summary>
Public Module GameSettings
    ''' <summary>遊戲模式</summary>
    Public Enum GameMode
        CountUp
        ZeroOne
        Cricket
    End Enum

    ''' <summary>x01 In/Out 規則</summary>
    Public Enum InOutRule
        Open    ' 任何區域
        Master  ' Double 或 Triple
        [Double] ' 僅 Double
    End Enum

    ' === 全域設定 ===
    Public CurrentMode As GameMode = GameMode.CountUp
    Public PlayerCount As Integer = 2
    Public StartScore As Integer = 501     ' x01 起始分
    Public RuleIn As InOutRule = InOutRule.Open
    Public RuleOut As InOutRule = InOutRule.Open
End Module
