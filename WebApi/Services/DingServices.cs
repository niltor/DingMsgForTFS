using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Services
{
    public class DingServices
    {

        public static async Task<string> SendMsgAsync(string url, MarkdownMsg msg)
        {
            using (var hc = new HttpClient())
            {
                hc.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json;charset=utf-8");
                var data = new StringContent(msg.ToJson());

                var result = await hc.PostAsync(url, data);
                if (result.IsSuccessStatusCode)
                {
                    return result.Content.ReadAsStringAsync().Result;
                }
                return default;
            }
        }
    }
}
