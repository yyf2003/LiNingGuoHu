using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LN.Model
{
    public class PromotionShopInfo
    {
        public int ID { get; set; }
        /// <summary>
        /// 店铺编码
        /// </summary>
        public string PosID { get; set; }
        /// <summary>
        /// 店铺名称
        /// </summary>
        public string Shopname { get; set; }
        /// <summary>
        /// 店铺简称
        /// </summary>
        public string Shopsamplename { get; set; }
        /// <summary>
        /// 店铺地址
        /// </summary>
        public string ShopAddress { get; set; }
        /// <summary>
        /// 省份
        /// 
        /// </summary>
        public int? ProvinceID { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        public int? CityID { get; set; }
        /// <summary>
        /// 县
        /// </summary>
        public int? TownID { get; set; }
        /// <summary>
        /// 省区
        /// </summary>
        public int? areaid { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        public string LinkMan { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string LinkPhone { get; set; }
        /// <summary>
        /// 收货地址
        /// </summary>
        public string PostAddress { get; set; }
        /// <summary>
        /// 上级客户编码
        /// </summary>
        public string DealerID { get; set; }
        /// <summary>
        /// 上级客户名称
        /// </summary>
        public string DealerName { get; set; }
        /// <summary>
        /// 直属客户编码
        /// </summary>
        public string FXID { get; set; }
        /// <summary>
        /// 直属客户名称
        /// </summary>
        public string FXName { get; set; }
        /// <summary>
        /// 店铺产权关系
        /// </summary>
        public string ShopOwnerShip { get; set; }
        /// <summary>
        /// 直属客户身份
        /// </summary>
        public string CustomerCard { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// 供应商ID
        /// </summary>
        public int? SupplierId { get; set; }
        /// <summary>
        /// 店铺形象Id
        /// </summary>
        public int? ShopImageId { get; set; }
        /// <summary>
        /// 店铺类型ID(级别)
        /// </summary>
        public int? ShopLevelId { get; set; }
        /// <summary>
        /// 是否是韦德店:1是，0否
        /// </summary>
        public int? IsWeiDeShop { get; set; }
        /// <summary>
        /// 开/关店      1：新开；0：关店；2 ：整改 ；3： 维持
        /// </summary>
        public int? ShopState { get; set; }
        /// <summary>
        /// 店铺类型
        /// </summary>
        public int? ShopType { get; set; }
        /// <summary>
        /// 店铺销售属性
        /// </summary>
        public int? SaleTypeID { get; set; }
        /// <summary>
        /// 地市级城市级别_市场定义
        /// </summary>
        public int? TCL_ID { get; set; }
        /// <summary>
        /// 区县级城市级别_市场定义
        /// </summary>
        public int? ACL_ID { get; set; }

        public string BigArea { get; set; }

        public string ShopCategory { get; set; }

        public string Remark { get; set; }
    }
}
