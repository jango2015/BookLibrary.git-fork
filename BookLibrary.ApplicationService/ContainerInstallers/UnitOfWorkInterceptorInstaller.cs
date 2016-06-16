﻿using BookLibrary.ApplicationService.UowHelper;
using Castle.DynamicProxy;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace BookLibrary.ApplicationService.ContainerInstallers
{
    public class UnitOfWorkInterceptorInstaller:IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IInterceptor>().ImplementedBy<UnitOfWorkInterceptor>().LifestylePerWebRequest());
        }
    }
}