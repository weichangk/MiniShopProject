using System.ComponentModel.DataAnnotations.Schema;

namespace MiniShop.Backend.Model
{
    /// <summary>
    /// 采购订单商品
    /// </summary>
    [Table("PurchaseOderItem")]
    public class PurchaseOderItem : EntityBaseNoDeletedStoreId<int>
    {
        [NotMapped]
        public override string Name { get => base.Name; set => base.Name = value; }

        /// <summary>
        /// 采购订单ID
        /// </summary>
        public int PurchaseOderId { get; set; }

        /// <summary>
        /// 采购订单
        /// </summary>
        [ForeignKey("PurchaseOderId")]
        public virtual PurchaseOder PurchaseOder { get; set; }

        /// <summary>
        /// 商品ID
        /// </summary>
        public int ItemId { get; set; }

        /// <summary>
        /// 商品
        /// </summary>
        [ForeignKey("ItemId")]
        public virtual Item Item { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public decimal Number { get; set; }

        /// <summary>
        /// 赠送数量
        /// </summary>
        public decimal GiveNumber { get; set; }

        /// <summary>
        /// 小计金额
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 实际进货价
        /// </summary>
        public decimal RealPurchasePrice { get; set; }

    }
}
