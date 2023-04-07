using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEA.Components.ProcessMachine
{
    public enum ProcessMachineStates
    {
        Start = 1,
        Running = 2,
        End = 3,
        PartialyEnd = 4,
        Error = 5,
    }
}
