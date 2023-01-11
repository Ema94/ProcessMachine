using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standar.ProcessMachine_V2.ProcessMachine.Process
{
    public class ProcessBuildConfig<TResult>
        where TResult : class
    {

        public Func<bool> ExecutionCondition { get; set; }
        public Action<TResult> OnProcess { get; set; }
    }
}
