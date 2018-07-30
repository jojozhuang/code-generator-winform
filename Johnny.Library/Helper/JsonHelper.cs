using System;
using System.Collections.Generic;
using System.Text;
//using Microsoft.JScript.Vsa;
//using Microsoft.JScript;

namespace Johnny.Library.Helper
{
    public class JsonHelper
    {
        // Methods
        public JsonHelper()
        {
        }

        #region GetMid
        public static string GetMid(string str, string start, string end)
        {
            int num;
            return GetMid(str, start, end, out num);
        }

        public static string GetMid(string str, string start, string end, out int pos)
        {
            pos = -1;
            if (str == null)
            {
                return null;
            }
            int index = str.IndexOf(start);
            if (-1 == index)
            {
                return null;
            }
            index += start.Length;
            int num2 = str.IndexOf(end, index);
            if (-1 == num2)
            {
                return null;
            }
            pos = num2;
            return str.Substring(index, num2 - index);
        }
        #endregion

        #region GetMidLast
        public static string GetMidLast(string str, string start, string end)
        {
            int num;
            return GetMidLast(str, start, end, out num);
        }

        public static string GetMidLast(string str, string start, string end, out int pos)
        {
            pos = -1;
            if (str == null)
            {
                return null;
            }
            int index = str.LastIndexOf(start);
            if (-1 == index)
            {
                return null;
            }
            index += start.Length;
            int num2 = str.LastIndexOf(end);
            if (-1 == num2)
            {
                return null;
            }
            pos = num2;
            return str.Substring(index, num2 - index);
        }
        #endregion

        #region GetFirstLast
        public static string GetFirstLast(string str, string start, string end)
        {
            int num;
            return GetFirstLast(str, start, end, out num);
        }

        public static string GetFirstLast(string str, string start, string end, out int pos)
        {
            pos = -1;
            if (str == null)
            {
                return null;
            }
            int index = str.IndexOf(start);
            if (-1 == index)
            {
                return null;
            }
            index += start.Length;
            int num2 = str.LastIndexOf(end);
            if (-1 == num2)
            {
                return null;
            }
            pos = num2;
            return str.Substring(index, num2 - index);
        }
        #endregion
        
        #region GetMidInteger
        public static int GetMidInteger(string str, string start, string end)
        {
            int num;
            return GetMidInteger(str, start, end, out num);
        }

        public static int GetMidInteger(string str, string start, string end, out int pos)
        {
            return GetInteger(GetMid(str, start, end, out pos));
        }        
        #endregion

        #region GetInteger
        public static int GetInteger(string str)
        {
            int num;
            if (!string.IsNullOrEmpty(str) && int.TryParse(str, out num))
            {
                return num;
            }
            return -1;
        }
        #endregion
        
        #region FiltrateHtmlTags
        public static string FiltrateHtmlTags(string result)
        {
            if (result == null)
            {
                return string.Empty;
            }
            StringBuilder builder = new StringBuilder();
            bool flag = false;
            foreach (char ch in result)
            {
                switch (ch)
                {
                    case '<':
                        flag = true;
                        break;

                    case '>':
                        flag = false;
                        break;

                    default:
                        if (!flag)
                        {
                            if (ch == '\n')
                            {
                                builder.Append(" ");
                            }
                            else if (((ch != ' ') && (ch != '\t')) && (ch != '\r'))
                            {
                                builder.Append(ch);
                            }
                        }
                        break;
                }
            }
            return builder.ToString().Trim().Replace("&yen;", "гд").Replace("&nbsp;", "");
        }
        #endregion

        #region CreateHtml
        public static string CreateHtml(string result)
        {
            if (result == null)
            {
                return string.Empty;
            }
            StringBuilder builder = new StringBuilder();
            bool flag = false;
            foreach (char ch in result)
            {
                if (ch == '\r')
                {
                    flag = true;
                    continue;
                }
                if (ch == '\n')
                {
                    if (flag)
                    {
                        builder.Append("<br>");
                        flag = false;
                        continue;
                    }
                }
                builder.Append(ch);
            }
            return builder.ToString().Trim();
        }
        #endregion

        #region RunJavascript
        //public static string RunJavascript(string scriptText)
        //{
        //    VsaEngine engine = VsaEngine.CreateEngine();
        //    return Eval.JScriptEvaluate(scriptText, engine).ToString();
        //}
        #endregion

    }
}
