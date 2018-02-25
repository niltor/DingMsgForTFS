using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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
                var data = new StringContent(JsonConvert.SerializeObject(msg), Encoding.UTF8, "application/json");

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
