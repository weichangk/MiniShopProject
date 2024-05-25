using System;
using System.ComponentModel.DataAnnotations.Schema;
using MiniShop.Backend.Model.Enums;

namespace MiniShop.Backend.Model
{
    /// <summary>
    /// 销售订单
    /// </summary>
    [Table("BillInfo")]
    public class BillInfo : EntityBaseNoDeletedStoreId<int>
    {
        [NotMapped]
        public override string Name { get => base.Name; set => base.Name = value; }

        /// <summary>
        /// 单号
        /// </summary>
        public string BillNo { get; set; }

        /// <summary>
        /// 销售方式
        /// </summary>
        /// <value></value>
        public EnumSaleWay SaleWay { get; set; }        

        /// <summary>
        /// 销售金额
        /// </summary>
        /// <value></value>
        public decimal SaleMoney { get; set; }

        /// <summary>
        /// 会员ID
        /// </summary>
        /// <value></value>
        public int MemberId { get; set; }
    }
}
