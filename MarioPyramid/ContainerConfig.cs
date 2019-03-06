using Autofac;
using System;
using System.Linq;
using System.Reflection;

namespace MarioPyramid
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Application>().As<IApplication>(); 
            builder.RegisterType<ProgramLogic>().As<IProgramLogic>();

            builder.RegisterAssemblyTypes(Assembly.Load(nameof(MarioPyramid)))
                .Where(t => t.Namespace.Contains("Utilities"))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

            return builder.Build();
        }
    }
}
