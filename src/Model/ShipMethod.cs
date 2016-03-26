using System.Collections.Generic;
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShipMethod.cs" company="Newegg" Author="oz3t">
//   Copyright (c) 2015 Newegg.inc. All rights reserved.
// </copyright>
// <summary>
//   ShipMethod created at  12/26/2015 6:33:23 PM
// </summary>
//<Description>
//
//</Description>
// --------------------------------------------------------------------------------------------------------------------
using System.Xml.Serialization;

namespace Model
{
    [XmlRoot("UPS")]
    public class UPSShipMethod
    {
        [XmlArrayItem(ElementName = "ShippingMethod")]
        public List<ShippingMethod> ShippingMethodList { get; set; }
    }

    public class ShippingMethod
    {
        public string Code { get; set; }
        public string MappingName { get; set; }
        public int Days { get; set; }
        public string TimeInTransitCode { get; set; }
    }
}
