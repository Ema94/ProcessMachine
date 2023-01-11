using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standar.ProcessMachine_V2.ProcessMachine.Process
{
    public class ProcessBuildConfigConfigurator<TConfiguration,TResult> : ProcessBuildConfig<TResult>
        where TConfiguration : class
        where TResult : class
    {
        public Func<IConfigurable<TConfiguration>, IConfigurable<TConfiguration>> configurable { get; set; }
    }
}
