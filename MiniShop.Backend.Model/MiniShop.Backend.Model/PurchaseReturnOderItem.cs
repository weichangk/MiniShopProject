using System.ComponentModel.DataAnnotations.Schema;

namespace MiniShop.Backend.Model
{
    /// <summary>
    /// 采购退货订单商品
    /// </summary>
    [Table("PurchaseReturnOderItem")]
    public class PurchaseReturnOderItem : EntityBaseNoDeletedStoreId<int>
    {
        [NotMapped]
        public override string Name { get => base.Name; set => base.Name = value; }

        /// <summary>
        /// 采购退货订单ID
        /// </summary>
        public int PurchaseReturnOderId { get; set; }

        /// <summary>
        /// 采购退货订单
        /// </summary>
        [ForeignKey("PurchaseReturnOderId")]
        public virtual PurchaseReturnOder PurchaseReturnOder { get; set; }

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

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
