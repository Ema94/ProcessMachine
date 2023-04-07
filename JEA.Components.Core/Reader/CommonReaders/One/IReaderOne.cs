using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEA.Components.Core.Reader.CommonReaders.One
{
    public interface IReaderOne<TObject, TObjectResult, TQuery> :
        IReader<TObject, TObjectResult, TQuery, ReaderOneResult<TObjectResult>>
        where TObject : class
        where TObjectResult : class
        where TQuery : ReaderQuery<TObject, TObjectResult>
    {
    }
}
