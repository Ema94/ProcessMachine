using Standar.ProcessMachine_V2.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standar.ProcessMachine_V2.ProcessMachine.Process
{
    public static class ProcessInfoBuilder
    {
        public static ProcessExecutionConfig<TResult> BuildProcessConfig<TConfiguration, TResult, TProcess>(this IProcessMachine machine, Func<ProcessBuildConfigConfigurator<TConfiguration, TResult>, ProcessBuildConfigConfigurator<TConfiguration, TResult>> buildConfig)
            where TConfiguration : class, new()
            where TResult : class, new()
            where TProcess : IConfigurableProcess<TConfiguration, TResult>, new()
        {
            ProcessExecutionConfig<TResult> processInfo = new();
            ProcessBuildConfigConfigurator<TConfiguration, TResult> processBuildConfig = new();
            IConfigurable<TConfiguration> configureBuilder = new Configurable<TConfiguration>();
            IConfigurableProcess<TConfiguration, TResult> Process = new TProcess();
            processBuildConfig = buildConfig(processBuildConfig);
            configureBuilder = processBuildConfig.configurable(configureBuilder);
            Process.Configure(configureBuilder);
            processInfo.Process = Process;
            processInfo.Condition = processBuildConfig.ExecutionCondition;
            processInfo.OnProcess = processBuildConfig.OnProcess;
            return processInfo;
        }

        public static ProcessExecutionConfig<TResult> BuildProcessParameters<TConfiguration, TResult, TProcess>(this IProcessMachine machine, Func<ProcessBuildConfigParametrizable<TConfiguration, TResult>, ProcessBuildConfigParametrizable<TConfiguration, TResult>> buildParameters)
            where TConfiguration : class, new()
            where TResult : class, new()
            where TProcess : IParameterizableProcess<TConfiguration, TResult>, new()
        {
            ProcessExecutionConfig<TResult> processInfo = new();
            ProcessBuildConfigParametrizable<TConfiguration, TResult> processBuildConfig = new();
            IParameterizableProcess<TConfiguration, TResult> Process = new TProcess();
            processBuildConfig = buildParameters(processBuildConfig);
            Process.Parametrizable(processBuildConfig.parameters);
            processInfo.Process = Process;
            processInfo.Condition = processBuildConfig.ExecutionCondition;
            processInfo.OnProcess = processBuildConfig.OnProcess;
            return processInfo;
        }
    }
}
