using IssueManager.Abstractions.Github.Models;
using IssueManager.Abstractions.Models;

namespace IssueManager.Abstractions.Github.Mappings;

public static class IssueMappings {


    public static NewIssueModel MapGithub(NewGithubIssueModel model) {
        return new NewIssueModel() {
            body = model.body,
            title = model.title
        };
    }
    public static NewGithubIssueModel MapGithub(NewIssueModel model) {
        return new NewGithubIssueModel() {
            body = model.body,
            title = model.title
        };
    }


}