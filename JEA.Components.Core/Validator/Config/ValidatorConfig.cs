using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEA.Components.Core.Validator.Config
{
    public class ValidatorConfig<TObject>
        where TObject : class
    {
        public TObject ToValidate { get; set; }
        public IEnumerable<Validation<TObject>> validations { get; set; }
    }
}
