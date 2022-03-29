using HIS.Context;
using HIS.ReqDTO;

namespace HIS.Service.OrderHub
{
    public interface IOrderHubService
    {
        /// <summary>
        /// 查询二级科室
        /// </summary>
        /// <returns></returns>
        public Response GetDept();

        /// <summary>
        /// 查询医生信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public Response GetDoctor(ReqDoctorDTO dto);

        /// <summary>
        /// 查询排班信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public Response GetSchedule(ReqScheduleDTO dto);

        /// <summary>
        /// 查询号源信息
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public Response GetSource(ReqSourceDTO dto);

        /// <summary>
        /// 查卡
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public Response GetCard(ReqQueryCardDTO dto);

        /// <summary>
        /// 建卡
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public Task<Response> RegCard(ReqRegCardDTO dto);

        /// <summary>
        /// 新增订单
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public Task<Response> AddOrder(ReqAddOrderDTO dto);

        /// <summary>
        /// 取消订单
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public Task<Response> CancelOrder(ReqCancelOrderDTO dto);
    }
}
