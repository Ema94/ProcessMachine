using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standar.ProcessMachine_V2.Process
{
    public class Process<TConfig, TResult> : IConfigurableProcess<TConfig, TResult>, IParameterizableProcess<TConfig,TResult>
        where TConfig : class
        where TResult : class
    {
        protected  IConfigurable<TConfig> configuration;
        protected TConfig parameters;
        public virtual void Configure(IConfigurable<TConfig> config)
        {
            configuration = config;
        }

        public virtual TResult Execute()
        {
            Console.WriteLine($"{this.GetType().Name} The metod 'Execute' is not implemented");
            throw new NotImplementedException();
        }

        public virtual Task<TResult> ExecuteAsync()
        {
            Console.WriteLine($"{this.GetType().Name} The metod 'ExecuteAsync' is not implemented");
            throw new NotImplementedException();
        }

        public virtual void Parametrizable(TConfig parameters)
        {
            this.parameters = parameters;
        }
    }
}
