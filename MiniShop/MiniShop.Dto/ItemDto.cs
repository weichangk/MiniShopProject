using System;
using System.ComponentModel.DataAnnotations;
using MiniShop.Model.Code;
using MiniShop.Model.Enums;

namespace MiniShop.Dto
{
    public class ItemDto
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "商店ID")]
        public Guid ShopId { get; set; }

        [Display(Name = "类别ID")]
        public int CategorieId { get; set; }

        [Display(Name = "类别")]
        public string CategorieName { get; set; }

        [Display(Name = "条码")]
        public string Code { get; set; }

        [Display(Name = "名称")]
        public string Name { get; set; }

        [Display(Name = "进货价")]
        public decimal PurchasePrice { get; set; }

        [Display(Name = "售价")]
        public decimal Price { get; set; }

        [Display(Name = "状态")]
        public EnumItemStatus State { get; set; }

        [Display(Name = "状态描述")]
        public string StateDes => State.ToDescription();

        [Display(Name = "类型")]
        public EnumItemType Type { get; set; }

        [Display(Name = "类型描述")]
        public string TypeDes => Type.ToDescription();

        [Display(Name = "供应商ID")]
        public int SupplierId { get; set; }

        [Display(Name = "供应商名称")]
        public string SupplierName { get; set; }

        [Display(Name = "计价方式")]
        public EnumPriceType PriceType { get; set; }

        [Display(Name = "计价方式描述")]
        public string PriceTypeDes => PriceType.ToDescription();

        [Display(Name = "单位ID")]
        public int UnitId { get; set; }

        [Display(Name = "单位名称")]
        public string UnitName { get; set; }

        [Display(Name = "图片")]
        public string Picture { get; set; }

        [Display(Name = "注册时间")]
        public DateTime CreatedTime { get; set; }
    }
}
