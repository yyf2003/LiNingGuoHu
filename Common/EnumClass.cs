using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public enum FileCodeEnum
    {
        /// <summary>
        /// 店面平面图
        /// </summary>
        ShopPicture = 1,
        /// <summary>
        /// 推广活动照片
        /// </summary>
        POPFunctionPicture = 2,
        /// <summary>
        /// 公共文件，
        /// </summary>
        CommonFile = 3,
        /// <summary>
        /// 导入的临时文件（Excel）
        /// </summary>
        TempFile=4,
        /// <summary>
        /// 推广照片
        /// </summary>
        POPPromotionPicture=5,
        /// <summary>
        /// 推广活动执行说明与季度相关资源
        /// </summary>
        POPPromotionAttach=6,
        /// <summary>
        /// 季度执行说明与季度相关资源
        /// </summary>
        POPLaunchAttach=7,
        /// <summary>
        /// 季度活动照片
        /// </summary>
        POPLaunchPicture = 8,
        /// <summary>
        /// 发货物流单
        /// </summary>
        SentWuLiuDang=9,
        /// <summary>
        /// 收货签收单
        /// </summary>
        ReceiveQianShouDang=10,
    }

    public enum FileTypeEnum
    {
        /// <summary>
        /// 图片
        /// </summary>
        Images,
        /// <summary>
        /// 上传Excel
        /// </summary>
        Excel,
        /// <summary>
        /// 文件
        /// </summary>
        Files,
        /// <summary>
        /// 全部
        /// </summary>
        All
    }
}
