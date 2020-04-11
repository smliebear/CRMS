using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRM.Data;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRM.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [EnableCors("any")]  //跨域
    public class SchoolManageController : Controller
    {
        private readonly CRMContext _crmcontext;
        public SchoolManageController(CRMContext crmcontext)
        {
            _crmcontext = crmcontext;
        }
        //加载主页
        /// <summary>
        /// 普通查询 （模糊查询和分页暂未实现）
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("SchoolGet")]
        public ActionResult SchoolGet()
        {
            List<Schools> list = new List<Schools>();
                 list = _crmcontext.Schools.ToList(); 
                 //list = _crmcontext.Schools.Where(u => u.SchoolName.Contains(schools.SchoolName)).ToList();
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

        /// <summary>
        /// 添加信息
        /// </summary>
        /// <param name="schools"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SchoolAdd")]
        public JsonResult SchoolAdd([FromBody] Schools schools)
        {
            _crmcontext.Schools.Add(schools);
            int i = _crmcontext.SaveChanges();
            if (i > 0)//当集合的成员大于0时候，说明登录成功
            {
                //return RedirectToAction("Index", "Users");//跳转到主页面
                return new JsonResult(i);
            }
            else
            {
                return new JsonResult(i);
            }
        }

        /// <summary>
        /// 删除信息
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("SchoolDelete")]
        public JsonResult SchoolDelete([FromBody] dynamic obj)
        {
            int schoolId = Convert.ToInt32(obj.Id);
            Schools s = _crmcontext.Schools.Where(r => r.SchoolId== schoolId).FirstOrDefault();
            int i = 0;
            if (s != null)
            {
                _crmcontext.Schools.Remove(s);
                 i = _crmcontext.SaveChanges();
                return Json(i);
            }
            else
            {
                return Json(i);
            }
        }

        /// <summary>
        /// 修改查询
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SchoolPostput")]
        public JsonResult SchoolPostPut([FromBody] dynamic obj)
        {
            int SchoolId = Convert.ToInt32(obj.Id);
            List<Schools> list = new List<Schools>();
            list = _crmcontext.Schools.Where(u => u.SchoolId== SchoolId).ToList();
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

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Schoolput")]
        public JsonResult SchoolPut([FromBody] dynamic obj)
        {
            Schools school = new Schools();
            school.SchoolId = obj.schoolId;
            school.SchoolName = obj.schoolName;
            school.SchoolRemark = obj.schoolRemark;
            school.SchoolCode = obj.SchoolCode;
            _crmcontext.Entry(school).State = EntityState.Modified;
            int i = 0;
            if(school!=null)
            {
                _crmcontext.Schools.Remove(school);
                i = _crmcontext.SaveChanges();
                return Json(i);
            }
            else
            {
                return Json(i);
            }
           
        }
    }
}