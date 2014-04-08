using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc3;
using SkopMe.Core.Interface.Services;
using SkopMe.Repositories;
using SkopMe.Web.Controllers;
using SkopMe.Core.Interface.Repository;

namespace SkopMe.Web
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();            

            // register all your components with the container here
            container.RegisterType<IUserCategoryService, UserCategoryService>();
            container.RegisterType<IUserCategoryRepository, UserCategoryRepository>();
            container.RegisterType<IController, UserCategoryController>("UserCategoryModel");

            return container;
        }
    }
}