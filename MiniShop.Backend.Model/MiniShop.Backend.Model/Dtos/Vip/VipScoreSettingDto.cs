using System;
using System.ComponentModel.DataAnnotations;
using MiniShop.Backend.Model.Code;
using MiniShop.Backend.Model.Enums;

namespace MiniShop.Backend.Model.Dto
{
    public class VipScoreSettingDto
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "商店ID")]
        public Guid ShopId { get; set; }

        [Display(Name = "会员类别ID")]
        public int VipTypeId { get; set; }

        [Display(Name = "会员类别名称")]
        public string VipTypeName { get; set; }

        [Display(Name = "积分方式")]
        public EnumVipScoreWay VipScoreWay { get; set; }

        [Display(Name = "积分方式")]
        public string VipScoreWayDes => VipScoreWay.ToDescription();

        [Display(Name = "消费金额")]
        public decimal ConsumeAmount { get; set; }

        [Display(Name = "积分数量")]
        public decimal ScoreAmount { get; set; }

    }
}
