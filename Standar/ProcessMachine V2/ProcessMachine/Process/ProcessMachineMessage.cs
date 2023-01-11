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
            ProcessExecutionConfig<MessageResult> processInfo = new();
            ProcessBuildConfigConfigurator<RandomMessageConfig, MessageResult> processBuildConfig = new();
            IConfigurable<RandomMessageConfig> configureBuilder = new Configurable<RandomMessageConfig>();
            IConfigurableProcess<RandomMessageConfig, MessageResult> Process = new RandomMessage();
            processBuildConfig = buildConfig(processBuildConfig);
            configureBuilder = processBuildConfig.configurable(configureBuilder);
            Process.Configure(configureBuilder);
            processInfo.Process = Process;
            processInfo.Condition = processBuildConfig.ExecutionCondition;
            processInfo.OnProcess = processBuildConfig.OnProcess;
            machine.ExecuteProcess(processInfo);
            return machine;
        }

        public static IProcessMachine RandomMessage(this IProcessMachine machine, Func<ProcessBuildConfigParametrizable<RandomMessageConfig, MessageResult>, ProcessBuildConfigParametrizable<RandomMessageConfig, MessageResult>> buildParameters)
        {
            ProcessExecutionConfig<MessageResult> processInfo = new();
            ProcessBuildConfigParametrizable<RandomMessageConfig, MessageResult> processBuildConfig = new();
            IParameterizableProcess<RandomMessageConfig, MessageResult> Process = new RandomMessage();
            processBuildConfig = buildParameters(processBuildConfig);
            Process.Parametrizable(processBuildConfig.parameters);
            processInfo.Process = Process;
            processInfo.Condition = processBuildConfig.ExecutionCondition;
            processInfo.OnProcess = processBuildConfig.OnProcess;
            machine.ExecuteProcess(processInfo);
            return machine;
        }
    }
}
