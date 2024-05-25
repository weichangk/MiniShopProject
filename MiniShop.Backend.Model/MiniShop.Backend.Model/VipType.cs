using System.ComponentModel.DataAnnotations.Schema;
using MiniShop.Backend.Model.Enums;

namespace MiniShop.Backend.Model
{
    /// <summary>
    /// 会员类别
    /// </summary>
    [Table("VipType")]
    public class VipType : EntityBaseNoDeletedStoreId<int>
    {
        /// <summary>
        /// 类别编码
        /// </summary>
        /// <value></value>
        public int Code { get; set; }   

        /// <summary>
        /// 优惠方式
        /// </summary>
        /// <value></value>
        public EnumDiscountWay DiscountWay { get; set; }

        /// <summary>
        /// 折扣率
        /// </summary>
        /// <value></value>
        public decimal DiscountRate { get; set; }

        /// <summary>
        /// 是否积分
        /// </summary>
        /// <value></value>
        public EnumYesOrNoStatus IsScore { get; set; }
        
        /// <summary>
        /// 是否储值
        /// </summary>
        /// <value></value>
        public EnumYesOrNoStatus IsStore { get; set; }

        /// <summary>
        /// 升级要求积分
        /// </summary>
        /// <value></value>
        public decimal RequirementScore { get; set; }
    }
}
