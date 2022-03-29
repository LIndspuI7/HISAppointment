using System.ComponentModel.DataAnnotations;

namespace HIS.ReqDTO
{
    public class ReqScheduleDTO
    {
        [Key]
        public string DeptId { get; set; }
        public string? DoctorId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
