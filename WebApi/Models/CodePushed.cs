using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public partial class CodePushed
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
        [JsonProperty("commits")]
        public Commit[] Commits { get; set; }

        [JsonProperty("refUpdates")]
        public RefUpdate[] RefUpdates { get; set; }

        [JsonProperty("repository")]
        public Repository Repository { get; set; }

        [JsonProperty("pushedBy")]
        public PushedBy PushedBy { get; set; }

        [JsonProperty("pushId")]
        public long PushId { get; set; }

        [JsonProperty("date")]
        public System.DateTimeOffset Date { get; set; }

    }

    public partial class Commit
    {
        [JsonProperty("commitId")]
        public string CommitId { get; set; }

        [JsonProperty("author")]
        public Author Author { get; set; }

        [JsonProperty("committer")]
        public Author Committer { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public partial class Author
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("date")]
        public System.DateTimeOffset Date { get; set; }
    }

    public partial class PushedBy
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("uniqueName")]
        public string UniqueName { get; set; }
    }

    public partial class RefUpdate
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("oldObjectId")]
        public string OldObjectId { get; set; }

        [JsonProperty("newObjectId")]
        public string NewObjectId { get; set; }
    }

    public partial class Repository
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("project")]
        public Project Project { get; set; }

        [JsonProperty("defaultBranch")]
        public string DefaultBranch { get; set; }

        [JsonProperty("remoteUrl")]
        public string RemoteUrl { get; set; }
    }

    public partial class Project
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("visibility")]
        public string Visibility { get; set; }
    }


    public partial class CodePushed
    {
        public static CodePushed FromJson(string json) => JsonConvert.DeserializeObject<CodePushed>(json, Converter.Settings);
    }
}
