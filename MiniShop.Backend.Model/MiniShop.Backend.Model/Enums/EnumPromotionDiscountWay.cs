using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MiniShop.Backend.Model.Enums
{
    /// <summary>
    /// 促销折扣方式
    /// </summary>
    public enum EnumPromotionDiscountWay
    {
        [Description("直接折扣")]
        [Display(Name = "直接折扣")]
        DirectDiscount,
    }
}
