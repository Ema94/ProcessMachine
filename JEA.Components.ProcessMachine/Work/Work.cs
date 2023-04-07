using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEA.Components.ProcessMachine.Work
{
    public class Work<TParameter> : IParametrizeWork<TParameter>
        where TParameter : class
    {
        protected PrametrizeWorkContext<TParameter> parameters;

        public Work()

        {
            parameters = new PrametrizeWorkContext<TParameter>();
        }

        public virtual WorkResult Execute()
        {
            System.Console.WriteLine($"{GetType().Name} The metod 'Execute' is not implemented");
            throw new NotImplementedException();
        }

        public virtual Task<WorkResult> ExecuteAsync()
        {
            System.Console.WriteLine($"{GetType().Name} The metod 'ExecuteAsync' is not implemented");
            throw new NotImplementedException();
        }

        public void SetParameter(PrametrizeWorkContext<TParameter> config)
        {
            this.parameters = config;
        }
    }
}
