using EMRDBLib;
using Heren.Common.Libraries;
using Heren.Common.RichEditor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace Heren.MedQC.TimeCheckGener.Controls
{
    public partial class HerenEditor : Panel
    {
       
        private TextEditor m_textEditor;
        /// <summary>
        /// 获取本窗口中编辑器控件,新控件名为TextEditor
        /// </summary>
        public TextEditor TextEditor
        {
            get
            {
                if (this.m_textEditor == null || this.m_textEditor.IsDisposed)
                {
                    this.m_textEditor = new TextEditor();
                    this.m_textEditor.RevisionVisible = false;
                    this.m_textEditor.ReviseEnabled = false;
                }
                return this.m_textEditor;
            }
        }
        public HerenEditor()
        {
            this.Controls.Add(this.m_textEditor);
        }
        /// <summary>
        /// 检查病历结构化元素缺陷
        /// </summary>
        /// <returns>元素缺陷列表</returns>
        public  List<ElementBugInfo> GetElementBugs()
        {
            List<ElementBugInfo> elementBugInfos = new List<ElementBugInfo>();
            if (this.m_textEditor == null || this.m_textEditor.IsDisposed)
                return elementBugInfos;

            TextField[] textFileds = this.m_textEditor.GetFields(null, MatchMode.Type);
            if (textFileds == null || textFileds.Length <= 0)
                return elementBugInfos;

            foreach (TextField field in textFileds)
            {
                string fieldText = string.Empty;
                this.m_textEditor.GetFieldText(field, out fieldText);

                ElementBugInfo bugInfo = new ElementBugInfo();
                bugInfo.Tag = field;
                bugInfo.ElementID = field.ID;
                bugInfo.ElementName = field.Name;
                if (field.FieldType == FieldType.TextOption)
                    bugInfo.ElementType = ElementType.SimpleOption;
                else if (field.FieldType == FieldType.RichOption)
                    bugInfo.ElementType = ElementType.ComplexOption;
                else
                    bugInfo.ElementType = ElementType.InputBox;

                if (!field.AllowEmpty && string.IsNullOrEmpty(fieldText))
                {
                    bugInfo.IsFatalBug = true;
                    bugInfo.BugDesc = string.Format("“{0}”内容为空!", bugInfo.ElementName);
                    elementBugInfos.Add(bugInfo);
                    continue;
                }

                if (field.HitForced && !field.AlreadyHitted)
                {
                    //用户必须点击，但是没有点击
                    bugInfo.BugDesc = string.Format("“{0}”是重点关注项，务必用鼠标点击一次!", field.Name);
                    elementBugInfos.Add(bugInfo);
                    continue;
                }

                //检查超出范围情况，MaxValue未null或者-1时，不用检查
                if (field.ValueType == FieldValueType.Numeric)
                {
                    decimal currValue = 0;
                    if (!decimal.TryParse(fieldText, out currValue))
                    {
                        bugInfo.IsFatalBug = true;
                        bugInfo.BugDesc = string.Format("请在“{0}”内正确输入数值!", field.Name);
                        elementBugInfos.Add(bugInfo);
                        continue;
                    }

                    decimal minValue = 0;
                    decimal maxValue = 0;
                    bool result1 = decimal.TryParse(field.MinValue, out minValue);
                    bool result2 = decimal.TryParse(field.MaxValue, out maxValue);

                    //数值不在范围内
                    if (result1 && minValue > 0 && currValue < minValue)
                    {
                        bugInfo.BugDesc = string.Format("“{0}”不能小于{1}!", field.Name, field.MinValue);
                        elementBugInfos.Add(bugInfo);
                        continue;
                    }
                    if (result2 && maxValue > 0 && currValue > maxValue && maxValue >= 0)
                    {
                        bugInfo.BugDesc = string.Format("“{0}”不能大于{1}!", field.Name, field.MaxValue);
                        elementBugInfos.Add(bugInfo);
                        continue;
                    }
                }
                else if (field.ValueType == FieldValueType.DateTime)
                {
                    DateTime currValue = new DateTime();
                    if (!GlobalMethods.Convert.StringToDate(fieldText, ref currValue))
                    {
                        bugInfo.IsFatalBug = true;
                        bugInfo.BugDesc = string.Format("请在“{0}”内正确输入日期!", field.Name);
                        elementBugInfos.Add(bugInfo);
                        continue;
                    }

                    //填入的内容确定为日期，再检查范围
                    DateTime minValue;
                    DateTime maxValue;
                    bool result1 = DateTime.TryParse(field.MinValue, out minValue);
                    bool result2 = DateTime.TryParse(field.MaxValue, out maxValue);

                    //时间不在范围内
                    if (result1 && currValue < minValue)
                    {
                        bugInfo.BugDesc = string.Format("“{0}”时间不能小于{1}!", field.Name, field.MinValue);
                        elementBugInfos.Add(bugInfo);
                        continue;
                    }
                    if (result2 && currValue > maxValue)
                    {
                        bugInfo.BugDesc = string.Format("“{0}”时间不能大于{1}!", field.Name, field.MaxValue);
                        elementBugInfos.Add(bugInfo);
                        continue;
                    }
                }
                else
                {
                    int minValue = 0;
                    int maxValue = 0;
                    bool result1 = int.TryParse(field.MinValue, out minValue);
                    bool result2 = int.TryParse(field.MaxValue, out maxValue);

                    //文本长度不在范围内
                    if (result1 && minValue > 0 && fieldText.Length < minValue)
                    {
                        bugInfo.BugDesc = string.Format("“{0}”文本长度不能小于{1}!", field.Name, field.MinValue);
                        elementBugInfos.Add(bugInfo);
                        continue;
                    }
                    if (result2 && maxValue > 0 && fieldText.Length > maxValue)
                    {
                        bugInfo.BugDesc = string.Format("“{0}”文本长度不能大于{1}!", field.Name, field.MaxValue);
                        elementBugInfos.Add(bugInfo);
                        continue;
                    }
                }
            }
            return elementBugInfos;
        }
    }
}
