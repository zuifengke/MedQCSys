using Heren.Common.Libraries;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Heren.MedQC.Utilities
{
    public class PdfHelper
    {
        /// <summary> 合併PDF檔(集合) </summary>
        /// <param name="fileList">欲合併PDF檔之集合(一筆以上)</param>
        /// <param name="outMergeFile">合併後的檔名</param>
        public static bool MergePDFFiles(string[] fileList, string outMergeFile)

        {
            PdfReader reader;
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(outMergeFile, FileMode.Create));
            document.Open();
            try
            {
                PdfContentByte cb = writer.DirectContent;
                PdfImportedPage newPage;
                for (int i = 0; i < fileList.Length; i++)

                {
                    reader = new PdfReader(fileList[i]);
                    int iPageNum = reader.NumberOfPages;

                    for (int j = 1; j <= iPageNum; j++)

                    {
                        document.NewPage();
                        newPage = writer.GetImportedPage(reader, j);
                        cb.AddTemplate(newPage, 0, 0);
                    }
                }
                document.Close();
                return true;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog(ex.ToString());
                document.Close();
                return false;
            }
        }
    }
}
