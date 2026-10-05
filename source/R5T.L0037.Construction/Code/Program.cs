using System;
using System.Threading.Tasks;


namespace R5T.L0037.Construction
{
    class Program
    {
        static async Task Main()
        {
            await Program
                .Demonstrations_()
                //.Demonstrations_Project()
                ;
        }

        static async Task Demonstrations_()
        {
            await Demonstrations.Instance
                //.Check_GitHubRepository_Exists()
                //.Create_RemoteRepository_Only()
                //.Delete_RemoteRepository_Only()
                //.Create_Repository()
                //.Delete_Repository()
                //.Create_Repository_WithGitIgnore()
                //.Create_Repository_Console()
                //.Create_Repository_Console_Chunked()
                //.Create_Project_InDirectory()
                //.Create_Project_InSolution_InDirectory()
                .Add_LibraryProject_ToSolution()
                ;
        }

        static async Task Demonstrations_Project()
        {
            await ProjectDemonstrations.Instance
                //.Add_ProjectFileReferences()
                //.Add_ContextType()
                .Add_StrongTypes()
                ;
        }
    }
}