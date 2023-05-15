using System;

using R5T.T0142;
using R5T.T0172;


namespace R5T.L0037
{
    [DataTypeMarker]
    public interface IHasConsoleProjectFilePath : 
        IHasProjectFilePath
    {
        public IProjectFilePath ConsoleProjectFilePath { get; set; }
    }
}
