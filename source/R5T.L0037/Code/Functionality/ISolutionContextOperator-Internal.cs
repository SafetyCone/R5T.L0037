using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using R5T.L0039.T000.N001;
using R5T.L0040.T000;
using R5T.T0132;
using R5T.T0172;
using R5T.T0172.Extensions;
using R5T.T0187;


namespace R5T.L0037.Internal
{
    [FunctionalityMarker]
    public partial interface ISolutionContextOperator : IFunctionalityMarker,
        L0039.O000.Internal.ISolutionContextOperator
    {
        public Task Create_SolutionFile(ISolutionContext solutionContext)
        {
            var solutionFileName = Instances.SolutionFileNameOperator.GetSolutionFileName_FromSolutionName(
                solutionContext.SolutionName.Value);

            var solutionFilePath = Instances.PathOperator.Combine(
                solutionContext.DirectoryPath.Value,
                solutionFileName);

            Instances.SolutionFileGenerator.Create_New(
                solutionFilePath);

            return Task.CompletedTask;
        }
    }
}
