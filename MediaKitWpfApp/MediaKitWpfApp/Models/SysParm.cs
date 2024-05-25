using System.ComponentModel.DataAnnotations.Schema;

namespace MediaKitWpfApp.Models
{
    [Table("SysParm")]
    public class SysParm : EntityBase<int>
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }
    }
}
