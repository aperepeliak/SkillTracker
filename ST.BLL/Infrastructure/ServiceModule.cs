﻿using Ninject.Extensions.Conventions;

namespace BusinessLayer.Infrastructure
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
