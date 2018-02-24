using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public partial class WorkItemCreated
    {
        [JsonProperty("subscriptionId")]
        public string SubscriptionId { get; set; }

        [JsonProperty("notificationId")]
        public long NotificationId { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("eventType")]
        public string EventType { get; set; }

        [JsonProperty("publisherId")]
        public string PublisherId { get; set; }

        [JsonProperty("message")]
        public Essage Message { get; set; }

        [JsonProperty("detailedMessage")]
        public Essage DetailedMessage { get; set; }

        [JsonProperty("resource")]
        public Resource Resource { get; set; }

        [JsonProperty("resourceVersion")]
        public string ResourceVersion { get; set; }

        [JsonProperty("resourceContainers")]
        public ResourceContainers ResourceContainers { get; set; }

        [JsonProperty("createdDate")]
        public System.DateTimeOffset CreatedDate { get; set; }
    }
    public partial class Essage
    {
        [JsonProperty("markdown")]
        public string Markdown { get; set; }
    }

    public partial class Resource
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("rev")]
        public long Rev { get; set; }

        [JsonProperty("fields")]
        public ResourceFields Fields { get; set; }

        [JsonProperty("_links")]
        public Links Links { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public partial class ResourceFields
    {
        [JsonProperty("System.AreaPath")]
        public string SystemAreaPath { get; set; }

        [JsonProperty("System.TeamProject")]
        public string SystemTeamProject { get; set; }

        [JsonProperty("System.IterationPath")]
        public string SystemIterationPath { get; set; }

        [JsonProperty("System.WorkItemType")]
        public string SystemWorkItemType { get; set; }

        [JsonProperty("System.State")]
        public string SystemState { get; set; }

        [JsonProperty("System.Reason")]
        public string SystemReason { get; set; }

        [JsonProperty("System.CreatedDate")]
        public System.DateTimeOffset SystemCreatedDate { get; set; }

        [JsonProperty("System.CreatedBy")]
        public string SystemCreatedBy { get; set; }

        [JsonProperty("System.ChangedDate")]
        public System.DateTimeOffset SystemChangedDate { get; set; }

        [JsonProperty("System.ChangedBy")]
        public string SystemChangedBy { get; set; }

        [JsonProperty("System.Title")]
        public string SystemTitle { get; set; }

        [JsonProperty("Microsoft.VSTS.Common.Severity")]
        public string MicrosoftVstsCommonSeverity { get; set; }

        [JsonProperty("WEF_EB329F44FE5F4A94ACB1DA153FDF38BA_Kanban.Column")]
        public string WefEb329F44Fe5F4A94Acb1Da153Fdf38BaKanbanColumn { get; set; }
    }

    public partial class Links
    {
        [JsonProperty("self")]
        public LinksFields Self { get; set; }

        [JsonProperty("workItemUpdates")]
        public LinksFields WorkItemUpdates { get; set; }

        [JsonProperty("workItemRevisions")]
        public LinksFields WorkItemRevisions { get; set; }

        [JsonProperty("workItemType")]
        public LinksFields WorkItemType { get; set; }

        [JsonProperty("fields")]
        public LinksFields Fields { get; set; }
    }

    public partial class LinksFields
    {
        [JsonProperty("href")]
        public string Href { get; set; }
    }

    public partial class ResourceContainers
    {
        [JsonProperty("collection")]
        public Account Collection { get; set; }

        [JsonProperty("account")]
        public Account Account { get; set; }

        [JsonProperty("project")]
        public Account Project { get; set; }
    }

    public partial class Account
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public partial class WorkItemCreated
    {
        public static WorkItemCreated FromJson(string json)
        {
            return JsonConvert.DeserializeObject<WorkItemCreated>(json, Converter.Settings);
        }
    }

    public static class Serialize
    {
        public static string ToJson(this Object self)
        {
            return JsonConvert.SerializeObject(self, Converter.Settings);
        }
    }

    internal class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter()
                {
                    DateTimeStyles = DateTimeStyles.AssumeUniversal,
                },
            },
        };
    }
}
