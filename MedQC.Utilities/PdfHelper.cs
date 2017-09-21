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
        public void ConvertJPG2PDF(string jpgfile, string pdf)
        {
            var document = new Document(iTextSharp.text.PageSize.A4, 25, 25, 25, 25);
            using (var stream = new FileStream(pdf, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                PdfWriter.GetInstance(document, stream);
                document.Open();
                using (var imageStream = new FileStream(jpgfile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    var image = iTextSharp.text.Image.GetInstance(imageStream);
                    if (image.Height > iTextSharp.text.PageSize.A4.Height - 25)
                    {
                        image.ScaleToFit(iTextSharp.text.PageSize.A4.Width - 25, iTextSharp.text.PageSize.A4.Height - 25);
                    }
                    else if (image.Width > iTextSharp.text.PageSize.A4.Width - 25)
                    {
                        image.ScaleToFit(iTextSharp.text.PageSize.A4.Width - 25, iTextSharp.text.PageSize.A4.Height - 25);
                    }
                    image.Alignment = iTextSharp.text.Image.ALIGN_MIDDLE;
                    document.Add(image);
                }

                document.Close();
            }
        }
        public static void process(string[] files, string newpdf)
        {
            iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 25, 25, 25, 25);
            try
            {
                iTextSharp.text.pdf.PdfWriter.GetInstance(document, new FileStream(newpdf, FileMode.Create, FileAccess.ReadWrite));
                document.Open();
                iTextSharp.text.Image image;
                for (int i = 0; i < files.Length; i++)
                {
                    if (String.IsNullOrEmpty(files[i])) break;

                    image = iTextSharp.text.Image.GetInstance(files[i]);

                    if (image.Height > iTextSharp.text.PageSize.A4.Height - 25)
                    {
                        image.ScaleToFit(iTextSharp.text.PageSize.A4.Width - 25, iTextSharp.text.PageSize.A4.Height - 25);
                    }
                    else if (image.Width > iTextSharp.text.PageSize.A4.Width - 25)
                    {
                        image.ScaleToFit(iTextSharp.text.PageSize.A4.Width - 25, iTextSharp.text.PageSize.A4.Height - 25);
                    }
                    image.Alignment = iTextSharp.text.Image.ALIGN_MIDDLE;
                    //image.SetDpi(72, 72);

                    document.NewPage();
                    document.Add(image);
                }
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog(ex.ToString());
            }
            document.Close();
        }
        public static bool process(System.Drawing.Image[] files, string newpdf)
        {
            iTextSharp.text.Document document = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 25, 25, 25, 25);
            try
            {
                iTextSharp.text.pdf.PdfWriter.GetInstance(document, new FileStream(newpdf, FileMode.Create, FileAccess.ReadWrite));
                document.Open();
                iTextSharp.text.Image image;
                for (int i = 0; i < files.Length; i++)
                {
                    image = iTextSharp.text.Image.GetInstance(files[i], System.Drawing.Imaging.ImageFormat.Bmp);

                    if (image.Height > iTextSharp.text.PageSize.A4.Height - 25)
                    {
                        image.ScaleToFit(iTextSharp.text.PageSize.A4.Width - 25, iTextSharp.text.PageSize.A4.Height - 25);
                    }
                    else if (image.Width > iTextSharp.text.PageSize.A4.Width - 25)
                    {
                        image.ScaleToFit(iTextSharp.text.PageSize.A4.Width - 25, iTextSharp.text.PageSize.A4.Height - 25);
                    }
                    image.Alignment = iTextSharp.text.Image.ALIGN_MIDDLE;
                    //image.SetDpi(72, 72);
                    document.NewPage();
                    document.Add(image);
                }

                document.Close();
                return true;
              
            }
            catch (Exception ex)
            {
                document.Close();
                LogManager.Instance.WriteLog(ex.ToString());
                return false;
            }
        }
    }
}
