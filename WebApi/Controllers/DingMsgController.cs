using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApi.Models;
using WebApi.Models.Build;
using WebApi.Models.Code;
using WebApi.Models.WorkCreated;
using WebApi.Models.WorkUpdated;
using WebApi.Services;

namespace WebApi.Controllers
{
    /// <summary>
    /// 接收TFS webhook 后向钉钉发送消息通知
    /// </summary>
    [Route("api/[controller]/[action]")]
    [Produces("application/json")]
    public class DingMsgController : Controller
    {
        readonly string workNoticeUrl = "";
        readonly string buildNoticeUrl = "";

        readonly IConfiguration _configuration;
        public DingMsgController(IConfiguration configuration)
        {
            _configuration = configuration;
            workNoticeUrl = _configuration.GetSection("Services")["DingDing:WorkNoticeUrl"];
            buildNoticeUrl = _configuration.GetSection("Services")["DingDing:BuildNoticeUrl"];
        }


        [HttpGet]
        public IActionResult Test()
        {
            return Json("ok");
        }
        /// <summary>
        /// 代码提交
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CodePushed([FromBody]CodePushed data)
        {
            var commit = data.Resource.Commits.First();
            //var repository = data.Resource.Repository;
            if (commit == null) return BadRequest();
            var text = $"### 代码推送\n\n" + $"#####{data.DetailedMessage.Markdown}";

            var sendMsg = new MarkdownMsg
            {
                Markdown = new Markdown
                {
                    Title = "代码推送",
                    Text = text
                },
                At = new At
                {
                    IsAtAll = false
                }
            };
            return Json(DingServices.SendMsgAsync(buildNoticeUrl, sendMsg).Result);

        }
        /// <summary>
        /// 生成完成
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult BuildCompleted([FromBody]BuildCompleted data)
        {
            var resource = data.Resource;
            // 用时
            TimeSpan timeSpends = resource.FinishTime - resource.StartTime;
            // 发起人
            var requestMan = resource.RequestedBy.DisplayName;
            if (requestMan.Equals("Microsoft.TeamFoundation.System")) requestMan = "系统";

            if (resource == null) return BadRequest();
            var text = $"### {resource.Definition.Name} 构建 {resource.Result}\n" +
                $"#### {data.DetailedMessage.Markdown}\n\n" +
                $"用时：{timeSpends.Seconds}秒\n\n" +
                $"请求方:{resource.RequestedBy.DisplayName}\n\n";
            var sendMsg = new MarkdownMsg
            {
                Markdown = new Markdown
                {
                    Title = $"构建{resource.Result}",
                    Text = text
                },
                At = new At
                {
                    IsAtAll = false
                }
            };
            //return Json(sendMsg);
            return Json(DingServices.SendMsgAsync(buildNoticeUrl, sendMsg).Result);
        }
        /// <summary>
        /// 创建工作项
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult WorkCreated([FromBody]WorkCreated data)
        {
            var work = data.Resource.Fields;
            var workContent = data.Resource.Fields?.SystemDescription;
            if (workContent.Length > 100)
            {
                workContent = workContent.Substring(0, 100);
            }
            if (work == null) return BadRequest();
            var text = $"### 新任务 \n\n >{data.DetailedMessage.Markdown}";
            text += $"任务内容：{workContent}";
            var sendMsg = new MarkdownMsg
            {
                Markdown = new Markdown
                {
                    Title = "新任务",
                    Text = text
                },
                At = new At
                {
                    IsAtAll = false
                }
            };
            return Json(DingServices.SendMsgAsync(workNoticeUrl, sendMsg).Result);
        }
        /// <summary>
        /// 更新工作项
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult WorkUpdated([FromBody]WorkUpdated data)
        {
            var work = data.Resource.Fields;
            var workContent = data.Resource.Revision?.Fields.SystemDescription;
            if (workContent.Length > 100)
            {
                workContent = workContent.Substring(0, 100);
            }
            if (work == null) return BadRequest();
            var text = $"### 任务更新\n\n {data.DetailedMessage.Markdown}";
            text += $"任务内容：{workContent}";
            var sendMsg = new MarkdownMsg
            {
                Markdown = new Markdown
                {
                    Title = "任务更新",
                    Text = text
                },
                At = new At
                {
                    IsAtAll = false
                }
            };
            return Json(DingServices.SendMsgAsync(workNoticeUrl, sendMsg).Result);
        }
    }
}
