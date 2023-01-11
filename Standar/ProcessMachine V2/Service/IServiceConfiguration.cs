using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standar.ProcessMachine_V2.Service
{
    public interface IServiceConfiguration<TConfiguration, TResponse> : IService<TResponse>
    {
        void Configure(Func<TConfiguration, TConfiguration> configuration);
    }

}

