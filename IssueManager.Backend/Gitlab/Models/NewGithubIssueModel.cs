using System.Text.Json.Serialization;

namespace IssueManager.Abstractions.Gitlab.Models;

public record NewGitlabIssueModel(
    [property: JsonPropertyName("title")] string Title,
    [property: JsonPropertyName("body")] string Body
    );