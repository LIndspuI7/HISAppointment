using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HIS.RespDTO
{
    public class RespDept2DTO
    {
        [Key]
        [Column("DeptId")]
        public string DeptId { get; set; }
        [Column("DeptName")]
        public string DeptName { get; set; }
        [Column("DeptDesc")]
        public string? DeptDesc { get; set; }
    }
}
