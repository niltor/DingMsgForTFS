using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.Code
{
    public class CodePushed
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
        public Commit[] Commits { get; set; }
        public RefUpdate[] RefUpdates { get; set; }
        public Repository Repository { get; set; }
        public PushedBy PushedBy { get; set; }
        public long PushId { get; set; }
        public System.DateTime Date { get; set; }
        public string Url { get; set; }
    }

    public class Commit
    {
        public string CommitId { get; set; }
        public Author Author { get; set; }
        public Author Committer { get; set; }
        public string Comment { get; set; }
        public string Url { get; set; }
    }

    public class Author
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public System.DateTime Date { get; set; }
    }

    public class PushedBy
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string UniqueName { get; set; }
    }

    public class RefUpdate
    {
        public string Name { get; set; }
        public string OldObjectId { get; set; }
        public string NewObjectId { get; set; }
    }

    public class Repository
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public Project Project { get; set; }
        public string DefaultBranch { get; set; }
        public string RemoteUrl { get; set; }
    }

    public class Project
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string State { get; set; }
        public string Visibility { get; set; }
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
