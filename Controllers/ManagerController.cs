using HIS.Context;
using HIS.Routes;
using HIS.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HIS.Controllers
{
    [ApiController]
    public class ManagerController : ControllerBase
    {

        /// <summary>
        /// 未实现
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route(ApiRoutes.Manager.SetSchedule)]
        public ActionResult<Response> SetSchedule()
        {

            return Ok(new Response { Code = "2", Message = "该方法未实现", Result = "" });

        }
    }
}
