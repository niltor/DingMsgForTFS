using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public partial class MarkdownMsg
    {
        [JsonProperty("msgtype")]
        public string Msgtype { get; set; } = "markdown";

        [JsonProperty("markdown")]
        public Markdown Markdown { get; set; }

        [JsonProperty("at")]
        public At At { get; set; }
    }

    public partial class At
    {
        [JsonProperty("atMobiles")]
        public string[] AtMobiles { get; set; }

        [JsonProperty("isAtAll")]
        public bool IsAtAll { get; set; }
    }

    public partial class Markdown
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }

    public partial class DingMsgMd
    {
        public static DingMsgMd FromJson(string json)
        {
            return JsonConvert.DeserializeObject<DingMsgMd>(json, Converter.Settings);
        }
    }
}
