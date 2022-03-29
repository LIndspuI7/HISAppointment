using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HIS.RespDTO
{
    [Table("source")]
    public class RespSourceDTO
    {
        /// <summary>
        /// 排班ID
        /// </summary>
        public string ScheduleId { get; set; }
        /// <summary>
        /// 号源ID
        /// </summary>
        [Key]
        public string SourceId { get; set; }
        /// <summary>
        /// 科室ID
        /// </summary>
        public string DeptId { get; set; }
        /// <summary>
        /// 医生ID
        /// </summary>
        public string DoctorID { get; set; }
        /// <summary>
        /// 号源状态
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 时段号源总数
        /// </summary>
        public int TotalNum { get; set; }
        /// <summary>
        /// 时段已占号源数
        /// </summary>
        public int UsedNum { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public string BeginTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public string EndTime { get; set; }
    }
}
