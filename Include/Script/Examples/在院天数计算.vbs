'*********************************************************************************
' 这是在院天数或者住院天数元素的在线自动实时计算的脚本
' 注意：这是Visual Basic脚本，您可以不区分大小写 
' Script Language : Visual Basic
' Author : YangMingkun, Date : 2011-11-21
' Copyright (C) Heren Health Services (SUPCON) Co.,Ltd.
'*********************************************************************************


'请在Calculate接口函数内编写您的代码,请不要修改函数名称以免无法被编辑器系统识别
'参数szElementName是元素名称,它的值是由编辑器系统运行时动态传入的
Public Overrides Sub Calculate(ByVal szElementName As String)

    Dim szName1 As String = "入院日期"
    Dim szName2 As String = "入院时间"
    Dim szName3 As String = "出院日期"
    Dim szName4 As String = "出院时间"

    '如果用户当前修改的不是此脚本需要监控的元素,那么退出,这是很重要的
    '因为如果不退出,就会影响编辑器系统的运行效率
    If szElementName <> szName1 AndAlso szElementName <> szName2 _
        AndAlso szElementName <> szName3 AndAlso szElementName <> szName4 Then
        Return
    End If

    '通过HideElementTip接口及时隐藏掉之前可能已经弹出的提示气泡
    Me.HideElementTip()

    Dim szElementValue As String

    '通过GetElementValue接口,获取计算时所需要的文档中的元素值(字符串类型的值)
    '获取入院时间或者入院日期元素值
    Me.GetElementValue(szName1, szElementValue)
    If szElementValue = Nothing OrElse szElementValue.Trim() = "" Then
        Me.GetElementValue(szName2, szElementValue)
    End If
    '如果有全角，那么转为半角
    szElementValue = Me.SBCToDBC(szElementValue)

    '将获取出来的入院时间字符串转换成日期数据类型
    Dim dtAdmissionDate As DateTime = DateTime.Now
    If szElementValue <> Nothing AndAlso szElementValue.Trim() <> "" Then
        DateTime.TryParse(szElementValue.Trim(), dtAdmissionDate)
    End If

    '获取出院时间或者出院日期元素值
    Me.GetElementValue(szName3, szElementValue)
    If szElementValue = Nothing OrElse szElementValue.Trim() = "" Then
        Me.GetElementValue(szName4, szElementValue)
    End If
    '如果有全角，那么转为半角
    szElementValue = Me.SBCToDBC(szElementValue)

    '将获取出来的出院时间字符串转换成日期数据类型
    Dim dtDischargeDate As DateTime = DateTime.Now
    If szElementValue <> Nothing AndAlso szElementValue.Trim() <> "" Then
        DateTime.TryParse(szElementValue, dtDischargeDate)
    End If

    '进行核心运算,然后将运算结果通过SetElementValue接口设置到病历中指定的元素
    Dim result As Integer = 0
    Try
        '计算两个日期的天数间隔,其中DateDiff函数是VB的内置函数
        result = DateDiff("d", dtAdmissionDate.Date, dtDischargeDate.Date) + 1
    Catch
    End Try
    If result <= 0 Then result = 1
    Me.SetElementValue("在院天数", result.ToString())
    Me.SetElementValue("住院天数", result.ToString())
End Sub
