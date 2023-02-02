using Standar.ProcessMachine_V2.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standar.ProcessMachine_V2.ProcessMachine.Process
{
    public static class BaseProcess
    {
        public static IProcessMachine ExecuteConfigurable<TConfiguration, TResult, TProcess>(this IProcessMachine machine, Func<ProcessBuildConfigConfigurator<TConfiguration, TResult>, ProcessBuildConfigConfigurator<TConfiguration, TResult>> buildConfig)
            where TConfiguration : class, new()
            where TResult : class, new()
            where TProcess : IConfigurableProcess<TConfiguration, TResult>, new()
        {
            var processInfo = machine.BuildProcessConfig<TConfiguration, TResult, TProcess>(buildConfig);
            machine.ExecuteProcess(processInfo);
            return machine;
        }

        public static async Task<IProcessMachine> ExecuteConfigurableAsync<TConfiguration, TResult, TProcess>(this IProcessMachine machine, Func<ProcessBuildConfigConfigurator<TConfiguration, TResult>, ProcessBuildConfigConfigurator<TConfiguration, TResult>> buildConfig)
        where TConfiguration : class, new()
        where TResult : class, new()
        where TProcess : IConfigurableProcess<TConfiguration, TResult>, new()
        {
            var processInfo = machine.BuildProcessConfig<TConfiguration, TResult, TProcess>(buildConfig);
            await machine.ExecuteProcessAsync(processInfo);
            return machine;
        }

        public static IProcessMachine ExecuteParametrizable<TConfiguration, TResult, TProcess>(this IProcessMachine machine, Func<ProcessBuildConfigParametrizable<TConfiguration, TResult>, ProcessBuildConfigParametrizable<TConfiguration, TResult>> buildParameters)
            where TConfiguration : class, new()
            where TResult : class, new()
            where TProcess : IParameterizableProcess<TConfiguration, TResult>, new()
        {
            var processInfo = machine.BuildProcessParameters<TConfiguration, TResult, TProcess>(buildParameters);
            machine.ExecuteProcess(processInfo);
            return machine;
        }

        public static async Task<IProcessMachine> ExecuteParametrizableAsync<TConfiguration, TResult, TProcess>(this IProcessMachine machine, Func<ProcessBuildConfigParametrizable<TConfiguration, TResult>, ProcessBuildConfigParametrizable<TConfiguration, TResult>> buildParameters)
        where TConfiguration : class, new()
        where TResult : class, new()
        where TProcess : IParameterizableProcess<TConfiguration, TResult>, new()
        {
            var processInfo = machine.BuildProcessParameters<TConfiguration, TResult, TProcess>(buildParameters);
            await machine.ExecuteProcessAsync(processInfo);
            return machine;
        }
    }
}
