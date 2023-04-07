using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEA.Components.Core.Validator.Config
{
    public class ValidationContext<TProperty,TValue>
    {
        public TProperty Property { get; set; }
        public TValue Value { get; set; }
    }
}
