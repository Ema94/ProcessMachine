using Standar.ProcessMachine_V2.Process;
using Standar.ProcessMachine_V2.Process.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standar.ProcessMachine_V2.ProcessMachine.Process
{
    public static class ProcessMachineMessage
    {
        public static IProcessMachine RandomMessage(this IProcessMachine machine, Func<ProcessBuildConfigConfigurator<RandomMessageConfig,MessageResult>, ProcessBuildConfigConfigurator<RandomMessageConfig,MessageResult>> buildConfig)
        {
            machine.ExecuteConfigurable<RandomMessageConfig, MessageResult, RandomMessage>(buildConfig);
            return machine;
        }

        public static IProcessMachine RandomMessage(this IProcessMachine machine, Func<ProcessBuildConfigParametrizable<RandomMessageConfig, MessageResult>, ProcessBuildConfigParametrizable<RandomMessageConfig, MessageResult>> buildParameters)
        {
            machine.ExecuteParametrizable<RandomMessageConfig, MessageResult, RandomMessage>(buildParameters);
            return machine;
        }
    }
}
