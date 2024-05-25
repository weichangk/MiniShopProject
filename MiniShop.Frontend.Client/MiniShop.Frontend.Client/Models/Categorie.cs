using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniShop.Frontend.Client.Models
{
    [Table("Categorie")]
    public class Categorie : EntityBase<int>
    {
        /// <summary>
        /// 类别ID
        /// </summary>
        public int CategorieId { get; set; }

        /// <summary>
        /// 类别编码
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 类别名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 类别等级
        /// </summary>
        [DefaultValue(0)]
        public int Level { get; set; }

        /// <summary>
        /// 父类别编码
        /// </summary>
        public int ParentCode { get; set; }
    }
}
