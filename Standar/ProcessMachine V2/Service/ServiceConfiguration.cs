using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standar.ProcessMachine_V2.Service
{
    public class ServiceConfiguration<TConfiguration, TResult> : Service<TResult>, IServiceConfiguration<TConfiguration, TResult>  
        where TConfiguration : class,new()
    {
        protected TConfiguration Configuration;
        public virtual void Configure(Func<TConfiguration, TConfiguration> configuration)
        {
            TConfiguration toConfigure = new TConfiguration();
            this.Configuration = configuration(toConfigure);
        }


    }
}
