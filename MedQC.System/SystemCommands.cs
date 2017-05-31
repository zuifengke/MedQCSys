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
using MedQCSys.DockForms;
using MedQCSys;
using System.IO;
using System.Diagnostics;

namespace Heren.MedQC.Systems
{
    /// <summary>
    /// 显示角色管理界面
    /// </summary>
    public class ShowSystemCommand1 : AbstractCommand
    {
        public ShowSystemCommand1()
        {
            this.m_name = "患者列表";
        }
        public override bool Execute(object param, object data)
        {
            MainForm form = param as MainForm;
            if (form == null)
                return false;
            foreach (DockContentBase item in form.DockPanel.Contents)
            {
                if (item is PatientListForm)
                {
                    item.Activate();
                    item.OnRefreshView();
                    return true;
                }
            }
            PatientListForm role = new PatientListForm(form);
            role.Show(form.DockPanel, DockState.Document);
            role.Activate();
            role.OnRefreshView();
            return true;
        }
    }
    /// <summary>
    /// 显示角色管理界面
    /// </summary>
    public class ShowSystemCommand2 : AbstractCommand
    {
        public ShowSystemCommand2()
        {
            this.m_name = "模板审核";
        }
        public override bool Execute(object param, object data)
        {
            string szTempletSysFile = string.Format("{0}\\meddoc\\MedTemplet.exe", GlobalMethods.Misc.GetWorkingPath());
            if (!File.Exists(szTempletSysFile))
            {
                LogManager.Instance.WriteLog("MedDocCtrl.StartMedTempletSystem", new string[] { "szTempletSysFile" }
                    , new object[] { szTempletSysFile }, string.Empty);
                MessageBoxEx.Show("您没有安装病历模板管理系统!");
                return false;
            }
            if (SystemParam.Instance.UserInfo == null)
            {
                MessageBoxEx.Show("您还没有登录系统,请先登录!");
                return false;
            }
            if (!SystemParam.Instance.UserRight.TempletSystem.Value)
            {
                MessageBoxEx.Show("您没有权限使用病历模板系统!");
                return false;
            }
            SystemParam.Instance.UserInfo = new UserInfo();
            SystemParam.Instance.UserInfo.DeptCode = SystemParam.Instance.UserInfo.DeptCode;
             SystemParam.Instance.UserInfo.DeptName = SystemParam.Instance.UserInfo.DeptName;
             SystemParam.Instance.UserInfo.ID = SystemParam.Instance.UserInfo.ID;
             SystemParam.Instance.UserInfo.Name = SystemParam.Instance.UserInfo.Name;
             SystemParam.Instance.UserInfo.Password = SystemParam.Instance.UserInfo.Password;

             SystemParam.Instance.UserInfo.Role = UserRole.InDoctor;

            string szUserInfo = UserInfo.GetStrFromUserInfo( SystemParam.Instance.UserInfo,  SystemData.StartupArgs.FIELD_SPLIT);
            szUserInfo = szUserInfo.Replace( SystemData.StartupArgs.ESCAPED_CHAR,  SystemData.StartupArgs.ESCAPE_CHAR);
            try
            {
                Process.Start(szTempletSysFile, szUserInfo);
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show("无法启动病历模板管理系统!");
                LogManager.Instance.WriteLog("MedDocCtrl.StartMedTempletSystem", new string[] { "szTempletSysFile", "szUserInfo" }
                    , new string[] { szTempletSysFile, szUserInfo }, ex);
            }
            return true;
        }
    }
    /// <summary>
    /// 显示角色管理界面
    /// </summary>
    public class ShowSystemCommand3 : AbstractCommand
    {
        public ShowSystemCommand3()
        {
            this.m_name = "质检问题";
        }
        public override bool Execute(object param, object data)
        {
           
            MainForm form = param as MainForm;
            if (form == null)
                return false;
            foreach (DockContentBase item in form.DockPanel.Contents)
            {
                if (item is QuestionListForm)
                {
                    item.Activate();
                    item.OnRefreshView();
                    return true;
                }
            }
            QuestionListForm role = new QuestionListForm(form);
            role.Show(form.DockPanel, DockState.DockBottom);
            role.Activate();
            role.OnRefreshView();
            return true;
        }
    }
    public class ShowSystemCommand4 : AbstractCommand
    {
        public ShowSystemCommand4()
        {
            this.m_name = "质控追踪";
        }
        public override bool Execute(object param, object data)
        {
         
            MainForm form = param as MainForm;
            if (form == null)
                return false;
            foreach (DockContentBase item in form.DockPanel.Contents)
            {
                if (item is QcTrackForm)
                {
                    item.Activate();
                    item.OnRefreshView();
                    return true;
                }
            }
            QcTrackForm role = new QcTrackForm(form);
            role.Show(form.DockPanel, DockState.Document);
            role.Activate();
            return true;
        }
    }
    public class ShowSystemCommand5 : AbstractCommand
    {
        public ShowSystemCommand5()
        {
            this.m_name = "病案召回";
        }
        public override bool Execute(object param, object data)
        {
            MedCallBackForm form = new MedCallBackForm();
            form.ShowDialog();
            return true;
        }
    }
    public class ShowSystemCommand6 : AbstractCommand
    {
        public ShowSystemCommand6()
        {
            this.m_name = "专家质控";
        }
        public override bool Execute(object param, object data)
        {
            MainForm form = param as MainForm;
            if (form == null)
                return false;
            foreach (DockContentBase item in form.DockPanel.Contents)
            {
                if (item is SepcialCheckConfigForm)
                {
                    item.Activate();
                    item.OnRefreshView();
                    return true;
                }
            }
            SepcialCheckConfigForm role = new SepcialCheckConfigForm(form);
            role.Show(form.DockPanel, DockState.Document);
            role.Activate();
            return true;
        }
    }
    public class ShowSystemCommand7 : AbstractCommand
    {
        public ShowSystemCommand7()
        {
            this.m_name = "待审核模板";
        }
        public override bool Execute(object param, object data)
        {
            MainForm form = param as MainForm;
            if (form == null)
                return false;
            foreach (DockContentBase item in form.DockPanel.Contents)
            {
                if (item is TempletStatForm)
                {
                    item.Activate();
                    item.OnRefreshView();
                    return true;
                }
            }
            TempletStatForm role = new TempletStatForm(form);
            role.Show(form.DockPanel, DockState.Document);
            role.Activate();
            return true;
        }
    }
}
