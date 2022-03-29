using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HIS.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        /// <summary>
        /// 未实现
        /// </summary>
        /// <returns></returns>
        [Route(Routes.ApiRoutes.Update.Client)]
        [HttpGet]
        public ActionResult DownLoad()
        {
            /*
            string path = "";
            string filename = Path.GetFileName(path);
            var stream = new FileStream(path, FileMode.Open);
            return File(stream, "application/octet-stream", filename);*/
            return NotFound("该功能暂未实现");
        }
    }
}
