// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UseInterfaceWithStructureMap.cs" company="Newegg" Author="oz3t">
//   Copyright (c) 2015 Newegg.inc. All rights reserved.
// </copyright>
// <summary>
//   UseInterfaceWithStructureMap created at  8/15/2015 5:16:32 PM
// </summary>
//<Description>
//
//</Description>
// --------------------------------------------------------------------------------------------------------------------
using IService;
namespace Test
{
    /// <summary>
    /// The class of UseInterfaceWithStructureMap.
    /// </summary>
    public class UseInterfaceWithStructureMap
    {
        private IOrder order;

        public UseInterfaceWithStructureMap(IOrder order)
        {
            this.order = order;
        }

        public void ConsoleMessage(string message)
        {
            order.ConsoleSomething(message);
        }
    }
}
