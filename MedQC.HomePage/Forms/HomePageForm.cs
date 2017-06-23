// ***********************************************************
// 病案质控系统质控问题类型维护窗口.
// Creator:YangMingkun  Date:2009-11-13
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Heren.Common.Libraries;
using Heren.Common.Controls;
using Heren.Common.Controls.TableView;
using Heren.Common.DockSuite;
using MedQCSys.DockForms;
using EMRDBLib;
using EMRDBLib.DbAccess;
using MedQCSys;
using System.Windows.Forms.DataVisualization.Charting;

namespace Heren.MedQC.HomePage
{
    public partial class HomePageForm : DockContentBase
    {
        public HomePageForm(MainForm form):base(form)
        {
            this.InitializeComponent();
            this.ShowHint = DockState.Document;
            this.DockAreas = DockAreas.Document;
          
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.Update();
            this.OnRefreshView();
            Random rand = new Random();
            for (int index = 1; index < 100; index++)
            {
                chart1.Series["Series1"].Points.AddY(rand.Next(1, 1000));
            }
            double yValue = 50.0;
            Random random = new Random();
            for (int pointIndex = 0; pointIndex < 20000; pointIndex++)
            {
                yValue = yValue + (random.NextDouble() * 10.0 - 5.0);
                chart2.Series["Series1"].Points.AddY(yValue);
            }

            // Set fast line chart type
            chart2.Series["Series1"].ChartType = SeriesChartType.FastLine;
            this.demoCard1.RefreshCard();
        }

    }
}