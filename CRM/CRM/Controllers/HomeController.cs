﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM.Data;
//using CRM.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{

    [Route("api/[Controller]")]
    [ApiController]
    [EnableCors("any")]  //跨域
    public class HomeController : Controller
    {
        private readonly CRMContext _crmcontext;
        public HomeController(CRMContext crmcontext)
        {
            _crmcontext = crmcontext;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}

        //加载主页
        [HttpGet]
        [Route("HomeGet")]
        public ActionResult HomeGet()
        {
            var list = _crmcontext.Specialties.ToList();
            if (list.Count > 0)//当集合的成员大于0时候，说明登录成功
            {
                //return RedirectToAction("Index", "Users");//跳转到主页面
                return new JsonResult(list);
            }
            else
            {
                return new JsonResult(null);
            }
        }

        
    }
}