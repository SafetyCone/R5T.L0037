using System;
using System.Threading.Tasks;


namespace R5T.L0037.Construction
{
    class Program
    {
        static async Task Main()
        {
            //await Demonstrations.Instance.Check_GitHubRepository_Exists();
            //await Demonstrations.Instance.Create_RemoteRepository_Only();
            //await Demonstrations.Instance.Delete_RemoteRepository_Only();
            //await Demonstrations.Instance.Create_Repository();
            //await Demonstrations.Instance.Delete_Repository();
            //await Demonstrations.Instance.Create_Repository_WithGitIgnore();
            //await Demonstrations.Instance.Create_Repository_Console();
            //await Demonstrations.Instance.Create_Repository_Console_Chunked();
            //await Demonstrations.Instance.Create_Project_InDirectory();
            //await Demonstrations.Instance.Create_Project_InSolution_InDirectory();
            await Demonstrations.Instance.Add_LibraryProject_ToSolution();

            //await ProjectDemonstrations.Instance.Add_ProjectFileReferences();
            //await ProjectDemonstrations.Instance.Add_ContextType();
            //await ProjectDemonstrations.Instance.Add_StrongTypes();
        }
    }
}