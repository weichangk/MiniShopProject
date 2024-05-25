using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MiniShop.Backend.Model.Enums
{
    /// <summary>
    /// 促销折扣范围
    /// </summary>
    public enum EnumPromotionDiscountScope
    {
        [Description("全场")]
        [Display(Name = "全场")]
        All,
        [Description("类别")]
        [Display(Name = "类别")]
        Categorie,
        [Description("商品")]
        [Display(Name = "商品")]
        Item,
    }
}
