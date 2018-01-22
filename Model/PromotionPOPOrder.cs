using System;
using System.Collections.Generic;
using System.Text;

namespace LN.Model
{
    public class PromotionPOPOrder
    {
        public int? ID { get; set; }
        /// <summary>
        /// 店铺ID
        /// </summary>
        public int? ShopID { get; set; }
        /// <summary>
        /// pop序号
        /// </summary>
        public string SeatNum { get; set; }
        /// <summary>
        /// pop区域Id，
        /// </summary>
        public string POPseat { get; set; }
        /// <summary>
        /// 位置描述
        /// </summary>
        public string SeatDesc { get; set; }
        /// <summary>
        /// POP实际制作高
        /// </summary>
        public double? RealHeight { get; set; }
        /// <summary>
        /// POP实际制作宽
        /// </summary>
        public double? RealWith { get; set; }
        /// <summary>
        /// POP可视画面高
        /// </summary>
        public double? POPHeight { get; set; }
        /// <summary>
        /// POP可视画面宽
        /// </summary>
        public double? POPWith { get; set; }
        /// <summary>
        /// POP可视画面位置
        /// </summary>
        public string POPPlwz { get; set; }
        /// <summary>
        /// POP可视画面偏离度
        /// </summary>
        public int? POPPljd { get; set; }
        /// <summary>
        /// POP面积 (POPHeight * POPWith)/(1000*1000);
        /// </summary>
        public double? POPArea { get; set; }
        /// <summary>
        /// POP材质
        /// </summary>
        public string POPMaterial { get; set; }
        /// <summary>
        /// POP产品系列大类ID 
        /// </summary>
        public int? ProductTypeId { get; set; }
        /// <summary>
        /// POP产品系列ID 
        /// </summary>
        public int? ProductLineID { get; set; }
        /// <summary>
        /// 男女区域
        /// </summary>
        public string Sexarea { get; set; }
        /// <summary>
        /// 是否为双面
        /// </summary>
        public string TwoSided { get; set; }
        /// <summary>
        /// 是否粘于玻璃上
        /// </summary>
        public string Glass { get; set; }
        /// <summary>
        /// 橱窗空间长度
        /// </summary>
        public double? PlatformWith { get; set; }
        /// <summary>
        /// 橱窗面积
        /// </summary>
        public double? PlatformHeight { get; set; }
        /// <summary>
        /// 橱窗空间进深
        /// </summary>
        public double? PlatformLong { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime? SysTime { get; set; }
        /// <summary>
        /// 添加状态
        /// </summary>
        public string AddState { get; set; }
        /// <summary>
        /// 材质说明
        /// </summary>
        public string POPMaterialRemark { get; set; }
        /// <summary>
        /// 是否隐藏
        /// </summary>
        public int? IsHide { get; set; }
        /// <summary>
        /// 推广活动ID
        /// </summary>
        public int? PromotionId { get; set; }
        public int? IsConfirm { get; set; }
    }
}
