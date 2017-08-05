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
    If szElementName <> "初步诊断内容" AndAlso szElementName <> "最后诊断内容" Then
        Exit Sub
    End If

    '通过HideElementTip接口及时隐藏掉之前可能已经弹出的提示气泡
    Me.HideElementTip()

    '通过GetElementValue接口,获取计算时所需要的文档中的元素值(字符串类型的值)
    Dim elementValue As String = ""
    Me.GetElementValue(szElementName, elementValue)

    If Not elementValue = "颈椎病" Then
        Exit Sub
    End If

    Dim sbDiagnosisDesc As New StringBuilder()
    sbDiagnosisDesc.AppendLine("颈椎病又称颈椎综合征，是颈椎骨关节炎、增生性颈椎炎、颈神经根综合征、颈椎间盘脱出症的总称；")
    sbDiagnosisDesc.AppendLine("是一种以退行性病理改变为基础的疾患。主要由于颈椎长期劳损、骨质增生，或椎间盘脱出、韧带增厚，")
    sbDiagnosisDesc.AppendLine("致使颈椎脊髓、神经根或椎动脉受压，导致一系列功能障碍的临床综合征。表现为颈椎间盘退变本身及其")
    sbDiagnosisDesc.AppendLine("继发性的一系列病理改变，如椎节失稳、松动；髓核突出或脱出；骨刺形成；韧带肥厚和继发的椎管狭窄")
    sbDiagnosisDesc.Append("等，刺激或压迫了邻近的神经根、脊髓、椎动脉及颈部交感神经等组织，并引起各种各样症状和体征的综合征。")

    Me.ShowElementTip("关于颈椎病的诊断建议", sbDiagnosisDesc.ToString())
End Sub
