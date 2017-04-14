using Ninject.Extensions.Conventions;

namespace ST.BLL.Infrastructure
{
    public class ServiceModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind(x => x.FromAssembliesMatching("ST.DAL.dll")
                            .SelectAllClasses()
                            .BindAllInterfaces());
        }
    }
}
