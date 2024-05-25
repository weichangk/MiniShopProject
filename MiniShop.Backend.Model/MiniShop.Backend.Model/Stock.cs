using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniShop.Backend.Model
{
    /// <summary>
    /// 库存
    /// </summary>
    [Table("Stock")]
    public class Stock : EntityBaseNoDeletedStoreId<int>
    {
        [NotMapped]
        public override string Name { get => base.Name; set => base.Name = value; }

        [NotMapped]
        public override DateTime CreatedTime { get; set; } = DateTime.Now;

        [NotMapped]
        public override DateTime ModifiedTime { get; set; } = DateTime.Now;

        [NotMapped]
        public override string OperatorName { get; set; }

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
        /// 库存数量
        /// </summary>
        public decimal Number { get; set; }

    }
}
