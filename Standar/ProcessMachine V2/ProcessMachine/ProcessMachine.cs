using Standar.ProcessMachine_V2.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standar.ProcessMachine_V2.ProcessMachine
{
    public class ProcessMachine : IProcessMachine

    {

        public void ExecuteProcess<TResult>(ProcessExecutionConfig<TResult> info) where TResult : class, new()
        {
            if (info.Condition())
            {
                TResult result = info.Process.Execute();
                info.OnProcess(result);
            }
          
        }
        public async Task ExecuteProcessAsync<TResult>(ProcessExecutionConfig<TResult> info) where TResult : class, new()
        {
            if (info.Condition())
            {
                TResult result = await info.Process.ExecuteAsync();
                info.OnProcess(result);
            }
        }
    }
}
