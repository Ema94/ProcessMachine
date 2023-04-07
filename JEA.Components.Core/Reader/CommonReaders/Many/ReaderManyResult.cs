using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JEA.Components.Core.Reader.CommonReaders.Many
{
    public class ReaderManyResult<TResult>
    {
        public List<TResult> Result { get; set; }

    }
}
