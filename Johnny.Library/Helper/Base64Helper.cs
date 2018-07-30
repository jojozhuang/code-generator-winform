using System;
using System.Collections.Generic;
using System.Text;

namespace Johnny.Library.Helper
{
    public class Base64Helper
    {
        //--------------------------------------------------------------------------------
        /// <summary>
        /// 将字符串使用base64算法加密
        /// </summary>
        /// <param name="sourceString">待加密的字符串</param>
        /// <param name="ens">System.Text.Encoding 对象，如创建中文编码集对象：System.Text.Encoding.GetEncoding(54936)</param>
        /// <returns>加码后的文本字符串</returns>
        public static string EncodingForString(string sourceString, System.Text.Encoding ens)
        {
            return Convert.ToBase64String(ens.GetBytes(sourceString));
        }


        /// <summary>
        /// 将字符串使用base64算法加密
        /// </summary>
        /// <param name="sourceString">待加密的字符串</param>
        /// <returns>加码后的文本字符串</returns>
        public static string EncodingForString(string sourceString)
        {
            return EncodingForString(sourceString, System.Text.Encoding.GetEncoding(54936));
        }


        /// <summary>
        /// 从base64编码的字符串中还原字符串，支持中文
        /// </summary>
        /// <param name="base64String">base64加密后的字符串</param>
        /// <param name="ens">System.Text.Encoding 对象，如创建中文编码集对象：System.Text.Encoding.GetEncoding(54936)</param>
        /// <returns>还原后的文本字符串</returns>
        public static string DecodingForString(string base64String, System.Text.Encoding ens)
        {
            /**
            * ***********************************************************
            * 
            * 从base64String中取得的字节值为字符的机内码（ansi字符编码）
            * 一般的，用机内码转换为汉字是公式：
            * (char)(第一字节的二进制值*256+第二字节值)
            * 而在c#中的char或string由于采用了unicode编码，就不能按照上面的公式计算了
            * ansi的字节编和unicode编码不兼容
            * 故利用.net类库提供的编码类实现从ansi编码到unicode代码的转换
            * 
            * GetEncoding 方法依赖于基础平台支持大部分代码页。但是，对于下列情况提供系统支持：默认编码，即在执行此方法的计算机的区域设置中指定的编码；Little-Endian Unicode (UTF-16LE)；Big-Endian Unicode (UTF-16BE)；Windows 操作系统 (windows-1252)；UTF-7；UTF-8；ASCII 以及 GB18030（简体中文）。
            *
            *指定下表中列出的其中一个名称以获取具有对应代码页的系统支持的编码。
            *
            * 代码页 名称 
            * 1200 “UTF-16LE”、“utf-16”、“ucs-2”、“unicode”或“ISO-10646-UCS-2” 
            * 1201 “UTF-16BE”或“unicodeFFFE” 
            * 1252 “windows-1252” 
            * 65000 “utf-7”、“csUnicode11UTF7”、“unicode-1-1-utf-7”、“unicode-2-0-utf-7”、“x-unicode-1-1-utf-7”或“x-unicode-2-0-utf-7” 
            * 65001 “utf-8”、“unicode-1-1-utf-8”、“unicode-2-0-utf-8”、“x-unicode-1-1-utf-8”或“x-unicode-2-0-utf-8” 
            * 20127 “us-ascii”、“us”、“ascii”、“ANSI_X3.4-1968”、“ANSI_X3.4-1986”、“cp367”、“csASCII”、“IBM367”、“iso-ir-6”、“ISO646-US”或“ISO_646.irv:1991” 
            * 54936 “GB18030” 
            *
            * 某些平台可能不支持特定的代码页。例如，Windows 98 的美国版本可能不支持日语 Shift-jis 代码页（代码页 932）。这种情况下，GetEncoding 方法将在执行下面的 C# 代码时引发 NotSupportedException：
            *
            * Encoding enc = Encoding.GetEncoding("shift-jis"); 
            *
            * **************************************************************/
            //从base64String中得到原始字符
            return ens.GetString(Convert.FromBase64String(base64String));
        }


        /// <summary>
        /// 从base64编码的字符串中还原字符串，支持中文
        /// </summary>
        /// <param name="base64String">base64加密后的字符串</param>
        /// <returns>还原后的文本字符串</returns>
        public static string DecodingForString(string base64String)
        {
            return DecodingForString(base64String, System.Text.Encoding.GetEncoding(54936));
        }


        //--------------------------------------------------------------------------------------

        /// <summary>
        /// 对任意类型的文件进行base64加码
        /// </summary>
        /// <param name="fileName">文件的路径和文件名</param>
        /// <returns>对文件进行base64编码后的字符串</returns>
        public static string EncodingForFile(string fileName)
        {
            System.IO.FileStream fs = System.IO.File.OpenRead(fileName);
            System.IO.BinaryReader br = new System.IO.BinaryReader(fs);

            /*System.Byte[] b=new System.Byte[fs.Length];
            fs.Read(b,0,Convert.ToInt32(fs.Length));*/


            string base64String = Convert.ToBase64String(br.ReadBytes((int)fs.Length));


            br.Close();
            fs.Close();
            return base64String;
        }

        /// <summary>
        /// 把经过base64编码的字符串保存为文件
        /// </summary>
        /// <param name="base64String">经base64加码后的字符串</param>
        /// <param name="fileName">保存文件的路径和文件名</param>
        /// <returns>保存文件是否成功</returns>
        public static bool SaveDecodingToFile(string base64String, string fileName)
        {
            System.IO.FileStream fs = new System.IO.FileStream(fileName, System.IO.FileMode.Create);
            System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs);
            bw.Write(Convert.FromBase64String(base64String));
            bw.Close();
            fs.Close();
            return true;
        }


        //-------------------------------------------------------------------------------

        /// <summary>
        /// 从网络地址一取得文件并转化为base64编码
        /// </summary>
        /// <param name="url">文件的url地址,一个绝对的url地址</param>
        /// <param name="objWebClient">System.Net.WebClient 对象</param>
        /// <returns></returns>
        public static string EncodingFileFromUrl(string url, System.Net.WebClient objWebClient)
        {
            return Convert.ToBase64String(objWebClient.DownloadData(url));
        }


        /// <summary>
        /// 从网络地址一取得文件并转化为base64编码
        /// </summary>
        /// <param name="url">文件的url地址,一个绝对的url地址</param>
        /// <returns>将文件转化后的base64字符串</returns>
        public static string EncodingFileFromUrl(string url)
        {
            //System.Net.WebClient myWebClient = new System.Net.WebClient();
            return EncodingFileFromUrl(url, new System.Net.WebClient());
        }
    }
}
