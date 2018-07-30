using System;
using System.Collections.Generic;
using System.Text;

using System.Web;

namespace Johnny.Library.Helper
{
    public class DataConvert
    {
        #region GetString(object)
        public static string GetString(object oValue)
        {
            if (oValue == null || oValue == System.DBNull.Value)
            {
                return String.Empty;
            }
            else
            {
                try
                {
                    return System.Convert.ToString(oValue, System.Globalization.CultureInfo.InvariantCulture);
                }
                catch
                {
                    return String.Empty;
                }
            }            
        }
        #endregion

        #region GetDigitLetter
        /// <summary>
        /// GetDigitLetter removes characters that are not number or letter from the input string.
        /// </summary>
        /// <param name="input">input string value. </param>
        /// <returns>a string value only contains numbers or letters (from 0 to 9 or a(A) to z(Z)). </returns>
        public static string GetDigitLetter(string input)
        {
            StringBuilder sb = new StringBuilder();
            if (!String.IsNullOrEmpty(input))
            {
                foreach (char c in input)
                {
                    if (char.IsLetterOrDigit(c))
                    {
                        sb.Append(c);
                    }
                }
            }
            return sb.ToString();
        }
        #endregion

        #region GetInt32(object)
        public static int GetInt32(object oValue)
        {            
            if (oValue is Enum)
            {
                return Convert.ToInt32(oValue);
            }
                
            int result;
            if (Int32.TryParse(GetString(oValue), out result))
                return result;
            else
                return 0;
        }
        #endregion

        #region GetBool(object)
        public static bool GetBool(object oValue)
        {
            bool result;
            Boolean.TryParse(GetString(oValue), out result);
            return result;            
        }
        #endregion

        #region GetBool(object)
        public static bool GetBool(int i)
        {
            return (i == 1) ? true : false;
        }
        #endregion

        #region GetEncodeData(string)
        public static string GetEncodeData(string str)
        {
            return HttpUtility.UrlEncode(str);           
        }
        #endregion
    }


}
