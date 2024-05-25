using System;
using System.ComponentModel.DataAnnotations;
using MiniShop.Backend.Model.Enums;

namespace MiniShop.Backend.Model.Dto
{
    public class VipScoreSettingCreateDto
    {
        [Display(Name = "商店ID")]
        [Required(ErrorMessage = "{0},不能为空")]
        public Guid ShopId { get; set; }

        [Display(Name = "会员类别ID")]
        [Required(ErrorMessage = "{0},不能为空")]
        public int VipTypeId { get; set; }

        [Display(Name = "积分方式")]
        [Required(ErrorMessage = "{0},不能为空")]
        public EnumVipScoreWay VipScoreWay { get; set; }

        [Display(Name = "消费金额")]
        [Required(ErrorMessage = "{0},不能为空")]
        public decimal ConsumeAmount { get; set; }

        [Display(Name = "积分数量")]
        [Required(ErrorMessage = "{0},不能为空")]
        public decimal ScoreAmount { get; set; }
    }
}
