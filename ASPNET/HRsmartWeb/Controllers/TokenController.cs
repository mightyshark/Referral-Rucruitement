
using HRsmartDomain;
using HRsmartWeb.Models;
using Microsoft.AspNet.Identity;

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Mvc;

namespace HRsmartWeb.Controllers
{
    public class TokenController : Controller
    {
        static ClaimsIdentity claim;
        static string username;
        // GET: Token
        [Route("Home/Index")]
        public async Task<ActionResult> Index()
        {

            /*  string a = HttpClientExtentions.GetToken("http://localhost:17468/", "bouzid", "azerty007");
              string b = HttpClientExtentions.CallApi("http://localhost:17468/api/data/authenticate", a);
                    HttpClient c = new HttpClient();
                   var t = JsonConvert.DeserializeObject<Token>(a);
                   c.DefaultRequestHeaders.Add("Authorization", "Bearer " + t.access_token);
                    HttpResponseMessage response = await c.GetAsync("http://localhost:17468/api/data/authenticate");
                    if (response.IsSuccessStatusCode)
                    {
                        var empResponse = response.Content.ReadAsStringAsync().Result;
                  string claim = JsonConvert.DeserializeObject<string>(empResponse);

                    }

              //Response.Cookies["UserName"].Value = "bouzid";


           

              ViewBag.token1 = Response.Cookies["Name"].Value;
              */
            //  string a = Session["AcessToken"] as string;

            // ViewBag.token1 = RefreshAccesToken;
            string RefreshAccesToken = HttpClientExtentions.CallApi("http://localhost:26945/api/data/RefreshToken", Session["AccessToken"] as string);

            if (RefreshAccesToken.Contains("Ok"))
            {
                Response.Cookies["Name"].Value = Session["Name"] as string;
                return View();
            }
            else { return RedirectToAction("Authentication"); }


        }

        //





        async Task<Uri> inscriptionAsync(UserMVC userMVC)
        {
            HttpClient client = new HttpClient();


            User t = new User();
            t.Id = userMVC.Id;
            t.UserName = userMVC.UserName;
            // t.Email = userMVC.Email;
            //   t.EmailConfirmed = userMVC.EmailConfirmed;
            // t.PasswordHash = Crypto.HashPassword(userMVC.PasswordHash);

            t.PasswordHash = userMVC.PasswordHash;




            HttpResponseMessage response = await client.PostAsJsonAsync("http://localhost:26945/inscription/add/", t);
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }
        [Route("Home/Signin")]
        public ActionResult Inscription()
        {

            return View();
        }
        [HttpPost]
        [Route("Home/Signin")]
        public async Task<ActionResult> Inscription(UserMVC userMVC)
        {
            if (await GetUser(userMVC.UserName) == true)
            {
                await inscriptionAsync(userMVC);
                return RedirectToAction("Authentication");
            }

            else {

                ViewBag.ErrorMessage = "UserName Alrady Exist";
                return View(); }
            
        }


    

        //

            [HttpGet]
        [Route("Home/Login")]
        public ActionResult Authentication()
        {
          
            return View();
        }
        [HttpPost]
        [Route("Home/Login")]
        public ActionResult Authentication(UserMVC user)
        {
            string AccesToken = HttpClientExtentions.GetToken("http://localhost:26945/", user.UserName, user.PasswordHash);

            ViewBag.AccesToken = AccesToken;
            if (AccesToken.Contains("expires_in"))
            {

                string UserName = HttpClientExtentions.CallApi("http://localhost:26945/api/data/authenticate", AccesToken);
                string Name = UserName.RemoveSpecialCharacters();
               Session["Name"] = Name as string;
                Session["AccessToken"] = AccesToken as string ;
           
                string hh = Session["AccessToken"] as string;
                string RefreshAccesToken = HttpClientExtentions.CallApi("http://localhost:26945/api/data/RefreshToken", Session["AccessToken"] as string);
                return RedirectToAction("Index");
               // ViewBag.s = RefreshAccesToken;
               
            }
            else
            {
                return View();
            }
        }



        public async Task<bool> GetUser(string UserName)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://localhost:26945/rec/getusers/" + UserName);
            if (response.IsSuccessStatusCode)
            {
                var empResponse = response.Content.ReadAsStringAsync().Result;
                if (empResponse.Contains("0"))
                { return true; }
                

                }
            return false;
            }


          
        }

    }
    public static class MethodExtensionHelper
    {
        public static string RemoveSpecialCharacters(this string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '_')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
        //
     
    }
