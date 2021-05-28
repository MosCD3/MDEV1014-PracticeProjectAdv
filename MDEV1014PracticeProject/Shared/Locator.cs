using System;
using System.Diagnostics;
using Autofac;
using MDEV1014PracticeProject.Services.Auth;

namespace MDEV1014PracticeProject
{
    public class Locator
    {

        public IContainer container;
        ContainerBuilder containerBuilder;

        public static Locator Instance { get; } = new Locator();

        public Locator()
        {
            containerBuilder = new ContainerBuilder();

            //Services
            switch (Settings.Shared.authType)
            {
                case AuthType.ServerBased:
                    containerBuilder.RegisterType<AuthService>().As<IAuthService>();
                    break;
                case AuthType.Aws:
                    containerBuilder.RegisterType<AwsAuthService>().As<IAuthService>();
                    break;
                case AuthType.Mock:
                    containerBuilder.RegisterType<FakeAuthService>().As<IAuthService>();
                    break;
            }


            //ViewModels

        }

        public T Resolve<T>()
        {
            try
            {
                return container.Resolve<T>();
            }
            catch (Exception e)
            {
                Debug.WriteLine($"~~ Locator Exception!:{e.Message}");
            }

            return default(T);

        }
        public object Resolve(Type type) => container.Resolve(type);
        public void Build() => container = containerBuilder.Build();
        public ILifetimeScope BeginLifetimeScope() => container.BeginLifetimeScope();
    }
}
