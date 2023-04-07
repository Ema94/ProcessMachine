using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEA.Components.Core.Validator.Result
{
    public class ValidatorResult
    {
        public bool IsValid => Details != null ? !Details.Any() : true;
        public List<ValidationDetail> Details { get; set; }
    }
}
