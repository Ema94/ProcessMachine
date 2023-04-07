using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEA.Components.ProcessMachine.Work
{
    public interface IWork
    {
        Task<WorkResult> ExecuteAsync();
        WorkResult Execute();
    }
}
