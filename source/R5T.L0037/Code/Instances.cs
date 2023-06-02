using System;


namespace R5T.L0037
{
    public static class Instances
    {
        public static F0000.IActionOperations ActionOperations => F0000.ActionOperations.Instance;
        public static F0000.IActionOperator ActionOperator => F0000.ActionOperator.Instance;
        public static F0053.ICodeFileGenerator CodeFileGenerator => F0053.CodeFileGenerator.Instance;
        public static ICodeFileNameOperator CodeFileNameOperator => L0037.CodeFileNameOperator.Instance;
        public static ICodeGenerator CodeGenerator => L0037.CodeGenerator.Instance;
        public static Z0036.ICommitMessages CommitMessages => Z0036.CommitMessages.Instance;
        public static L0031.IContextOperator ContextOperator => L0031.ContextOperator.Instance;
        public static F0041.IDirectoryPathOperator DirectoryPathOperator => F0041.DirectoryPathOperator.Instance;
        public static F0124.IFileOperator FileOperator => F0124.FileOperator.Instance;
        public static F0000.IFileSystemOperator FileSystemOperator => F0000.FileSystemOperator.Instance;
        public static F0041.IGitHubOperator GitHubOperator => F0041.GitHubOperator.Instance;
        public static L0036.IGitHubRepositoryContextOperator GitHubRepositoryContextOperator => L0036.GitHubRepositoryContextOperator.Instance;
        public static F0019.IGitOperator GitOperator => F0019.GitOperator.Instance;
        public static L0047.F000.ILocalGitRepositoryContextOperator LocalGitRepositoryContextOperator => L0047.F000.LocalGitRepositoryContextOperator.Instance;
        public static F0042.ILocalRepositoryOperator LocalRepositoryOperator => F0042.LocalRepositoryOperator.Instance;
        public static F0059.ILoggingOperator LoggingOperator => F0059.LoggingOperator.Instance;
        public static F0002.IPathOperator PathOperator => F0002.PathOperator.Instance;
        public static L0040.IProjectContextOperations ProjectContextOperations => L0040.ProjectContextOperations.Instance;
        public static IProjectDirectoryRelativePaths ProjectDirectoryRelativePaths => L0037.ProjectDirectoryRelativePaths.Instance;
        public static L0033.IProjectElementContextOperations ProjectElementContextOperations => L0033.ProjectElementContextOperations.Instance;
        public static L0033.IProjectFileContextOperator ProjectFileContextOperator => L0033.ProjectFileContextOperator.Instance;
        public static F0020.IProjectFileOperator ProjectFileOperator => F0020.ProjectFileOperator.Instance;
        public static Z0045.IProjectFileReferences ProjectFileReferences => Z0045.ProjectFileReferences.Instance;
        public static Z0045.Raw.IProjectFileReferences ProjectFileReferences_Raw => Z0045.Raw.ProjectFileReferences.Instance;
        public static F0056.IProjectOperations ProjectOperations => F0056.ProjectOperations.Instance;
        public static IProjectPathsOperator ProjectPathsOperator => L0037.ProjectPathsOperator.Instance;
        public static IRepositoryContextConstructors RepositoryContextConstructors => L0037.RepositoryContextConstructors.Instance;
        public static F0042.F002.IRepositoryFilesOperator RepositoryFilesOperator => F0042.F002.RepositoryFilesOperator.Instance;
        public static F0042.IRepositoryOperator RepositoryOperator => F0042.RepositoryOperator.Instance;
        public static F0057.IRepositoryPathsOperator RepositoryPathsOperator => F0057.RepositoryPathsOperator.Instance;
        public static Internal.ISolutionContextOperator SolutionContextOperator_Internal => Internal.SolutionContextOperator.Instance;
        public static ISolutionContextOperations SolutionContextOperations => L0037.SolutionContextOperations.Instance;
        public static F0024.ISolutionFileGenerator SolutionFileGenerator => F0024.SolutionFileGenerator.Instance;
        public static F0050.ISolutionFileNameOperator SolutionFileNameOperator => F0050.SolutionFileNameOperator.Instance;
        public static F0024.ISolutionFileOperator SolutionFileOperator => F0024.SolutionFileOperator.Instance;
        public static F0129.ISolutionPathsOperator SolutionPathsOperator => F0129.SolutionPathsOperator.Instance;
        public static F0063.ISolutionOperations SolutionOperations => F0063.SolutionOperations.Instance;
        public static Extensions.IStringOperator StringOperator_Extensions => Extensions.StringOperator.Instance;
        public static F0054.ITextFileGenerator TextFileGenerator => F0054.TextFileGenerator.Instance;
        public static ITypeNameOperator TypeNameOperator => L0037.TypeNameOperator.Instance;
    }
}