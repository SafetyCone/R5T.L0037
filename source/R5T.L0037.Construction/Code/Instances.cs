using R5T.T0161;
using System;


namespace R5T.L0037.Construction
{
    public static class Instances
    {
        public static F0000.IActionOperations ActionOperations => F0000.ActionOperations.Instance;
        public static L0038.IApplicationContextOperator ApplicationContextOperator => L0038.ApplicationContextOperator.Instance;
        public static ICodeFileGenerator CodeFileGenerator => L0037.CodeFileGenerator.Instance;
        public static ICodeGenerator CodeGenerator => L0037.CodeGenerator.Instance;
        public static Z0036.ICommitMessages CommitMessages => Z0036.CommitMessages.Instance;
        public static IExampleProjectDirectoryPaths ExampleProjectDirectoryPaths => Construction.ExampleProjectDirectoryPaths.Instance;
        public static IExampleProjectNames ExampleProjectNames => Construction.ExampleProjectNames.Instance;
        public static IExampleSolutionDirectoryPaths ExampleSolutionDirectoryPaths => Construction.ExampleSolutionDirectoryPaths.Instance;
        public static IExampleSolutionNames ExampleSolutionNames => Construction.ExampleSolutionNames.Instance;
        public static F0000.IFileOperator FileOperator => F0000.FileOperator.Instance;
        public static Z0015.IFilePaths FilePaths => Z0015.FilePaths.Instance;
        public static F0000.IFileSystemOperator FileSystemOperator => F0000.FileSystemOperator.Instance;
        public static F0019.IGitOperator GitOperator => F0019.GitOperator.Instance;
        public static F0041.IGitHubOperator GitHubOperator => F0041.GitHubOperator.Instance;
        public static L0036.IGitHubRepositoryContextOperations GitHubRepositoryContextOperations => L0036.GitHubRepositoryContextOperations.Instance;
        public static L0047.O001.ILocalGitRepositoryContextOperations LocalGitRepositoryContextOperations => L0047.O001.LocalGitRepositoryContextOperations.Instance;
        public static L0047.O001.ILocalRepositoryContextOperations LocalRepositoryContextOperations => L0047.O001.LocalRepositoryContextOperations.Instance;
        public static L0047.F000.ILocalRepositoryContextOperator LocalRepositoryContextOperator => L0047.F000.LocalRepositoryContextOperator.Instance;
        public static F0033.INotepadPlusPlusOperator NotepadPlusPlusOperator => F0033.NotepadPlusPlusOperator.Instance;
        public static IOperator Operator => Construction.Operator.Instance;
        public static IOperations Operations => Construction.Operations.Instance;
        public static Z0043.IOwnerNames OwnerNames => Z0043.OwnerNames.Instance;
        public static F0002.IPathOperator PathOperator => F0002.PathOperator.Instance;
        public static L0040.IProjectContextOperations ProjectContextOperations => L0040.ProjectContextOperations.Instance;
        public static L0040.O001.IProjectContextOperations ProjectContextOperations_FileGeneration => L0040.O001.ProjectContextOperations.Instance;
        public static L0040.IProjectContextOperator ProjectContextOperator => L0040.ProjectContextOperator.Instance;
        public static L0033.IProjectElementContextOperations ProjectElementContextOperations => L0033.ProjectElementContextOperations.Instance;
        public static IProjectFileContextOperations ProjectFileContextOperations => L0037.ProjectFileContextOperations.Instance;
        public static F0052.IProjectFileNameOperator ProjectFileNameOperator => F0052.ProjectFileNameOperator.Instance;
        public static F0020.IProjectFileOperator ProjectFileOperator => F0020.ProjectFileOperator.Instance;
        public static F0127.IProjectNameOperator ProjectNameOperator => F0127.ProjectNameOperator.Instance;
        public static Z0045.IProjectFileReferences ProjectFileReferences => Z0045.ProjectFileReferences.Instance;
        public static Z0045.Raw.IProjectFileReferences ProjectFileReferences_Raw => Z0045.Raw.ProjectFileReferences.Instance;
        public static IProjectFileReferenceSets ProjectFileReferenceSets => L0037.ProjectFileReferenceSets.Instance;
        public static F0132.IProjectNamespaceNamesOperator ProjectNamespaceNamesOperator => F0132.ProjectNamespaceNamesOperator.Instance;
        public static F0056.IProjectOperations ProjectOperations => F0056.ProjectOperations.Instance;
        public static IProjectPathsOperator ProjectPathsOperator => L0037.ProjectPathsOperator.Instance;
        public static F0016.F001.IProjectReferencesOperator ProjectReferencesOperator => F0016.F001.ProjectReferencesOperator.Instance;
        public static IRepositoryContextOperator RepositoryContextOperator => L0037.RepositoryContextOperator.Instance;
        public static Z0042.IRepositoryDescriptions RepositoryDescriptions => Z0042.RepositoryDescriptions.Instance;
        public static Z0042.IRepositoryNames RepositoryNames => Z0042.RepositoryNames.Instance;
        public static IRepositoryContextOperations RepositoryContextOperations => L0037.RepositoryContextOperations.Instance;
        public static ISolutionContextOperations SolutionContextOperations => L0037.SolutionContextOperations.Instance;
        public static L0039.F000.ISolutionContextOperator SolutionContextOperator => L0039.F000.SolutionContextOperator.Instance;
        public static F0024.ISolutionFileOperator SolutionFileOperator => F0024.SolutionFileOperator.Instance;
        public static F0000.IStrings Strings => F0000.Strings.Instance;
        public static T0159.F000.ITextOutputOperator TextOutputOperator => T0159.F000.TextOutputOperator.Instance;
        public static ITypeNameOperator TypeNameOperator => L0037.TypeNameOperator.Instance;
        public static IValues Values => Construction.Values.Instance;
        public static F0088.IVisualStudioOperator VisualStudioOperator => F0088.VisualStudioOperator.Instance;
        public static F0034.IWindowsExplorerOperator WindowsExplorerOperator => F0034.WindowsExplorerOperator.Instance;
    }
}