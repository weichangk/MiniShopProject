using System;
using System.ComponentModel.DataAnnotations;
using MiniShop.Backend.Model.Code;
using MiniShop.Backend.Model.Enums;

namespace MiniShop.Backend.Model.Dto
{
    public class PayFlowBillInfoDto
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "商店ID")]
        public Guid ShopId { get; set; }

        [Display(Name = "单号")]
        public string BillNo { get; set; }
        
        [Display(Name = "付款ID")]
        public int PaymentId { get; set; }

         [Display(Name = "付款方式编码")]
        public String PaymentCode { get; set; }

        [Display(Name = "付款方式")]
        public String PaymentName { get; set; }

        [Display(Name = "付款金额")]
        public decimal PayMoney { get; set; }

        [Display(Name = "创建时间")]
        public DateTime CreatedTime { get; set; }
        
        //附加 BillInfo
        [Display(Name = "操作员")]
        public virtual string OperatorName { get; set; }

        [Display(Name = "销售方式")]
        public EnumSaleWay SaleWay { get; set; }    

        [Display(Name = "销售方式描述")]
        public string SaleWayDes => SaleWay.ToDescription();

        [Display(Name = "销售金额")]
        public decimal SaleMoney { get; set; }

        [Display(Name = "会员ID")]
        public int MemberId { get; set; }
    }
}
