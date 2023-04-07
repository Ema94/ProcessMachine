using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEA.Components.ProcessMachine
{
    public interface IProcessMachine<TObjectContext>
        where TObjectContext : class
    {
        Task<ProcessMachineContext<TObjectContext>> RunProcess(ProcessMachineContext<TObjectContext> ProcessContext);
    }
}
