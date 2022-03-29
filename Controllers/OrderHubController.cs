using HIS.Context;
using HIS.ReqDTO;
using HIS.Routes;
using HIS.Service.OrderHub;
using HIS.Service.Pub;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HIS.Controllers
{
    [ApiController]
    public class OrderHubController : ControllerBase
    {
        private readonly IOrderHubService ohs;
        private readonly IPubServices ps;
        public OrderHubController(IOrderHubService _ohs, IPubServices _ps)
        {
            ohs = _ohs;
            ps = _ps;
        }
        /// <summary>
        /// 查二级科室
        /// </summary>
        /// <param name="Token"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(ApiRoutes.OrderHub.Dept2)]
        public async Task<ActionResult<Response>> QueryDept(string channelId, string token)
        {
            if (await ps.CheckCT(channelId, token))
            {
                return Ok(ohs.GetDept());
            }
            else
            {
                return BadRequest(new Response() { Code = "2", Message = "无访问权限", Result = "" });
            }
        }


        /// <summary>
        /// 查询医生
        /// </summary>
        /// <param name="Token"></param>
        /// <param name="deptid"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(ApiRoutes.OrderHub.Doctor)]
        public async Task<ActionResult<Response>> QueryDoctor(string channelId, string token, ReqDoctorDTO dto)
        {
            if (await ps.CheckCT(channelId, token))
            {
                return Ok(ohs.GetDoctor(dto));
            }
            else
            {
                return BadRequest(new Response() { Code = "2", Message = "无访问权限", Result = "" });
            }
        }


        /// <summary>
        /// 查询排班
        /// </summary>
        /// <param name="Token"></param>
        /// <param name="res"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(ApiRoutes.OrderHub.Schedule)]
        public async Task<ActionResult<Response>> QuerySchedule(string channelId, string token, [FromBody] ReqScheduleDTO dto)
        {
            if (await ps.CheckCT(channelId, token))
            {
                return Ok(ohs.GetSchedule(dto));
            }
            else
            {
                return BadRequest(new Response() { Code = "2", Message = "无访问权限", Result = "" });
            }
        }


        /// <summary>
        /// 查询号源
        /// </summary>
        /// <param name="Token"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(ApiRoutes.OrderHub.Source)]
        public async Task<ActionResult<Response>> QuerySource(string channelId, string token, [FromBody] ReqSourceDTO dto)
        {
            if (await ps.CheckCT(channelId, token))
            {
                return Ok(ohs.GetSource(dto));
            }
            else
            {
                return BadRequest(new Response() { Code = "2", Message = "无访问权限", Result = "" });
            }
        }


        /// <summary>
        /// 查卡
        /// </summary>
        /// <param name="Token"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(ApiRoutes.OrderHub.QueryCard)]
        public async Task<ActionResult<Response>> QueryCard(string channelId, string token, [FromBody] ReqQueryCardDTO dto)
        {
            if (await ps.CheckCT(channelId, token))
            {
                return Ok(ohs.GetCard(dto));
            }
            else
            {
                return BadRequest(new Response() { Code = "2", Message = "无访问权限", Result = "" });
            }
        }


        /// <summary>
        /// 建卡
        /// </summary>
        /// <param name="Token"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(ApiRoutes.OrderHub.BuildCard)]
        public async Task<ActionResult<Response>> BuildCard(string channelId, string token, [FromBody] ReqRegCardDTO dto)
        {
            if (await ps.CheckCT(channelId, token))
            {
                return Ok(await ohs.RegCard(dto));
            }
            else
            {
                return BadRequest(new Response() { Code = "2", Message = "无访问权限", Result = "" });
            }
        }


        /// <summary>
        /// 新增订单
        /// </summary>
        /// <param name="Token"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(ApiRoutes.OrderHub.AddOrder)]
        public async Task<ActionResult<Response>> AddOrder(string channelId, string token, [FromBody] ReqAddOrderDTO dto)
        {
            if (await ps.CheckCT(channelId, token))
            {
                return Ok(await ohs.AddOrder(dto));
            }
            else
            {
                return BadRequest(new Response() { Code = "2", Message = "无访问权限", Result = "" });
            }
        }


        /// <summary>
        /// 取消订单
        /// </summary>
        /// <param name="Token"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(ApiRoutes.OrderHub.CancelOrder)]
        public async Task<ActionResult<Response>> CancelOrder(string channelId, string token, [FromBody] ReqCancelOrderDTO dto)
        {
            if (await ps.CheckCT(channelId, token))
            {
                return Ok(await ohs.CancelOrder(dto));
            }
            else
            {
                return BadRequest(new Response() { Code = "2", Message = "无访问权限", Result = "" });
            }
        }


    }
}
