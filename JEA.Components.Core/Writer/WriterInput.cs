using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEA.Components.Core.Writer
{
    public class WriterInput<TObject> 
    {
        public TObject ToWrite { get; set; }
        public WriterTypes Action { get; set; } 
    }
}
