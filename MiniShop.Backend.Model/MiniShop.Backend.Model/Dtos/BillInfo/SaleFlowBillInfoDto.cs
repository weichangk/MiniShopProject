using System;
using System.ComponentModel.DataAnnotations;
using MiniShop.Backend.Model.Code;
using MiniShop.Backend.Model.Enums;

namespace MiniShop.Backend.Model.Dto
{
    public class SaleFlowBillInfoDto
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "商店ID")]
        public Guid ShopId { get; set; }

        [Display(Name = "单号")]
        public string BillNo { get; set; }
        
        [Display(Name = "商品ID")]
        public int ItemId { get; set; }

        [Display(Name = "条码")]
        public string Code { get; set; }

        [Display(Name = "名称")]
        public string Name { get; set; }

        [Display(Name = "商品售价")]
        public decimal Price { get; set; }

        [Display(Name = "计价方式")]
        public EnumPriceType PriceType { get; set; }

        [Display(Name = "计价方式描述")]
        public string PriceTypeDes => PriceType.ToDescription();

        [Display(Name = "单位")]
        public string UnitName { get; set; }

        [Display(Name = "类别")]
        public string CategorieName { get; set; }

        [Display(Name = "数量")]
        public decimal Qty { get; set; }

        [Display(Name = "销售售价")]
        public decimal SalePrice { get; set; }

        [Display(Name = "销售金额")]
        public decimal SaleMoney { get; set; }

        [Display(Name = "创建时间")]
        public DateTime CreatedTime { get; set; }

        //附加 BillInfo
        [Display(Name = "操作员")]
        public virtual string OperatorName { get; set; }

        [Display(Name = "销售方式")]
        public EnumSaleWay SaleWay { get; set; }    

        [Display(Name = "销售方式描述")]
        public string SaleWayDes => SaleWay.ToDescription();
    }
}
