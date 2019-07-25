using client.common;
using client.controll;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Configuration;

namespace client.web
{
    public static class PosService
    {
        /// <summary>
        /// POST基础方法
        /// 流水上传为50秒超时，其他的为10秒
        /// </summary>
        /// <param name="postData"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string WebService(string postData, string url, int posTime = 10000)//在没有传参的情况下赋值默认值
        {
            WXLog.Info("WebService Start");

            string json = "{\"Result\":\"FAILURE\",\"NewData\":\"false\",\"success\":\"false\",\"isSuccess\":false}";
            //创建HttpWebRequest对象
            try
            {
                //     WXLog.Debug("SendRestRequest WebService Start");
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url); //目标主机ip地址

                //模拟POST的数据
                Encoding utf8 = Encoding.UTF8;
                byte[] data = utf8.GetBytes(postData);
                request.Method = "POST";
                request.ContentType = "application/json;charset=UTF-8;";
                if (TokenInfo.TokenEd != null && TokenInfo.TokenEd.accessToken != "")
                {
                    request.Headers.Add("Authorization", TokenInfo.TokenEd.accessToken);
                    request.Headers.Add("CORP_ID", ConfigurationManager.AppSettings["CORP_ID"]);//企业ID 从配置文件中读取
                }
                request.Timeout = posTime; //超时10秒之后进行提示，这是全部的
                request.ContentLength = data.Length;
                using (Stream newStream = request.GetRequestStream())
                {
                    newStream.Write(data, 0, data.Length);
                    newStream.Close();
                }
                //获得HttpWebResponse对象
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                WXLog.Debug("SendRestRequest WebService End");
                if (response.StatusCode.ToString() != "OK")
                {
                    WXLog.Error("服务器响应失败，response.StatusCode=【" + response.StatusCode.ToString() + "】");
                    //         throw new DataAccessException(WSMessageCode.SendFailed.ToString());
                }
                //获得响应流
                Stream receiveStream = response.GetResponseStream();
                if (receiveStream != null)
                {
                    StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                    json = readStream.ReadToEnd();
                    WXLog.Info("返回数据" + json);
                    //       Console.WriteLine(json);
                    response.Close();
                    receiveStream.Close();
                    readStream.Close();
                }
            }
            catch (WebException ex)
            {
                WXLog.Error("HTTP发送数据失败：", ex);
                switch (ex.Status)
                {
                    case WebExceptionStatus.NameResolutionFailure:
                        json = "{\"Result\":\"FAILURE\",\"Message\":\"未找到服务器，请检查网络设置\",\"NewData\":\"false\",\"success\":\"false\",\"isSuccess\":false}";
                        break;
                    case WebExceptionStatus.ConnectFailure:
                        json = "{\"Result\":\"FAILURE\",\"Message\":\"与服务器链接失败，请检查网络设置\",\"NewData\":\"false\",\"success\":\"false\",\"isSuccess\":false}";
                        break;
                    case WebExceptionStatus.Timeout:
                        json = "{\"Result\":\"FAILURE\",\"Message\":\"请求超时，请重试\",\"NewData\":\"false\",\"success\":\"false\",\"isSuccess\":false}";
                        break;
                    //*************20160506 add by zxy 捕获到协议级错误时，将token过期时间置为当前，便于下次直接请求
                    case WebExceptionStatus.ProtocolError:
                        TokenInfo.TokenDateTime = DateTime.Now;
                        json = "{\"Result\":\"FAILURE\",\"Message\":\"" + ex.Message + "，请重试\",\"NewData\":\"false\",\"success\":\"false\",\"isSuccess\":false}";
                        break;
                    default:
                        json = "{\"Result\":\"FAILURE\",\"Message\":\"" + ex.Message + "\",\"NewData\":\"false\",\"success\":\"false\",\"isSuccess\":false}";
                        break;
                }
            }
            catch (Exception ex)
            {
                WXLog.Error("HTTP发送数据失败：", ex);
                json = "{\"Result\":\"FAILURE\",\"Message\":\"" + ex.Message + "\",\"NewData\":\"false\",\"success\":\"false\",\"isSuccess\":false}";
            }
            finally
            {
                WXLog.Info("SendRestRequest End");
            }

            return json;

        }


        /// <summary>
        /// 设备注册的方法
        /// </summary>
        /// <param name="postData"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string Register(string postData, string url)
        {
            return WebService(postData, url);
        }
        /// <summary>
        /// 获取Token的方法
        /// </summary>
        /// <returns></returns>
        public static bool GetToken()
        {
            WXLog.Info("开始获取Token");
            string postData = "{\"appId\":\"" + ConfigurationManager.AppSettings["appId"] + "\",\"appSecret\":\"" + ConfigurationManager.AppSettings["appSecret"] + "\"}";
            try
            {
                string json = WebService(postData, PosServiceConfig.GetTokenUrl);
                TokenData token = Tools.JsonToObject<TokenData>(json);
                if (token != null && token.data.accessToken != null)
                {
                    TokenInfo.TokenEd = token.data;
                    TokenInfo.TokenDateTime = DateTime.Now.AddSeconds(token.data.expiresIn - 2);
                    WXLog.Info("获取到Token");
                }
                else
                {
                    token = new TokenData();
                    token.data.accessToken = "";
                    TokenInfo.TokenEd = token.data;
                    TokenInfo.TokenDateTime = DateTime.Now;
                    WXLog.Info("未获取到Token");
                    return false;
                }

            }
            catch (Exception e)
            {
                Token token = new Token();
                token.accessToken = "";
                TokenInfo.TokenEd = token;
                TokenInfo.TokenDateTime = DateTime.Now;
                WXLog.Info("获取Token出错");
                return false;
            }

            return true;
        }
        /// <summary>
        /// Get方式请求
        /// </summary>
        /// <param name="postdate"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string WebGet(string postdate, string url)
        {
            string responseText = String.Empty;
            try
            {
                if (TokenInfo.TokenDateTime < DateTime.Now)
                {
                    if (!GetToken())
                    {
                        responseText =
                            "{\"Result\":\"FAILURE\",\"Message\":\"获取Token失败\",\"NewData\":\"false\",\"success\":\"false\",\"isSuccess\":false}";
                        return responseText;
                    }
                }
                url += postdate + "&accessToken=" + TokenInfo.TokenEd.accessToken;
                WXLog.Info("Get请求的URL" + url + "请求开始");
                HttpWebRequest request;
                // 创建一个HTTP请求
                //url = HttpUtility.UrlEncode(url, System.Text.Encoding.UTF8); 
                request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "get";
                HttpWebResponse response;
                response = (System.Net.HttpWebResponse)request.GetResponse();
                StreamReader myreader = new System.IO.StreamReader(response.GetResponseStream(), Encoding.UTF8);
                responseText = myreader.ReadToEnd();
                //   Console.WriteLine("responseText"+responseText);
                WXLog.Info("请求结束，返回结果" + responseText);
                myreader.Close();
            }
            catch (WebException ex)
            {
                WXLog.Error("HTTP发送数据失败：", ex);
                switch (ex.Status)
                {
                    case WebExceptionStatus.NameResolutionFailure:
                        responseText = "{\"Result\":\"FAILURE\",\"Message\":\"未找到服务器，请检查网络设置\",\"NewData\":\"false\",\"success\":\"false\",\"isSuccess\":false}";
                        break;
                    case WebExceptionStatus.ConnectFailure:
                        responseText = "{\"Result\":\"FAILURE\",\"Message\":\"与服务器链接失败，请检查网络设置\",\"NewData\":\"false\",\"success\":\"false\",\"isSuccess\":false}";
                        break;
                    case WebExceptionStatus.Timeout:
                        responseText = "{\"Result\":\"FAILURE\",\"Message\":\"请求超时，请重试\",\"NewData\":\"false\",\"success\":\"false\",\"isSuccess\":false}";
                        break;
                    //*************20160506 add by zxy 捕获到协议级错误时，将token过期时间置为当前，便于下次直接请求
                    case WebExceptionStatus.ProtocolError:
                        TokenInfo.TokenDateTime = DateTime.Now;
                        responseText = "{\"Result\":\"FAILURE\",\"Message\":\"" + ex.Message + "，请重试\",\"NewData\":\"false\",\"success\":\"false\",\"isSuccess\":false}";
                        break;
                    default:
                        responseText = "{\"Result\":\"FAILURE\",\"Message\":\"" + ex.Message + "\",\"NewData\":\"false\",\"success\":\"false\",\"isSuccess\":false}";
                        break;
                }
            }
            catch (Exception ex)
            {
                responseText = "{\"Result\":\"FAILURE\",\"Message\":\"" + ex.Message +
                               "\",\"NewData\":\"false\",\"success\":\"false\",\"isSuccess\":false}";
                WXLog.Error("Get请求失败", ex);
            }
            return responseText;
        }
        /// <summary>
        /// Get方式请求
        /// </summary>
        /// <param name="postdate"></param>
        /// <param name="url"></param>
        /// <param name="timeOut"></param>
        /// <returns></returns>
        public static string WebGet(string postdate, string url, int timeOut = 10)
        {
            string responseText = String.Empty;
            try
            {
                if (TokenInfo.TokenDateTime < DateTime.Now)
                {
                    if (!GetToken())
                    {
                        responseText =
                            "{\"Result\":\"FAILURE\",\"Message\":\"获取Token失败\",\"error\":\"获取Token失败\",\"NewData\":\"false\",\"success\":\"false\",\"isSuccess\":false}";
                        return responseText;
                    }
                }
                url += postdate + "&accessToken=" + TokenInfo.TokenEd.accessToken;
                WXLog.Info("Get请求的URL" + url + "请求开始");
                HttpWebRequest request;
                // 创建一个HTTP请求
                //url = HttpUtility.UrlEncode(url, System.Text.Encoding.UTF8); 
                request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "get";
                request.Timeout = timeOut * 1000;
                HttpWebResponse response;
                response = (System.Net.HttpWebResponse)request.GetResponse();
                StreamReader myreader = new System.IO.StreamReader(response.GetResponseStream(), Encoding.UTF8);
                responseText = myreader.ReadToEnd();
                //   Console.WriteLine("responseText"+responseText);
                WXLog.Info("请求结束，返回结果" + responseText);
                myreader.Close();
            }
            catch (WebException ex)
            {
                WXLog.Error("HTTP发送数据失败：", ex);
                switch (ex.Status)
                {
                    case WebExceptionStatus.NameResolutionFailure:
                        responseText = "{\"Result\":\"FAILURE\",\"Message\":\"未找到服务器，请检查网络设置\",\"error\":\"未找到服务器，请检查网络设置\",\"NewData\":\"false\",\"success\":\"false\",\"isSuccess\":false}";
                        break;
                    case WebExceptionStatus.ConnectFailure:
                        responseText = "{\"Result\":\"FAILURE\",\"Message\":\"与服务器链接失败，请检查网络设置\",\"error\":\"与服务器链接失败，请检查网络设置\",\"NewData\":\"false\",\"success\":\"false\",\"isSuccess\":false}";
                        break;
                    case WebExceptionStatus.Timeout:
                        responseText = "{\"Result\":\"FAILURE\",\"Message\":\"请求超时，请重试\",\"NewData\":\"false\",\"error\":\"请求超时，请重试\",\"success\":\"false\",\"isSuccess\":false}";
                        break;
                    //*************20160506 add by zxy 捕获到协议级错误时，将token过期时间置为当前，便于下次直接请求
                    case WebExceptionStatus.ProtocolError:
                        TokenInfo.TokenDateTime = DateTime.Now;
                        responseText = "{\"Result\":\"FAILURE\",\"Message\":\"" + ex.Status + "，请重试\",\"NewData\":\"false\",\"success\":\"false\",\"isSuccess\":false}";
                        break;
                    default:
                        responseText = "{\"Result\":\"FAILURE\",\"Message\":\"" + ex.Message + "\",\"error\":\"" + ex.Message + "\",\"NewData\":\"false\",\"success\":\"false\",\"isSuccess\":false}";
                        break;
                }
            }
            catch (Exception ex)
            {
                responseText = "{\"Result\":\"FAILURE\",\"Message\":\"" + ex.Message +
                               "\",\"error\":\"" + ex.Message +
                               "\",\"NewData\":\"false\",\"success\":\"false\",\"isSuccess\":false}";
                WXLog.Error("Get请求失败", ex);
            }
            return responseText;
        }
        /// <summary>
        /// POST方式请求
        /// </summary>
        /// <param name="postdate"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string WebPost(string postdate, string url, int posTime = 10000) //在没有传参的情况下赋值默认值
        {
            if (TokenInfo.TokenDateTime < DateTime.Now)
            {
                if (!GetToken())
                {
                    return "{\"Result\":\"FAILURE\",\"Message\":\"获取Token失败\",\"NewData\":\"false\",\"success\":\"false\",\"isSuccess\":\"false\"}";
                }
            }
            WXLog.Info("开始发送数据" + postdate);
            return WebService(postdate, url, posTime);
        }
    }

}