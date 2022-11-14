using ASP.NET_WebAPI_With_Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace ASP.NET_WebAPI_With_Db.Controllers
{
    public class NewApiController : ApiController
    {
        practiceEntities db = new practiceEntities();

        //GET Method
        [HttpGet]
        public IHttpActionResult GetStudent()
        {
            List<student> obj = db.students.ToList();
            return Ok(obj);
        }

        [HttpGet]
        public IHttpActionResult GetStudentById(int id)
        {
            var obj = db.students.Where(model => model.std_id == id).FirstOrDefault();
            return Ok(obj);
        }

        //POST Method
        [HttpPost]
        public IHttpActionResult InsertStudent(student e)
        {
            db.students.Add(e);
            db.SaveChanges();
            return Ok();
        }


    }
}
