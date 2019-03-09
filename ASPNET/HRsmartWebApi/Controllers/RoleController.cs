
using HRsmartDomain;
using HRsmartService;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HRsmartWebApi.Controllers
{
    public class RoleController : ApiController
    {

        [Route("role/add/")]
        [HttpPost]
        public void add([FromBody]Role t)
        {

            GestionRole gt = new GestionRole();
            gt.Create(t);
            gt.Commit();

        }

        [Route("role/addRoleUser/")]
        [HttpPost]
        public void addRoleToUser([FromBody]UserRole t)
        {

            GestionUserRoles gt = new GestionUserRoles();
            gt.Create(t);
            gt.Commit();

        }



        [HttpGet]
        [Route("role/get/")]
        public IHttpActionResult Getroles()
        {

            GestionRole gr = new GestionRole();

            IEnumerable<Role> list = gr.GetAll();


            return Ok(list);
        }

        [HttpGet]
        [Route("role/getUsers/")]
        public IHttpActionResult GetUsers()
        {

            GestionIdentity gr = new GestionIdentity();

            IEnumerable<User> list = gr.GetAll();


            return Ok(list);
        }
    }
}
