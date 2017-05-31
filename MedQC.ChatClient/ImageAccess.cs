using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
using Heren.Common.Libraries;
using System.Drawing.Imaging;

namespace MedQC.ChatClient
{
    public class ImageAccess
    {
        public Image ResourceImage;
        private int ImageWidth;
        private int ImageHeight;
        public string ErrMessage;

        /// <summary>
        /// 类的构造函数
        /// </summary>
        /// <param name="ImageFileName">图片文件的全路径名称</param>
        public ImageAccess()
        {

        }
        private static ImageAccess m_Instance = null;
        public static ImageAccess Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new ImageAccess();
                }
                return m_Instance;
            }
        }
        /// <summary>
        /// 类的构造函数
        /// </summary>
        /// <param name="ImageFileName">图片文件的全路径名称</param>
        public ImageAccess(string ImageFileName)
        {
            ResourceImage = Image.FromFile(ImageFileName);
            ErrMessage = "";
        }
        public bool ThumbnailCallback()
        {
            return false;
        }
        /// <summary>
        /// 生成缩略图重载方法1，返回缩略图的Image对象
        /// </summary>
        /// <param name="Width">缩略图的宽度</param>
        /// <param name="Height">缩略图的高度</param>
        /// <returns>缩略图的Image对象</returns>
        public Image GetReducedImage(int Width, int Height)
        {
            try
            {
                Image ReducedImage;
                Image.GetThumbnailImageAbort callb = new Image.GetThumbnailImageAbort(ThumbnailCallback);

                ReducedImage = ResourceImage.GetThumbnailImage(Width, Height, callb, IntPtr.Zero);

                return ReducedImage;
            }
            catch (Exception e)
            {
                ErrMessage = e.Message;
                return null;
            }
        }
        /// <summary>
        /// 生成缩略图重载方法2，将缩略图文件保存到指定的路径
        /// </summary>
        /// <param name="Width">缩略图的宽度</param>
        /// <param name="Height">缩略图的高度</param>
        /// <param name="targetFilePath">缩略图保存的全文件名，(带路径)，参数格式：D:\Images\filename.jpg</param>
        /// <returns>成功返回true，否则返回false</returns>
        public bool GetReducedImage(int Width, int Height, string targetFilePath)
        {
            try
            {
                Image ReducedImage;
                Image.GetThumbnailImageAbort callb = new Image.GetThumbnailImageAbort(ThumbnailCallback);

                ReducedImage = ResourceImage.GetThumbnailImage(Width, Height, callb, IntPtr.Zero);
                ReducedImage.Save(@targetFilePath, ImageFormat.Jpeg);
                ReducedImage.Dispose();

                return true;
            }
            catch (Exception e)
            {
                ErrMessage = e.Message;
                return false;
            }
        }
        /// <summary>
        /// 生成缩略图重载方法3，返回缩略图的Image对象
        /// </summary>
        /// <param name="Percent">缩略图的宽度百分比 如：需要百分之80，就填0.8</param>  
        /// <returns>缩略图的Image对象</returns>
        public Image GetReducedImage(double Percent)
        {
            try
            {
                Image ReducedImage;
                Image.GetThumbnailImageAbort callb = new Image.GetThumbnailImageAbort(ThumbnailCallback);
                ImageWidth = Convert.ToInt32(ResourceImage.Width * Percent);
                ImageHeight = Convert.ToInt32(ResourceImage.Width * Percent);

                ReducedImage = ResourceImage.GetThumbnailImage(ImageWidth, ImageHeight, callb, IntPtr.Zero);

                return ReducedImage;
            }
            catch (Exception e)
            {
                ErrMessage = e.Message;
                return null;
            }
        }
        /// <summary>
        /// 生成缩略图重载方法4，返回缩略图的Image对象
        /// </summary>
        /// <param name="Percent">缩略图的宽度百分比 如：需要百分之80，就填0.8</param>  
        /// <param name="targetFilePath">缩略图保存的全文件名，(带路径)，参数格式：D:\Images\filename.jpg</param>
        /// <returns>成功返回true,否则返回false</returns>
        public bool GetReducedImage(double Percent, string targetFilePath)
        {
            try
            {
                Image ReducedImage;
                Image.GetThumbnailImageAbort callb = new Image.GetThumbnailImageAbort(ThumbnailCallback);
                ImageWidth = Convert.ToInt32(ResourceImage.Width * Percent);
                ImageHeight = Convert.ToInt32(ResourceImage.Width * Percent);

                ReducedImage = ResourceImage.GetThumbnailImage(ImageWidth, ImageHeight, callb, IntPtr.Zero);
                ReducedImage.Save(@targetFilePath, ImageFormat.Jpeg);

                ReducedImage.Dispose();

                return true;
            }
            catch (Exception e)
            {
                ErrMessage = e.Message;
                return false;
            }
        }
        /// <summary>
        /// byte[]转Image
        /// </summary>
        /// <param name="Buffer">所要转换的byte[]</param>
        /// <returns>Image文件</returns>
        public Bitmap BufferToImage(byte[] Buffer)
        {
            if (Buffer == null || Buffer.Length == 0) { return null; }
            byte[] data = null;
            Image oImage = null;
            Bitmap oBitmap = null;
            data = (byte[])Buffer.Clone();
            try
            {
                MemoryStream oMemoryStream = new MemoryStream(Buffer);
                oMemoryStream.Position = 0;

                oImage = System.Drawing.Image.FromStream(oMemoryStream);
                oBitmap = new Bitmap(oImage);
            }
            catch (Exception err)
            {
                MessageBoxEx.Show("图片格式转换过程中出错");
            }
            return oBitmap;
        }

        /// <summary>
        /// Image转byte[]
        /// </summary>
        /// <param name="Image">所要转换的Image</param>
        /// <param name="imageFormat">所要转换的Image文件格式</param>
        /// <returns>byte[]</returns>
        public byte[] ImageToBuffer(Bitmap Image, System.Drawing.Imaging.ImageFormat imageFormat)
        {

            if (Image == null) { return null; }

            byte[] data = null;

            using (MemoryStream oMemoryStream = new MemoryStream())
            {
                using (Bitmap oBitmap = new Bitmap(Image))
                {
                    oBitmap.Save(oMemoryStream, imageFormat);
                    oMemoryStream.Position = 0;
                    data = new byte[oMemoryStream.Length];
                    oMemoryStream.Read(data, 0, Convert.ToInt32(oMemoryStream.Length));
                    oMemoryStream.Flush();
                }
            }
            return data;
        }


    }
}
