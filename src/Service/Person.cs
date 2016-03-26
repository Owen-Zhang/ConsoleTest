// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPerson.cs" company="Newegg" Author="oz3t">
//   Copyright (c) 2015 Newegg.inc. All rights reserved.
// </copyright>
// <summary>
//   IPerson created at  8/15/2015 5:26:25 PM
// </summary>
//<Description>
//
//</Description>
// --------------------------------------------------------------------------------------------------------------------
using IService;
using Model;
using System;
using System.Collections.Generic;

namespace Service
{
    /// <summary>
    /// The class of IPerson.
    /// </summary>
    public class Person : IPerson
    {
        public List<PersonModel> ConsolePeson(string personStr)
        {
            return new List<PersonModel> { 
                new PersonModel(){
                     Id = 1,
                     Name = "Person1"
                },
                new PersonModel(){
                    Id = 2,
                    Name = "Person2"
                }
            };
        }
    }
}
