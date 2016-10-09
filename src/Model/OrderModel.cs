// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderModel.cs" company="Newegg" Author="oz3t">
//   Copyright (c) 2015 Newegg.inc. All rights reserved.
// </copyright>
// <summary>
//   OrderModel created at  9/25/2015 9:06:13 AM
// </summary>
//<Description>
//
//</Description>
// --------------------------------------------------------------------------------------------------------------------
namespace Model
{
    /// <summary>
    /// The class of OrderModel.
    /// </summary>
    public class OrderModel
    {
        public int Id { get; set; }

        [ExcelMapAttribute("Order Number")]
        public string OrderNumber { get; set; }
    }
}
