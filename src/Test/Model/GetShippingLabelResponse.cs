// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetShippingLabelResponse.cs" company="Newegg" Author="oz3t">
//   Copyright (c) 2016 Newegg.inc. All rights reserved.
// </copyright>
// <summary>
//   GetShippingLabelResponse created at  1/14/2016 11:12:42 AM
// </summary>
//<Description>
//
//</Description>
// --------------------------------------------------------------------------------------------------------------------
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Test.Model
{
    public class GetShippingLabelResponse
    {
        public string RequestID { get; set; }
        public string OrderNumber { get; set; }

        [XmlArrayItem("File")]
        public List<string> PdfFileList { get; set; }
    }
}
