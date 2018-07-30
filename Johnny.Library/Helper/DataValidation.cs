using System;
using System.Collections;
using System.Text.RegularExpressions;

namespace Johnny.Library.Helper
{
    public class DataValidation
    {        
        public DataValidation()
        {
        }

        #region IsNull(object)
        /// <summary>
        /// 判断是否为null
        /// </summary>
        /// <param name="oValue">指定的object值</param>
        /// <returns>返回bool型判断结果</returns>
        public static bool IsNull(object oValue)
        {
            if (oValue == null || oValue == System.DBNull.Value)
                return true;
            else
                return false;
        }
        #endregion

        #region IsNullOrEmpty(object)
        /// <summary>
        /// 判断是否为Emtpy
        /// </summary>
        /// <param name="oValue">指定的object值</param>
        /// <returns>返回bool型判断结果</returns>
        public static bool IsNullOrEmpty(object oValue)
        {
            if (oValue == null || oValue == System.DBNull.Value || oValue.ToString() == string.Empty)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 判断是否为Emtpy
        /// </summary>
        /// <param name="oValue">指定的string值</param>
        /// <returns>返回bool型判断结果</returns>
        public static bool IsEmpty(string strValue)
        {
            if (strValue == string.Empty)
                return true;
            else
                return false;
        }
        #endregion

        #region IsEqual(object1, object2)
        /// <summary>
        /// 判断是否相等
        /// </summary>
        /// <param name="oValue">指定的object1, object2值</param>
        /// <returns>返回bool型判断结果</returns>
        public static bool IsEqual(object oValue1, object oValue2)
        {
            if (object.Equals(oValue1,oValue2))
                return true;
            if (!IsNullOrEmpty(oValue1) && !IsNullOrEmpty(oValue2))
            {
                if (oValue1.ToString().Equals(oValue2.ToString()))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 判断是否相等
        /// </summary>
        /// <param name="oValue">指定的object1, object2值</param>
        /// <returns>返回bool型判断结果</returns>
        public static bool IsEqual(string strValue1, object strValue2)
        {
            if (strValue1.Equals(strValue2))
                return true;
            return false;
        }
        #endregion

        #region IsInt32(object)
        /// <summary>
        /// 判断是否为null
        /// </summary>
        /// <param name="oValue">指定的object值</param>
        /// <returns>返回bool型判断结果</returns>
        public static bool IsInt32(object oValue)
        {
            int result;
            if (Int32.TryParse(DataConvert.GetString(oValue), out result))
                return true;
            else
                return false;
        }
        #endregion

        #region IsNaturalNumber(object)
        /// <summary>
        /// 判断是否为null
        /// </summary>
        /// <param name="oValue">指定的object值</param>
        /// <returns>返回bool型判断结果</returns>
        public static bool IsNaturalNumber(object oValue)
        {
            if (IsInt32(oValue) && DataConvert.GetInt32(oValue) >= 0)
                return true;
            else
                return false;
        }
        #endregion

        #region 是否EMail类型（XXX@XXX.XXX \w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*）
        /// <summary>
        /// 是否EMail类型（XXX@XXX.XXX \w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*）
        /// </summary>
        /// <returns>Boolean</returns>
        public static bool IsEmail(string input)
        {
            ArrayList aryResult = new ArrayList();
            return CommRegularMatch(input, @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", RegexOptions.None, ref aryResult, false);
        }
        #endregion

        #region 通用正则表达式判断函数
        /// <summary>
        /// 通用正则表达式判断函数
        /// </summary>
        /// <param name="strVerifyString">String，用于匹配的字符串</param>
        /// <param name="strRegular">String，正则表达式</param>
        /// <param name="regOption">RegexOptions，配置正则表达式的选项</param>
        /// <param name="aryResult">ArrayList，分解的字符串内容</param>
        /// <param name="IsEntirety">Boolean，是否需要完全匹配</param>
        /// <returns></returns>
        public static bool CommRegularMatch(string strVerifyString, string strRegular, System.Text.RegularExpressions.RegexOptions regOption, ref System.Collections.ArrayList aryResult, bool IsEntirety)
        {
            System.Text.RegularExpressions.Regex r;
            System.Text.RegularExpressions.Match m;

            #region 如果需要完全匹配的处理
            if (IsEntirety)
            {
                strRegular = strRegular.Insert(0, @"\A");
                strRegular = strRegular.Insert(strRegular.Length, @"\z");
            }
            #endregion

            try
            {
                r = new System.Text.RegularExpressions.Regex(strRegular, regOption);
            }
            catch (System.Exception e)
            {
                throw (e);
            }

            for (m = r.Match(strVerifyString); m.Success; m = m.NextMatch())
            {
                aryResult.Add(m);
            }

            if (aryResult.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        public static bool IsValidPathName(string pathname)
        {
            string invalidchar = new string(System.IO.Path.GetInvalidPathChars());
            Regex containsABadCharacter = new Regex("[" + Regex.Escape(invalidchar) + "]");
            if (containsABadCharacter.IsMatch(pathname))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool IsValidFileName(string filename)
        {
            Regex containsABadCharacter = new Regex("[" + Regex.Escape(System.IO.Path.GetInvalidFileNameChars().ToString()) + "]");
            if (containsABadCharacter.IsMatch(filename) )
            {
                return false; 
            }
            else
            {
                return true;
            }           
        }
    }
}
