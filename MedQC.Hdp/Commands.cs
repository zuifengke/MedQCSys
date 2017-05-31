using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Heren.MedQC.Core;
using MedQCSys;
using Heren.Common.DockSuite;
using Heren.MedQC.Hdp;

namespace Heren.MedQC.Hdp
{
    /// <summary>
    /// 显示角色管理界面
    /// </summary>
    public class ShowRoleManageCommand : AbstractCommand
    {
        public ShowRoleManageCommand()
        {
            this.m_name = "角色管理";
        }
        public override bool Execute(object param, object data)
        {
            MainForm form = param as MainForm;
            if (form == null)
                return false;
            foreach (DockContent item in form.DockPanel.Contents)
            {
                if (item is RoleManageForm)
                {
                    item.Activate();
                    return true;
                }
            }
            RoleManageForm role = new RoleManageForm(form);
            role.Show(form.DockPanel, DockState.Document);
            role.Activate();
            return true;
        }
    }
    /// <summary>
    /// 显示用户管理界面
    /// </summary>
    public class ShowUserManageCommand : AbstractCommand
    {
        public ShowUserManageCommand()
        {
            this.m_name = "用户管理";
        }
        public override bool Execute(object param, object data)
        {
            MainForm form = param as MainForm;
            if (form == null)
                return false;
            foreach (DockContent item in form.DockPanel.Contents)
            {
                if (item is UserManageForm)
                {
                    item.Activate();
                    return true;
                }
            }
            UserManageForm role = new UserManageForm(form);
            role.Show(form.DockPanel, DockState.Document);
            role.Activate();
            return true;
        }
    }
    /// <summary>
    /// 显示产品管理界面
    /// </summary>
    public class ShowProductManageCommand : AbstractCommand
    {
        public ShowProductManageCommand()
        {
            this.m_name = "产品管理";
        }
        public override bool Execute(object param, object data)
        {
            MainForm form = param as MainForm;
            if (form == null)
                return false;
            foreach (DockContent item in form.DockPanel.Contents)
            {
                if (item is ProductManageForm)
                {
                    item.Activate();
                    return true;
                }
            }
            ProductManageForm role = new ProductManageForm(form);
            role.Show(form.DockPanel, DockState.Document);
            role.Activate();
            return true;
        }
    }
    /// <summary>
    /// 显示菜单管理界面
    /// </summary>
    public class ShowMenuConfigFormCommand : AbstractCommand
    {
        public ShowMenuConfigFormCommand()
        {
            this.m_name = "菜单管理";
        }
        public override bool Execute(object param, object data)
        {
            MainForm form = param as MainForm;
            if (form == null)
                return false;
            foreach (DockContent item in form.DockPanel.Contents)
            {
                if (item is MenuConfigForm)
                {
                    item.Activate();
                    return true;
                }
            }
            MenuConfigForm role = new MenuConfigForm(form);
            role.Show(form.DockPanel, DockState.Document);
            role.Activate();
            return true;
        }
    }
    /// <summary>
    /// 显示系统参数管理界面
    /// </summary>
    public class ShowCommand1 : AbstractCommand
    {
        public ShowCommand1()
        {
            this.m_name = "系统参数管理";
        }
        public override bool Execute(object param, object data)
        {
            MainForm form = param as MainForm;
            if (form == null)
                return false;
            foreach (DockContent item in form.DockPanel.Contents)
            {
                if (item is ParameterManageForm)
                {
                    item.Activate();
                    return true;
                }
            }
            ParameterManageForm role = new ParameterManageForm(form);
            role.Show(form.DockPanel, DockState.Document);
            role.Activate();
            return true;
        }
    }
}
