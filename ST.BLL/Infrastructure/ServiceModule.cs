using Ninject.Extensions.Conventions;

namespace BusinessLayer.Infrastructure
{
    public class ServiceModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind(x => x.FromAssembliesMatching("Data.AdoNet.dll")
                            .SelectAllClasses()
                            .BindAllInterfaces());
        }
    }
}
