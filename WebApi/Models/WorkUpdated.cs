namespace WebApi.Models.WorkUpdated
{

    public class WorkUpdated
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
        public long WorkItemId { get; set; }
        public long Rev { get; set; }
        public object RevisedBy { get; set; }
        public System.DateTime RevisedDate { get; set; }
        public ResourceFields Fields { get; set; }
        public Links Links { get; set; }
        public string Url { get; set; }
        public Revision Revision { get; set; }
    }

    public class ResourceFields
    {
        public MicrosoftVstsCommonSeverity SystemRev { get; set; }
        public SystemEdDate SystemAuthorizedDate { get; set; }
        public SystemEdDate SystemRevisedDate { get; set; }
        public MicrosoftVstsCommonSeverity SystemState { get; set; }
        public MicrosoftVstsCommonSeverity SystemReason { get; set; }
        public SystemAssignedTo SystemAssignedTo { get; set; }
        public SystemEdDate SystemChangedDate { get; set; }
        public MicrosoftVstsCommonSeverity SystemWatermark { get; set; }
        public MicrosoftVstsCommonSeverity MicrosoftVstsCommonSeverity { get; set; }
    }

    public class MicrosoftVstsCommonSeverity
    {
        public string OldValue { get; set; }
        public string NewValue { get; set; }
    }

    public class SystemAssignedTo
    {
        public string NewValue { get; set; }
    }

    public class SystemEdDate
    {
        public System.DateTime OldValue { get; set; }
        public System.DateTime NewValue { get; set; }
    }

    public class Links
    {
        public Parent Self { get; set; }
        public Parent Parent { get; set; }
        public Parent WorkItemUpdates { get; set; }
    }

    public class Parent
    {
        public string Href { get; set; }
    }

    public class Revision
    {
        public long Id { get; set; }
        public long Rev { get; set; }
        public RevisionFields Fields { get; set; }
        public string Url { get; set; }
    }

    public class RevisionFields
    {
        public string SystemAreaPath { get; set; }
        public string SystemTeamProject { get; set; }
        public string SystemIterationPath { get; set; }
        public string SystemWorkItemType { get; set; }
        public string SystemState { get; set; }
        public string SystemReason { get; set; }
        public System.DateTime SystemCreatedDate { get; set; }
        public string SystemCreatedBy { get; set; }
        public System.DateTime SystemChangedDate { get; set; }
        public string SystemChangedBy { get; set; }
        public string SystemTitle { get; set; }
        public string MicrosoftVstsCommonSeverity { get; set; }
        public string WefEb329F44Fe5F4A94Acb1Da153Fdf38BaKanbanColumn { get; set; }
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
