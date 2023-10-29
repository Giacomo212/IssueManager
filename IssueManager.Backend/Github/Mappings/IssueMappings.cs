using IssueManager.Abstractions.Github.Models;
using IssueManager.Abstractions.Models;

namespace IssueManager.Abstractions.Github.Mappings;

public static class IssueMappings {


    public static NewIssueModel MapGithub(NewGithubIssueModel model){
        return new NewIssueModel(
            model.Body,
            model.Title
            );
    }
    public static NewGithubIssueModel MapGithub(NewIssueModel model) {
        return new NewGithubIssueModel(
            model.Body,
            model.Title
        );
    }


}
