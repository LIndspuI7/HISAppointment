using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HIS.RespDTO
{
    public class RespDoctorDTO
    {
        [Key]
        [Column("DoctorId")]
        public string DoctorId { get; set; }
        [Column("DoctorName")]
        public string DoctorName { get; set; }
        [Column("DoctorLevel")]
        public int DoctorLevel { get; set; }
        [Column("Sex")]
        public int Sex { get; set; }
        [Column("Phone")]
        public string? Phone { get; set; }
        [Column("Desc")]
        public string? Desc { get; set; }
        [Column("Status")]
        public int Status { get; set; }
    }
}
