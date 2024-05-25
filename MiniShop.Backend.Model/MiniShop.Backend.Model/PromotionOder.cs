using MiniShop.Backend.Model.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniShop.Backend.Model
{
    /// <summary>
    /// 促销订单
    /// </summary>
    [Table("PromotionOder")]
    public class PromotionOder : EntityBaseNoDeletedStoreId<int>
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string OderNo { get; set; }

        /// <summary>
        /// 会员类别ID
        /// </summary>
        public int VipTypeId { get; set; }

        /// <summary>
        /// 会员类别
        /// </summary>
        [ForeignKey("VipTypeId")]
        public virtual VipType VipType { get; set; }

        /// <summary>
        /// 促销类型
        /// </summary>
        public EnumPromotionType PromotionType { get; set; }

        /// <summary>
        /// 特价方式
        /// </summary>
        public EnumPromotionSpecialOfferWay SpecialOfferWay { get; set; }

        /// <summary>
        /// 特价范围
        /// </summary>
        public EnumPromotionSpecialOfferScope SpecialOfferScope { get; set; }

        /// <summary>
        /// 折扣方式
        /// </summary>
        public EnumPromotionDiscountWay DiscountWay { get; set; }

        /// <summary>
        /// 折扣范围
        /// </summary>
        public EnumPromotionDiscountScope DiscountScope { get; set; }

        /// <summary>
        /// 折扣率
        /// </summary>
        public decimal DiscountRate { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 审核状态
        /// </summary>
        public EnumAuditStatus AuditState { get; set; }

        /// <summary>
        /// 审核人员
        /// </summary>
        public string AuditOperatorName { get; set; }

        /// <summary>
        /// 审核日期
        /// </summary>
        public DateTime? AuditTime { get; set; }
    }
}
