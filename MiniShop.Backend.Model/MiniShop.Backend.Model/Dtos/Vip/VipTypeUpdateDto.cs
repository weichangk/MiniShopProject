using System.ComponentModel.DataAnnotations;
using MiniShop.Backend.Model.Enums;

namespace MiniShop.Backend.Model.Dto
{
    public class VipTypeUpdateDto
    {
        [Display(Name = "ID")]
        [Required(ErrorMessage = "{0},不能为空")]
        public int Id { get; set; }

        [Display(Name = "会员类别名称")]
        [Required(ErrorMessage = "{0},不能为空")]
        public string Name { get; set; }

        [Display(Name = "优惠方式")]
        [Required(ErrorMessage = "{0},不能为空")]
        public EnumDiscountWay DiscountWay { get; set; }

        [Display(Name = "折扣率")]
        [Required(ErrorMessage = "{0},不能为空")]
        public decimal DiscountRate { get; set; }

        [Display(Name = "是否积分")]
        [Required(ErrorMessage = "{0},不能为空")]
        public EnumYesOrNoStatus IsScore { get; set; }
        
        [Display(Name = "是否储值")]
        [Required(ErrorMessage = "{0},不能为空")]
        public EnumYesOrNoStatus IsStore { get; set; }

        [Display(Name = "升级要求积分")]
        [Required(ErrorMessage = "{0},不能为空")]
        public decimal RequirementScore { get; set; }
    }
}
