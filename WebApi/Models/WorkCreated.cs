using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.WorkCreated
{


    public class WorkCreated
    {
        public string SubscriptionId { get; set; }
        public long NotificationId { get; set; }
        public string Id { get; set; }
        public string EventType { get; set; }
        public string PublisherId { get; set; }
        public Essage Message { get; set; }
        public Essage DetailedMessage { get; set; }
        public Resource Resource { get; set; }
        public string ResourceVersion { get; set; }
        public ResourceContainers ResourceContainers { get; set; }
        public System.DateTime CreatedDate { get; set; }
    }

    public class Essage
    {
        public string Markdown { get; set; }
    }

    public class Resource
    {
        public long Id { get; set; }
        public long Rev { get; set; }
        public ResourceFields Fields { get; set; }
        public Relation[] Relations { get; set; }
        public Links Links { get; set; }
        public string Url { get; set; }
    }


    public class ResourceFields
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

        [JsonProperty("System.AssignedTo")]
        public string SystemAssignedTo { get; set; }

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

        [JsonProperty("Microsoft.VSTS.Scheduling.OriginalEstimate")]
        public double MicrosoftVstsSchedulingOriginalEstimate { get; set; }

        [JsonProperty("Microsoft.VSTS.Common.Activity")]
        public string MicrosoftVstsCommonActivity { get; set; }

        [JsonProperty("Microsoft.VSTS.Common.StateChangeDate")]
        public System.DateTimeOffset MicrosoftVstsCommonStateChangeDate { get; set; }

        [JsonProperty("Microsoft.VSTS.Common.Priority")]
        public long MicrosoftVstsCommonPriority { get; set; }

        [JsonProperty("System.Description")]
        public string SystemDescription { get; set; }

        [JsonProperty("System.History")]
        public string SystemHistory { get; set; }
    }

    public class Links
    {
        public LinksFields Self { get; set; }
        public LinksFields WorkItemUpdates { get; set; }
        public LinksFields WorkItemRevisions { get; set; }
        public LinksFields WorkItemHistory { get; set; }
        public LinksFields Html { get; set; }
        public LinksFields WorkItemType { get; set; }
        public LinksFields Fields { get; set; }
    }

    public class LinksFields
    {
        public string Href { get; set; }
    }

    public class Relation
    {
        public string Rel { get; set; }
        public string Url { get; set; }
        public Attributes Attributes { get; set; }
    }

    public class Attributes
    {
        public bool IsLocked { get; set; }
    }

    public class ResourceContainers
    {
        public Collection Collection { get; set; }
        public Collection Server { get; set; }
        public Collection Project { get; set; }
    }

    public class Collection
    {
        public string Id { get; set; }
        public string BaseUrl { get; set; }
    }



}
