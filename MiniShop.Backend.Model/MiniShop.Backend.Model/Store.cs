using System.ComponentModel.DataAnnotations.Schema;
using MiniShop.Backend.Model.Enums;

namespace MiniShop.Backend.Model
{
    /// <summary>
    /// 门店
    /// </summary>
    [Table("Store")]
    public class Store : EntityBase<int>
    {
        /// <summary>
        /// 联系人
        /// </summary>
        public string Contacts { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public EnumStoreStatus State { get; set; }
    }
}
