'*********************************************************************************
' 这是系统提供的SAPSII元素的在线自动实时计算的脚本
' 注意：这是Visual Basic脚本，您可以不区分大小写 
' Script Language : Visual Basic
' Author : YangMingkun, Date : 2011-11-21
' Copyright (C) Heren Health Services (SUPCON) Co.,Ltd.
'*********************************************************************************


'请在Calculate接口函数内编写您的代码,请不要修改函数名称以免无法被编辑器系统识别
'参数szElementName是元素名称,它的值是由编辑器系统运行时动态传入的
Public Overrides Sub Calculate(ByVal szElementName As String)

    Dim szName1 As String = "T(℃.直肠)"
    Dim szName2 As String = "MAP(KPa)"
    Dim szName3 As String = "HR(次/mm)"
    Dim szName4 As String = "RR(次/mm)"
    Dim szName5 As String = "PaO2(KPa)"
    Dim szName6 As String = "(A-a)DO2(KPa)"
    Dim szName7 As String = "pH"
    Dim szName8 As String = "Na(mmol/L)"
    Dim szName9 As String = "K(mmol/L)"
    Dim szName10 As String = "Cr(μmol/L)(无急性肾功能衰竭时选择)"
    Dim szName11 As String = "Cr(μmol/L)(急性肾功能衰竭时选择)"
    Dim szName12 As String = "Hcl(%)"
    Dim szName13 As String = "WBC(×109/L)"
    Dim szName14 As String = "GCS"

    '如果用户当前修改的不是此脚本需要监控的元素,那么退出,这是很重要的
    '因为如果不退出,就会影响编辑器系统的运行效率
    If szElementName <> szName1 AndAlso szElementName <> szName2 _
        AndAlso szElementName <> szName3 AndAlso szElementName <> szName4 _
        AndAlso szElementName <> szName5 AndAlso szElementName <> szName6 _
        AndAlso szElementName <> szName7 AndAlso szElementName <> szName8 _
        AndAlso szElementName <> szName9 AndAlso szElementName <> szName10 _
        AndAlso szElementName <> szName11 AndAlso szElementName <> szName12 _
        AndAlso szElementName <> szName13 AndAlso szElementName <> szName14 Then
        Exit Sub
    End If

    Dim szElementValue As String = ""

    Dim nElementValue1 As Integer = 0
    Dim nElementValue2 As Integer = 0
    Dim nElementValue3 As Integer = 0
    Dim nElementValue4 As Integer = 0
    Dim nElementValue5 As Integer = 0
    Dim nElementValue6 As Integer = 0
    Dim nElementValue7 As Integer = 0
    Dim nElementValue8 As Integer = 0
    Dim nElementValue9 As Integer = 0
    Dim nElementValue10 As Integer = 0
    Dim nElementValue11 As Integer = 0
    Dim nElementValue12 As Integer = 0
    Dim nElementValue13 As Integer = 0
    Dim nElementValue14 As Integer = 0

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

    Me.GetElementValue(szName14, szElementValue)
    If Not Integer.TryParse(szElementValue, nElementValue14) Then
        If szElementName = szName14 Then
            Me.ShowElementTip("非法的数据输入", "请您正确输入元素数值!")
            Exit Sub
        End If
    End If


    Dim result As Integer = nElementValue1 + nElementValue2 + nElementValue3 + nElementValue4 _
                           + nElementValue5 + nElementValue6 + nElementValue7 + nElementValue8 _
                           + nElementValue9 + nElementValue10 + nElementValue11 + nElementValue12 _
                           + nElementValue13 + nElementValue14
    Me.SetElementValue("APACHEⅡ得分", result.ToString())
End Sub
