using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standar.ProcessMachine_V2.Process
{
    public class Configurable<TConfiguration> : IConfigurable<TConfiguration>
        where TConfiguration : class, new()
    {
        private  TConfiguration configuration;

        public TConfiguration AsConfigurable()
        {
            if(configuration == null)
            {
                this.configuration = new TConfiguration();
            }
           return configuration;
        }
    }
}
