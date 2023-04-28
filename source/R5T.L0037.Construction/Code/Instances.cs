using System;


namespace R5T.L0037.Construction
{
    public static class Instances
    {
        public static L0038.IApplicationContextOperator ApplicationContextOperator => L0038.ApplicationContextOperator.Instance;
        public static F0053.ICodeFileGenerator CodeFileGenerator => F0053.CodeFileGenerator.Instance;
        public static Z0036.ICommitMessages CommitMessages => Z0036.CommitMessages.Instance;
        public static F0019.IGitOperator GitOperator => F0019.GitOperator.Instance;
        public static F0041.IGitHubOperator GitHubOperator => F0041.GitHubOperator.Instance;
        public static L0036.IGitHubRepositoryContextOperations GitHubRepositoryContextOperations => L0036.GitHubRepositoryContextOperations.Instance;
        public static ILocalGitRepositoryContextOperations LocalGitRepositoryContextOperations => L0037.LocalGitRepositoryContextOperations.Instance;
        public static ILocalRepositoryContextOperations LocalRepositoryContextOperations => L0037.LocalRepositoryContextOperations.Instance;
        public static F0033.INotepadPlusPlusOperator NotepadPlusPlusOperator => F0033.NotepadPlusPlusOperator.Instance;
        public static IOperator Operator => Construction.Operator.Instance;
        public static IOperations Operations => Construction.Operations.Instance;
        public static Z0043.IOwnerNames OwnerNames => Z0043.OwnerNames.Instance;
        public static F0002.IPathOperator PathOperator => F0002.PathOperator.Instance;
        public static IProjectContextOperations ProjectContextOperations => L0037.ProjectContextOperations.Instance;
        public static L0033.IProjectElementContextOperations ProjectElementContextOperations => L0033.ProjectElementContextOperations.Instance;
        public static F0052.IProjectPathsOperator ProjectPathsOperator => F0052.ProjectPathsOperator.Instance;
        public static IRepositoryContextOperator RepositoryContextOperator => L0037.RepositoryContextOperator.Instance;
        public static Z0042.IRepositoryDescriptions RepositoryDescriptions => Z0042.RepositoryDescriptions.Instance;
        public static Z0042.IRepositoryNames RepositoryNames => Z0042.RepositoryNames.Instance;
        public static IRepositoryContextOperations RepositoryContextOperations => L0037.RepositoryContextOperations.Instance;
        public static ISolutionContextOperations SolutionContextOperations => L0037.SolutionContextOperations.Instance;
        public static F0024.ISolutionFileOperator SolutionFileOperator => F0024.SolutionFileOperator.Instance;
        public static T0159.F000.ITextOutputOperator TextOutputOperator => T0159.F000.TextOutputOperator.Instance;
        public static IValues Values => Construction.Values.Instance;
        public static F0088.IVisualStudioOperator VisualStudioOperator => F0088.VisualStudioOperator.Instance;
        public static F0034.IWindowsExplorerOperator WindowsExplorerOperator => F0034.WindowsExplorerOperator.Instance;
    }
}