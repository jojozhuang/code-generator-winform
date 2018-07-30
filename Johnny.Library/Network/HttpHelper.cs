using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Web;
using System.Threading;
using System.IO;

using Johnny.Library.Log;

namespace Johnny.Library.Network
{
    public class HttpHelper
    {
        // Fields
        private CookieContainer _cookie;
        private int _defaultdelay = 0;
        private int _delayedtime = 0;
        private int _timeout = 30;
        private int _trytimes = 3;
        private WebProxy _proxy;
        private string _message;

        public delegate void MessageChangedEventHandler(string message);
        public event MessageChangedEventHandler messageChanged;
     
        public HttpHelper()
        {
            this._cookie = new CookieContainer();
        }

        #region Get
        public string Get(string url)
        {
            return Get(url, "");
        }
        #endregion

        #region Get
        public string Get(string url, string referurl)
        {
            int tries = _trytimes;            
            while (tries-- > 0)
            {
                try
                {
                    if (this._delayedtime > 0)
                    {
                        Thread.Sleep((int)(this._delayedtime * 1000));
                    }
                    if (this._delayedtime != this._defaultdelay)
                        this._delayedtime = this._defaultdelay;
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(url));
                    request.CookieContainer = this._cookie;
                    request.Method = "GET";
                    if (!String.IsNullOrEmpty(referurl))
                    {
                        request.Referer = referurl;
                    }
                    if ((this._proxy != null) && (this._proxy.Credentials != null))
                    {
                        request.UseDefaultCredentials = true;
                    }
                    request.Proxy = this._proxy;
                    request.Timeout = this._timeout * 1000;
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("GB2312"));
                    if (_trytimes - tries > 1)
                        Message = TraceLog.SetMessageLn("第" + (_trytimes - tries).ToString() + "次尝试发送Get请求成功！");
                    return reader.ReadToEnd();
                }
                catch (ThreadAbortException ex)
                { }
                catch (ThreadInterruptedException ex)
                { }
                catch (Exception ex)
                {
                    Message = TraceLog.SetMessageLn("第" + (_trytimes - tries).ToString() + "次尝试发送Get请求失败！ 错误：" + ex.Message);
                    Message = TraceLog.SetMessageLn("URL:" + url);
                    continue;
                }
            }
            return string.Empty;
        }
        #endregion

        #region Get
        public string GetRedirect(string url, ref string query)
        {
            int tries = _trytimes;
            while (tries-- > 0)
            {
                try
                {
                    if (this._delayedtime > 0)
                    {
                        Thread.Sleep((int)(this._delayedtime * 1000));
                    }
                    if (this._delayedtime != this._defaultdelay)
                        this._delayedtime = this._defaultdelay;
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(url));
                    request.CookieContainer = this._cookie;
                    request.Method = "GET";
                    if ((this._proxy != null) && (this._proxy.Credentials != null))
                    {
                        request.UseDefaultCredentials = true;
                    }
                    request.Proxy = this._proxy;
                    request.Timeout = this._timeout * 1000;
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    if (response.ResponseUri != null)
                    {
                        query = response.ResponseUri.Query;
                    }
                    StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                    if (_trytimes - tries > 1)
                        Message = TraceLog.SetMessageLn("第" + (_trytimes - tries).ToString() + "次尝试发送Get请求成功！");
                    return reader.ReadToEnd();
                }
                catch (ThreadAbortException ex)
                { }
                catch (ThreadInterruptedException ex)
                { }
                catch (Exception ex)
                {
                    Message = TraceLog.SetMessageLn("第" + (_trytimes - tries).ToString() + "次尝试发送Get请求失败！ 错误：" + ex.Message);
                    Message = TraceLog.SetMessageLn("URL:" + url);
                    continue;
                }
            }
            return string.Empty;
        }
        #endregion

        #region Post
        public string Post(string url, string param)
        {
            return Post(url, "", param);
        }
        #endregion

        #region Post
        public string Post(string url, string referurl, string param)
        {
            int tries = _trytimes;
            while (tries-- > 0)
            {
                try
                {
                    if (this._delayedtime > 0)
                    {
                        Thread.Sleep((int)(this._delayedtime * 1000));
                    }
                    if (this._delayedtime != this._defaultdelay)
                        this._delayedtime = this._defaultdelay;
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(url));
                    request.CookieContainer = this._cookie;
                    byte[] bytes = Encoding.GetEncoding("GB2312").GetBytes(param);
                    request.Method = "POST";
                    if (!String.IsNullOrEmpty(referurl))
                    {
                        request.Referer = referurl;
                    }
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.ContentLength = bytes.Length;
                    if ((this._proxy != null) && (this._proxy.Credentials != null))
                    {
                        request.UseDefaultCredentials = true;
                    }
                    request.Proxy = this._proxy;
                    request.Timeout = this._timeout * 1000;
                    Stream requestStream = request.GetRequestStream();
                    requestStream.Write(bytes, 0, bytes.Length);
                    requestStream.Close();
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                    if (_trytimes - tries > 1)
                        Message = TraceLog.SetMessageLn("第" + (_trytimes - tries).ToString() + "次尝试发送Post请求成功！");
                    return reader.ReadToEnd();
                }
                catch (ThreadAbortException ex)
                { }
                catch (ThreadInterruptedException ex)
                { }
                catch (Exception ex)
                {
                    Message = TraceLog.SetMessageLn("第" + (_trytimes - tries).ToString() + "次尝试发送Post请求失败！ 错误：" + ex.Message);
                    Message = TraceLog.SetMessageLn("URL:" + url);
                    Message = TraceLog.SetMessage(" 参数:" + param);
                    continue;
                }
            }
            return string.Empty;
        }
        #endregion

        #region Post
        public string Post(string url, ref string query, string param)
        {
            int tries = _trytimes;
            while (tries-- > 0)
            {
                try
                {
                    if (this._delayedtime > 0)
                    {
                        Thread.Sleep((int)(this._delayedtime * 1000));
                    }
                    if (this._delayedtime != this._defaultdelay)
                        this._delayedtime = this._defaultdelay;
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(url));
                    request.CookieContainer = this._cookie;
                    byte[] bytes = Encoding.GetEncoding("GB2312").GetBytes(param);
                    request.Method = "POST";
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.ContentLength = bytes.Length;
                    if ((this._proxy != null) && (this._proxy.Credentials != null))
                    {
                        request.UseDefaultCredentials = true;
                    }
                    request.Proxy = this._proxy;
                    request.Timeout = this._timeout * 1000;
                    Stream requestStream = request.GetRequestStream();
                    requestStream.Write(bytes, 0, bytes.Length);
                    requestStream.Close();
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    if (response.ResponseUri != null)
                    {
                        query = response.ResponseUri.Query;
                    }
                    StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                    if (_trytimes - tries > 1)
                        Message = TraceLog.SetMessageLn("第" + (_trytimes - tries).ToString() + "次尝试发送Post请求成功！");
                    return reader.ReadToEnd();
                }
                catch (ThreadAbortException ex)
                { }
                catch (ThreadInterruptedException ex)
                { }
                catch (Exception ex)
                {
                    Message = TraceLog.SetMessageLn("第" + (_trytimes - tries).ToString() + "次尝试发送Post请求失败！ 错误：" + ex.Message);
                    Message = TraceLog.SetMessageLn("URL:" + url);
                    Message = TraceLog.SetMessage(" 参数:" + param);
                    continue;
                }
            }
            return string.Empty;
        }
        #endregion

        #region SetDelay
        public void SetDelay(int? delayedtime, int? timeout, int? trytimes)
        {
            if (delayedtime.HasValue)
            {
                this._defaultdelay = delayedtime.Value;
                this._delayedtime = delayedtime.Value;
            }
            if (timeout.HasValue)
                this._timeout = timeout.Value;
            if (trytimes.HasValue)
                this._trytimes = trytimes.Value;
        }
        #endregion

        #region SetProxy
        public void SetProxy(string server, int? port, string username, string password)
        {
            if ((server != null) && (server != string.Empty) && (port.HasValue) && (port.Value > 0))
            {
                this._proxy = new WebProxy(server, port.Value);
                if ((username != null) && (password != null))
                {
                    this._proxy.Credentials = new NetworkCredential(username, password);
                    this._proxy.BypassProxyOnLocal = true;
                }
            }
        }
        #endregion

        #region Properties
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                if (messageChanged != null)
                    messageChanged(_message);
            }
        }
        public int DelayedTime
        {
            get { return _delayedtime; }
            set { _delayedtime = value; }
        }
        #endregion
    }
}
