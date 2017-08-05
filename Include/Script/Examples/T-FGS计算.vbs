'*********************************************************************************
' 这是系统提供的T-FGS元素的在线自动实时计算的脚本
' 注意：这是Visual Basic脚本，您可以不区分大小写 
' Script Language : Visual Basic
' Author : YangMingkun, Date : 2011-11-21
' Copyright (C) Heren Health Services (SUPCON) Co.,Ltd.
'*********************************************************************************


'请在Calculate接口函数内编写您的代码,请不要修改函数名称以免无法被编辑器系统识别
'参数szElementName是元素名称,它的值是由编辑器系统运行时动态传入的
Public Overrides Sub Calculate(ByVal szElementName As String)

    Dim szName1 As String = "抬额头标准表情"
    Dim szName2 As String = "轻闭眼标准表情"
    Dim szName3 As String = "耸鼻标准表情"
    Dim szName4 As String = "咧嘴笑标准表情"
    Dim szName5 As String = "唇吸吮标准表情"
    Dim szName6 As String = "抬额头联动"
    Dim szName7 As String = "轻闭眼联动"
    Dim szName8 As String = "耸鼻联动"
    Dim szName9 As String = "咧嘴笑联动"
    Dim szName10 As String = "唇吸吮联动"
    Dim szName11 As String = "睑裂"
    Dim szName12 As String = "颊鼻唇沟"
    Dim szName13 As String = "口角"

    '如果用户当前修改的不是此脚本需要监控的元素,那么退出,这是很重要的
    '因为如果不退出,就会影响编辑器系统的运行效率
    If szElementName <> szName1 AndAlso szElementName <> szName2 _
        AndAlso szElementName <> szName3 AndAlso szElementName <> szName4 _
        AndAlso szElementName <> szName5 AndAlso szElementName <> szName6 _
        AndAlso szElementName <> szName7 AndAlso szElementName <> szName8 _
        AndAlso szElementName <> szName9 AndAlso szElementName <> szName10 _
        AndAlso szElementName <> szName11 AndAlso szElementName <> szName12 _
        AndAlso szElementName <> szName13 Then
        Return
    End If

    Dim szElementValue As String = ""

    Dim nElementValue1 As Integer
    Dim nElementValue2 As Integer
    Dim nElementValue3 As Integer
    Dim nElementValue4 As Integer
    Dim nElementValue5 As Integer
    Dim nElementValue6 As Integer
    Dim nElementValue7 As Integer
    Dim nElementValue8 As Integer
    Dim nElementValue9 As Integer
    Dim nElementValue10 As Integer
    Dim nElementValue11 As Integer
    Dim nElementValue12 As Integer
    Dim nElementValue13 As Integer

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

    '通过GetElementValue接口,获取计算时所需要的文档中的元素值(字符串类型的值)
    Me.GetElementValue(szName4.Trim(), szElementValue)
    If Not Integer.TryParse(szElementValue, nElementValue4) Then
        If szElementName = szName4 Then
            Me.ShowElementTip("非法的数据输入", "请您正确输入元素数值!")
            Exit Sub
        End If
    End If


    Me.GetElementValue(szName5, szElementValue)
    If Not Integer.TryParse(szElementValue, nElementValue5) Then
        If szElementName = szName5 Then
            Me.ShowElementTip("非法的数据输入", "请您正确输入元素数值!")
            Exit Sub
        End If
    End If

    Me.GetElementValue(szName6, szElementValue)
    If Not Integer.TryParse(szElementValue, nElementValue6) Then
        If szElementName = szName6 Then
            Me.ShowElementTip("非法的数据输入", "请您正确输入元素数值!")
            Exit Sub
        End If
    End If

    Me.GetElementValue(szName7, szElementValue)
    If Not Integer.TryParse(szElementValue, nElementValue7) Then
        If szElementName = szName7 Then
            Me.ShowElementTip("非法的数据输入", "请您正确输入元素数值!")
            Exit Sub
        End If
    End If

    Me.GetElementValue(szName8, szElementValue)
    If Not Integer.TryParse(szElementValue, nElementValue8) Then
        If szElementName = szName8 Then
            Me.ShowElementTip("非法的数据输入", "请您正确输入元素数值!")
            Exit Sub
        End If
    End If

    Me.GetElementValue(szName9, szElementValue)
    If Not Integer.TryParse(szElementValue, nElementValue9) Then
        If szElementName = szName9 Then
            Me.ShowElementTip("非法的数据输入", "请您正确输入元素数值!")
            Exit Sub
        End If
    End If

    Me.GetElementValue(szName10, szElementValue)
    If Not Integer.TryParse(szElementValue, nElementValue10) Then
        If szElementName = szName10 Then
            Me.ShowElementTip("非法的数据输入", "请您正确输入元素数值!")
            Exit Sub
        End If
    End If

    Me.GetElementValue(szName11, szElementValue)
    If Not Integer.TryParse(szElementValue, nElementValue11) Then
        If szElementName = szName11 Then
            Me.ShowElementTip("非法的数据输入", "请您正确输入元素数值!")
            Exit Sub
        End If
    End If

    Me.GetElementValue(szName12, szElementValue)
    If Not Integer.TryParse(szElementValue, nElementValue12) Then
        If szElementName = szName12 Then
            Me.ShowElementTip("非法的数据输入", "请您正确输入元素数值!")
            Exit Sub
        End If
    End If

    Me.GetElementValue(szName13, szElementValue)
    If Not Integer.TryParse(szElementValue, nElementValue13) Then
        If szElementName = szName13 Then
            Me.ShowElementTip("非法的数据输入", "请您正确输入元素数值!")
            Exit Sub
        End If
    End If

    Dim result As Integer = nElementValue1 + nElementValue2 + nElementValue3 + nElementValue4 + nElementValue5 _
                            - nElementValue6 - nElementValue7 - nElementValue8 - nElementValue9 - nElementValue10 _
                         - nElementValue11 + nElementValue12 - nElementValue13
    Me.SetElementValue("T-FGS", result.ToString())

End Sub
