using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HIS.Entity
{
    [Table("patient")]
    public class EntCard
    {
        [Key]
        public int PatientId { get; set; }
        public int ChannelId { get; set; }
        public string CardNo { get; set; }
        public int CardType { get; set; }
        public string Name { get; set; }
        public int Sex { get; set; }
        public string Birth { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
