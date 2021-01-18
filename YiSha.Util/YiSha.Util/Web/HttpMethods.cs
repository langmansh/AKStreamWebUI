using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace YiSha.Util
{
    /// <summary>
    /// 版 本 Learun-ADMS V7.0.3 力软敏捷开发框架
    /// Copyright (c) 2013-2018 上海力软信息技术有限公司
    /// 创建人：力软-框架开发组
    /// 日 期：2017.03.07
    /// 描 述：mvc过滤模式
    /// </summary>
    public class HttpMethods
    {

        /// <summary>
        /// 创建HttpClient
        /// </summary>
        /// <returns></returns>
        public static HttpClient CreateHttpClient(string url, IDictionary<string, string> cookies = null)
        {
            HttpClient httpclient;
            HttpClientHandler handler = new HttpClientHandler();
            var uri = new Uri(url);
            if (cookies != null)
            {
                foreach (var key in cookies.Keys)
                {
                    string one = key + "=" + cookies[key];
                    handler.CookieContainer.SetCookies(uri, one);
                }
            }
            //如果是发送HTTPS请求  
            if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
                httpclient = new HttpClient(handler);
            }
            else
            {
                httpclient = new HttpClient(handler);
            }
            return httpclient;
        }
        /// <summary>
        /// post 请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="jsonData">请求参数</param>
        /// <returns></returns>
        public static string Post(string url,string jsonData)
        {
            HttpClient httpClient = CreateHttpClient(url);
            var postData = new StringContent(jsonData);
            postData.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
            Task<string> result = httpClient.PostAsync(url, postData).Result.Content.ReadAsStringAsync();
            return result.Result;
        }
        /// <summary>
        /// post 请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <returns></returns>
        public static string Post(string url)
        {
            HttpClient httpClient = CreateHttpClient(url);
            var postData = new StringContent("");
            postData.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
            Task<string> result = httpClient.PostAsync(url, postData).Result.Content.ReadAsStringAsync();
            return result.Result;
        }

        /// <summary>
        /// post 请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="req">请求参数</param>
        /// <returns></returns>
        public static string Post(string url, byte[] req)
        {
            HttpClient httpClient = CreateHttpClient(url);
            var postData = new ByteArrayContent(req);
            Task<string> result = httpClient.PostAsync(url, postData).Result.Content.ReadAsStringAsync();
            return result.Result;
        }

        /// <summary>
        /// get 请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <returns></returns>
        public static string Get(string url)
        {
            HttpClient httpClient = CreateHttpClient(url);
            Task<string> result = httpClient.GetAsync(url).Result.Content.ReadAsStringAsync();
            return result.Result;
        }
    }
}
