// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Person.cs" company="Newegg" Author="oz3t">
//   Copyright (c) 2015 Newegg.inc. All rights reserved.
// </copyright>
// <summary>
//   Person created at  8/15/2015 5:27:36 PM
// </summary>
//<Description>
//
//</Description>
// --------------------------------------------------------------------------------------------------------------------
using Model;
using System.Collections.Generic;

namespace IService
{
    /// <summary>
    /// The class of Person.
    /// </summary>
    public interface IPerson
    {
        List<PersonModel> ConsolePeson(string personStr);
    }
}
