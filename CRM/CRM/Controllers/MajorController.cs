using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM.Data;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [EnableCors("any")]  //跨域
    public class MajorController : Controller
    {
        private readonly CRMContext _crmcontext;
        public MajorController(CRMContext crmcontext)
        {
            _crmcontext = crmcontext;
        }

        //加载主页
        [HttpGet]
        [Route("MajorGet")]
        public ActionResult MajorGet()
        {
            var list = _crmcontext.Stations.ToList();
            if (list.Count > 0)//当集合的成员大于0时候，说明登录成功
            {
                
                return new JsonResult(list);
            }
            else
            {
                return new JsonResult(null);
            }
        }
    }
}