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
    [Route("api/[Controller]/[action]")]
    [ApiController]
    [EnableCors("any")]  //跨域
    public class LoginController : Controller
    {
        private readonly CRMContext _crmcontext;
        public LoginController(CRMContext crmcontext)
        {
            _crmcontext = crmcontext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Login()
        {
            return new string[] { "value1", "value2" };
        }


        [AllowAnonymous]
        //GET api/values/5
        [HttpPost]
        public JsonResult LoginPost([FromBody]Teachers teachers)
        {
            var list = _crmcontext.Teachers.Where(u => u.TLoginName == teachers.TLoginName && u.TPwd == teachers.TPwd).ToList();
            if (list.Count > 0)//当集合的成员大于0时候，说明登录成功
            {
                //return RedirectToAction("Index", "Users");//跳转到主页面
                return new JsonResult(new { Name = teachers.TLoginName });
            }
            else
            {
                return new JsonResult(null);
            }
        }
    }
}