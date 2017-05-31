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

namespace Heren.MedQC.Maintenance
{
    /// <summary>
    /// 显示角色管理界面
    /// </summary>
    public class ShowMaintenanceCommand1 : AbstractCommand
    {
        public ShowMaintenanceCommand1()
        {
            this.m_name = "修改口令";
        }
        public override bool Execute(object param, object data)
        {
            if (SystemParam.Instance.UserInfo == null)
            {
                MessageBoxEx.Show("您还没有登录系统,无法修改口令!");
            }
            else
            {
                ModifyPwdForm frmModifyPwd = new ModifyPwdForm();
                frmModifyPwd.ShowDialog();
            }
            return true;
        }
    }
    /// <summary>
    /// 显示角色管理界面
    /// </summary>
    public class ShowMaintenanceCommand2 : AbstractCommand
    {
        public ShowMaintenanceCommand2()
        {
            this.m_name = "修改质检问题字典";
        }
        public override bool Execute(object param, object data)
        {
            MainForm main = param as MainForm;
            if (main == null)
                return false;
            MainForm form = param as MainForm;
            if (form == null)
                return false;
            foreach (DockContentBase item in form.DockPanel.Contents)
            {
                if (item is QCMsgTempletForm)
                {
                    item.Activate();
                    item.OnRefreshView();
                    return true;
                }
            }
            QCMsgTempletForm role = new QCMsgTempletForm(form);
            role.Show(form.DockPanel, DockState.Document);
            role.Activate();
            return true;
        }
    }
    /// <summary>
    /// 显示角色管理界面
    /// </summary>
    public class ShowMaintenanceCommand3 : AbstractCommand
    {
        public ShowMaintenanceCommand3()
        {
            this.m_name = "修改问题分类字典";
        }
        public override bool Execute(object param, object data)
        {
            MainForm main = param as MainForm;
            if (main == null)
                return false;
            MainForm form = param as MainForm;
            if (form == null)
                return false;
            foreach (DockContentBase item in form.DockPanel.Contents)
            {
                if (item is QCEventTypesForm)
                {
                    item.Activate();
                    item.OnRefreshView();
                    return true;
                }
            }
            QCEventTypesForm role = new QCEventTypesForm(form);
            role.Show(form.DockPanel, DockState.Document);
            role.Activate();
            return true;
        }
    }
    public class ShowMaintenanceCommand4 : AbstractCommand
    {
        public ShowMaintenanceCommand4()
        {
            this.m_name = "时效规则配置";
        }
        public override bool Execute(object param, object data)
        {
            MainForm main = param as MainForm;
            if (main == null)
                return false;
            MainForm form = param as MainForm;
            if (form == null)
                return false;
            foreach (DockContentBase item in form.DockPanel.Contents)
            {
                if (item is TimeRuleEditForm)
                {
                    item.Activate();
                    item.OnRefreshView();
                    return true;
                }
            }
            TimeRuleEditForm role = new TimeRuleEditForm(form);
            role.Show(form.DockPanel, DockState.Document);
            role.Activate();
            return true;
        }
    }
    public class ShowMaintenanceCommand5 : AbstractCommand
    {
        public ShowMaintenanceCommand5()
        {
            this.m_name = "时效事件配置";
        }
        public override bool Execute(object param, object data)
        {
            MainForm form = param as MainForm;
            if (form == null)
                return false;
            foreach (DockContentBase item in form.DockPanel.Contents)
            {
                if (item is TimeEventEditForm)
                {
                    item.Activate();
                    item.OnRefreshView();
                    return true;
                }
            }
            TimeEventEditForm role = new TimeEventEditForm(form);
            role.Show(form.DockPanel, DockState.Document);
            role.Activate();
            return true;
        }
    }
    public class ShowMaintenanceCommand6 : AbstractCommand
    {
        public ShowMaintenanceCommand6()
        {
            this.m_name = "缺陷规则配置";
        }
        public override bool Execute(object param, object data)
        {
            MainForm form = param as MainForm;
            if (form == null)
                return false;
            foreach (DockContentBase item in form.DockPanel.Contents)
            {
                if (item is QcCheckPointForm)
                {
                    item.Activate();
                    item.OnRefreshView();
                    return true;
                }
            }
            QcCheckPointForm role = new QcCheckPointForm(form);
            role.Show(form.DockPanel, DockState.Document);
            role.Activate();
            return true;
        }
    }
    public class ShowMaintenanceCommand7 : AbstractCommand
    {
        public ShowMaintenanceCommand7()
        {
            this.m_name = "ICD10标准诊断库";
        }
        public override bool Execute(object param, object data)
        {
            MainForm form = param as MainForm;
            if (form == null)
                return false;
            foreach (DockContentBase item in form.DockPanel.Contents)
            {
                if (item is StandardTermForm)
                {
                    item.Activate();
                    item.OnRefreshView();
                    return true;
                }
            }
            StandardTermForm role = new StandardTermForm(form);
            role.Show(form.DockPanel, DockState.Document);
            role.Activate();
            return true;
        }
    }
}
