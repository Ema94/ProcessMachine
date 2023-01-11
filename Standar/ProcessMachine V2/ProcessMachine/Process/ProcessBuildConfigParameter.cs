using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standar.ProcessMachine_V2.ProcessMachine.Process
{
    public class ProcessBuildConfigParametrizable<TParameters,TResult> : ProcessBuildConfig<TResult>
        where TParameters : class
        where TResult : class
    {
        public TParameters parameters { get; set; }
    }
}
