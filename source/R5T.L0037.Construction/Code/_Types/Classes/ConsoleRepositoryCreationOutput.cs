using System;

using R5T.T0142;
using R5T.T0172;


namespace R5T.L0037.Construction
{
    [DataTypeMarker]
    public class ConsoleRepositoryCreationOutput :
        IHasConsoleProjectFilePath,
        IHasSolutionFilePath
    {
        public IProjectFilePath ConsoleProjectFilePath { get; set; }
        public ISolutionFilePath SolutionFilePath { get; set; }

        public IProjectFilePath ProjectFilePath {
            get => this.ConsoleProjectFilePath;
            set
            {
                this.ConsoleProjectFilePath = value;
            }
        }
    }
}
