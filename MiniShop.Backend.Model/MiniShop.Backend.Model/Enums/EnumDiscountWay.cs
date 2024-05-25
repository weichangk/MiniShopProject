using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MiniShop.Backend.Model.Enums
{
    /// <summary>
    /// 会员优惠方式
    /// </summary>
    public enum EnumDiscountWay
    {
        [Description("无")]
        [Display(Name = "无")]
        None,
        [Description("零售价折扣")]
        [Display(Name = "零售价折扣")]
        PriceDiscount,
    }
}
