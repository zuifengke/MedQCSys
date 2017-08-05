'*********************************************************************************
' 这是系统提供的一个默认的,空的在线自动实时计算的脚本,请基于此实现自己的功能
' 您可以参考该脚本编写用于其他计算目的的任何计算或者质控脚本
' 注意：这是Visual Basic脚本，您可以不区分大小写 
' Script Language : Visual Basic
' Author : YangMingkun, Date : 2011-11-21
' Copyright (C) Heren Health Services (SUPCON) Co.,Ltd.
'*********************************************************************************


'请在Calculate接口函数内编写您的代码,请不要修改函数名称以免无法被编辑器系统识别
'参数szElementName是元素名称,它的值是由编辑器系统运行时动态传入的
Public Overrides Sub Calculate(ByVal szElementName As String)

    '如果用户当前修改的不是此脚本需要监控的元素,那么退出,这是很重要的
    '因为如果不退出,就会影响编辑器系统的运行效率
    If szElementName <> "您需要计算和监控的元素名称" Then
        Exit Sub
    End If

    '通过HideElementTip接口及时隐藏掉之前可能已经弹出的提示气泡
    Me.HideElementTip()

    '通过GetElementValue接口,获取计算时所需要的文档中的元素值(字符串类型的值)
    Dim elementValue As String = ""
    Me.GetElementValue("您需要计算和监控的元素名称", elementValue)

    '如果计算时,需要整型数据,那么转换元素值为整型值
    '如果转换失败,那么可以通过ShowElementTip接口给用户一个输入有误的提示气泡
    '有关如何转换数据类型,请参考帮助手册
    Dim value As Long
    If Not Long.TryParse(elementValue, value) Then
        Me.ShowElementTip("非法的xxx输入", "请您正确输入xxx元素值!")
        Exit Sub
    End If

    '进行核心运算,然后将运算结果通过SetElementValue接口设置到病历中指定的元素
    If value < 60 Then
        Me.SetElementValue("这个参数是目标元素的名称", "这个参数是插入到目标元素的字符串")
    Else
        Me.SetElementValue("这个参数是目标元素的名称", "这个参数是插入到目标元素的字符串")
    End If
End Sub
