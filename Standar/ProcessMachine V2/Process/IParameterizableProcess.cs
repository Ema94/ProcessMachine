using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standar.ProcessMachine_V2.Process
{
    public interface IParameterizableProcess<TParameter, TResult> : IProcess<TResult>
        where TParameter : class
        where TResult : class
    {
        void Parametrizable(TParameter parameters);
    }
}
