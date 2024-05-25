﻿using MiniShop.Backend.Model.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniShop.Backend.Model
{
    /// <summary>
    /// 商品档案
    /// </summary>
    [Table("Item")]
    public class Item : EntityBaseNoDeletedStoreId<int>
    {
        /// <summary>
        /// 类别ID
        /// </summary>
        public int CategorieId { get; set; }

        /// <summary>
        /// 类别
        /// </summary>
        [ForeignKey("CategorieId")]
        public virtual Categorie Categorie { get; set; }

        /// <summary>
        /// 商品条码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 进货价
        /// </summary>
        public decimal PurchasePrice { get; set; }

        /// <summary>
        /// 商品售价
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 商品状态
        /// </summary>
        public EnumItemStatus State { get; set; }

        /// <summary>
        /// 商品类型
        /// </summary>
        public EnumItemType Type { get; set; }

        /// <summary>
        /// 计价方式
        /// </summary>
        public EnumPriceType PriceType { get; set; }

        /// <summary>
        /// 商品单位ID
        /// </summary>
        public int UnitId { get; set; }

        /// <summary>
        /// 商品单位
        /// </summary>
        [ForeignKey("UnitId")]
        public virtual Unit Unit { get; set; }

        /// <summary>
        /// 商品图片
        /// </summary>
        public string Picture { get; set; }
    }
}
