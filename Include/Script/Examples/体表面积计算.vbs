'*********************************************************************************
' 这是系统提供的病人体表面积以及BMI值元素的在线自动实时计算的脚本
' 注意：这是Visual Basic脚本，您可以不区分大小写 
' Script Language : Visual Basic
' Author : YangMingkun, Date : 2011-11-21
' Copyright (C) Heren Health Services (SUPCON) Co.,Ltd.
'*********************************************************************************


'请在Calculate接口函数内编写您的代码,请不要修改函数名称以免无法被编辑器系统识别
'参数szElementName是元素名称,它的值是由编辑器系统运行时动态传入的
Public Overrides Sub Calculate(ByVal szElementName As String)

    Dim szName1 As String = "身高"
    Dim szName2 As String = "体重"

    '如果用户当前修改的不是此脚本需要监控的元素,那么退出,这是很重要的
    '因为如果不退出,就会影响编辑器系统的运行效率
    If szElementName <> szName1 AndAlso szElementName <> szName2 Then
        Return
    End If

    Dim szElementValue As String = ""

    '通过HideElementTip接口及时隐藏掉之前可能已经弹出的提示气泡
    Me.HideElementTip()

    '通过GetElementValue接口,获取计算时所需要的文档中的元素值(字符串类型的值)
    '获取身高元素值
    Me.GetElementValue(szName1, szElementValue)
    Dim dBodyHeight As Double
    Double.TryParse(szElementValue, dBodyHeight)
    's如果不小于3,则认为单位是cm,需要转换为m
    If dBodyHeight >= 3 Then
        dBodyHeight = dBodyHeight / 100
    End If

    '获取体重元素值
    Me.GetElementValue(szName2, szElementValue)
    Dim dBodyWeight As Double
    Double.TryParse(szElementValue, dBodyWeight)

    If dBodyHeight <= 0 OrElse dBodyWeight <= 0 Then
        Exit Sub
    End If

    '进行核心运算,然后将运算结果通过SetElementValue接口设置到病历中指定的元素 
    '保留两位小数,并四舍五入
    Dim dBmiValue As Double = dBodyWeight / (dBodyHeight * dBodyHeight)
    dBmiValue = Me.RoundValue(dBmiValue, 2)

    '保留两位小数,并四舍五入
    Dim dAreaValue As Double = 0.0061 * dBodyHeight * 100 + 0.0128 * dBodyWeight - 0.1529
    dAreaValue = Me.RoundValue(dAreaValue, 2)

    Me.SetElementValue("BMI值", dBmiValue.ToString())
    Me.SetElementValue("体表面积", dAreaValue.ToString())
End Sub
