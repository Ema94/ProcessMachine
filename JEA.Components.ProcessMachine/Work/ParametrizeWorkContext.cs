using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEA.Components.ProcessMachine.Work
{
    public class PrametrizeWorkContext<TParameter>
    {
        public Type Type { get; set; }
        public Func<TParameter> Parameter { get; set; }
        public Action<WorkResult> OnExecute { get; set; }
    }
}
