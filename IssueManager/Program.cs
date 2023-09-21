// See https://aka.ms/new-console-template for more information

using IssueManager.Abstractions;
using IssueManager.Abstractions.Github.Implementations;
using IssueManager.Abstractions.Implementations;
using IssueManager.Abstractions.Interfaces;
using IssueManager.Abstractions.Models;

Console.WriteLine("Please enter a repo provider");
var providerString = Console.ReadLine();
var issuemanager = new RepoManager(new RepoFactory().CreateRepo(providerString));
IRepoIDProvider repoIdProvider;
Console.WriteLine("Please enter a repo ID");
var repoString = Console.ReadLine();
if (CommonNames.GitlabName.Trim().ToLower() == providerString.ToLower().Trim())
    repoIdProvider = new GitlabIdProvider(repoString);
else if (CommonNames.GithubName.Trim().ToLower() == providerString.ToLower().Trim())
    repoIdProvider = new GithubIdProvider(repoString);
else{
    throw new Exception("Unsupported provider");
}

Console.WriteLine("Please enter what you want to do");
Console.WriteLine("1 add issue");
Console.WriteLine("2 update issue");
Console.WriteLine("3 close issue");
Console.WriteLine("4 import issue");
Console.WriteLine("5 export issue");
var chosenNumber = int.Parse(Console.ReadLine());
switch (chosenNumber){
    case 1:
        var newModel = PrepareModel(true);
        await issuemanager.AddIssue(repoIdProvider,newModel);
        break;
    case 2:
        var updateModel  = (IssueModel)PrepareModel(false)  ;
        await issuemanager.UpdateIssue(repoIdProvider, updateModel);
        break;
    case 3:
        Console.WriteLine("5 Enter issue number");
        var id = int.Parse(Console.ReadLine());
        await issuemanager.CloseIssue(repoIdProvider,id,false);
        break;
    case 4:
        var path = PreparePath();
        await issuemanager.ImportIssue(repoIdProvider,path);
        break;
    case 5:
        var pathExport = PreparePath();
        await issuemanager.ExportIssue(repoIdProvider,pathExport);
        break;
}


NewIssueModel PrepareModel(bool isNew){
    Console.WriteLine("Enter a title");

    var title = Console.ReadLine();
    Console.WriteLine("Enter a desc");
    var desc = Console.ReadLine();
    if (isNew)
        return new NewIssueModel(){
            body = desc,
            title = title
        };
    Console.WriteLine("Enter id");
    var id = int.Parse(Console.ReadLine());
    return new IssueModel(){
        body = desc,
        title = title,
        number = id
    };
}

string PreparePath(){
    Console.WriteLine("Enter a path");
    var path = Console.ReadLine();
    return path;
}