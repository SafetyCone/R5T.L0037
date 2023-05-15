using System;

using R5T.T0142;
using R5T.T0172;


namespace R5T.L0037.Construction
{
    [DataTypeMarker]
    public class LibraryRepositoryCreationOutput :
        IHasLibraryProjectFilePath,
        IHasSolutionFilePath
    {
        public IProjectFilePath LibraryProjectFilePath { get; set; }
        public ISolutionFilePath SolutionFilePath { get; set; }

        IProjectFilePath IHasProjectFilePath.ProjectFilePath
        {
            get => this.LibraryProjectFilePath;
            set
            {
                this.LibraryProjectFilePath = value;
            }
        }
    }
}
