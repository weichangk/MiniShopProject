using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MiniShop.Backend.Model.Enums
{
    /// <summary>
    /// 促销特价范围
    /// </summary>
    public enum EnumPromotionSpecialOfferScope
    {
        [Description("商品")]
        [Display(Name = "商品")]
        Item,
    }
}
