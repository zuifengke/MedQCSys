using EMRDBLib;
using EMRDBLib.DbAccess;
using Heren.Common.Libraries;
using MedDocSys.QCEngine.BugCheck;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Heren.MedQC.TimeCheckGener.Forms
{
    public partial class DocBugCheckForm : Form
    {
        public DocBugCheckForm()
        {
            InitializeComponent();
        }
        private BugCheckEngine m_bugCheckEngine =null;
        private void button1_Click(object sender, EventArgs e)
        {
            //查询文档
            string szDocID = this.txtDocID.Text;
            if (string.IsNullOrEmpty(szDocID))
            {
                MessageBox.Show("请输入文档ID号");
                return;
            }
            MedDocInfo medDocInfo = null;
            short shRet = EmrDocAccess.Instance.GetDocInfo(szDocID, ref medDocInfo);
            if (medDocInfo == null)
            {
                MessageBoxEx.ShowError("查找文档信息失败");
                return;
            }
            if (!string.IsNullOrEmpty(SystemParam.Instance.LocalConfigOption.IgnoreDocTypeIDs)
                && SystemParam.Instance.LocalConfigOption.IgnoreDocTypeIDs.Contains(medDocInfo.DOC_TYPE))
            {
                MessageBoxEx.Show(string.Format("{0}已忽略分析,忽略DocTypeIDs有{1}"
                    ,medDocInfo.DOC_TITLE
                    , SystemParam.Instance.LocalConfigOption.IgnoreDocTypeIDs));
                return;
            }
            Editor.Instance.ParentControl = this;
            string szTextData = Editor.Instance.GetDocText(medDocInfo);
            if (this.m_bugCheckEngine == null)
                this.m_bugCheckEngine = new BugCheckEngine();
            m_bugCheckEngine.PatientInfo = GetPatientInfo(medDocInfo.PATIENT_ID, medDocInfo.VISIT_ID);
            m_bugCheckEngine.VisitInfo = GetVisitInfo(medDocInfo.PATIENT_ID, medDocInfo.VISIT_ID);
            m_bugCheckEngine.UserInfo = GetUserInfo();
            m_bugCheckEngine.DocType = medDocInfo.DOC_TITLE;
            m_bugCheckEngine.DocText = szTextData;
            shRet = m_bugCheckEngine.InitializeEngine();
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog(string.Format("{0} 病历质控引擎初始化失败,无法对病历进行自动质控！", DateTime.Now), null,
                    LogType.Information);
            }
            //检查文档内容缺陷
            List<DocuemntBugInfo> lstDocuemntBugList = null;
            if (shRet == SystemData.ReturnValue.OK)
            {
                lstDocuemntBugList = m_bugCheckEngine.PerformBugCheck();
                m_bugCheckEngine.DocText = null;
            }
            //检查文档元素缺陷
            List<ElementBugInfo> lstElementBugList = null;
            Editor.Instance.CheckElementBugs(medDocInfo.EMR_TYPE, ref lstElementBugList);
            LoadGridBugs(lstDocuemntBugList, lstElementBugList);
        }

        private void LoadGridBugs(List<DocuemntBugInfo> lstDocuemntBugList, List<ElementBugInfo> lstElementBugList)
        {
            this.dataGridView1.Rows.Clear();
            if (lstDocuemntBugList != null
                && lstDocuemntBugList.Count > 0)
            {
                foreach (var item in lstDocuemntBugList)
                {
                    int index = this.dataGridView1.Rows.Add();
                    if (item.BugLevel == BugLevel.Error)
                        this.dataGridView1.Rows[index].Cells[this.colBugClass.Index].Value = "错误";
                    else
                        this.dataGridView1.Rows[index].Cells[this.colBugClass.Index].Value = "警告";
                    this.dataGridView1.Rows[index].Cells[this.colBugType.Index].Value = "逻辑性";
                    this.dataGridView1.Rows[index].Cells[this.colQCExpalin.Index].Value = item.BugDesc;
                }
            }
            if (lstElementBugList != null
                && lstElementBugList.Count > 0)
            {
                foreach (var item in lstElementBugList)
                {
                    int index = this.dataGridView1.Rows.Add();
                    this.dataGridView1.Rows[index].Cells[this.colBugClass.Index].Value = "错误";
                    this.dataGridView1.Rows[index].Cells[this.colBugType.Index].Value = "内容元素";
                    this.dataGridView1.Rows[index].Cells[this.colQCExpalin.Index].Value = item.BugDesc;
                }
            }

        }

        /// <summary>
        ///     生成系统数据
        /// </summary>
        /// <returns></returns>
        private UserInfo GetUserInfo()
        {
            UserInfo clientUserInfo = new UserInfo();
            clientUserInfo.USER_ID = "System";
            clientUserInfo.USER_NAME = "System";
            return clientUserInfo;
        }
        private PatientInfo GetPatientInfo(string patientId, string visitId)
        {
            EMRDBLib.PatVisitInfo patVisitInfo = null;
            PatVisitAccess.Instance.GetPatVisitInfo(patientId, visitId, ref patVisitInfo);
            if (patVisitInfo == null)
                return null;

            PatientInfo patInfo = new PatientInfo();
            patInfo.ID = patientId;
            patInfo.Name = patVisitInfo.PATIENT_NAME;
            patInfo.Gender = patVisitInfo.PATIENT_SEX;
            patInfo.BirthTime = patVisitInfo.BIRTH_TIME;
            return patInfo;
        }
        private VisitInfo GetVisitInfo(string patientId, string visitId)
        {
            EMRDBLib.PatVisitInfo patVisitInfo = null;
            PatVisitAccess.Instance.GetPatVisitInfo(patientId, visitId, ref patVisitInfo);
            if (patVisitInfo == null)
                return null;
            VisitInfo clientVisitInfo = new VisitInfo();
            clientVisitInfo.ID = visitId;
            clientVisitInfo.InpID = patVisitInfo.INP_NO;
            clientVisitInfo.Time = patVisitInfo.VISIT_TIME;
            clientVisitInfo.WardCode = patVisitInfo.WARD_CODE;
            clientVisitInfo.WardName = patVisitInfo.WardName;
            clientVisitInfo.BedCode = patVisitInfo.BED_CODE;
            clientVisitInfo.Type = VisitType.IP;
            return clientVisitInfo;
        }

    }
}
