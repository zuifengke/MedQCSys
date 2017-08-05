'*********************************************************************************
' 这是系统提供的RTS元素的在线自动实时计算的脚本
' 注意：这是Visual Basic脚本，您可以不区分大小写 
' Script Language : Visual Basic
' Author : YangMingkun, Date : 2011-11-21
' Copyright (C) Heren Health Services (SUPCON) Co.,Ltd.
'*********************************************************************************


'请在Calculate接口函数内编写您的代码,请不要修改函数名称以免无法被编辑器系统识别
'参数szElementName是元素名称,它的值是由编辑器系统运行时动态传入的
Public Overrides Sub Calculate(ByVal szElementName As String)

    Dim szName1 As String = "RTSGCS"
    Dim szName2 As String = "RTS收缩压"
    Dim szName3 As String = "RTS呼吸"

    '如果用户当前修改的不是此脚本需要监控的元素,那么退出,这是很重要的
    '因为如果不退出,就会影响编辑器系统的运行效率
    If szElementName <> szName1 AndAlso szElementName <> szName2 _
       AndAlso szElementName <> szName3 Then
        Return
    End If

    Dim szElementValue As String = ""

    Dim nElementValue1 As Integer = 0
    Dim nElementValue2 As Integer = 0
    Dim nElementValue3 As Integer = 0

    '通过HideElementTip接口及时隐藏掉之前可能已经弹出的提示气泡
    Me.HideElementTip()

    '通过GetElementValue接口,获取计算时所需要的文档中的元素值(字符串类型的值)
    Me.GetElementValue(szName1.Trim(), szElementValue)
    If Not Integer.TryParse(szElementValue, nElementValue1) Then
        If szElementName = szName1 Then
            Me.ShowElementTip("非法的数据输入", "请您正确输入元素数值!")
            Exit Sub
        End If
    End If

    '通过GetElementValue接口,获取计算时所需要的文档中的元素值(字符串类型的值)
    Me.GetElementValue(szName2.Trim(), szElementValue)
    If Not Integer.TryParse(szElementValue, nElementValue2) Then
        If szElementName = szName2 Then
            Me.ShowElementTip("非法的数据输入", "请您正确输入元素数值!")
            Exit Sub
        End If
    End If

    '通过GetElementValue接口,获取计算时所需要的文档中的元素值(字符串类型的值)
    Me.GetElementValue(szName3.Trim(), szElementValue)
    If Not Integer.TryParse(szElementValue, nElementValue3) Then
        If szElementName = szName3 Then
            Me.ShowElementTip("非法的数据输入", "请您正确输入元素数值!")
            Exit Sub
        End If
    End If

    '进行核心运算,然后将运算结果通过SetElementValue接口设置到病历中指定的元素
    Dim result As Integer = nElementValue1 + nElementValue2 + nElementValue3
    Me.SetElementValue("RTS", result.ToString())

End Sub
