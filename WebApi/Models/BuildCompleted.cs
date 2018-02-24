using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public partial class BuildCompleted
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
        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("buildNumber")]
        public string BuildNumber { get; set; }

        [JsonProperty("startTime")]
        public System.DateTimeOffset StartTime { get; set; }

        [JsonProperty("finishTime")]
        public System.DateTimeOffset FinishTime { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("dropLocation")]
        public string DropLocation { get; set; }

        [JsonProperty("drop")]
        public Drop Drop { get; set; }

        [JsonProperty("log")]
        public Drop Log { get; set; }

        [JsonProperty("sourceGetVersion")]
        public string SourceGetVersion { get; set; }

        [JsonProperty("lastChangedBy")]
        public LastChangedBy LastChangedBy { get; set; }

        [JsonProperty("retainIndefinitely")]
        public bool RetainIndefinitely { get; set; }

        [JsonProperty("hasDiagnostics")]
        public bool HasDiagnostics { get; set; }

        [JsonProperty("definition")]
        public Definition Definition { get; set; }

        [JsonProperty("queue")]
        public Queue Queue { get; set; }

        [JsonProperty("requests")]
        public Request[] Requests { get; set; }
    }

    public partial class Definition
    {
        [JsonProperty("batchSize")]
        public long BatchSize { get; set; }

        [JsonProperty("triggerType")]
        public string TriggerType { get; set; }

        [JsonProperty("definitionType")]
        public string DefinitionType { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public partial class Drop
    {
        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("downloadUrl")]
        public string DownloadUrl { get; set; }
    }

    public partial class LastChangedBy
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("uniqueName")]
        public string UniqueName { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }
    }

    public partial class Queue
    {
        [JsonProperty("queueType")]
        public string QueueType { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public partial class Request
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("requestedFor")]
        public LastChangedBy RequestedFor { get; set; }
    }

    public partial class BuildCompleted
    {
        public static BuildCompleted FromJson(string json) => JsonConvert.DeserializeObject<BuildCompleted>(json, Converter.Settings);
    }
}
