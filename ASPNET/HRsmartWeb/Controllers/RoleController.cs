
using HRsmartDomain;
using HRsmartWeb.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HRsmartWeb.Controllers
{
    public class RoleController : Controller
    {
        HttpClient client = new HttpClient();
        async Task<Uri> CreatRoleAsync(RoleMVC roletMVC)
        {
            HRsmartDomain.Role t = new HRsmartDomain.Role();
            t.Id = roletMVC.Id;
            t.Name = roletMVC.Name;


            HttpResponseMessage response = await client.PostAsJsonAsync("http://localhost:26945/role/add", t);
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }


        async Task<Uri> CreatUserRoleAsync(BigModel b)
        {
            UserRole t = new UserRole();
            t.RoleId = b.UserRole.RoleId;
            t.UserId = b.UserRole.UserId;


            HttpResponseMessage response = await client.PostAsJsonAsync("http://localhost:26945/role/addRoleUser/", t);
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }


    

        // GET: Role
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(RoleMVC r)
        {
            await CreatRoleAsync(r);
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> CreateUserRole(BigModel bigM)
        {
            await CreatUserRoleAsync(bigM);
            return RedirectToAction("GetRoles");
        }

        public async Task<ActionResult> GetRoles()
        {

            BigModel big = new BigModel();

            List<Role> tests = new List<Role>();
            List<RoleMVC> testsMVC = new List<RoleMVC>();
            HttpResponseMessage response = await client.GetAsync("http://localhost:26945/role/get");
            if (response.IsSuccessStatusCode)
            {
                var empResponse = response.Content.ReadAsStringAsync().Result;
                tests = JsonConvert.DeserializeObject<List<Role>>(empResponse);
                foreach (var t in tests)
                {
                    testsMVC.Add(new RoleMVC(t.Id, t.Name));
                }
            }
            big.RoleMVC = testsMVC;
            ////

          

            List<User> tests1 = new List<User>();
            List<UserMVC> testsMVC1 = new List<UserMVC>();
            HttpResponseMessage response1 = await client.GetAsync("http://localhost:26945/role/getUsers/");
            if (response.IsSuccessStatusCode)
            {
                var empResponse1 = response1.Content.ReadAsStringAsync().Result;
                tests1 = JsonConvert.DeserializeObject<List<User>>(empResponse1);
                foreach (var t in tests1)
                {
                    testsMVC1.Add(new UserMVC(t.Id, t.UserName));
                }
            }
            big.UserMVC = testsMVC1;
            ///

            return View(big);



        }
    }
}