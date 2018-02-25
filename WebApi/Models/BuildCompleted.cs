using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.Build
{
    public class BuildCompleted
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
        public string Uri { get; set; }
        public long Id { get; set; }
        public string BuildNumber { get; set; }
        public string Url { get; set; }
        public System.DateTime StartTime { get; set; }
        public System.DateTime FinishTime { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }
        public string DropLocation { get; set; }
        public Drop Drop { get; set; }
        public Drop Log { get; set; }
        public string SourceGetVersion { get; set; }
        public LastChangedBy LastChangedBy { get; set; }
        public bool RetainIndefinitely { get; set; }
        public bool HasDiagnostics { get; set; }
        public Definition Definition { get; set; }
        public Queue Queue { get; set; }
        public Request[] Requests { get; set; }
    }

    public class Definition
    {
        public long BatchSize { get; set; }
        public string TriggerType { get; set; }
        public string DefinitionType { get; set; }
        public long Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class Drop
    {
        public string Location { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        public string DownloadUrl { get; set; }
    }

    public class LastChangedBy
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string UniqueName { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
    }

    public class Queue
    {
        public string QueueType { get; set; }
        public long Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class Request
    {
        public long Id { get; set; }
        public string Url { get; set; }
        public LastChangedBy RequestedFor { get; set; }
    }

    public class ResourceContainers
    {
        public Account Collection { get; set; }
        public Account Account { get; set; }
        public Account Project { get; set; }
    }

    public class Account
    {
        public string Id { get; set; }
    }

}
