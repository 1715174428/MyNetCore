using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace Microsoft.EntityFrameworkCore
{
   public static  class ModelBuilderExtenions
    {
        private static IEnumerable<Type>GetMappingTypes(this Assembly assembly,Type mappingInterface)
        {
            return assembly.GetTypes().Where(x=>!x.GetTypeInfo().IsAbstract&&x.GetInterfaces().Any(y=>y.GetTypeInfo().IsGenericType&&y.GetGenericTypeDefinition()==mappingInterface));
        }
        public static void AddEntityConfigurationFromAssembly(this ModelBuilder modelBuilder,Assembly assembly)
        {
            var mappingTypes = assembly.GetMappingTypes(typeof(IMyEntityTypeConfiguration<>));
            foreach (var config in mappingTypes.Select(Activator.CreateInstance).Cast<IMyEntityTypeConfiguration>())
            {
                config.Map(modelBuilder);
            }
           
        }
    }
}
