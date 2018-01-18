using SicherheitCore.Repository.Abstract;
using SicherheitCore.Repository.SqlConcret;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unity;

namespace SicherheitCore
{
    public static class Configuration
    {
        public static object SqlUs { get; private set; }

        public static IUnityContainer GetContainer()
        {
            IUnityContainer container = new UnityContainer();

            container.RegisterType<IUserRepository, SqlUserRepository>();

            return container;
        }
    }
}
