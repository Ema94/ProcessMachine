using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEA.Components.Core.Validator.Config
{
    public class Validation<TObject>
    {
        public string RuleName { get; set; }
        public Func<bool> Rule { get; set; }
        public string Message { get; set; }
     
    }
}
