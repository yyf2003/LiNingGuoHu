using System;
using System.Collections.Generic;
using System.Text;


namespace LN.Model
{
    public class PromotionShops
    {
        public int? Id { get; set; }
        public int? PromotionId { get; set; }
        public int? AreaId { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
        public int? TownId { get; set; }
        public int? ShopId { get; set; }
        public int? AddUserId { get; set; }
        public DateTime? AddDate { get; set; }

        public int? SentOrderUserId { get; set; }
        public int? ReceiveOrderUserId { get; set; }
        public DateTime? SentOrderDate { get; set; }
        public DateTime? ReceiveOrderDate { get; set; }
        public string SentRemark { get; set; }
        public string ReceiveRemark { get; set; }


        public string PosID { get; set; }
        public string Shopname { get; set; }
        public string Shopsamplename { get; set; }
        public string ShopAddress { get; set; }
        public string BigArea { get; set; }
        public string LinkMan { get; set; }
        public string LinkPhone { get; set; }
        public string PostAddress { get; set; }
        public string DealerID { get; set; }
        public string DealerName { get; set; }
        public string FXID { get; set; }
        public string FXName { get; set; }
        public string ShopOwnerShip { get; set; }
        public string CustomerCard { get; set; }
        public int? ShopImageId { get; set; }
        public int? ShopLevelId { get; set; }
        public int? ShopType { get; set; }
        public string ShopCategory { get; set; }

        public int? SaleTypeID { get; set; }
        public int? TCL_ID { get; set; }
        public int? ACL_ID { get; set; }
        public string Remark { get; set; }
       
    }
}
