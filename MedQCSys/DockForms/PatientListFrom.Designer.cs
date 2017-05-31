using EMRDBLib;
namespace MedQCSys.DockForms
{
    partial class PatientListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PatientListForm));
            this.cmenuPatientList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuHistoryVisit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPreviousView = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDocumentList = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPatientInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOrderList = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExamList = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTestList = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDiagnosisList = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVitalSignsGraph = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPatientIndex = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDocumentTime = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQuestionList = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDocScore = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuIEDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRollBackDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.patSearchPane1 = new MedQCSys.Controls.PatSearchPane();
            this.patInfoList = new MedQCSys.Controls.PatInfoList.PatInfoList();
            this.cmenuPatientList.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmenuPatientList
            // 
            this.cmenuPatientList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHistoryVisit,
            this.mnuPreviousView,
            this.toolStripSeparator1,
            this.mnuDocumentList,
            this.mnuPatientInfo,
            this.mnuOrderList,
            this.mnuExamList,
            this.mnuTestList,
            this.mnuDiagnosisList,
            this.mnuVitalSignsGraph,
            this.mnuPatientIndex,
            this.toolStripSeparator2,
            this.mnuDocumentTime,
            this.mnuQuestionList,
            this.mnuDocScore,
            this.toolStripSeparator3,
            this.mnuIEDoc,
            this.mnuRollBackDoc});
            this.cmenuPatientList.Name = "cmenuPatientList";
            this.cmenuPatientList.Size = new System.Drawing.Size(161, 352);
            this.cmenuPatientList.Opening += new System.ComponentModel.CancelEventHandler(this.cmenuPatientList_Opening);
            // 
            // mnuHistoryVisit
            // 
            this.mnuHistoryVisit.Name = "mnuHistoryVisit";
            this.mnuHistoryVisit.Size = new System.Drawing.Size(160, 22);
            this.mnuHistoryVisit.Text = "历次就诊";
            this.mnuHistoryVisit.Click += new System.EventHandler(this.mnuHistoryVisit_Click);
            // 
            // mnuPreviousView
            // 
            this.mnuPreviousView.Name = "mnuPreviousView";
            this.mnuPreviousView.Size = new System.Drawing.Size(160, 22);
            this.mnuPreviousView.Text = "前一视图";
            this.mnuPreviousView.Click += new System.EventHandler(this.mnuPreviousView_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(157, 6);
            // 
            // mnuDocumentList
            // 
            this.mnuDocumentList.Name = "mnuDocumentList";
            this.mnuDocumentList.Size = new System.Drawing.Size(160, 22);
            this.mnuDocumentList.Text = "病历文书";
            this.mnuDocumentList.Click += new System.EventHandler(this.mnuDocumentList_Click);
            // 
            // mnuPatientInfo
            // 
            this.mnuPatientInfo.Name = "mnuPatientInfo";
            this.mnuPatientInfo.Size = new System.Drawing.Size(160, 22);
            this.mnuPatientInfo.Text = "患者信息";
            this.mnuPatientInfo.Click += new System.EventHandler(this.mnuPatientInfo_Click);
            // 
            // mnuOrderList
            // 
            this.mnuOrderList.Name = "mnuOrderList";
            this.mnuOrderList.Size = new System.Drawing.Size(160, 22);
            this.mnuOrderList.Text = "医嘱内容";
            this.mnuOrderList.Click += new System.EventHandler(this.mnuOrderList_Click);
            // 
            // mnuExamList
            // 
            this.mnuExamList.Name = "mnuExamList";
            this.mnuExamList.Size = new System.Drawing.Size(160, 22);
            this.mnuExamList.Text = "检查记录";
            this.mnuExamList.Click += new System.EventHandler(this.mnuExamList_Click);
            // 
            // mnuTestList
            // 
            this.mnuTestList.Name = "mnuTestList";
            this.mnuTestList.Size = new System.Drawing.Size(160, 22);
            this.mnuTestList.Text = "检验记录";
            this.mnuTestList.Click += new System.EventHandler(this.mnuTestList_Click);
            // 
            // mnuDiagnosisList
            // 
            this.mnuDiagnosisList.Name = "mnuDiagnosisList";
            this.mnuDiagnosisList.Size = new System.Drawing.Size(160, 22);
            this.mnuDiagnosisList.Text = "诊断记录";
            this.mnuDiagnosisList.Click += new System.EventHandler(this.mnuDiagnosisList_Click);
            // 
            // mnuVitalSignsGraph
            // 
            this.mnuVitalSignsGraph.Name = "mnuVitalSignsGraph";
            this.mnuVitalSignsGraph.Size = new System.Drawing.Size(160, 22);
            this.mnuVitalSignsGraph.Text = "体温单";
            this.mnuVitalSignsGraph.Click += new System.EventHandler(this.mnuVitalSignsGraph_Click);
            // 
            // mnuPatientIndex
            // 
            this.mnuPatientIndex.Name = "mnuPatientIndex";
            this.mnuPatientIndex.Size = new System.Drawing.Size(160, 22);
            this.mnuPatientIndex.Text = "病案首页";
            this.mnuPatientIndex.Click += new System.EventHandler(this.mnuPatientIndex_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(157, 6);
            // 
            // mnuDocumentTime
            // 
            this.mnuDocumentTime.Name = "mnuDocumentTime";
            this.mnuDocumentTime.Size = new System.Drawing.Size(160, 22);
            this.mnuDocumentTime.Text = "病历时效";
            this.mnuDocumentTime.Click += new System.EventHandler(this.mnuDocumentTime_Click);
            // 
            // mnuQuestionList
            // 
            this.mnuQuestionList.Name = "mnuQuestionList";
            this.mnuQuestionList.Size = new System.Drawing.Size(160, 22);
            this.mnuQuestionList.Text = "质检问题";
            this.mnuQuestionList.Click += new System.EventHandler(this.mnuQuestionList_Click);
            // 
            // mnuDocScore
            // 
            this.mnuDocScore.Name = "mnuDocScore";
            this.mnuDocScore.Size = new System.Drawing.Size(160, 22);
            this.mnuDocScore.Text = "病案评分";
            this.mnuDocScore.Click += new System.EventHandler(this.mnuDocScore_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(157, 6);
            // 
            // mnuIEDoc
            // 
            this.mnuIEDoc.Name = "mnuIEDoc";
            this.mnuIEDoc.Size = new System.Drawing.Size(160, 22);
            // 
            // mnuRollBackDoc
            // 
            this.mnuRollBackDoc.Name = "mnuRollBackDoc";
            this.mnuRollBackDoc.Size = new System.Drawing.Size(160, 22);
            this.mnuRollBackDoc.Text = "回退已提交病历";
            this.mnuRollBackDoc.Click += new System.EventHandler(this.mnuRollBackDoc_Click);
            // 
            // patSearchPane1
            // 
            this.patSearchPane1.Cursor = System.Windows.Forms.Cursors.Default;
            this.patSearchPane1.Dock = System.Windows.Forms.DockStyle.Top;
            this.patSearchPane1.LastInHospDays = 0;
            this.patSearchPane1.LastInHospDept = "";
            this.patSearchPane1.LastInHospPatientType = EMRDBLib.PatientType.PatInHosptial;
            this.patSearchPane1.LastInpNo = "";
            this.patSearchPane1.LastOperation = null;
            this.patSearchPane1.LastOperatorType = EMRDBLib.OperatorType.UnKnown;
            this.patSearchPane1.LastOperDept = "";
            this.patSearchPane1.LastPatientID = "";
            this.patSearchPane1.LastPatientName = "";
            this.patSearchPane1.Location = new System.Drawing.Point(2, 2);
            this.patSearchPane1.Margin = new System.Windows.Forms.Padding(4);
            this.patSearchPane1.Name = "patSearchPane1";
            this.patSearchPane1.OperBeginTime = new System.DateTime(2015, 2, 13, 11, 9, 28, 23);
            this.patSearchPane1.OperEndTime = new System.DateTime(2015, 4, 13, 11, 9, 28, 23);
            this.patSearchPane1.OperPatientType = EMRDBLib.PatientType.PatInHosptial;
            this.patSearchPane1.SearchType = EMRDBLib.PatSearchType.Department;
            this.patSearchPane1.Size = new System.Drawing.Size(288, 169);
            this.patSearchPane1.TabIndex = 3;
            this.patSearchPane1.StartSearch += new System.EventHandler(this.patSearchPane1_StartSearch);
            this.patSearchPane1.StatusMessageChanged += new MedQCSys.Controls.PatSearchPane.ShowStatusMessageHandler(this.patSearchPane1_StatusMessageChanged);
            // 
            // patInfoList
            // 
            this.patInfoList.AutoScroll = true;
            this.patInfoList.BackColor = System.Drawing.Color.White;
            this.patInfoList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.patInfoList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.patInfoList.Location = new System.Drawing.Point(2, 171);
            this.patInfoList.Margin = new System.Windows.Forms.Padding(2);
            this.patInfoList.Name = "patInfoList";
            this.patInfoList.Padding = new System.Windows.Forms.Padding(1);
            this.patInfoList.SelectedCard = null;
            this.patInfoList.Size = new System.Drawing.Size(288, 385);
            this.patInfoList.TabIndex = 2;
            this.patInfoList.CardSelectedChanged += new System.EventHandler(this.patInfoList_CardSelectedChanged);
            this.patInfoList.CardSelectedChanging += new System.ComponentModel.CancelEventHandler(this.patInfoList_CardSelectedChanging);
            this.patInfoList.CardMouseClick += new System.Windows.Forms.MouseEventHandler(this.patInfoList_CardMouseClick);
            this.patInfoList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.patInfoList_MouseUp);
            // 
            // PatientListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 558);
            this.Controls.Add(this.patInfoList);
            this.Controls.Add(this.patSearchPane1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PatientListForm";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Text = "患者列表";
            this.cmenuPatientList.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        #endregion

        private MedQCSys.Controls.PatInfoList.PatInfoList patInfoList;
        private System.Windows.Forms.ContextMenuStrip cmenuPatientList;
        private System.Windows.Forms.ToolStripMenuItem mnuHistoryVisit;
        private MedQCSys.Controls.PatSearchPane patSearchPane1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuDocumentList;
        private System.Windows.Forms.ToolStripMenuItem mnuOrderList;
        private System.Windows.Forms.ToolStripMenuItem mnuExamList;
        private System.Windows.Forms.ToolStripMenuItem mnuTestList;
        private System.Windows.Forms.ToolStripMenuItem mnuPatientInfo;
        private System.Windows.Forms.ToolStripMenuItem mnuPatientIndex;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuDocumentTime;
        private System.Windows.Forms.ToolStripMenuItem mnuQuestionList;
        private System.Windows.Forms.ToolStripMenuItem mnuPreviousView;
        private System.Windows.Forms.ToolStripMenuItem mnuDiagnosisList;
        private System.Windows.Forms.ToolStripMenuItem mnuDocScore;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mnuRollBackDoc;
        private System.Windows.Forms.ToolStripMenuItem mnuVitalSignsGraph;
        private System.Windows.Forms.ToolStripMenuItem mnuIEDoc;
    }
}