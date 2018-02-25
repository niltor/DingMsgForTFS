using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public partial class WorkItemUpdated
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


    public partial class Resource
    {

        [JsonProperty("workItemId")]
        public long WorkItemId { get; set; }

        [JsonProperty("revisedBy")]
        public object RevisedBy { get; set; }
        [JsonProperty("fields")]
        public UpdateResourceFields UpdateFields { get; set; }
        [JsonProperty("revisedDate")]
        public System.DateTimeOffset RevisedDate { get; set; }

        [JsonProperty("revision")]
        public Revision Revision { get; set; }
    }

    public partial class UpdateResourceFields
    {
        [JsonProperty("System.Rev")]
        public MicrosoftVstsCommonSeverity SystemRev { get; set; }

        [JsonProperty("System.AuthorizedDate")]
        public SystemEdDate SystemAuthorizedDate { get; set; }

        [JsonProperty("System.RevisedDate")]
        public SystemEdDate SystemRevisedDate { get; set; }

        [JsonProperty("System.State")]
        public MicrosoftVstsCommonSeverity SystemState { get; set; }

        [JsonProperty("System.Reason")]
        public MicrosoftVstsCommonSeverity SystemReason { get; set; }

        [JsonProperty("System.AssignedTo")]
        public SystemAssignedTo SystemAssignedTo { get; set; }

        [JsonProperty("System.ChangedDate")]
        public SystemEdDate SystemChangedDate { get; set; }

        [JsonProperty("System.Watermark")]
        public MicrosoftVstsCommonSeverity SystemWatermark { get; set; }

        [JsonProperty("Microsoft.VSTS.Common.Severity")]
        public MicrosoftVstsCommonSeverity MicrosoftVstsCommonSeverity { get; set; }


    }

    public partial class MicrosoftVstsCommonSeverity
    {
        [JsonProperty("oldValue")]
        public string OldValue { get; set; }

        [JsonProperty("newValue")]
        public string NewValue { get; set; }
    }

    public partial class SystemAssignedTo
    {
        [JsonProperty("newValue")]
        public string NewValue { get; set; }
    }

    public partial class SystemEdDate
    {
        [JsonProperty("oldValue")]
        public System.DateTimeOffset OldValue { get; set; }

        [JsonProperty("newValue")]
        public System.DateTimeOffset NewValue { get; set; }
    }

    public partial class Links
    {


        [JsonProperty("parent")]
        public Parent Parent { get; set; }


    }

    public partial class Parent
    {
        [JsonProperty("href")]
        public string Href { get; set; }
    }

    public partial class Revision
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("rev")]
        public long Rev { get; set; }

        [JsonProperty("fields")]
        public RevisionFields Fields { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public partial class RevisionFields
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


    public partial class WorkItemUpdated
    {
        public static WorkItemUpdated FromJson(string json)
        {
            return JsonConvert.DeserializeObject<WorkItemUpdated>(json, Converter.Settings);
        }
    }

  
}
