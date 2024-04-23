using AjaxRevision.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AjaxRevision.Controllers
{
    public class HomeController : Controller
    {
        DataLayer db=new DataLayer();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(DataModel data)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@name",data.name),
                new SqlParameter("@email",data.email),
                new SqlParameter("@mobno",data.mobno),
                new SqlParameter("@clg",data.clg),
                new SqlParameter("@action",1),
            };
            int res = db.ExecuteDML("sp_crudAjax",parameters);
            if(res>0)
            {
                return Json("Student Added");
            }
            else
            {
                return Json("Student Not Added");
            }
        }
        public JsonResult Selectdata()
        {
            SqlParameter[] para = new SqlParameter[]
           {
                new SqlParameter("@action",2),
           };
            DataTable dt = db.ExecuteSelect("sp_crudAjax", para);
            List<DataModel> list = new List<DataModel>();
            foreach (DataRow row in dt.Rows) 
            {
                DataModel d1= new DataModel()
                {
                    sr = Convert.ToInt32(row["sr"]),
                    name = row["name"].ToString(),
                    email = row["email"].ToString(),
                    mobno = Convert.ToInt64(row["mobno"]),
                    clg = row["clg"].ToString(),
                };
                list.Add(d1);
                
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public JsonResult UpdateUser(DataModel data)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@name",data.name),
                new SqlParameter("@email",data.email),
                new SqlParameter("@mobno",data.mobno),
                new SqlParameter("@clg",data.clg),
                new SqlParameter("sr",data.sr),
                new SqlParameter("@action",3),
            };
            int res = db.ExecuteDML("sp_crudAjax", parameters);
            if (res > 0)
            {
                return Json("Student Data Updated");
            }
            else
            {
                return Json("Student Data Not Updated");
            }
        }
    }
}