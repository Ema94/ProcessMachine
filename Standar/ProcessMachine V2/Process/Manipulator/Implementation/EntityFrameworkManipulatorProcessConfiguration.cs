using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standar.ProcessMachine_V2.Process.Manipulator.Implementation
{
    public static class EntityFrameworkManipulatorProcessConfiguration
    {
        public static IConfigurable<EntityFrameworkManipulatorProcessConfig<TObject>> AddContext<TObject>(this IConfigurable<EntityFrameworkManipulatorProcessConfig<TObject>> configurable, DbContext context)
         where TObject : class
        {
            EntityFrameworkManipulatorProcessConfig<TObject> result = configurable.AsConfigurable();
            result.Context = context;
            return configurable;
        }

        public static IConfigurable<EntityFrameworkManipulatorProcessConfig<TObject>> AddQuery<TObject>(this IConfigurable<EntityFrameworkManipulatorProcessConfig<TObject>> configurable, Func<IQueryable<TObject>, IQueryable<TObject>> query)
          where TObject : class
        {
            EntityFrameworkManipulatorProcessConfig<TObject> result = configurable.AsConfigurable();
            result.FindObjectQuery = query;
            return configurable;
        }
        public static IConfigurable<EntityFrameworkManipulatorProcessConfig<TObject>> AddObjectToEdit<TObject>(this IConfigurable<EntityFrameworkManipulatorProcessConfig<TObject>> configurable,TObject obj)
         where TObject : class
        {
            EntityFrameworkManipulatorProcessConfig<TObject> result = configurable.AsConfigurable();
            result.objectToEdit = obj;
            return configurable;
        }
        public static IConfigurable<EntityFrameworkManipulatorProcessConfig<TObject>> AddAction<TObject>(this IConfigurable<EntityFrameworkManipulatorProcessConfig<TObject>> configurable, ActionTypes action)
         where TObject : class
        {
            EntityFrameworkManipulatorProcessConfig<TObject> result = configurable.AsConfigurable();
            result.action = action;
            return configurable;
        }
    }
}
