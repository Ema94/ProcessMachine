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
            await processMachine.ExecuteConfigurableAsync<EntityFrameworkFinderConfig<Tin,TObject>, FindManyResult<TObject>, EntityFrameworkFinderMany<Tin,TObject>>(config);
            return processMachine;
        }
    }
}
