﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Horario.Domain.Abstract;
using Horario.Domain.Concrete;


namespace Horario.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
            //tip: poner el raton sobre cada método invocado, dice qué hace
        }

        private void AddBindings()
        {
            //////////////aquí volveremos a cada rato
            kernel.Bind<IProfesorRepository>().To<EFProfesorRepository>();
        }


    }

}