using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HIS.Entity
{
    [Table("dictionary")]
    public class EntDictionary
    {
        [Key]
        public string Code { get; set; }
        public string Tables { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
    }
}
