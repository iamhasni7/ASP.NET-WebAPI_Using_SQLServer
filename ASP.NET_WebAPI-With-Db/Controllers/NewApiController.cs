using ASP.NET_WebAPI_With_Db.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        //PUT Method
        [HttpPut]
        public IHttpActionResult UpdateStudent(student e)
        {
            db.Entry(e).State = EntityState.Modified;
            db.SaveChanges();

            /*var std = db.students.Where(model => model.std_id == e.std_id).FirstOrDefault();
            if (std != null)
            {
                std.std_id = e.std_id;
                std.std_name = e.std_name;
                std.std_gender = e.std_gender;
                std.std_age = e.std_age;
                std.std_class = e.std_class;
                std.t_id = e.t_id;
                db.SaveChanges();
            }
            else
            {
                return NotFound();
            }*/

            return Ok();
        }

        //DELETE Method

        [HttpDelete]
        public IHttpActionResult DeleteStudent(int id)
        {
            var obj = db.students.Where(model => model.std_id == id).FirstOrDefault();
            db.Entry(obj).State = EntityState.Deleted;
            db.SaveChanges();

            return Ok();
        }
    }
}
