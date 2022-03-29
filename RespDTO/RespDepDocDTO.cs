using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HIS.RespDTO
{
    public class RespDepDocDTO
    {
        [Key]
        [Column("DeptId")]
        public string DeptId { get; set; }
        [Column("DoctorId")]
        public string DoctorId { get; set; }
    }
}
