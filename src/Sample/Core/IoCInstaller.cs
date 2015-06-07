using System.Web.Http;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Sample.Core.Contracts;
using Sample.Core.Logging;
using Sample.Core.Repository;
using Sample.Models;

namespace Sample.Core
{
    public class IoCInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<ILog>().ImplementedBy<Log>()
                );

            container.Register(
                Classes
                    .FromThisAssembly()
                    .BasedOn<ApiController>()
                    .LifestyleScoped()
                );

            container.Register(
                Component.For<IRepository<SampleModel, int>>().ImplementedBy< StaticListRepository<SampleModel, int>>()
                );
        }
    }
}