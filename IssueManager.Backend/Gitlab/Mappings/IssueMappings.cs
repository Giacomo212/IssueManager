using IssueManager.Abstractions.Gitlab.Models;
using IssueManager.Abstractions.Models;

namespace IssueManager.Abstractions.Gitlab.Mappings;

public static class IssueMappings {


    public static NewIssueModel MapGitlab(NewGitlabIssueModel model) {
        return new NewIssueModel() {
            body = model.body,

            title = model.title
        };
    }
    public static NewGitlabIssueModel MapGitlab(NewIssueModel model) {
        return new NewGitlabIssueModel() {
            body = model.body,

            title = model.title
        };
    }

}