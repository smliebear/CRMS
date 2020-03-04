using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{

    //[EnableCors("AllowAllOrigin")]  //跨域  原位置
    [Route("api/Login")]
    [ApiController]
    [EnableCors("any")]  //跨域
    public class LoginController : Controller
    {
        private readonly OSMSContext _osmscontext;
        public LoginController(OSMSContext osmscontext)
        {
            _osmscontext = osmscontext;
        }


        [HttpGet]
        public ActionResult<IEnumerable<string>> Login()
        {
            return new string[] { "value1", "value2" };
        }

        [AllowAnonymous]
        // GET api/values/5
        [HttpPost]
        public JsonResult Login([FromBody] Staff staff)
        {
            var list = _osmscontext.Staff.Where(u => u.Name == staff.Name && u.Password == staff.Password).ToList();
            if (list.Count > 0)//当集合的成员大于0时候，说明登录成功
            {
                //return RedirectToAction("Index", "Users");//跳转到主页面
                return new JsonResult(new { Name=staff.Name });
            }
            else
            {
                return new JsonResult(new { code = 0, result = "aaaaaaaa" });
            }
        }
    }
}