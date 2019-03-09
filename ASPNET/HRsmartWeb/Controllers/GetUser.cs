
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
    public class GetUser :Controller
    {
        public GetUser()
        {

        }
        public string getUserName()
        {
            string a = Session["Name"] as string;
            return a; }
    }
}