using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Heren.MedQC.Core;
using MedQCSys;
using Heren.Common.DockSuite;
using Heren.Common.Libraries;
using Heren.MedQC.PDF.Forms;

namespace Heren.MedQC.PDF
{
    /// <summary>
    /// 显示角色管理界面
    /// </summary>
    public class ShowHomePageCommand : AbstractCommand
    {
        public ShowHomePageCommand()
        {
            this.m_name = "PDF浏览器";
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
                    if (item is PdfViewForm)
                    {
                        item.Activate();
                        return true;
                    }
                }
                PdfViewForm role = new PdfViewForm(form);
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
    public class ShowHomePageCommand2 : AbstractCommand
    {
        public ShowHomePageCommand2()
        {
            this.m_name = "报告查看";
        }
        public override bool Execute(object param, object data)
        {
            try
            {

                MainForm form = param as MainForm;
                if (form == null)
                    return false;
                string filePath = data as string;
                if (string.IsNullOrEmpty(filePath))
                    return true;

                foreach (DockContent item in form.DockPanel.Contents)
                {
                    if (item is PdfViewForm)
                    {

                        if ((item as PdfViewForm).FilePath == filePath)
                        {
                            item.Activate();
                            return true;
                        }  
                    }
                }
                PdfViewForm frm = new PdfViewForm(form);
                frm.FilePath = filePath;
                frm.Show(form.DockPanel, DockState.Document);
                frm.Activate();
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog(ex.ToString());
            }
            return true;
        }
    }
}
