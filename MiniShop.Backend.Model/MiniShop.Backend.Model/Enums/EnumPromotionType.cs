using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MiniShop.Backend.Model.Enums
{
    /// <summary>
    /// 促销类型
    /// </summary>
    public enum EnumPromotionType
    {
        [Description("特价")]
        [Display(Name = "特价")]
        SpecialOffer,
        
        [Description("折扣")]
        [Display(Name = "折扣")]
        Discount,
    }
}
