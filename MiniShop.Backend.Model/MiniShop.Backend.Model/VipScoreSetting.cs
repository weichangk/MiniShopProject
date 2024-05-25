using System.ComponentModel.DataAnnotations.Schema;
using MiniShop.Backend.Model.Enums;

namespace MiniShop.Backend.Model
{
    /// <summary>
    /// 会员积分设置
    /// </summary>
    [Table("VipScoreSetting")]
    public class VipScoreSetting : EntityBaseNoDeletedStoreId<int>
    {
        [NotMapped]
        public override string Name { get => base.Name; set => base.Name = value; }

        /// <summary>
        /// 会员类别ID
        /// </summary>
        public int VipTypeId { get; set; }

        /// <summary>
        /// 会员类别
        /// </summary>
        [ForeignKey("VipTypeId")]
        public virtual VipType VipType { get; set; }

        /// <summary>
        /// 会员积分方式
        /// </summary>
        /// <value></value>
        public EnumVipScoreWay VipScoreWay { get; set; }

        /// <summary>
        /// 消费金额
        /// </summary>
        /// <value></value>
        public decimal ConsumeAmount { get; set; }

        /// <summary>
        /// 积分数量
        /// </summary>
        /// <value></value>
        public decimal ScoreAmount { get; set; }
    }
}
