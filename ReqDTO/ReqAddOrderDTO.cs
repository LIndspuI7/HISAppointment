namespace HIS.ReqDTO
{
    public class ReqAddOrderDTO
    {
        public int ChannelId { get; set; }
        public string ScheduleId { get; set; }
        public DateTime ScheduleDate { get; set; }
        public string SourceId { get; set; }
        public string BeginTime { get; set; }
        public string EndTime { get; set; }
        public string DeptId { get; set; }
        public string DoctorId { get; set; }
        public string CardNo { get; set; }
        public string Phone { get; set; }
    }
}
