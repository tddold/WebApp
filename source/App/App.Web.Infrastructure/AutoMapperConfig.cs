﻿using System;
using System.Collections.Generic;

using AutoMapper;
using System.Reflection;
using System.Linq;

namespace App.Web.Infrastructure
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration Configuration { get; private set; }

        public void Execute(Assembly assembly)
        {
            Configuration = new MapperConfiguration(

                cfg =>
                {
                    var types = assembly.GetExportedTypes();
                    LoadBothWaysMapping(types, cfg);
                    LoadStandardMappings(types, cfg);
                    LoadReverseMappings(types, cfg);
                    LoadCustomMappings(types, cfg);
                });
        }

        public static void LoadBothWaysMapping(IEnumerable<Type> types, IMapperConfiguration mapperConfiguration)
        {
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapBothWays<>) &&
                            !t.IsAbstract &&
                            !t.IsInterface
                        select new
                        {
                            Source = i.GetGenericArguments()[0],
                            Destination = t
                        }).ToArray();

            foreach (var map in maps)
            {
                mapperConfiguration.CreateMap(map.Source, map.Destination);
                mapperConfiguration.CreateMap(map.Destination, map.Source);
            }
        }

        public static void LoadStandardMappings(IEnumerable<Type> types, IMapperConfiguration mapperConfiguration)
        {
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>) &&
                            !t.IsAbstract &&
                            !t.IsInterface
                        select new
                        {
                            Source = i.GetGenericArguments()[0],
                            Destination = t
                        }).ToArray();

            foreach (var map in maps)
            {
                mapperConfiguration.CreateMap(map.Source, map.Destination);
            }
        }

        public static void LoadReverseMappings(IEnumerable<Type> types, IMapperConfiguration mapperConfiguration)
        {
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapTo<>) &&
                            !t.IsAbstract &&
                            !t.IsInterface
                        select new
                        {
                            Source = i.GetGenericArguments()[0],
                            Destination = t
                        }).ToArray();

            foreach (var map in maps)
            {
                mapperConfiguration.CreateMap(map.Source, map.Destination);
            }
        }

        public static void LoadCustomMappings(IEnumerable<Type> types, IMapperConfiguration mapperConfiguration)
        {
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where typeof(IHaveCustomMappings).IsAssignableFrom(t) &&
                            !t.IsAbstract &&
                            !t.IsInterface
                        select (IHaveCustomMappings)Activator.CreateInstance(t)).ToArray();

            foreach (var map in maps)
            {
                map.CreateMappings(mapperConfiguration);
            }
        }
    }
}
