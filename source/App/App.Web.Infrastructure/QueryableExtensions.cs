using AutoMapper.QueryableExtensions;
using System;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace App.Web.Infrastructure
{
    public static class QueryableExtensions
    {
        public static IQueryable<TDestination> To<TDestination>(this IQueryable source, params Expression<Func<TDestination, object>>[] membersToExpand)
        {
            if (source is null)
            {
                Console.WriteLine("error source is null");
            }

            if (source.Equals(null))
            {
                Console.WriteLine("error source");
            }

            if (membersToExpand.Equals(null))
            {
                Console.WriteLine("error members");
            }
            //try
            //{
            //    var result = source.ProjectTo(AutoMapperConfig.Configuration, membersToExpand);

            //}
            //catch (Exception ex)
            //{
            //    Debug.WriteLine("Exception: " + ex.Message);
            //    Debug.WriteLine("Task IsFaulted: " + ex.InnerException);
            //    var exep = ex.InnerException;
            //    foreach (var inEx in exep.ToString())
            //    {
            //        Debug.WriteLine("Task Inner Exception: " + inEx.ToString());
            //    }
            //}

            var result = source.ProjectTo(AutoMapperConfig.Configuration, membersToExpand);

            return result;
            //return source.ProjectTo(AutoMapperConfig.Configuration, membersToExpand);
        }
    }
}
