using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standar.ProcessMachine_V2.Service
{
    public class Service<TResult> : IService<TResult>
    {
        public virtual TResult Execute()
        {
            Console.WriteLine($"{this.GetType().Name} Not Implement Execute Method");
            throw new NotImplementedException();
        }

        public virtual Task<TResult> ExecuteAsync()
        {
            Console.WriteLine($"{this.GetType().Name} Not Implement ExecuteAsync Method");
            throw new NotImplementedException();
        }
    }
}
