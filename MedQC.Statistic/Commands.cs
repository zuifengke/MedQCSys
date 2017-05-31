using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Heren.MedQC.Core;
using MedQCSys;
using Heren.Common.DockSuite;
using MedQCSys.DockForms;

namespace Heren.MedQC.Statistic
{
    public class ShowDeathCommand : AbstractCommand
    {
        public ShowDeathCommand()
        {
            this.m_name = "检查问题清单";
        }
        public override bool Execute(object param, object data)
        {
            MainForm form = param as MainForm;
            if (form == null)
                return false;
            foreach (DockContentBase item in form.DockPanel.Contents)
            {
                if (item is StatByBugsForm)
                {
                    item.Activate();
                    item.OnRefreshView();
                    return true;
                }
            }
            StatByBugsForm role = new StatByBugsForm(form);
            role.Show(form.DockPanel, DockState.Document);
            role.Activate();
            return true;
        }
    }
    public class ShowDeathCommand1 : AbstractCommand
    {
        public ShowDeathCommand1()
        {
            this.m_name = "问题类型统计";
        }
        public override bool Execute(object param, object data)
        {
            MainForm form = param as MainForm;
            if (form == null)
                return false;
            foreach (DockContentBase item in form.DockPanel.Contents)
            {
                if (item is StatByBugTypeForm)
                {
                    item.Activate();
                    item.OnRefreshView();
                    return true;
                }
            }
            StatByBugTypeForm role = new StatByBugTypeForm(form);
            role.Show(form.DockPanel, DockState.Document);
            role.Activate();
            return true;
        }
    }
    public class ShowDeathCommand2 : AbstractCommand
    {
        public ShowDeathCommand2()
        {
            this.m_name = "病案质量统计";
        }
        public override bool Execute(object param, object data)
        {
            MainForm form = param as MainForm;
            if (form == null)
                return false;
            foreach (DockContentBase item in form.DockPanel.Contents)
            {
                if (item is StatByDocScoreCompreForm)
                {
                    item.Activate();
                    item.OnRefreshView();
                    return true;
                }
            }
            StatByDocScoreCompreForm role = new StatByDocScoreCompreForm(form);
            role.Show(form.DockPanel, DockState.Document);
            role.Activate();
            return true;
        }
    }
    public class ShowDeathCommand3 : AbstractCommand
    {
        public ShowDeathCommand3()
        {
            this.m_name = "病案评分一览表";
        }
        public override bool Execute(object param, object data)
        {
            MainForm form = param as MainForm;
            if (form == null)
                return false;
            foreach (DockContentBase item in form.DockPanel.Contents)
            {
                if (item is StatByDocScoreForm)
                {
                    item.Activate();
                    item.OnRefreshView();
                    return true;
                }
            }
            StatByDocScoreForm role = new StatByDocScoreForm(form);
            role.Show(form.DockPanel, DockState.Document);
            role.Activate();
            return true;
        }
    }
    public class ShowDeathCommand4 : AbstractCommand
    {
        public ShowDeathCommand4()
        {
            this.m_name = "按科室统计";
        }
        public override bool Execute(object param, object data)
        {
            MainForm form = param as MainForm;
            if (form == null)
                return false;
            foreach (DockContentBase item in form.DockPanel.Contents)
            {
                if (item is StatByDeptForm)
                {
                    item.Activate();
                    item.OnRefreshView();
                    return true;
                }
            }
            StatByDeptForm role = new StatByDeptForm(form);
            role.Show(form.DockPanel, DockState.Document);
            role.Activate();
            return true;
        }
    }
    public class ShowDeathCommand10 : AbstractCommand
    {
        public ShowDeathCommand10()
        {
            this.m_name = "按检查者统计";
        }
        public override bool Execute(object param, object data)
        {
            MainForm form = param as MainForm;
            if (form == null)
                return false;
            foreach (DockContentBase item in form.DockPanel.Contents)
            {
                if (item is StatByCheckerForm)
                {
                    item.Activate();
                    item.OnRefreshView();
                    return true;
                }
            }
            StatByCheckerForm role = new StatByCheckerForm(form);
            role.Show(form.DockPanel, DockState.Document);
            role.Activate();
            return true;
        }
    }
    public class ShowDeathCommand9 : AbstractCommand
    {
        public ShowDeathCommand9()
        {
            this.m_name = "按质检问题统计";
        }
        public override bool Execute(object param, object data)
        {
            MainForm form = param as MainForm;
            if (form == null)
                return false;
            foreach (DockContentBase item in form.DockPanel.Contents)
            {
                if (item is StatByQuestionForm)
                {
                    item.Activate();
                    item.OnRefreshView();
                    return true;
                }
            }
            StatByQuestionForm role = new StatByQuestionForm(form);
            role.Show(form.DockPanel, DockState.Document);
            role.Activate();
            return true;
        }
    }
    public class ShowDeathCommand8 : AbstractCommand
    {
        public ShowDeathCommand8()
        {
            this.m_name = "病历修改次数统计";
        }
        public override bool Execute(object param, object data)
        {
            MainForm form = param as MainForm;
            if (form == null)
                return false;
            foreach (DockContentBase item in form.DockPanel.Contents)
            {
                if (item is StatByModifyTimesForm)
                {
                    item.Activate();
                    item.OnRefreshView();
                    return true;
                }
            }
            StatByModifyTimesForm role = new StatByModifyTimesForm(form);
            role.Show(form.DockPanel, DockState.Document);
            role.Activate();
            return true;
        }
    }
    public class ShowDeathCommand7 : AbstractCommand
    {
        public ShowDeathCommand7()
        {
            this.m_name = "工作详细内容统计";
        }
        public override bool Execute(object param, object data)
        {
            MainForm form = param as MainForm;
            if (form == null)
                return false;
            foreach (DockContentBase item in form.DockPanel.Contents)
            {
                if (item is StatByJobDetailForm)
                {
                    item.Activate();
                    item.OnRefreshView();
                    return true;
                }
            }
            StatByJobDetailForm role = new StatByJobDetailForm(form);
            role.Show(form.DockPanel, DockState.Document);
            role.Activate();
            return true;
        }
    }
    public class ShowDeathCommand6 : AbstractCommand
    {
        public ShowDeathCommand6()
        {
            this.m_name = "科室病案检查情况统计";
        }
        public override bool Execute(object param, object data)
        {
            MainForm form = param as MainForm;
            if (form == null)
                return false;
            foreach (DockContentBase item in form.DockPanel.Contents)
            {
                if (item is StatByDeptWorkLoadForm)
                {
                    item.Activate();
                    item.OnRefreshView();
                    return true;
                }
            }
            StatByDeptWorkLoadForm role = new StatByDeptWorkLoadForm(form);
            role.Show(form.DockPanel, DockState.Document);
            role.Activate();
            return true;
        }
    }
    public class ShowDeathCommand11 : AbstractCommand
    {
        public ShowDeathCommand11()
        {
            this.m_name = "工作量统计";
        }
        public override bool Execute(object param, object data)
        {
            MainForm form = param as MainForm;
            if (form == null)
                return false;
            foreach (DockContentBase item in form.DockPanel.Contents)
            {
                if (item is StatByWorkloadForm)
                {
                    item.Activate();
                    item.OnRefreshView();
                    return true;
                }
            }
            StatByWorkloadForm role = new StatByWorkloadForm(form);
            role.Show(form.DockPanel, DockState.Document);
            role.Activate();
            return true;
        }
    }
    public class ShowDeathCommand12 : AbstractCommand
    {
        public ShowDeathCommand12()
        {
            this.m_name = "系统时效超时统计";
        }
        public override bool Execute(object param, object data)
        {
            MainForm form = param as MainForm;
            if (form == null)
                return false;
            foreach (DockContentBase item in form.DockPanel.Contents)
            {
                if (item is StatByTimeCheckTimeOutForm)
                {
                    item.Activate();
                    item.OnRefreshView();
                    return true;
                }
            }
            StatByTimeCheckTimeOutForm role = new StatByTimeCheckTimeOutForm(form);
            role.Show(form.DockPanel, DockState.Document);
            role.Activate();
            return true;
        }
    }
    public class ShowDeathCommand13 : AbstractCommand
    {
        public ShowDeathCommand13()
        {
            this.m_name = "系统时效检查详情";
        }
        public override bool Execute(object param, object data)
        {
            MainForm form = param as MainForm;
            if (form == null)
                return false;
            foreach (DockContentBase item in form.DockPanel.Contents)
            {
                if (item is StatByTimeCheckDetailForm)
                {
                    item.Activate();
                    item.OnRefreshView();
                    return true;
                }
            }
            StatByTimeCheckDetailForm role = new StatByTimeCheckDetailForm(form);
            role.Show(form.DockPanel, DockState.Document);
            role.Activate();
            return true;
        }
    }
    public class ShowDeathCommand14 : AbstractCommand
    {
        public ShowDeathCommand14()
        {
            this.m_name = "病历缺陷分类统计";
        }
        public override bool Execute(object param, object data)
        {
            MainForm form = param as MainForm;
            if (form == null)
                return false;
            foreach (DockContentBase item in form.DockPanel.Contents)
            {
                if (item is StatByClassifyQcCheckResultForm)
                {
                    item.Activate();
                    item.OnRefreshView();
                    return true;
                }
            }
            StatByClassifyQcCheckResultForm role = new StatByClassifyQcCheckResultForm(form);
            role.Show(form.DockPanel, DockState.Document);
            role.Activate();
            return true;
        }
    }
    public class ShowDeathCommand15 : AbstractCommand
    {
        public ShowDeathCommand15()
        {
            this.m_name = "病历缺陷科室统计";
        }
        public override bool Execute(object param, object data)
        {
            MainForm form = param as MainForm;
            if (form == null)
                return false;
            foreach (DockContentBase item in form.DockPanel.Contents)
            {
                if (item is StatByDeptQcCheckResultForm)
                {
                    item.Activate();
                    item.OnRefreshView();
                    return true;
                }
            }
            StatByDeptQcCheckResultForm role = new StatByDeptQcCheckResultForm(form);
            role.Show(form.DockPanel, DockState.Document);
            role.Activate();
            return true;
        }
    }
    public class ShowDeathCommand16 : AbstractCommand
    {
        public ShowDeathCommand16()
        {
            this.m_name = "病历缺陷详情清单";
        }
        public override bool Execute(object param, object data)
        {
            MainForm form = param as MainForm;
            if (form == null)
                return false;
            foreach (DockContentBase item in form.DockPanel.Contents)
            {
                if (item is StatByQcCheckResultForm)
                {
                    item.Activate();
                    item.OnRefreshView();
                    return true;
                }
            }
            StatByQcCheckResultForm role = new StatByQcCheckResultForm(form);
            role.Show(form.DockPanel, DockState.Document);
            role.Activate();
            return true;
        }
    }
}
