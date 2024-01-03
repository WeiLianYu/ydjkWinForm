using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using 移动家客WinApp.Model.Output;

namespace 移动家客WinApp.Comm
{
    internal class HttpWebRequestHelper
    {
        public static async Task<BaseDto<T>> HttpApi<T>(string url, string jsonstr, string Method, string token)
        {
            Loger.WriteLog($"url:{url}; \r\n jsonstr:{jsonstr}", "WebApi");
            try
            {
                return Task.Run(async () =>
                {
                    Encoding encoding = Encoding.UTF8;
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);//webrequest请求api地址
                    request.Accept = "application/json, text/plain, */*";
                    request.ContentType = "application/json;charset=UTF-8";
                    request.Method = Method.ToUpper().ToString();//get或者post
                    if (!string.IsNullOrWhiteSpace(token))
                    {
                        request.Headers.Add("Authorization", "Bearer " + token);
                    }
                    if (!string.IsNullOrWhiteSpace(jsonstr))
                    {
                        byte[] buffer = encoding.GetBytes(jsonstr);
                        request.ContentLength = buffer.Length;
                        var RequestStream = await request.GetRequestStreamAsync();
                        await RequestStream.WriteAsync(buffer, 0, buffer.Length);
                        RequestStream.Close();
                    }
                    using (HttpWebResponse response = (HttpWebResponse) await request.GetResponseAsync())
                    {
                        using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                        {
                            var api_Result = await reader.ReadToEndAsync();
                            if (!string.IsNullOrWhiteSpace(api_Result))
                            {
                                var api_Data = JsonConvert.DeserializeObject<BaseDto<T>>(api_Result);
                                return api_Data;
                            }
                        }
                    }
                    return new BaseDto<T>();
                }).Result;
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new BaseDto<T> { error = true, errormessage = $"WebAPI接口异常：{url}", errorcode = "501" });
            }
        }
    }
}