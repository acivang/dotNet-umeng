using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using qiezi.web.www.common;

namespace qiezi.service.message.pushmessage
{
    public class Notification
    {
        protected string AppMasterSecret; 
        protected async Task<ResponseResult> Send(Message message)
        {
            var result = new ResponseResult();
            message.timestamp = Convert.ToInt64((DateTime.UtcNow-new DateTime(1970,1,1,0,0,0,0)).TotalSeconds).ToString();
            message.production_mode = PushConfig.PRODUCTION_MODE;
            var postBody = JsonConvert.SerializeObject(message);
            var method = "POST";
            var sign = MD5Helper.MD5Value(method + PushConfig.APP_HOST + PushConfig.APP_URL + postBody + AppMasterSecret).ToLower();
            var url = $"{PushConfig.APP_URL}?sign={sign}";

            var client = new HttpClient {BaseAddress = new Uri(PushConfig.APP_HOST) };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.PostAsJsonAsync(url, message);
            if (response.IsSuccessStatusCode)
            {
                response.Content.ReadAsStreamAsync().ContinueWith(
                    (contentTask) =>
                    {
                        if (contentTask.IsCanceled)
                        {
                            return;
                        }
                        if (contentTask.IsFaulted)
                        {
                            throw contentTask.Exception;
                        }
                        var stream = contentTask.Result;
                        var reader = new StreamReader(stream);
                        result = JsonConvert.DeserializeObject<ResponseResult>(reader.ReadToEnd());
                    }).Wait();
            }

            return result;
        }
    }
}