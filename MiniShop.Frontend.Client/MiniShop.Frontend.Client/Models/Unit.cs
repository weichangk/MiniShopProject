using System.ComponentModel.DataAnnotations.Schema;

namespace MiniShop.Frontend.Client.Models
{
    [Table("Unit")]
    public class Unit : EntityBase<int>
    {
        /// <summary>
        /// 单位ID
        /// </summary>
        public int UnitId { get; set; }

        /// <summary>
        /// 单位编码
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 单位名称
        /// </summary>
        public string Name { get; set; }
    }
}
