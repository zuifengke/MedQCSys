'*********************************************************************************
' 这是系统提供的Ps(TRISS)元素的在线自动实时计算的脚本
' 注意：这是Visual Basic脚本，您可以不区分大小写 
' Script Language : Visual Basic
' Author : YangMingkun, Date : 2011-11-21
' Copyright (C) Heren Health Services (SUPCON) Co.,Ltd.
'*********************************************************************************


'请在Calculate接口函数内编写您的代码,请不要修改函数名称以免无法被编辑器系统识别
'参数szElementName是元素名称,它的值是由编辑器系统运行时动态传入的
Public Overrides Sub Calculate(ByVal szElementName As String)

    Dim szName1 As String = "Ps(TRISS)损伤类型"
    Dim szName2 As String = "年龄"
    Dim szName3 As String = "RTSGCS"
    Dim szName4 As String = "RTS收缩压"
    Dim szName5 As String = "RTS呼吸"
    Dim szName6 As String = "NISS"

    '如果用户当前修改的不是此脚本需要监控的元素,那么退出,这是很重要的
    '因为如果不退出,就会影响编辑器系统的运行效率
    If szElementName <> szName1 AndAlso szElementName <> szName2 _
        AndAlso szElementName <> szName3 AndAlso szElementName <> szName4 _
        AndAlso szElementName <> szName5 AndAlso szElementName <> szName6 Then
        Return
    End If

    Dim szElementValue1 As String = ""
    Dim szElementValue2 As String = ""
    Dim szElementValue3 As String = ""
    Dim szElementValue4 As String = ""
    Dim szElementValue5 As String = ""
    Dim szElementValue6 As String = ""

    Dim ld_b0 As Single = 0
    Dim ld_b1 As Single = 0
    Dim ld_b2 As Single = 0
    Dim ld_b3 As Single = 0
    Dim ld_a As Integer = 0
    Dim value_1 As Integer = 0
    Dim value_2 As Integer = 0
    Dim value_3 As Integer = 0
    Dim nNiss As Integer = 0
    Dim temp As Integer = 0
    Dim result As Single = 0

    '通过HideElementTip接口及时隐藏掉之前可能已经弹出的提示气泡
    Me.HideElementTip()

    '通过GetElementValue接口,获取计算时所需要的文档中的元素值(字符串类型的值)
    Me.GetElementValue(szName1, szElementValue1)
    Me.GetElementValue(szName2, szElementValue2)
    Me.GetElementValue(szName3, szElementValue3)
    Me.GetElementValue(szName4, szElementValue4)
    Me.GetElementValue(szName5, szElementValue5)
    Me.GetElementValue(szName6, szElementValue6)

    If szElementValue1 = "1" Then
        ld_b0 = 1.247
        ld_b1 = 0.9544
        ld_b2 = 0.0768
        ld_b3 = 1.9052
    End If

    If szElementValue1 = "2" Then
        ld_b0 = 0.6029
        ld_b1 = 1.143
        ld_b2 = 0.1516
        ld_b3 = 2.6676
    End If

    If Integer.TryParse(szElementValue2, temp) = False Then
        If String.IsNullOrEmpty(szElementValue2) Then
            Exit Sub
        End If
        szElementValue2 = szElementValue2.Substring(0, szElementValue2.Length - 1)
        If Integer.TryParse(szElementValue2, temp) = False Then
            If szElementName = szName2 Then
                Me.ShowElementTip("非法的数据输入", "请您正确输入元素数值!")
                Exit Sub
            End If
        End If
    End If

    If temp >= 55 Then
        ld_a = 1
    Else
        ld_a = 0
    End If

    If Not Integer.TryParse(szElementValue3, value_1) Then
        If szElementName = szName3 Then
            Me.ShowElementTip("非法的数据输入", "请您正确输入元素数值!")
            Exit Sub
        End If
    End If

    If Not Integer.TryParse(szElementValue4, value_2) Then
        If szElementName = szName4 Then
            Me.ShowElementTip("非法的数据输入", "请您正确输入元素数值!")
            Exit Sub
        End If
    End If

    If Not Integer.TryParse(szElementValue5, value_3) Then
        If szElementName = szName5 Then
            Me.ShowElementTip("非法的数据输入", "请您正确输入元素数值!")
            Exit Sub
        End If
    End If

    If Integer.TryParse(szElementValue6, nNiss) = False Then

        If String.IsNullOrEmpty(szElementValue6) Then
            Exit Sub
        End If

        szElementValue6 = szElementValue6.Substring(0, szElementValue6.Length - 1)
        If Integer.TryParse(szElementValue6, nNiss) = False Then
            If szElementName = szName6 Then
                Me.ShowElementTip("非法的数据输入", "请您正确输入元素数值!")
                Exit Sub
            End If
        End If
    End If

    result = ld_b0 + ld_b1 * value_1 * 0.9368 + value_2 * 0.7326 + value_3 * 0.2908 + ld_b2 * nNiss + ld_b3 * ld_a
    result = System.Math.Round(1 / (1 + System.Math.Exp(-result)), 3)

    Me.SetElementValue("Ps(TRISS)", result.ToString())

End Sub
