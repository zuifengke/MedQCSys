// ***********************************************************
// 病案质控系统问题分类对话框.
// Creator:LiChunYing  Date:2011-09-13
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Heren.Common.Libraries;
using Heren.Common.Controls;
using System.Linq;
using EMRDBLib.DbAccess;
using EMRDBLib;

namespace MedQCSys.Dialogs
{
    public partial class SelectQuestionForm : HerenForm
    {
        private MedicalQcMsg m_MedicalQcMsg = null;
        /// <summary>
        /// 获取或设置质检问题模板类
        /// </summary>
        public MedicalQcMsg MedicalQcMsg
        {
            get { return this.m_MedicalQcMsg; }
            set { this.m_MedicalQcMsg = value; }
        }

        private static List<QaEventTypeDict> lstQCEventTypes = null;

        public static List<QaEventTypeDict> LstQCEventTypes
        {
            get
            {
                if (lstQCEventTypes == null)
                {
                    short shRet = QaEventTypeDictAccess.Instance.GetQCEventTypeList(ref lstQCEventTypes);
                    if (shRet != SystemData.ReturnValue.OK)
                    {
                        MessageBoxEx.Show("获取病案质量问题分类字典失败！");
                    }
                }
                return SelectQuestionForm.lstQCEventTypes;
            }
        }

        private static List<QcMsgDict> m_lstQcMsgDicts = null;

        public static List<QcMsgDict> ListQcMsgDict
        {
            get
            {
                if (m_lstQcMsgDicts == null)
                {
                    short shRet = QcMsgDictAccess.Instance.GetQcMsgDictList(ref m_lstQcMsgDicts);
                    if (shRet != SystemData.ReturnValue.OK)
                    {
                        MessageBoxEx.Show("获取病案质量问题分类字典失败！");
                    }
                }
                return SelectQuestionForm.m_lstQcMsgDicts;
            }
        }

        public SelectQuestionForm()
        {
            InitializeComponent();
            string caption = "提示:";
            if (SystemParam.Instance.LocalConfigOption.VetoHigh > 0)
            {
                caption += string.Format("\n{0}项单项否决将被设置成乙病历"
                , SystemParam.Instance.LocalConfigOption.VetoHigh);
            }
            if (SystemParam.Instance.LocalConfigOption.VetoLow > 0)
            {
                caption += string.Format("\n{0}项单项否决将被设置成丙病历"
               , SystemParam.Instance.LocalConfigOption.VetoLow);
            }
            this.toolTip1.SetToolTip(this.picVetoDesc, caption);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.txtChecker.Text = SystemParam.Instance.UserInfo.USER_ID;
            if (SystemParam.Instance.PatVisitInfo == null)
                return;
            if (String.IsNullOrEmpty(SystemParam.Instance.PatVisitInfo.DISCHARGE_MODE))
                this.rdbIn.Checked = true;
            else if (SystemParam.Instance.PatVisitInfo.DISCHARGE_MODE == "死亡")
                this.rdbDeath.Checked = true;
            else
                this.rdbOut.Checked = true;
            this.txtPatientID.Text = SystemParam.Instance.PatVisitInfo.PATIENT_ID;
            this.txtPatName.Text = SystemParam.Instance.PatVisitInfo.PATIENT_NAME;
            this.txtPatSex.Text = SystemParam.Instance.PatVisitInfo.PATIENT_SEX;
            this.txtDocTitle.Text = this.m_MedicalQcMsg.TOPIC;
            this.txtQuestionType.Text = "<双击选择>";
            this.txt_ISSUED_DATE_TIME.Text = this.m_MedicalQcMsg.ISSUED_DATE_TIME.ToString("yyyy-M-d HH:mm");
            if (this.MedicalQcMsg != null && !string.IsNullOrEmpty(this.m_MedicalQcMsg.QC_MSG_CODE))
            {
                if (this.m_MedicalQcMsg.ASK_DATE_TIME != this.m_MedicalQcMsg.DefaultTime)
                    this.txtAskDateTime.Text = this.m_MedicalQcMsg.ASK_DATE_TIME.ToString();
                this.txtDoctorComment.Text = this.m_MedicalQcMsg.DOCTOR_COMMENT;
                this.txtQuestionType.Text = this.MedicalQcMsg.QA_EVENT_TYPE;
                this.txtMessage.Text = this.MedicalQcMsg.MESSAGE;
                this.txtMessage.Focus();
                this.txtMessage.SelectAll();
                this.txtMessage.Tag = this.MedicalQcMsg.QC_MSG_CODE;
                this.txtBoxScore.Text = this.MedicalQcMsg.POINT.ToString();
                //修改或者浏览
                //设置病历类型
                if (this.MedicalQcMsg.QCDOC_TYPE == SystemData.QCDocType.INHOSPITAL)
                {
                    this.rdbIn.Checked = true;
                }
                else if (this.MedicalQcMsg.QCDOC_TYPE == SystemData.QCDocType.OUTHOSPITAL)
                {
                    this.rdbOut.Checked = true;
                }
                else
                {
                    this.rdbDeath.Checked = true;
                }
                if (!string.IsNullOrEmpty(this.m_MedicalQcMsg.QC_MSG_CODE))
                {
                    QcMsgDict qcMsgDict = ListQcMsgDict.Where(m => m.QC_MSG_CODE == this.m_MedicalQcMsg.QC_MSG_CODE).FirstOrDefault();
                    this.txtMesssageTitle.Text = qcMsgDict.MESSAGE_TITLE;
                    if (qcMsgDict != null)
                        this.lbCurrentScoreInfo.Text = "问题标准分数：" + Math.Round(new decimal(GlobalMethods.Convert.StringToValue(qcMsgDict.SCORE, 0f)), 1).ToString("F1");
                    this.lbCurrentScoreInfo.Tag = qcMsgDict;
                    List<QcMsgDict> lstQCMessageTemplet = ListQcMsgDict;
                    if (lstQCMessageTemplet == null)
                    {
                        MessageBoxEx.Show("质控质检问题字典表获取失败！");
                    }
                    var item = lstQCMessageTemplet.Where(m => m.QC_MSG_CODE == this.m_MedicalQcMsg.QC_MSG_CODE).FirstOrDefault();
                    if(item!=null)
                    {
                        this.SetScoreInfos(item);
                        //在修改分数的时候，减去当前选中的
                        double scoreLevel1Count = 0.0;//大类分数
                        double scoreLevel2Count = 0.0;//子类分数
                        double currentScore = (double)Math.Round(new decimal(GlobalMethods.Convert.StringToValue(this.txtBoxScore.Text, 0f)), 1);
                        scoreLevel1Count = (double)Math.Round(new decimal(GlobalMethods.Convert.StringToValue(this.txtLevel1Score.Text, 0f)), 1);
                        scoreLevel2Count = (double)Math.Round(new decimal(GlobalMethods.Convert.StringToValue(this.txtLevel2Socre.Text, 0f)), 1);
                        scoreLevel1Count -= currentScore;
                        scoreLevel2Count -= currentScore;
                        this.txtLevel1Score.Text = scoreLevel1Count.ToString();
                        this.txtLevel2Socre.Text = scoreLevel2Count.ToString();
                     
                    }
                }
            }
        }


        private void btnOK_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(MedicalQcMsg.QC_MSG_CODE))
            {
                MessageBoxEx.Show("请双击选择问题类型!");
                return;
            }
            if (string.IsNullOrEmpty(this.txtQuestionType.Text) || this.txtQuestionType.Text == "<双击选择>")
            {
                MessageBoxEx.Show("请双击选择问题类型!");
                return;
            }
            if (string.IsNullOrEmpty(this.txtMessage.Text))
            {
                MessageBoxEx.Show("请输入质检问题描述!");
                this.txtMessage.Focus();
                return;
            }
            bool bPassed = CheckBoxScore();
            if (!bPassed)
                return;
            this.MedicalQcMsg.MESSAGE = (string)this.txtMessage.Text;
            this.MedicalQcMsg.POINT = string.IsNullOrEmpty(this.txtBoxScore.Text) ? 0 : float.Parse(this.txtBoxScore.Text);
            //设置病历类型
            if (this.rdbIn.Checked)
            {
                this.MedicalQcMsg.QCDOC_TYPE = SystemData.QCDocType.INHOSPITAL;
            }
            else if (this.rdbOut.Checked)
            {
                this.MedicalQcMsg.QCDOC_TYPE = SystemData.QCDocType.OUTHOSPITAL;
            }
            else
            {
                this.MedicalQcMsg.QCDOC_TYPE = SystemData.QCDocType.DEATH;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void txtQuestionType_DoubleClick(object sender, EventArgs e)
        {
            if (this.txtQuestionType.Text == "<双击选择>")
                this.txtQuestionType.Clear();
            QuestionTypeForm frmQuestionType = new QuestionTypeForm();
            if (frmQuestionType.ShowDialog() != DialogResult.OK)
                return;
            this.m_MedicalQcMsg.QC_MSG_CODE = frmQuestionType.QcMsgCode;
            this.m_MedicalQcMsg.QA_EVENT_TYPE = frmQuestionType.QaEventType;
            this.m_MedicalQcMsg.MESSAGE = frmQuestionType.Message;
            this.txtQuestionType.Text = frmQuestionType.QaEventType;
            this.txtMessage.Text = string.Concat(this.txtMessage.Text, frmQuestionType.Message);
            this.txtMesssageTitle.Text = frmQuestionType.MessageTitle;
            this.txtMessage.Tag = frmQuestionType.QcMsgCode;
            this.lbCurrentScoreInfo.Text = "问题标准分数：" + Math.Round(new decimal(GlobalMethods.Convert.StringToValue(frmQuestionType.Score, 0f)), 1).ToString("F1"); ;
            this.lbCurrentScoreInfo.Tag = frmQuestionType.SelectedQCMessageTemplet;
            this.SetScoreInfos(frmQuestionType.SelectedQCMessageTemplet);
            this.txtBoxScore.Text = Math.Round(new decimal(GlobalMethods.Convert.StringToValue(frmQuestionType.Score, 0f)), 1).ToString("F1");
            this.txtBoxIsVeto.Text = frmQuestionType.SelectedQCMessageTemplet.ISVETO ? "是" : "否";
            this.txtBoxIsVeto.ForeColor = frmQuestionType.SelectedQCMessageTemplet.ISVETO ? Color.Red : Color.Black;
            this.txtMessage.Focus();
            this.txtMessage.SelectAll();
        }

        /// <summary>
        /// 设置扣分上限信息
        /// </summary>
        /// <param name="frmQuestionType"></param>
        private void SetScoreInfos(QcMsgDict qcMessageTemplet)
        {
            string szLevel1Socre = string.Empty;
            string szLevel2Socre = string.Empty;
            string szPatientID = SystemParam.Instance.PatVisitInfo.PATIENT_ID;
            string szVisitID = SystemParam.Instance.PatVisitInfo.VISIT_ID;

            List<MedicalQcMsg> lstQCQuestionInfos = null;
            short shRet = MedicalQcMsgAccess.Instance.GetMedicalQcMsgList(szPatientID, szVisitID, ref lstQCQuestionInfos);
            if (shRet != SystemData.ReturnValue.OK
                && shRet != SystemData.ReturnValue.RES_NO_FOUND)
            {
                MessageBoxEx.Show("质控质检问题下载失败！");
                return;
            }
            if (lstQCQuestionInfos == null || lstQCQuestionInfos.Count <= 0)
            {
                szLevel1Socre = "0.0";
                szLevel2Socre = "0.0";
            }
            else
            {
                double scoreLevel1Count = 0.0;
                double scoreLevel2Count = 0.0;
                foreach (MedicalQcMsg qcQuestionInfo in lstQCQuestionInfos)
                {
                    if (qcQuestionInfo.QA_EVENT_TYPE == qcMessageTemplet.QA_EVENT_TYPE)//问题大类扣分累计
                    {
                        scoreLevel1Count += (double)Math.Round(new decimal(GlobalMethods.Convert.StringToValue(qcQuestionInfo.POINT, 0f)), 1);
                    }
                    QcMsgDict itemQCMessageTemplet = ListQcMsgDict.Find(delegate (QcMsgDict p) { return p.QC_MSG_CODE == qcQuestionInfo.QC_MSG_CODE; });
                    if (itemQCMessageTemplet == null)
                        continue;
                    //子类问题扣分累加
                    //添加了子类标题按照子类标题计算

                    if (!string.IsNullOrEmpty(qcMessageTemplet.MESSAGE_TITLE) &&
                        itemQCMessageTemplet.MESSAGE_TITLE == qcMessageTemplet.MESSAGE_TITLE)
                    {
                        scoreLevel2Count += (double)Math.Round(new decimal(GlobalMethods.Convert.StringToValue(qcQuestionInfo.POINT, 0f)), 1);
                    } //没有添加子类标题的按照原来的问题类型CODE计算
                    else if (string.IsNullOrEmpty(qcMessageTemplet.MESSAGE_TITLE) &&
                             itemQCMessageTemplet.QC_MSG_CODE == qcMessageTemplet.QC_MSG_CODE)
                    {
                        scoreLevel2Count += (double)Math.Round(new decimal(GlobalMethods.Convert.StringToValue(qcQuestionInfo.POINT, 0f)), 1);
                    }

                }
                this.txtLevel1Score.Text = scoreLevel1Count.ToString();
                this.txtLevel2Socre.Text = scoreLevel2Count.ToString();
            }
            //上限分数设置
            if (LstQCEventTypes != null)
            {
                double scoreLevel1Max = 0.0;
                double scoreLevel2Max = 0.0;
                foreach (QaEventTypeDict qcEventType in LstQCEventTypes)
                {
                    //问题大类分数上限
                    if (qcEventType.QA_EVENT_TYPE == qcMessageTemplet.QA_EVENT_TYPE)
                    {
                        scoreLevel1Max = (double)Math.Round(new decimal(GlobalMethods.Convert.StringToValue(qcEventType.MAX_SCORE, 0f)), 1);
                        if (scoreLevel1Max == 0.0)
                        {
                            this.lblevel1MaxScore.Text = "类型上限分数：无限制";
                        }
                        else
                        {
                            this.lblevel1MaxScore.Text = "类型上限分数：" + scoreLevel1Max.ToString();
                            this.lblevel1MaxScore.Tag = scoreLevel1Max;
                        }
                    }
                    //子类问题类型分数上限
                    if (!string.IsNullOrEmpty(qcEventType.PARENT_CODE) && qcEventType.QA_EVENT_TYPE == qcMessageTemplet.MESSAGE_TITLE)
                    {
                        scoreLevel2Max = (double)Math.Round(new decimal(GlobalMethods.Convert.StringToValue(qcEventType.MAX_SCORE, 0f)), 1);
                        if (scoreLevel2Max == 0.0)
                        {
                            this.lblevel2MaxScore.Text = "子类上限分数：无限制";
                        }
                        else
                        {
                            this.lblevel2MaxScore.Text = "子类上限分数：" + scoreLevel2Max.ToString();
                            this.lblevel2MaxScore.Tag = scoreLevel2Max;
                        }
                    }
                    //没有MessageTitle的问题类型
                    if (string.IsNullOrEmpty(qcMessageTemplet.MESSAGE_TITLE))
                    {
                        this.lblevel2MaxScore.Text = "子类上限分数：无限制";
                    }
                }
            }
            else
            {
                this.lblevel1MaxScore.Text = "类型上限分数：未知";
                this.lblevel2MaxScore.Text = "子类上限分数：未知";
            }
        }

        private void txtBoxScore_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x20) e.KeyChar = (char)0;  //禁止空格键  
            if ((e.KeyChar == 0x2D) && (((TextBox)sender).Text.Length == 0)) return;   //处理负数  
            if (e.KeyChar > 0x20)
            {
                try
                {
                    double.Parse(((TextBox)sender).Text + e.KeyChar.ToString());
                }
                catch
                {
                    e.KeyChar = (char)0;   //处理非法字符  
                }
            }
        }

        private bool CheckBoxScore()
        {
            if (string.IsNullOrEmpty(MedicalQcMsg.QC_MSG_CODE))
            {
                return false;
            }
            string szText = this.txtBoxScore.Text;
            try
            {
                if (string.IsNullOrEmpty(szText))
                    this.txtBoxScore.Text = "0.0";
                int result = 0;
                if (szText.Contains("."))
                    result = szText.Length - szText.IndexOf('.') - 1;
                if (result > 1)
                {
                    MessageBox.Show("扣分仅需精确到小数点一位");
                    this.txtBoxScore.Text = szText.Remove(szText.IndexOf('.') + 2, result - 1);
                    return false;
                }

                double level1ScoreCount = (double)Math.Round(new decimal(GlobalMethods.Convert.StringToValue(this.txtLevel1Score.Text, 0f)), 1);
                double level2ScoreCount = (double)Math.Round(new decimal(GlobalMethods.Convert.StringToValue(this.txtLevel2Socre.Text, 0f)), 1);
                double level1ScoreMax = this.lblevel1MaxScore.Tag == null ?
                    9999.9 : (double)Math.Round(new decimal(GlobalMethods.Convert.StringToValue(this.lblevel1MaxScore.Tag.ToString(), 0f)), 1);
                double level2ScoreMax = this.lblevel2MaxScore.Tag == null ?
                                    9999.9 : (double)Math.Round(new decimal(GlobalMethods.Convert.StringToValue(this.lblevel2MaxScore.Tag.ToString(), 0f)), 1);
                double currentScore = (double)Math.Round(new decimal(GlobalMethods.Convert.StringToValue(szText, 0f)), 1);
                QcMsgDict qcMessageTemplet = this.lbCurrentScoreInfo.Tag as QcMsgDict;
                double templetScore = 0.0;
                if (qcMessageTemplet == null)
                {
                    qcMessageTemplet = ListQcMsgDict.Find(delegate (QcMsgDict t) { return t.QC_MSG_CODE == MedicalQcMsg.QC_MSG_CODE; });
                }
                if (qcMessageTemplet == null)
                {
                    MessageBox.Show("质检标准信息获取失败");
                    return false;
                }
                else
                {
                    templetScore = (double)Math.Round(new decimal(GlobalMethods.Convert.StringToValue(qcMessageTemplet.SCORE, 0f)), 1);
                }
                double leftLevel_1_Socre = (double)Math.Round(level1ScoreMax - level1ScoreCount - currentScore, 1);
                double leftLevel_2_Socre = (double)Math.Round(level2ScoreMax - level2ScoreCount - currentScore, 1);
                if (leftLevel_2_Socre < 0.0)
                {
                    MessageBoxEx.Show("分数不得超过问题子类可扣分数！", MessageBoxIcon.Warning);
                    if ((level2ScoreMax - level2ScoreCount - templetScore) <= 0.0)
                        templetScore = level2ScoreMax - level2ScoreCount;
                    if (templetScore < 0)
                        templetScore = 0.0;
                    this.txtBoxScore.Text = templetScore.ToString("F1");
                    return false;
                }
                else if (leftLevel_1_Socre < 0.0)
                {
                    MessageBoxEx.Show("分数不得超过问题大类可扣分数！", MessageBoxIcon.Warning);
                    if ((level1ScoreMax - level1ScoreCount - templetScore) <= 0.0)
                        templetScore = level1ScoreMax - level1ScoreCount;
                    if (templetScore < 0)
                        templetScore = 0.0;
                    this.txtBoxScore.Text = templetScore.ToString("F1");
                    return false;
                }
                else
                {
                    this.txtBoxScore.Text = currentScore.ToString("F1");
                    return true;
                }

            }
            catch
            {

            }
            return false;
        }

        private void txtBoxScore_MouseLeave(object sender, EventArgs e)
        {
            CheckBoxScore();
        }
    }
}