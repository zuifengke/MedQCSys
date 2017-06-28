using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Heren.MedQC.Core;
using Heren.Common.DockSuite;
using MedQCSys.Dialogs;
using Heren.Common.Libraries;
using System.Windows.Forms;
using EMRDBLib;
using MedQCSys.MenuBars;

namespace MedQCSys
{
    /// <summary>
    /// 显示角色管理界面
    /// </summary>
    public class ShowHomePageCommand : AbstractCommand
    {
        public ShowHomePageCommand()
        {
            this.m_name = "关于";
        }
        public override bool Execute(object param, object data)
        {
            (new SystemAboutForm()).ShowDialog();
            return true;
        }
    }
    /// <summary>
    /// 显示角色管理界面
    /// </summary>
    public class ShowHomePageCommand2 : AbstractCommand
    {
        public ShowHomePageCommand2()
        {
            this.m_name = "帮助";
        }
        public override bool Execute(object param, object data)
        {
            MainForm main = param as MainForm;
            if (main == null)
                return false;
            //打开用户手册(Word文档)
            string szHelpFile = string.Format("{0}\\mrqc.doc", Application.StartupPath);
            try
            {
                if (System.IO.File.Exists(szHelpFile))
                    System.Diagnostics.Process.Start(szHelpFile);
                else
                    MessageBoxEx.Show("未找到用户手册文件!");
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("MainForm.ShowSysHelpForm", ex);
                MessageBoxEx.Show("无法打开用户手册文件!", ex.Message);
            }
            return true;
        }
    }
    /// <summary>
    /// 快捷入口
    /// </summary>
    public class ShowHomePageCommand3 : AbstractCommand
    {
        public ShowHomePageCommand3()
        {
            this.m_name = "快捷入口";
        }
        public override bool Execute(object param, object data)
        {
            try
            {
                MainForm main = param as MainForm;
                if (main == null)
                    return false;

                PatVisitInfo patVisitInfo = new PatVisitInfo();
                patVisitInfo.PATIENT_ID = "P101210";
                patVisitInfo.VISIT_ID = "2";
                main.SwitchPatient(patVisitInfo);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog(ex.ToString());
            }
            
            return true;
        }
    }
    /// <summary>
    /// 显示或隐藏工具栏
    /// </summary>
    public class ShowToolStripCommand3 : AbstractCommand
    {
        public ShowToolStripCommand3()
        {
            this.m_name = "隐藏/显示工具栏";
        }
        public override bool Execute(object param, object data)
        {
            try
            {
                MainForm main = param as MainForm;
                if (main == null)
                    return false;
                MqsMenuItemBase toolbtn = data as MqsMenuItemBase;
                toolbtn.Checked = !toolbtn.Checked;
                main.ShowToolStrip(toolbtn.Checked);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog(ex.ToString());
            }

            return true;
        }
    }
}
