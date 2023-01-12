using Standar.ProcessMachine_V2.Process;
using Standar.ProcessMachine_V2.Process.Manipulator;
using Standar.ProcessMachine_V2.Process.Manipulator.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standar.ProcessMachine_V2.ProcessMachine.Process
{
    public static class ManipulatorProcess
    {
        public static async Task<IProcessMachine> ManipulateProcess<TObject>(this IProcessMachine processMachine,
                                                            Func<ProcessBuildConfigConfigurator<EntityFrameworkManipulatorProcessConfig<TObject>, ManipulatorResult<TObject>>,
                                                            ProcessBuildConfigConfigurator<EntityFrameworkManipulatorProcessConfig<TObject>, ManipulatorResult<TObject>>> config)
        where TObject : class,new()
        {
            ProcessExecutionConfig<ManipulatorResult<TObject>> processInfo = new();
            ProcessBuildConfigConfigurator<EntityFrameworkManipulatorProcessConfig<TObject>, ManipulatorResult<TObject>> processBuildConfig = new();
            IConfigurable<EntityFrameworkManipulatorProcessConfig<TObject>> configureBuilder = new Configurable<EntityFrameworkManipulatorProcessConfig<TObject>>();
            IConfigurableProcess<EntityFrameworkManipulatorProcessConfig<TObject>, ManipulatorResult<TObject>> Process = new EntityFrameworkManipulatorProcess<TObject>();
            processBuildConfig = config(processBuildConfig);
            configureBuilder = processBuildConfig.configurable(configureBuilder);
            Process.Configure(configureBuilder);
            processInfo.Process = Process;
            processInfo.Condition = processBuildConfig.ExecutionCondition;
            processInfo.OnProcess = processBuildConfig.OnProcess;
            await processMachine.ExecuteProcessAsync(processInfo);
            return processMachine;
        }
    }
}
