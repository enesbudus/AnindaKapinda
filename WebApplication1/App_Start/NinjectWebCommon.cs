[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(WebApplication1.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(WebApplication1.App_Start.NinjectWebCommon), "Stop")]

namespace WebApplication1.App_Start
{
    using System;
    using System.Web;
    using System.Web.Http;
    using AnindaKapinda.BusinessLogic;
    using AnindaKapinda.BusinessLogic.Abstract;
    using AnindaKapinda.BusinessLogic.Concrete;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using WebApiContrib.IoC.Ninject;

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
                GlobalConfiguration.Configuration.DependencyResolver = new NinjectResolver(kernel);
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
            kernel.Load<NinjectModuleDAL>();
            kernel.Bind<IKullaniciService>().To<KullaniciService>();
            kernel.Bind<IKullaniciRolService>().To<KullaniciRolService>();
            kernel.Bind<IUrunService>().To<UrunService>();
            kernel.Bind<IKategoriService>().To<KategoriService>();
            kernel.Bind<IMarkaService>().To<MarkaService>();
            kernel.Bind<ISatisService>().To<SatisService>();
            kernel.Bind<ISatisDetayService>().To<SatisDetayService>();
            kernel.Bind<ISiparisDurumService>().To<SiparisDurumService>();
            kernel.Bind<IKartService>().To<KartService>();
            kernel.Bind<IKargoService>().To<KargoService>();
        }
    }
}