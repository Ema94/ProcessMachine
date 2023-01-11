using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standar.ProcessMachine_V2.Process.Finder.Implementations.EntityFramework
{
    public static class EntityFrameworkFinderConfig
    {
        public static IConfigurable<EntityFrameworkFinderConfig<TIn, TObject>> AddContext<TIn,TObject>(this IConfigurable<EntityFrameworkFinderConfig<TIn, TObject>> configurable, DbContext context)
            where TIn : class
            where TObject : class
        {
            EntityFrameworkFinderConfig<TIn, TObject> result = configurable.AsConfigurable();
            result.context = context;
            return configurable;
        }

        public static IConfigurable<EntityFrameworkFinderConfig<TIn, TObject>> AddQuery<TIn, TObject>(this IConfigurable<EntityFrameworkFinderConfig<TIn, TObject>> configurable, Func<IQueryable<TIn>, IQueryable<TObject>> query)
          where TIn : class
          where TObject : class
        {
            EntityFrameworkFinderConfig<TIn, TObject> result = configurable.AsConfigurable();
            result.contextQuery = query;
            return configurable;
        }
    }
}
