using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standar.ProcessMachine_V2.Process
{
    public interface IConfigurableProcess<TConfiguration, TResult> : IProcess<TResult>

        where TConfiguration : class
        where TResult : class
    {
        void Configure(IConfigurable<TConfiguration> config);
    }
}
