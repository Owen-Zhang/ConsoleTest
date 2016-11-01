// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SellerPremierItemSettingStatus.cs" company="Newegg" Author="oz3t">
//   Copyright (c) 2016 Newegg.inc. All rights reserved.
// </copyright>
// <summary>
//   SellerPremierItemSettingStatus created at  10/22/2016 4:55:52 PM
// </summary>
//<Description>
//
//</Description>
// --------------------------------------------------------------------------------------------------------------------
using System.Collections.Generic;
namespace Model
{
    public class SellerPremierItemSettingStatus
    {
        public string ItemNumber { get; set; }

        public int CompanyCode { get; set; }

        public string CountryCode { get; set; }

        public bool IsPremierMark { get; set; }

        public bool IsSuccess { get; set; }

        public string ResponseCode { get; set; }

        public string ErroMessage { get; set; } 
    }

    public class SellerPremierItemSettingStatusList
    {
        public List<SellerPremierItemSettingStatus> SellerPremierItemSettingStatuses { get; set; }

        public SellerPremierItemSettingStatusList()
        {
            SellerPremierItemSettingStatuses = new List<SellerPremierItemSettingStatus>();
        }
    }
}


