/********************************************************
 * @FileName   : PatOutHospitalListForm.cs
 * @Description: 病案管理系统之病案归档
 * @Author     : 叶慧(Yehui)
 * @Date       : 2017-04-17 11:06:51
 * @History    : 
 * @Copyright  : 版权所有(C)浙江和仁科技股份有限公司
********************************************************/
using Heren.Common.Libraries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Heren.Common.DockSuite;
using MedQCSys.Utility;
using EMRDBLib;
using EMRDBLib.DbAccess;
using Heren.Common.Controls.TableView;
using Heren.MedQC.Utilities;
using MedQCSys.DockForms;
using MedQCSys;
using System.Collections;
using MedQCSys.PatPage;
using Heren.MedQC.Core;
using System.IO;
using Heren.Common.Controls.VirtualTreeView;
namespace Heren.MedQC.MedRecord
{
    public partial class RecMrBatchSendForm : DockContentBase
    {
        public RecMrBatchSendForm(MainForm parent)
            : base(parent)
        {
            this.InitializeComponent();
            this.HideOnClose = false;
            this.ShowHint = DockState.Document;
            this.DockAreas = DockAreas.Document;
            this.CloseButtonVisible = true;
        }
        private List<PatVisitInfo> m_lstPatVisit = null;
        private int m_paperCount = 0;
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.virtualTree1.Columns.Add(new VirtualColumn("病历记录时间", 160));
            this.virtualTree1.Columns.Add(new VirtualColumn("病历标题", 250));
            this.virtualTree1.Columns.Add(new VirtualColumn("翻拍正面", 80));
            this.virtualTree1.Columns.Add(new VirtualColumn("翻拍反面", 80));
        }
        public override void OnRefreshView()
        {
            base.OnRefreshView();
            this.Update();

            this.ShowStatusMessage("正在下载，请稍候...");
            if (this.m_lstPatVisit != null)
                this.m_lstPatVisit.Clear();
            this.virtualTree1.Nodes.Clear();
            this.m_paperCount = 0;
            this.txtDocID.Text = string.Empty;
            this.txt_BATCH_NO.Text = string.Empty;
            this.txt_WORKER_ID.Text = string.Empty;
            this.txt_WORKER_NAME.Text = string.Empty;
            this.virtualTree1.Font = new Font("宋体", 10.5f);
            this.ShowStatusMessage(null);
        }


        private void metroTextBox1_TextChanged(object sender, EventArgs e)
        {
            string szDocID = this.txtDocID.Text.Trim();
            MedDocInfo docInfo = null;
            short shRet = EmrDocAccess.Instance.GetDocInfo(szDocID, ref docInfo);
            PatVisitInfo patVisit = null;
            if (docInfo == null)
            {
                string szPatientID = this.txtDocID.Text.Trim();
                List<PatVisitInfo> lstPatVisitInfo = null;
                PatVisitAccess.Instance.GetPatVisitInfos(szPatientID, ref lstPatVisitInfo);
                if (lstPatVisitInfo == null)
                    return;
                patVisit = lstPatVisitInfo.LastOrDefault();
            }
            else
            {
                string szPatientID = docInfo.PATIENT_ID;
                string szVisitNo = docInfo.VISIT_ID;//文书VisitID存了 VisitNo
                shRet = PatVisitAccess.Instance.GetPatVisit(szPatientID, szVisitNo, ref patVisit);
            }
            if (patVisit == null)
                return;
            if (m_lstPatVisit == null)
                m_lstPatVisit = new List<PatVisitInfo>();
            if (m_lstPatVisit.Exists(m => m.PATIENT_ID == patVisit.PATIENT_ID && m.VISIT_NO == patVisit.VISIT_NO))
                return;
            List<MedDocInfo> lstMedDocInfos = null;
            shRet = EmrDocAccess.Instance.GetDocList(patVisit.PATIENT_ID, patVisit.VISIT_NO, ref lstMedDocInfos);
            if (lstMedDocInfos == null)
                return;
            List<RecPaper> lstRecPapers = new List<RecPaper>();
            shRet = RecPaperAccess.Instance.GetRecPapers(patVisit.PATIENT_ID, patVisit.VISIT_NO, ref lstRecPapers);
            string[] arrSignKeyName = DataCache.Instance.DicHdpParameter[SystemData.ConfigKey.SignKeyName].Split('|');
            var result = lstMedDocInfos.Where(m => StringHelper.ArrayContains(m.DOC_TITLE, arrSignKeyName)).ToList();
            if (result != null && result.Count > 0)
            {
                VirtualNode node = new VirtualNode();
                string szNodeText = string.Format("应{0}张 患者号:{1} 姓名:{2} ", result.Count, patVisit.PATIENT_ID, patVisit.PATIENT_NAME);
                if (patVisit.DISCHARGE_TIME != patVisit.DefaultTime)
                {
                    szNodeText += "出院时间:" + patVisit.DISCHARGE_TIME.ToString("yyyy-MM-dd HH:mm");
                }
                node.Text = szNodeText;
                node.CheckBox = true;
                node.Expand();
                node.ImageIndex = 0;
                this.virtualTree1.Nodes.Add(node);
                foreach (var doc in result)
                {
                    string szRecordTime = doc.RECORD_TIME.ToString("yyyy-MM-dd HH:mm");
                    VirtualNode childNode = new VirtualNode(szRecordTime);
                    childNode.SubItems.Add(new VirtualSubItem());
                    childNode.SubItems.Add(new VirtualSubItem());
                    childNode.SubItems.Add(new VirtualSubItem());
                    childNode.SubItems[0].Text = doc.DOC_TITLE;
                    var recPaper = lstRecPapers.Where(m => m.DOC_ID == doc.DOC_ID).FirstOrDefault();
                    if (recPaper != null)
                    {
                        if (!string.IsNullOrEmpty(recPaper.IMAGE_FRONTAGE))
                        {
                            childNode.SubItems[1].ImageIndex = 1;
                            childNode.SubItems[1].Tag = recPaper.IMAGE_FRONTAGE;
                        }
                        if (!string.IsNullOrEmpty(recPaper.IMAGE_OPPOSITE))
                        {
                            childNode.SubItems[2].ImageIndex = 1;
                            childNode.SubItems[2].Tag = recPaper.IMAGE_OPPOSITE;
                        }
                        childNode.Tag = recPaper;
                    }
                    this.m_paperCount++;
                    node.Nodes.Add(childNode);
                }
                if (m_lstPatVisit == null)
                    m_lstPatVisit = new List<PatVisitInfo>();
                m_lstPatVisit.Add(patVisit);
            }
        }
        private string GetRecPaperRemoteDir(RecPaper recPaperInfo)
        {
            //链接病人根目录
            StringBuilder ftpPath = new StringBuilder();
            ftpPath.Append("/RECPAPER");

            if (recPaperInfo == null || recPaperInfo.PATIENT_ID == null)
                return ftpPath.ToString();

            string szPatientID = recPaperInfo.PATIENT_ID.PadLeft(10, '0');
            for (int index = 0; index < 10; index += 2)
            {
                ftpPath.Append("/");
                ftpPath.Append(szPatientID.Substring(index, 2));
            }

            //链接就诊目录
            ftpPath.Append("/");
            ftpPath.Append("IP_");
            ftpPath.Append(recPaperInfo.VISIT_ID);
            ftpPath.Append("/");
            return ftpPath.ToString();
        }
        private void btnReceive_Click(object sender, EventArgs e)
        {

        }

        private void virtualTree1_NodeMouseClick(object sender, VirtualTreeEventArgs e)
        {

            if (e.SubItem == null)
            {
                VirtualNode[] selectNodes = this.virtualTree1.GetCheckedNodes(null);
                this.lbl_PatientCount.Text = selectNodes.Count().ToString();
                return;
            }
            if (e.SubItem.Index == 1 || e.SubItem.Index == 2)
            {
                string szImageName = e.SubItem.Tag as string;
                RecPaper recPaper = e.Node.Tag as RecPaper;
                if (string.IsNullOrEmpty(szImageName))
                    return;
                string szPath = szImageName;

                GlobalMethods.UI.SetCursor(this.virtualTree1, Cursors.WaitCursor);
                szPath = RecPaperAccess.Instance.GetImageLocalFile(szImageName);
                if (!File.Exists(szPath))
                {
                    short shRet = RecPaperAccess.Instance.GetImageFromFtp(recPaper, szImageName, ref szPath);
                    if (shRet != SystemData.ReturnValue.OK)
                    {
                        MessageBoxEx.Show("预览图片失败");
                        return;
                    }
                }
                GlobalMethods.UI.SetCursor(this.virtualTree1, Cursors.Default);
                Heren.MedQC.Utilities.Dialogs.ImageViewerDialog diglog = new Utilities.Dialogs.ImageViewerDialog();
                diglog.ImagePath = szPath;
                diglog.ShowDialog();
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (this.txt_BATCH_NO.Text.Trim() != string.Empty)
            {
                MessageBoxEx.ShowMessage("批次号已经生成，请刷新页面后重试");
                return;
            }
            if (this.txt_WORKER_ID.Text.Trim() == string.Empty || this.txt_WORKER_NAME.Text.Trim() == string.Empty)
            {
                MessageBoxEx.ShowMessage("请输入工人信息");
                return;
            }
            RecMrBatch recMrBatch = new RecMrBatch();
            recMrBatch.BATCH_NO = recMrBatch.MakeBatchNo(SystemParam.Instance.UserInfo.DEPT_CODE);
            recMrBatch.INP_NOS = string.Join("|", m_lstPatVisit.Select(m => m.INP_NO).ToArray());
            recMrBatch.MR_COUNT = this.m_lstPatVisit.Count;
            recMrBatch.PAPER_COUNT = this.m_paperCount++;
            recMrBatch.SEND_DEPT_CODE = SystemParam.Instance.UserInfo.DEPT_CODE;
            recMrBatch.SEND_DEPT_NAME = SystemParam.Instance.UserInfo.DEPT_NAME;
            recMrBatch.SEND_DOCTOR_ID = SystemParam.Instance.UserInfo.USER_ID;
            recMrBatch.SEND_DOCTOR_NAME = SystemParam.Instance.UserInfo.USER_NAME;
            recMrBatch.SEND_TIME = SysTimeHelper.Instance.Now;
            recMrBatch.VISIT_NOS = string.Join("|", m_lstPatVisit.Select(m => m.VISIT_NO).ToArray());
            recMrBatch.WORKER_ID = this.txt_WORKER_ID.Text;
            recMrBatch.WORKER_NAME = this.txt_WORKER_NAME.Text;
            short shRet = RecMrBatchAccess.Instance.Insert(recMrBatch);
            if (shRet != SystemData.ReturnValue.OK)
            {
                MessageBoxEx.ShowError("无法正常发送");
                return;
            }
            MessageBoxEx.ShowMessage("发送成功");
            this.txt_BATCH_NO.Text = recMrBatch.BATCH_NO;
        }
    }
}
