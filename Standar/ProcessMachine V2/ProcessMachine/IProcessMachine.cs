using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standar.ProcessMachine_V2.ProcessMachine
{
    public interface IProcessMachine
    {
        void ExecuteProcess<TResult>(ProcessExecutionConfig<TResult> info)
         where TResult : class, new();

        Task ExecuteProcessAsync<TResult>(ProcessExecutionConfig<TResult> info)
            where TResult : class, new();
    }
}


