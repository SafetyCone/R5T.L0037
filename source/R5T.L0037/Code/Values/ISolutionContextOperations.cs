using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using R5T.F0000.Extensions;
using R5T.L0031.Extensions;
using R5T.L0032.T000;
using R5T.L0033;
using R5T.L0033.T000;
using R5T.L0039.T000;
using R5T.L0040.T000;
using R5T.T0131;
using R5T.T0172;
using R5T.T0187;


namespace R5T.L0037
{
    [ValuesMarker]
    public partial interface ISolutionContextOperations : IValuesMarker,
        L0039.ISolutionContextOperations
    {
        public Task Create_SolutionFile(N001.ISolutionContext context)
            => Instances.SolutionContextOperator_Internal.Create_SolutionFile(context);
    }
}
