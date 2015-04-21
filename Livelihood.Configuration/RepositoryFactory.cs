using Livelihood.EntiryFramework.Repository;
using Livelihood.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livelihood.Configuration
{
    public class RepositoryFactory
    {
        public static IBaseRepository<T> GetHandler<T>() where T : class
        {
            //var handlers = GetHandlerTypes<T>().ToList();
            //var repType = GetHandlerTypes<T>().FirstOrDefault();

            var rtype = GetRepositoryType<T>();

            //var ttt = repType;


            return (IBaseRepository<T>)Activator.CreateInstance(rtype);

            //var cmdHandler = handlers.Select(handler =>
            //    (IBaseRepository<T>)container.Build().Resolve(handler)).FirstOrDefault();

            //return cmdHandler;
        }

        public static Type GetRepositoryType<T>() where T : class
        {
            //查找当前的程序集中(ICommandHandler)所在的程序集中的所有的实现了ICommandHandler的接口的类型，然后在所有的类型找查找实现了该泛型接口并且泛型的类型参数类型为T类型的所有类型
            var handlers = typeof(IBaseRepository<>).Assembly.GetExportedTypes()
                .Where(x => x.GetInterfaces()
                    .Any(a => a.IsGenericType && a.GetGenericTypeDefinition() == typeof(IBaseRepository<>)))
                    .Where(h => h.GetInterfaces()
                        .Any(ii => ii.GetGenericArguments()
                            .Any(aa => aa == typeof(T)))).ToList();

            var h0 = typeof(IBaseRepository<>).Assembly.GetExportedTypes();

            


            var interfaces = typeof(IBaseRepository<>).Assembly.GetExportedTypes();

            var types = typeof(BaseRepository<>).Assembly.GetExportedTypes();

            types.ToList().ForEach(tt =>
            {
                if (handlers.FirstOrDefault().IsAssignableFrom(tt))
                {
                    var i = tt;
                }
            });

            var ret = types.ToList().Where(t =>
            {
                var firstOrDefault = handlers.FirstOrDefault();
                return firstOrDefault != null && firstOrDefault.IsAssignableFrom(t);
            }).FirstOrDefault();

            return ret;
        }
        /// <summary>
        /// 获取处理器的类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private static IEnumerable<Type> GetHandlerTypes<T>() where T : class
        {
            //查找当前的程序集中(ICommandHandler)所在的程序集中的所有的实现了ICommandHandler的接口的类型，然后在所有的类型找查找实现了该泛型接口并且泛型的类型参数类型为T类型的所有类型
            var handlers = typeof(IBaseRepository<>).Assembly.GetExportedTypes()
                .Where(x => x.GetInterfaces()
                    .Any(a => a.IsGenericType && a.GetGenericTypeDefinition() == typeof(IBaseRepository<>)))
                    .Where(h => h.GetInterfaces()
                        .Any(ii => ii.GetGenericArguments()
                            .Any(aa => aa == typeof(T)))).ToList();




            //var types = typeof(BaseRepository<>).Assembly.GetExportedTypes();

            //types.ToList().ForEach(tt =>
            //{
            //    if (handlers.FirstOrDefault().IsAssignableFrom(tt))
            //    {
            //        var i = tt;
            //    }
            //});


            //var type = typeof (BaseRepository<>).Assembly.GetExportedTypes();

            //var name = handlers.First().ToString();

            //type[1].GetInterface(name);

            //var tmp = type[8].GetInterfaces();

            //var tt = handlers.FirstOrDefault();

            //var tmp2 = tmp.Any(i => !i.IsGenericType);

            //var tmps = type.Where(t => t.GetInterfaces().Any(i => !i.IsGenericType));

            //.Where(t => t.GetInterfaces()
            //    .Any(a => a.GetGenericTypeDefinition() == typeof (IBaseRepository<>)));

            //type[8].GetInterfaces().Any(i => i.IsGenericType);



            //var handlerss = typeof(IBaseRepository<>).Assembly.GetExportedTypes()
            //  .Where(x => x.get
            //      .Any(a => a.IsGenericType && a.GetGenericTypeDefinition() == typeof(IBaseRepository<>)))
            //      .Where(h => h.GetInterfaces()
            //          .Any(ii => ii.GetGenericArguments()
            //              .Any(aa => aa == typeof(T)))).ToList();
            return handlers;
        }

        //private static Type GetRepositoryType<T>() where T : class
        //{

        //}
    }
}
