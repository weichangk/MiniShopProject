using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniShop.Backend.Model
{
    /// <summary>
    /// 促销折扣类别
    /// </summary>
    [Table("PromotionDiscountCategorie")]
    public class PromotionDiscountCategorie : EntityBaseNoDeletedStoreId<int>
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
        /// 促销订单ID
        /// </summary>
        public int PromotionOderId { get; set; }

        /// <summary>
        /// 促销订单
        /// </summary>
        [ForeignKey("PromotionOderId")]
        public virtual PromotionOder PromotionOder { get; set; }

        /// <summary>
        /// 类别ID
        /// </summary>
        public int CategorieId { get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        [ForeignKey("CategorieId")]
        public virtual Categorie Categorie { get; set; }

    }
}
