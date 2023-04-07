using JEA.Components.ProcessMachine.Work;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEA.Components.ProcessMachine.Process
{
    public class WorkProcessContext
    {
        public IWork Work { get; set; }
        public WorksTypes ExecutionType { get; set; }
        public Action<WorkResult> OnExecute { get; set; }   
    }
}
