using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEA.Components.Core.Reader
{
    public interface IReader<TObject,TObjectResult,TQuery,TResult>
        where TObject : class
        where TObjectResult : class
        where TQuery : ReaderQuery<TObject, TObjectResult>
        where TResult : class
    {
        Task<TResult> ReadAsync(TQuery query);
    }
}
