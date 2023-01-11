using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standar.ProcessMachine_V2
{
    public interface IProcess<TResult>
        where TResult : class
    {
        TResult Execute();
        Task<TResult> ExecuteAsync();
    }
}
