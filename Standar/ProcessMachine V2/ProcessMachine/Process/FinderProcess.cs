using Microsoft.EntityFrameworkCore;
using Standar.ProcessMachine_V2.Process;
using Standar.ProcessMachine_V2.Process.Finder.Definition;
using Standar.ProcessMachine_V2.Process.Finder.Implementations.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standar.ProcessMachine_V2.ProcessMachine.Process
{
    public static class FinderProcess
    {
        public static async Task<IProcessMachine> FindProcess<Tin, TObject>(this IProcessMachine processMachine, 
                                                                    Func<ProcessBuildConfigConfigurator<EntityFrameworkFinderConfig<Tin, TObject>, FindManyResult<TObject>>, 
                                                                    ProcessBuildConfigConfigurator<EntityFrameworkFinderConfig<Tin, TObject>, 
                                                                    FindManyResult<TObject>>> config)
            where Tin : class
            where TObject : class
        {
            ProcessExecutionConfig<FindManyResult<TObject>> processInfo = new();
            ProcessBuildConfigConfigurator<EntityFrameworkFinderConfig<Tin, TObject>, FindManyResult<TObject>> processBuildConfig = new();
            IConfigurable<EntityFrameworkFinderConfig<Tin, TObject>> configureBuilder = new Configurable<EntityFrameworkFinderConfig<Tin, TObject>>();
            IConfigurableProcess<EntityFrameworkFinderConfig<Tin, TObject>, FindManyResult<TObject>> Process = new EntityFrameworkFinderMany<Tin, TObject>();
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
