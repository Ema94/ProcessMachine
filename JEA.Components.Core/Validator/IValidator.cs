using JEA.Components.Core.Validator.Config;
using JEA.Components.Core.Validator.Result;

namespace JEA.Components.Core.Validator
{
    public interface IValidator<TObject>
        where TObject : class
    {
        ValidatorResult Validate(ValidatorConfig<TObject> config);
    }
}
