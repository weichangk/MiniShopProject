using MiniShop.Backend.Model.Code;
using MiniShop.Backend.Model.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace MiniShop.Backend.Model.Dto
{
    public class PromotionOderDto
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "商店ID")]
        public Guid ShopId { get; set; }

        [Display(Name = "单号")]
        public string OderNo { get; set; }

        [Display(Name = "促销名称")]
        public string Name { get; set; }

        [Display(Name = "会员类别ID")]
        public int VipTypeId { get; set; }

        [Display(Name = "会员类别")]
        public string VipTypeName { get; set; }

        [Display(Name = "促销类型")]
        public EnumPromotionType PromotionType { get; set; }

        [Display(Name = "促销类型")]
        public string PromotionTypeDes => PromotionType.ToDescription();

        [Display(Name = "促销模式")]
        public string PromotionModelDes => 
                      PromotionType == EnumPromotionType.SpecialOffer 
                      ? $"{PromotionType.ToDescription()}-{SpecialOfferWay.ToDescription()}" 
                      : $"{PromotionType.ToDescription()}-{DiscountWay.ToDescription()}"  ;

        [Display(Name = "特价方式")]
        public EnumPromotionSpecialOfferWay SpecialOfferWay { get; set; }

        [Display(Name = "特价方式")]
        public string SpecialOfferWayDes => SpecialOfferWay.ToDescription();

        [Display(Name = "特价范围")]
        public EnumPromotionSpecialOfferScope SpecialOfferScope { get; set; }

        [Display(Name = "特价方式")]
        public string SpecialOfferScopeDes => SpecialOfferScope.ToDescription();

        [Display(Name = "折扣方式")]
        public EnumPromotionDiscountWay DiscountWay { get; set; }

        [Display(Name = "特价方式")]
        public string DiscountWayDes => DiscountWay.ToDescription();

        [Display(Name = "折扣范围")]
        public EnumPromotionDiscountScope DiscountScope { get; set; }

        [Display(Name = "折扣范围")]
        public string DiscountScopeDes => DiscountScope.ToDescription();

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

        [Display(Name = "审核状态")]
        public string AuditStateDes => AuditState.ToDescription();

        [Display(Name = "审核人员")]
        public string AuditOperatorName { get; set; }

        [Display(Name = "审核日期")]
        public DateTime? AuditTime { get; set; }

        [Display(Name = "制单人员")]
        public string OperatorName { get; set; }

        [Display(Name = "制单日期")]
        public DateTime CreatedTime { get; set; }
    }
}
