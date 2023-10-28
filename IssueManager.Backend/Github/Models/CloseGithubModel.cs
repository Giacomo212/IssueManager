using System.Text.Json.Serialization;

namespace IssueManager.Abstractions.Github.Models;

public record CloseGithubModel
(
[property: JsonPropertyName("state")] string State
);