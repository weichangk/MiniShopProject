using MiniShop.Backend.Model.Code;
using MiniShop.Backend.Model.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace MiniShop.Backend.Model.Dto
{
    public class PromotionOderUpdateDto
    {
        [Display(Name = "ID")]
        [Required(ErrorMessage = "{0},不能为空")]
        public int Id { get; set; }

        [Display(Name = "促销名称")]
        public string Name { get; set; }

        [Display(Name = "会员类别ID")]
        public int VipTypeId { get; set; }

        [Display(Name = "促销类型")]
        public EnumPromotionType PromotionType { get; set; }

        [Display(Name = "特价方式")]
        public EnumPromotionSpecialOfferWay SpecialOfferWay { get; set; }

        [Display(Name = "特价范围")]
        public EnumPromotionSpecialOfferScope SpecialOfferScope { get; set; }

        [Display(Name = "折扣方式")]
        public EnumPromotionDiscountWay DiscountWay { get; set; }

        [Display(Name = "折扣范围")]
        public EnumPromotionDiscountScope DiscountScope { get; set; }

        [Display(Name = "折扣率")]
        public decimal DiscountRate { get; set; }

        [Display(Name = "开始日期")]
        public DateTime StartTime { get; set; }

        [Display(Name = "结束日期")]
        public DateTime EndTime { get; set; }

        [Display(Name = "备注")]
        public string Remark { get; set; }

        [Display(Name = "审核状态")]
        public EnumAuditStatus AuditState { get; set; }

        [Display(Name = "审核人员")]
        public string AuditOperatorName { get; set; }

        [Display(Name = "审核日期")]
        public DateTime? AuditTime { get; set; }
    }
}
