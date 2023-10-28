using System.Text.Json.Serialization;

namespace IssueManager.Abstractions.Gitlab.Models;

public record CloseGitlabIssueModel(
    [property: JsonPropertyName("state_event")] string StateEvent
);
    
