// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ResgisterManager.cs" company="Newegg" Author="oz3t">
//   Copyright (c) 2015 Newegg.inc. All rights reserved.
// </copyright>
// <summary>
//   ResgisterManager created at  8/15/2015 5:05:28 PM
// </summary>
//<Description>
//
//</Description>
// --------------------------------------------------------------------------------------------------------------------
using StructureMap.Configuration.DSL;
using StructureMap;
using IService;
using Service;
using System.Threading;

namespace Test.IOC
{
    /// <summary>
    /// The class of ResgisterManager.
    /// </summary>
    public class ResgisterManager
    {
        public static Container ServiceContainer;
        private static object threadLock = new object();

        public static void Register()
        {
            lock (threadLock) {
                if (ServiceContainer == null)
                {
                    ServiceContainer = new Container(
                        c =>
                        {
                            c.For<IOrder>().Use<Order>();
                            c.For<IPerson>().Use<Person>();
                        });
                }
            }
        }

        public static void InitStructureMap()
        {
            Register();
            new ServiceProvider(ServiceContainer);
        }
    }
}
