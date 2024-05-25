using System;
using System.ComponentModel.DataAnnotations;
using MiniShop.Backend.Model.Code;
using MiniShop.Backend.Model.Enums;

namespace MiniShop.Backend.Model.Dto
{
    public class VipTypeDto
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "商店ID")]
        public Guid ShopId { get; set; }

        [Display(Name = "会员类别编码")]
        public int Code { get; set; }

        [Display(Name = "会员类别名称")]
        public string Name { get; set; }

        [Display(Name = "优惠方式")]
        public EnumDiscountWay DiscountWay { get; set; }

        [Display(Name = "优惠方式")]
        public string DiscountWayDes => DiscountWay.ToDescription();

        [Display(Name = "折扣率")]
        public decimal DiscountRate { get; set; }

        [Display(Name = "是否积分")]
        public EnumYesOrNoStatus IsScore { get; set; }

        [Display(Name = "是否积分")]
        public string IsScoreDes => IsScore.ToDescription();
        
        [Display(Name = "是否储值")]
        public EnumYesOrNoStatus IsStore { get; set; }

        [Display(Name = "是否储值")]
        public string IsStoreDes => IsStore.ToDescription();

        [Display(Name = "升级要求积分")]
        public decimal RequirementScore { get; set; }
        
        [Display(Name = "创建时间")]
        public DateTime CreatedTime { get; set; }
    }
}
