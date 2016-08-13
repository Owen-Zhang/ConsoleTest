// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FlectoerCreateInstance.cs" company="Newegg" Author="oz3t">
//   Copyright (c) 2016 Newegg.inc. All rights reserved.
// </copyright>
// <summary>
//   FlectoerCreateInstance created at  8/4/2016 1:19:42 PM
// </summary>
//<Description>
//
//</Description>
// --------------------------------------------------------------------------------------------------------------------
using System;

namespace Test.Reflector
{
    public abstract class FlectoerCreateInstanceAbstract
    {
        protected string name;
        public FlectoerCreateInstanceAbstract(string name)
        {
            this.name = name;
        }

        public void Run() 
        {
            Console.WriteLine(name);
            TestImpl();
        }

        public abstract void TestImpl();
    }
}
