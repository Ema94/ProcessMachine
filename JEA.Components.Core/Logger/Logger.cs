using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEA.Components.Core.Logger
{
    public interface ILogger<TContext>
        where TContext : class
    {
        Task Log(LoggerInput<TContext> input);
    }
}
