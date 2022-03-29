using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HIS.RespDTO
{
    [Table("schedule")]
    public class RespScheduleDTO
    {
        /// <summary>
        /// 排班ID
        /// </summary>
        [Key]
        public string ScheduleId { get; set; }
        /// <summary>
        /// 排班日期
        /// </summary>
        public DateTime ScheduleDate { get; set; }
        /// <summary>
        /// 科室ID
        /// </summary>
        public string DeptId { get; set; }
        /// <summary>
        /// 科室名称
        /// </summary>
        [NotMapped]
        public string DeptName { get; set; }
        /// <summary>
        /// 医生ID
        /// </summary>
        public string DoctorId { get; set; }
        /// <summary>
        /// 医生姓名
        /// </summary>
        [NotMapped]
        public string DoctorName { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public double Amt { get; set; }
        /// <summary>
        /// 放号总数
        /// </summary>
        public int TotalNum { get; set; }
        /// <summary>
        /// 已约数
        /// </summary>
        public int UsedNum { get; set; }
        /// <summary>
        /// 排班状态
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 班别
        /// </summary>
        public int TimeType { get; set; }
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
