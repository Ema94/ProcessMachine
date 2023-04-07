using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEA.Components.Core.Reader.CommonReaders.Many
{
    public interface IReaderMany<TObject, TObjectResult, TQuery> :
        IReader<TObject, TObjectResult,TQuery,ReaderManyResult<TObjectResult>>
        where TObject : class
        where TObjectResult : class
        where TQuery : ReaderQuery<TObject, TObjectResult>
    {
    }
}
