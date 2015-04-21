using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using System.Reflection;
using Livelihood.IRepository;
using System.Web.Http;
using Autofac.Integration.WebApi;
using Livelihood.EntiryFramework.Repository;
using System.Data.Entity;

namespace Livelihood.Configuration
{
    public sealed class ServiceLocator
    {
        private static bool _isInitialized;
        private static readonly object _lockThis = string.Empty;
        private static IContainer _container;

        /// <summary>
        /// 服务定位器
        /// </summary>
        static ServiceLocator()
        {
            if (!_isInitialized)
            {
                lock (_lockThis)
                {
                    _container = BootstrapAutofac();
                    GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(_container);
                    _isInitialized = true;
                }
            }
        }

        /// <summary>
        /// 查询对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IQueryable Query<T>() where T : class
        {
            var _query = _container.Resolve<IBaseRepository<T>>();
            return _query.Entities;
        }

        /// <summary>
        /// 启动容器
        /// </summary>
        /// <returns></returns>
        public static dynamic BootstrapAutofac()
        {

            var builder = new ContainerBuilder();
            //注册EF上下文
            builder.RegisterType<LivelihoodContext>().As(typeof(DbContext)).InstancePerLifetimeScope();
            //注册工作单元
            builder.RegisterType<UnitOfWork>().AsImplementedInterfaces().InstancePerLifetimeScope();
            //注册ApiController
            builder.RegisterApiControllers(Assembly.Load("Livelihood.WebAPI"))
                .Where(t => !t.IsAbstract && typeof(ApiController).IsAssignableFrom(t));
            // Register API controllers using assembly scanning. 
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            // BPL的注册放这里
            builder.RegisterAssemblyTypes(Assembly.Load("Livelihood.Service"))
                      .Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();
            // DAL的注册放这里
            builder.RegisterAssemblyTypes(Assembly.Load("Livelihood.EntiryFramework.Repository"))
                      .Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();
            //注册泛型类
            builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IBaseRepository<>));

            _container = builder.Build();

            _isInitialized = true;
            return _container;
        }
    }
}
