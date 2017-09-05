using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Heren.MedQC.Core;
using MedQCSys;
using Heren.Common.DockSuite;
using MedQCSys.DockForms;
using Heren.MedQC.Search.Forms;
namespace Heren.MedQC.Search
{
    public class ShowDeathCommand : AbstractCommand
    {
        public ShowDeathCommand()
        {
            this.m_name = "死亡患者查询";
        }
        public override bool Execute(object param, object data)
        {
            MainForm form = param as MainForm;
            if (form == null)
                return false;
            foreach (DockContentBase item in form.DockPanel.Contents)
            {
                if (item is SearchDeathForm)
                {
                    item.Activate();
                    item.OnRefreshView();
                    return true;
                }
            }
            SearchDeathForm role = new SearchDeathForm(form);
            role.Show(form.DockPanel, DockState.Document);
            role.Activate();
            return true;
        }
    }
    public class ShowOperationCommand : AbstractCommand
    {
        public ShowOperationCommand()
        {
            this.m_name = "手术患者查询";
        }
        public override bool Execute(object param, object data)
        {
            MainForm form = param as MainForm;
            if (form == null)
                return false;
            foreach (DockContentBase item in form.DockPanel.Contents)
            {
                if (item is SearchOperationForm)
                {
                    item.Activate();
                    item.OnRefreshView();
                    return true;
                }
            }
            SearchOperationForm role = new SearchOperationForm(form);
            role.Show(form.DockPanel, DockState.Document);
            role.Activate();
            return true;
        }
    }
    public class ShowSeriousCommand : AbstractCommand
    {
        public ShowSeriousCommand()
        {
            this.m_name = "危重患者查询";
        }
        public override bool Execute(object param, object data)
        {
            MainForm form = param as MainForm;
            if (form == null)
                return false;
            foreach (DockContentBase item in form.DockPanel.Contents)
            {
                if (item is SearchSeriousAndCriticalForm)
                {
                    item.Activate();
                    item.OnRefreshView();
                    return true;
                }
            }
            SearchSeriousAndCriticalForm role = new SearchSeriousAndCriticalForm(form);
            role.Show(form.DockPanel, DockState.Document);
            role.Activate();
            return true;
        }
    }
    public class ShowOutPatientCommand : AbstractCommand
    {
        public ShowOutPatientCommand()
        {
            this.m_name = "出院患者查询";
        }
        public override bool Execute(object param, object data)
        {
            MainForm form = param as MainForm;
            if (form == null)
                return false;
            foreach (DockContentBase item in form.DockPanel.Contents)
            {
                if (item is SearchByOutPatientForm)
                {
                    item.Activate();
                    item.OnRefreshView();
                    return true;
                }
            }
            SearchByOutPatientForm role = new SearchByOutPatientForm(form);
            role.Show(form.DockPanel, DockState.Document);
            role.Activate();
            return true;
        }
    }
    public class ShowCommand1 : AbstractCommand
    {
        public ShowCommand1()
        {
            this.m_name = "病历查询";
        }
        public override bool Execute(object param, object data)
        {
            MainForm form = param as MainForm;
            if (form == null)
                return false;
            foreach (DockContentBase item in form.DockPanel.Contents)
            {
                if (item is SearchByOutPatientForm)
                {
                    item.Activate();
                    item.OnRefreshView();
                    return true;
                }
            }
            SearchEmrDocForm role = new SearchEmrDocForm(form);
            role.Show(form.DockPanel, DockState.Document);
            role.Activate();
            return true;
        }
    }

    public class ShowDelayCommand : AbstractCommand
    {
        public ShowDelayCommand()
        {
            this.m_name = "延期未提交病历查询";
        }
        public override bool Execute(object param, object data)
        {
            MainForm main = param as MainForm;
            if (main == null)
                return false;
            foreach (DockContentBase item in main.DockPanel.Contents)
            {
                if (item is SearchDelayUnCommitDocForm)
                {
                    item.Activate();
                    item.OnRefreshView();
                    return true;
                }
            }
            SearchDelayUnCommitDocForm form = new SearchDelayUnCommitDocForm(main);
            form.Show(main.DockPanel, DockState.Document);
            form.Activate();
            return true;
        }
    }

    public class ShowCriticalValuesCommand : AbstractCommand
    {
        public ShowCriticalValuesCommand()
        {
            this.m_name = "危急值患者查询";
        }
        public override bool Execute(object param, object data)
        {
            MainForm main = param as MainForm;
            if (main == null)
                return false;
            foreach (DockContentBase item in main.DockPanel.Contents)
            {
                if (item is SearchCriticalValuesForm)
                {
                    item.Activate();
                    item.OnRefreshView();
                    return true;
                }
            }
            SearchCriticalValuesForm form = new SearchCriticalValuesForm(main);
            form.Show(main.DockPanel, DockState.Document);
            form.Activate();
            return true;
        }
    }
}
