[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Ankh_Morpork_MVC.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Ankh_Morpork_MVC.App_Start.NinjectWebCommon), "Stop")]

namespace Ankh_Morpork_MVC.App_Start
{
    using Ankh_Morpork_MVC.Models;
    using Ankh_Morpork_MVC.Repositories;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using System;
    using System.Web;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application.
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
            kernel.Bind<IGameDbContext>().To<GameDbContext>();
            kernel.Bind<IEventRepository>().To<EventRepository>();
            kernel.Bind<IAssassinRepository>().To<AssassinRepository>();
            kernel.Bind<IThiefRepository>().To<ThiefRepository>();
            kernel.Bind<IBeggarsRepository>().To<BeggarRepository>();
            kernel.Bind<IClownRepository>().To<ClownRepository>();
            kernel.Bind<IHoodRepository>().To<HoodRepository>();
            kernel.Bind<IBeerRepository>().To<BeerRepository>();
            kernel.Bind<IGameRepository>().To<GameRepository>();

        }
    }
}