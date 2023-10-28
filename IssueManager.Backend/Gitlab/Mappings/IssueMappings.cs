using IssueManager.Abstractions.Gitlab.Models;
using IssueManager.Abstractions.Models;

namespace IssueManager.Abstractions.Gitlab.Mappings;

public static class IssueMappings {


    public static NewIssueModel MapGitlab(NewGitlabIssueModel model) {
        return new NewIssueModel(
            model.Title,
            model.Body
            );
    }
    public static NewGitlabIssueModel MapGitlab(NewIssueModel model) {
        return new NewGitlabIssueModel(
            model.Title,
            model.Body
            );
    }

}