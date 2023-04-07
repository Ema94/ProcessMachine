using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEA.Components.Core.Logger
{
    public class LoggerInput<TContext>
        where TContext : class
    {
        public string Message { get; set; }
        public LoggerTypes LoggerType { get; set; }
        public string Context => typeof(TContext).FullName;
       
    }
}
