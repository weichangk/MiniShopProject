using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniShop.Frontend.Client.Models
{
    [Table("Item")]
    public class Item : EntityBase<int>
    {
        /// <summary>
        /// 商品ID
        /// </summary>
        public int ItemId { get; set; }

        /// <summary>
        /// 类别ID
        /// </summary>
        public int CategorieId { get; set; }

        /// <summary>
        /// 商品条码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string Name { get; set; }

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
        public int State { get; set; }

        /// <summary>
        /// 商品类型
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 计价方式
        /// </summary>
        public int PriceType { get; set; }

        /// <summary>
        /// 商品单位ID
        /// </summary>
        public int UnitId { get; set; }

        /// <summary>
        /// 商品图片
        /// </summary>
        public string? Picture { get; set; }
    }
}
