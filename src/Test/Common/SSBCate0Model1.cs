using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MKPL.SP.UpdateInventoryAndPriceJob.Host.SSBModel
{
    /// <summary>
    /// cate0对应的实体结构
    /// </summary>
    public class SSBCate0Model
    {
        /// <summary>
        /// 如： UpdateSellerItemPriceInfo
        /// </summary>
        public string Action { get; set; }

        public int ActionUserId { get; set; }

        public string ActionUserName { get; set; }

        public DateTime ActionDate { get; set; }

        public int CompanyCode { get; set; }

        public string LanguageCode { get; set; }

        public string CountryCode { get; set; }

        public string SellerID { get; set; }

        public List<Cate0ItemDetail> ItemList { get; set; }
    }


    public class Cate0ItemDetail
    {
        public int TransactionNumber { get; set; }

        public string SellerItemNumber { get; set; }

        public string SellerPartNumber { get; set; }

        public decimal? UnitPrice { get; set; }

        public int ShippingType { get; set; }

        public int? InstantRebate { get; set; }

        public int? ItemActiveMark { get; set; }

        public int? MAPPriceMark { get; set; }

        public decimal? MAPPrice { get; set; }

        public decimal? Inventory { get; set; }

        public string WarehouseNumber { get; set; }

        public string CurrencyCode { get; set; }
    }
}
