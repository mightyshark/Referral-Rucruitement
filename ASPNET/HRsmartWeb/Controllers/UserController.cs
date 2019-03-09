using HRsmartDomain;

using HRsmartWeb.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace HRsmartWeb.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {


        public UserController()
        {

        }
        // GET: User
        public ActionResult Index(string name)
        {
            HttpResponseMessage response;
            HttpClient Users = new HttpClient();
            Users.BaseAddress = new Uri("http://hrsmartwebapi-test.eu-west-1.elasticbeanstalk.com/");
            UserViewModel UVM = new UserViewModel();
            Users.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            if (String.IsNullOrEmpty(name))
            {
                response = Users.GetAsync("api/UserApi").Result;
            }
            else
            {
                response = Users.GetAsync("api/UserApi?name="+name).Result;
            }

            if (response.IsSuccessStatusCode)
            {

                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<User>>().Result;
            }
            else
            {
                ViewBag.result = "error";
            }

            return View();
        }


        //Export list via excel

        [HttpPost]
        [ValidateInput(false)]
        public FileResult Export(string GridHtml)
        {
            return File(Encoding.ASCII.GetBytes(GridHtml), "application/vnd.ms-excel", "Grid.xls");
        }


        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            HttpClient Users = new HttpClient();
            Users.BaseAddress = new Uri("http://localhost:26945");
            UserViewModel UVM = new UserViewModel();

            var url = "api/UserApi/" + id;
            HttpResponseMessage response = Users.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var u = response.Content.ReadAsAsync<User>().Result;

                UVM.FirstName = u.Email;
                UVM.LastName = u.UserName;

                UVM.Email = u.Email;
                UVM.Role = (Roles)u.Role;


                return View(UVM);
            }
            else
            {
                ViewBag.result = "error";
            }
            return View();

        }
        [HttpGet]
        // GET: User/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User u)
        {

            /* second try*/
            //string connexionString = "Data Source=(LocalDb)\\MSSQLLocalDB;" +
            //    "Initial Catalog=CloudStorm; ";
            //SqlConnection conn = new SqlConnection(connexionString);
            //SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE UserName = @UserName", conn);
            //cmd.Parameters.AddWithValue("@UserName", this.UserName.Text);
            //conn.Open();
            //SqlDataReader reader = cmd.ExecuteReader();
            //if (!reader.HasRows)
            //{

            HttpClient Users = new HttpClient();
            Users.BaseAddress = new Uri("http://localhost:26945");
            Users.PostAsJsonAsync<User>("api/UserApi", u).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
            return RedirectToAction("Index");



            //}
            //else { ViewBag.MessageErreur = " You Already Used this userName"; }
            //return View();

        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {



            HttpClient Users = new HttpClient();
            Users.BaseAddress = new Uri("http://localhost:26945");
            UserViewModel UVM = new UserViewModel();

            var url = "api/UserApi/" + id;
            HttpResponseMessage response = Users.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var u = response.Content.ReadAsAsync<User>().Result;

                UVM.FirstName = u.Email;
                UVM.LastName = u.UserName;
                UVM.Email = u.Email;
                UVM.Role = (Roles)u.Role;
                return View(UVM);
            }
            else
            {
                ViewBag.result = "error";
            }
            return View();


        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User u)
        {
            var url = "api/UserApi/" + id;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:26945/");
            HttpResponseMessage responseMessage = client.PutAsJsonAsync(url, u).Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:26945/");
            UserViewModel UVM = new UserViewModel();

            var url = "api/UserApi/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var u = response.Content.ReadAsAsync<User>().Result;
                UVM.FirstName = u.Id;
                UVM.LastName = u.UserName;
                UVM.Email = u.Email;
                UVM.Role = (Roles)u.Role;

            }
            else
            {
                ViewBag.result = "error";
            }
            return View(UVM);
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, User u)
        {

            List<UserViewModel> ListUser = new List<UserViewModel>();
            var us = ListUser.Where(s => s.UserId == id).FirstOrDefault();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:26945/");

            var url = "api/UserApi/" + id;

            HttpResponseMessage response = client.DeleteAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }


        private void SendEmail(User user)
        {

            using (MailMessage mm = new MailMessage("sender@gmail.com", user.Email))
            {
                mm.Subject = "Account Activation";
                string body = "Hello " + user.UserName + ",";
                body += "<br /><br />You will be logging to HRsmart Recrutement via this email";
                body += "<br /><br />Thanks";
                mm.Body = body;
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential("sender@gmail.com", "<password>");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);
            }
        }



    }
}
