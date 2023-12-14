using System;

using R5T.T0142;
using R5T.T0172;


namespace R5T.L0037
{
    [DataTypeMarker]
    public interface IHasLibraryProjectFilePath :
        IWithProjectFilePath
    {
        public IProjectFilePath LibraryProjectFilePath { get; set; }
    }
}
