// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StructureMapScope.cs" company="Newegg" Author="oz3t">
//   Copyright (c) 2015 Newegg.inc. All rights reserved.
// </copyright>
// <summary>
//   StructureMapScope created at  8/16/2015 3:10:57 PM
// </summary>
//<Description>
//
//</Description>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Threading;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace Test.IOC
{
    /// <summary>
    /// The class of StructureMapScope.
    /// </summary>
    public class ServiceProvider : IServiceProvider
    {
        protected IContainer container;

        public ServiceProvider(IContainer container)
        {
            this.container = container;
        }

        public void Dispose()
        {
            IDisposable disposable = (IDisposable)container;
            if (disposable != null)
            {
                disposable.Dispose();
            }
            container = null;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == null)
                throw new Exception(
                    string.Format("Please implement the interface: {0}", serviceType.Name));

            if (serviceType.IsInterface)
                return container.TryGetInstance(serviceType);

            return container.GetInstance(serviceType);
        }

        /*
        public static IContainer Default
        {
            get
            {
                if (_default == null)
                    Interlocked.CompareExchange(ref _default, new Container(), null);
                return _default;
            }
        }
         */
    }
}
