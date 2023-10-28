using System.Text.Json.Serialization;

namespace IssueManager.Abstractions.Models;

public record IssueModel(
    string Title,
    string Body,
    int number
    ) : NewIssueModel(
        Title,
        Body
        );