using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace EMRDBLib
{
    public partial struct SystemData
    {

        /// <summary>
        /// 快捷键
        /// </summary>
        public struct ShortcutKeys
        {
            /// <summary>
            /// Ctrl+D
            /// </summary>
            public const string Ctrl_D = "Ctrl+D";

            /// <summary>
            /// Ctrl_F
            /// </summary>
            public const string Ctrl_F = "Ctrl_F";

            public const string F2 = "F2";
            public const string F3 = "F3";
            public const string F1 = "F1";
            public const string Ctrl_P = "Ctrl+P";

            public const string Ctrl_O = "Ctrl+O";
            public const string Ctrl_L = "Ctrl+L";
            public const string Ctrl_E = "Ctrl+E";
            public const string Ctrl_T = "Ctrl+T";
            public const string Ctrl_Q = "Ctrl+Q";
            public const string Ctrl_W = "Ctrl+W";

            public const string ALt_B = "ALt+B";
            public const string ALt_W = "ALt+W";
            public const string ALt_T = "ALt+T";
            public const string ALt_O = "ALt+O";
            public const string ALt_H = "ALt+H";
            public const string ALt_M = "ALt+M";
            public const string ALt_S= "ALt+S";
            public const string ALt_C = "ALt+C";
            public const string ALt_F = "ALt+F";
            public static string[] GetArrShortcutKeys()
            {
                return new string[] { Ctrl_D, Ctrl_F, Ctrl_E, Ctrl_L, Ctrl_O, Ctrl_P, Ctrl_Q, Ctrl_T, Ctrl_W, ALt_T,ALt_W, ALt_O, ALt_H,ALt_M,ALt_S,ALt_C,ALt_B, F1, F2, F3,ALt_F };
            }
            /// <summary>
            /// 获取菜单的快捷方式
            /// </summary>
            /// <param name="szKey"></param>
            /// <returns></returns>
            public static Keys GetShortcutKeys(string szKey)
            {
                Keys key = 0;
                switch (szKey)
                {
                    case Ctrl_D:
                        key = (Keys)((Keys.Control | Keys.D));
                        break;
                    case Ctrl_F:
                        key = (Keys)((Keys.Control | Keys.F));
                        break;
                    case Ctrl_E:
                        key = (Keys)((Keys.Control | Keys.E));
                        break;
                    case Ctrl_L:
                        key = (Keys)((Keys.Control | Keys.L));
                        break;
                    case Ctrl_O:
                        key = (Keys)((Keys.Control | Keys.O));
                        break;
                    case Ctrl_P:
                        key = (Keys)((Keys.Control | Keys.P));
                        break;
                    case Ctrl_Q:
                        key = (Keys)((Keys.Control | Keys.Q));
                        break;
                    case Ctrl_T:
                        key = (Keys)((Keys.Control | Keys.T));
                        break;
                    case Ctrl_W:
                        key = (Keys)((Keys.Control | Keys.W));
                        break;
                    case ALt_H:
                        key = (Keys)((Keys.Alt | Keys.H));
                        break;
                    case ALt_B:
                        key = (Keys)((Keys.Alt | Keys.B));
                        break;
                    case ALt_O:
                        key = (Keys)((Keys.Alt | Keys.O));
                        break;
                    case ALt_T:
                        key = (Keys)((Keys.Alt | Keys.T));
                        break;
                    case ALt_S:
                        key = (Keys)((Keys.Alt | Keys.S));
                        break;
                    case ALt_C:
                        key = (Keys)((Keys.Alt | Keys.C));
                        break;
                    case ALt_F:
                        key = (Keys)((Keys.Alt | Keys.F));
                        break;
                    case ALt_W:
                        key = (Keys)((Keys.Alt | Keys.W));
                        break;
                    case F1:
                        key = (Keys)(Keys.F1);
                        break;
                    case F2:
                        key = (Keys)(Keys.F2);
                        break;
                    case F3:
                        key = (Keys)(Keys.F3);
                        break;
                    default:
                        break;
                }
                return key;
            }
        }
    }
}
