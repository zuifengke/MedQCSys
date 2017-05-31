using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Heren.MedQC.Test
{
    class Public_class
    {
        static string sex;
        public static string Fsex(int flag)
        {

            switch (flag)
            {
                case 0:
                    sex = "Î´Öª";
                    break;
                case 1:
                    sex = "ÄÐ";
                    break;
                case 2:
                    sex = "Å®";
                    break;
                case 9:
                    sex = "Î´ËµÃ÷";
                    break;
                default:
                    MessageBox.Show("ÐÔ±ð´íÎó!");
                    sex = "´íÎó";
                    break;
            }
            return sex;
        }

        static string minzi;
        public static string Fminzu(int flag)
        {

            switch (flag)
            {
                case 1:
                    minzi = "ºº";
                    break;
                case 2:
                    minzi = "ÃÉ¹Å";
                    break;
                case 3:
                    minzi = "»Ø";
                    break;
                case 4:
                    minzi = "²Ø";
                    break;
                case 5:
                    minzi = "Î¬Îá¶û";
                    break;
                case 6:
                    minzi = "Ãç";
                    break;
                case 7:
                    minzi = "ÒÍ";
                    break;
                case 8:
                    minzi = "×³";
                    break;
                case 9:
                    minzi = "²¼ÒÀ";
                    break;
                case 10:
                    minzi = "³¯ÏÊ";
                    break;
                case 11:
                    minzi = "Âú";
                    break;
                case 12:
                    minzi = "¶±";
                    break;
                case 13:
                    minzi = "Ñþ";
                    break;
                case 14:
                    minzi = "°×";
                    break;
                case 15:
                    minzi = "ÍÁ¼Ò";
                    break;
                case 16:
                    minzi = "¹þÄá";
                    break;
                case 17:
                    minzi = "¹þÈø¿Ë";
                    break;
                case 18:
                    minzi = "´ö";
                    break;
                case 19:
                    minzi = "Àè";
                    break;
                case 20:
                    minzi = "ÀüËÛ";
                    break;
                case 21:
                    minzi = "Øô";
                    break;
                case 22:
                    minzi = "î´";
                    break;
                case 23:
                    minzi = "¸ßÉ½";
                    break;
                case 24:
                    minzi = "À­ìï";
                    break;
                case 25:
                    minzi = "Ë®";
                    break;
                case 26:
                    minzi = "¶«Ïç";
                    break;
                case 27:
                    minzi = "ÄÉÎ÷";
                    break;
                case 28:
                    minzi = "¾°ÆÄ";
                    break;
                case 29:
                    minzi = "¿Â¶û¿Ë×Î";
                    break;
                case 30:
                    minzi = "ÍÁ";
                    break;
                case 31:
                    minzi = "´ïÎÓ¶û";
                    break;
                case 32:
                    minzi = "ØïÀÐ";
                    break;
                case 33:
                    minzi = "Ç¼";
                    break;
                case 34:
                    minzi = "²¼ÀÊ";
                    break;
                case 35:
                    minzi = "ÈöÀ­";
                    break;
                case 36:
                    minzi = "Ã«ÄÏ";
                    break;
                case 37:
                    minzi = "ØîÀÐ";
                    break;
                case 38:
                    minzi = "Îý²®";
                    break;
                case 39:
                    minzi = "°¢²ý";
                    break;
                case 40:
                    minzi = "ÆÕÃ×";
                    break;
                case 41:
                    minzi = "Ëþ¼ª¿Ë";
                    break;
                case 42:
                    minzi = "Å­";
                    break;
                case 43:
                    minzi = "ÎÚ×Î±ð¿Ë";
                    break;
                case 44:
                    minzi = "¶íÂÞË¹";
                    break;
                case 45:
                    minzi = "¶õÎÂ¿Ë";
                    break;
                case 46:
                    minzi = "µÂ°º";
                    break;
                case 47:
                    minzi = "±£°²";
                    break;
                case 48:
                    minzi = "Ô£¹Ì";
                    break;
                case 49:
                    minzi = "¾©";
                    break;
                case 50:
                    minzi = "ËþËþ¶û";
                    break;
                case 51:
                    minzi = "¶ÀÁú";
                    break;
                case 52:
                    minzi = "¶õÂ×´º";
                    break;
                case 53:
                    minzi = "ºÕÕÜ";
                    break;
                case 54:
                    minzi = "ÃÅ°Í";
                    break;
                case 55:
                    minzi = "çó°Í";
                    break;
                case 56:
                    minzi = "»ùÅµ";
                    break;
                default:
                    MessageBox.Show("Ãñ×å´íÎó!");
                    minzi = "´íÎó";
                    break;
            }
            return minzi;
        }


        public static long Getzplength()
        {
            long bmpend = 0;
            try
            {
                using (FileStream zpFile = new FileStream("D:\\zp.bmp", FileMode.Open))
                {
                    long bmpbegin = zpFile.Seek(0, SeekOrigin.Begin);
                    bmpend = zpFile.Seek(0, SeekOrigin.End);
                    byte[] bmp = new byte[bmpend];
                    zpFile.Seek(0, SeekOrigin.Begin);

                    zpFile.Close();
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("An IO exception has been thrown!");
                Console.WriteLine(ex.ToString());
                return -1;
            }
            
            return bmpend;
        }
    }
}
