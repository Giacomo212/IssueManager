using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;

namespace IssueManager.Abstractions.Models;

public record NewIssueModel(
     string title,
     string body
    );


