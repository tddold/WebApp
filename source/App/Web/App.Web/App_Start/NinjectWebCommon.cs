[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(App.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(App.Web.App_Start.NinjectWebCommon), "Stop")]

namespace App.Web.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using App.Data.Common.Contracts;
    using App.Data;
    using App.Data.Common;
    using App.Services.Data.Common.Contracts;
    using App.Services.Data.Common;
    using Microsoft.AspNet.Identity.EntityFramework;
    using App.Data.Models;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        public static IKernel Kernel
        {
            get;
            private set;
        }

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IdentityDbContext<User>>().To<AppDbContext>().InSingletonScope();
            kernel.Bind<IDbContextSaveChanges>().To<AppDbContext>().InRequestScope();
            kernel.Bind(typeof(IRepository<>)).To(typeof(EfGenericRepository<>));
            kernel.Bind<IArticleService>().To<ArticleService>();
            kernel.Bind<ICategoryService>().To<CategoryService>();
            //kernel.Bind<IGalleryService>().To<GallerlyService>();
            //kernel.Bind<IHomeArticleService>().To<HomeArticleService>();
            //kernel.Bind<IItemArticleService>().To<ItemArticleService>();
            kernel.Bind(typeof(IService<>)).To(typeof(Service<>));
            kernel.Bind(typeof(IBaseDataService<>)).To(typeof(BaseDataService<>)).InRequestScope();
        }
    }
}
