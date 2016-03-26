using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Test.Common
{
    /// <summary>
    /// cate0对应的实体结构
    /// </summary>
    //[DataContract(Namespace = "")]
    [XmlRoot("RequestMaster")]
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

        [XmlArrayItem(ElementName = "Item")]
        public List<Cate0ItemDetail> ItemList { get; set; }
    }


    public class Cate0ItemDetail
    {
        
        public int TransactionNumber { get; set; }

        public string SellerItemNumber { get; set; }

        public string SellerPartNumber { get; set; }

        public decimal? UnitPrice { get; set; }

        public int ShippingType { get; set; }

        public string InstantRebate { get; set; }

        
        public string ItemActiveMark { get; set; }
        
        public string MAPPriceMark { get; set; }

        public string MAPPrice { get; set; }

        public int? Inventory_int { 
            get {
                int a;
                if (int.TryParse(Inventory, out a))
                    return a;
                return null;
            }
            set { 
                
            }
        }

        public string Inventory { get; set; }



        public string WarehouseNumber { get; set; }
         
        public string CurrencyCode { get; set; }
    }
}
