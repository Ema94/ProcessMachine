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
        where TObject : class, new()
        {
            await processMachine.ExecuteConfigurableAsync<EntityFrameworkManipulatorProcessConfig<TObject>, ManipulatorResult<TObject>, EntityFrameworkManipulatorProcess<TObject>>(config);
            return processMachine;
        }
    }
}
