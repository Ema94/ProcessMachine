using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEA.Components.ProcessMachine
{
    public class ProcessMachineContext<TObjectContext>
        where TObjectContext : class
    {
        public ProcessMachineContext()
        {
            LogMessages = new List<string>();
        }

        public Func<TObjectContext> Object { get; set; }  
        public IEnumerable<ProcessContrat<TObjectContext>> Processes { get; set; }
        public ProcessMachineStates State { get; set; }
        public Action<TObjectContext> OnEndProcess { get; set; }
        public List<string> LogMessages { get; set; }

    }
}
