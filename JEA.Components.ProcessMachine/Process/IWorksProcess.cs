using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEA.Components.ProcessMachine.Process
{
    public interface IWorksProcess : IProcess
    {
        void AddContext(WorkProcessContext context);
    }
}
