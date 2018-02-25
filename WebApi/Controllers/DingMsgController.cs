using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    /// <summary>
    /// 接收TFS webhook 后向钉钉发送消息通知
    /// </summary>
    [Route("api/[controller]")]
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
            var text = $@"**作者:** {commit.Author.Name}\n
提交：[{commit.Comment}]({commit.Url})\n";

            var sendMsg = new MarkdownMsg
            {
                Markdown = new Markdown
                {
                    Title = data.DetailedMessage.Markdown,
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
            if (resource == null) return BadRequest();
            var text = $@"{resource.LastChangedBy.DisplayName} {resource.Reason} 创建,结果:**{resource.Status}**\n
[日志]({resource.Log.Url})\n";
            var sendMsg = new MarkdownMsg
            {
                Markdown = new Markdown
                {
                    Title = data.DetailedMessage.Markdown,
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
        /// 创建工作项
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult WorkCreated([FromBody]WorkItemCreated data)
        {
            var work = data.Resource.Fields;
            if (work == null) return BadRequest();
            var text = $@"{work.SystemCreatedBy} 创建了 {work.SystemWorkItemType}：{work.SystemTitle}";
            var sendMsg = new MarkdownMsg
            {
                Markdown = new Markdown
                {
                    Title = data.Message.Markdown,
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
        public IActionResult WorkUpdated([FromBody]WorkItemUpdated data)
        {
            var work = data.Resource.UpdateFields;
            if (work == null) return BadRequest();
            var text = $@"状态:{work.SystemState.OldValue}=>{work.SystemState.NewValue}\n
指派给：{work.SystemAssignedTo}";
            var sendMsg = new MarkdownMsg
            {
                Markdown = new Markdown
                {
                    Title = data.DetailedMessage.Markdown,
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
