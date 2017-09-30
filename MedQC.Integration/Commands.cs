using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Heren.MedQC.Core;
using MedQCSys;
using Heren.Common.DockSuite;
using Heren.Common.Libraries;
using Heren.MedQC.HomePage.Forms;
using MedQCSys.PatPage;
using MedQCSys.DockForms;

namespace Heren.MedQC.HomePage
{
    /// <summary>
    /// 显示角色管理界面
    /// </summary>
    public class ShowHomePageCommand : AbstractCommand
    {
        public ShowHomePageCommand()
        {
            this.m_name = "起始页";
        }
        public override bool Execute(object param, object data)
        {
            try
            {

                MainForm form = param as MainForm;
                if (form == null)
                    return false;
                foreach (DockContent item in form.DockPanel.Contents)
                {
                    if (item is HomePageForm)
                    {
                        item.Activate();
                        return true;
                    }
                }
                HomePageForm role = new HomePageForm(form);
                role.Show(form.DockPanel, DockState.Document);
                role.Activate();
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog(ex.ToString());
            }
            return true;
        }
    }
    public class ShowNurdocCommand : AbstractCommand
    {
        public ShowNurdocCommand()
        {
            this.m_name = "护理文书";
        }
        public override bool Execute(object param, object data)
        {
            try
            {
                PatientPageControl form = param as PatientPageControl;
                if (form == null)
                    return false;
                foreach (DockContent item in form.DockPanel.Contents)
                {
                    if (item is PatientNurdocForm)
                    {
                        return true;
                    }
                }
                PatientNurdocForm role = new PatientNurdocForm(form.MainForm,form);
                role.Show(form.DockPanel, false);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog(ex.ToString());
            }
            return true;
        }
    }
}
