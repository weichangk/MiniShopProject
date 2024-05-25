using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MiniShop.Backend.Model.Enums
{
    /// <summary>
    /// 促销特价方式
    /// </summary>
    public enum EnumPromotionSpecialOfferWay
    {
        [Description("直接特价")]
        [Display(Name = "直接特价")]
        DirectSpecial,
    }
}
