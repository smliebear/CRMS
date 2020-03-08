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
    [Route("api/Home")]
    [ApiController]
    [EnableCors("any")]  //跨域
    public class HomeController : Controller
    {
        private readonly OSMSContext _osmscontext;
        public HomeController(OSMSContext osmscontext)
        {
            _osmscontext = osmscontext;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}

        ////加载主页
        //[AllowAnonymous]
        //// GET api/values/5
        //[HttpGet]
        //public JsonResult Home()
        //{
        //    var list = _osmscontext.SystemResourceModule.ToList();
        //    if (list.Count > 0)//当集合的成员大于0时候，说明登录成功
        //    {
        //        //return RedirectToAction("Index", "Users");//跳转到主页面
        //        return new JsonResult(null);
        //    }
        //    else
        //    {
        //        return new JsonResult(null);
        //    }
        //}
    }
}