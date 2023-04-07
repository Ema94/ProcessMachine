using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEA.Components.Core.Writer
{
    public interface IWriter<TObject,TInput>
        where TObject : class
        where TInput : WriterInput<TObject>
    {
        Task<WriterResult<TObject>> WriteAsync(TInput writeIn);
    }
}
