using HRsmartDomain;
using HRsmartWeb.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using Rotativa;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HRsmartWeb.Controllers
{
    [Route("api/[controller]")]

    public class JobOfferController : Controller
    {


        [HttpGet]
        public PartialViewResult SomeAction()
        {

            return PartialView();
        }


        public JobOfferController()
        {

        }
        // GET: JobOffer
        public ActionResult Index(string location)
        {
            HttpResponseMessage response;
            HttpClient Job = new HttpClient();
            Job.BaseAddress = new Uri("http://localhost:26945/");
            Job.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            if(String.IsNullOrEmpty(location))
            {
                response = Job.GetAsync("api/JobOfferApi").Result;
            }
            else
            {
                response = Job.GetAsync("api/JobOfferApi?location="+location).Result;
            }
            
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<JobOffer>>().Result;
            }
            else
            {
                ViewBag.result = "error";
            }

            return View();
        }

       

        public ActionResult Details(int id)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:26945/");
            JobOfferViewModel JVM = new JobOfferViewModel();

            var url = "api/JobOfferApi/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var jo = response.Content.ReadAsAsync<JobOffer>().Result;
                JVM.JobTitle = jo.JobTitle;
                JVM.Mission = jo.Mission;
                JVM.Reference = jo.Reference;
                JVM.DemanderProfile = jo.DemanderProfile;
                JVM.Location = jo.Location;
                JVM.ExpirationDate = jo.ExpirationDate;
                JVM.ContratType = (ContractType)jo.ContratType;


                return View(JVM);
            }
            else
            {
                ViewBag.result = "error";
            }
            return View();


        }
        public ActionResult DownloadViewPDF(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:26945/");
            JobOfferViewModel JVM = new JobOfferViewModel();

            var url = "api/JobOfferApi/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var jo = response.Content.ReadAsAsync<JobOffer>().Result;
                JVM.JobTitle = jo.JobTitle;
                JVM.Mission = jo.Mission;
                JVM.Reference = jo.Reference;
                JVM.DemanderProfile = jo.DemanderProfile;
                JVM.Location = jo.Location;
                JVM.ExpirationDate = jo.ExpirationDate;
                JVM.ContratType = (ContractType)jo.ContratType;


                return new ViewAsPdf("Details", JVM) { FileName = "JobOffer.pdf" };
            }
            else
            {
                ViewBag.result = "error";
            }
            return View();
            //Code to get content
        }

        [HttpGet]
        // GET: Candidate/Create
        public ActionResult Create()
        {
            var JVM = new JobOfferViewModel();


            IEnumerable<ContractType> contractTypes = Enum.GetValues(typeof(ContractType)).Cast<ContractType>();
            JVM.Types = from type in contractTypes
                        select new SelectListItem
                        {
                            Text = type.ToString(),
                            Value = ((int)type).ToString()
                        };


            return View(JVM);
        }

        public ActionResult Map()
        {
            return View("Map");
        }

        [HttpPost]
        public ActionResult Create(JobOffer j)
        {
            var JVM = new JobOfferViewModel();


            HttpClient Job = new HttpClient();
            Job.BaseAddress = new Uri("http://localhost:26945/");
            Job.PostAsJsonAsync<JobOffer>("api/JobOfferApi", j).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
            if (string.IsNullOrEmpty(JVM.Mission))
            {
                ModelState.AddModelError("Name", "Name is required");
            }
            if (string.IsNullOrEmpty(JVM.Reference))
            {
                ModelState.AddModelError("Reference", "Reference is required");
            }
            if (string.IsNullOrEmpty(JVM.Location))
            {

                ModelState.AddModelError("Location", "Location is required");

            }

            if (ModelState.IsValid)
            {
                ViewBag.Mission = JVM.Mission;
                ViewBag.Location = JVM.Location;
                ViewBag.Reference = JVM.Reference;
            }
            return RedirectToAction("Index");
        }

        // GET: Candidate/Edit/5
        public ActionResult Edit(int id)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:26945/");
            JobOfferViewModel JVM = new JobOfferViewModel();

            var url = "api/JobOfferApi/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var jo = response.Content.ReadAsAsync<JobOffer>().Result;
                JVM.JobTitle = jo.JobTitle;
                JVM.Mission = jo.Mission;
                JVM.Reference = jo.Reference;
                JVM.DemanderProfile = jo.DemanderProfile;
                JVM.Location = jo.Location;
                JVM.ExpirationDate = jo.ExpirationDate;
                JVM.ContratType = (ContractType)jo.ContratType;


                return View(JVM);
            }
            else
            {
                ViewBag.result = "ddqsdsdq";
            }
            return View();
        }

         public ActionResult search(string topic)
                    {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:26945/");
            JobOfferViewModel JVM = new JobOfferViewModel();
            HttpClient Job = new HttpClient();
            var url = "api/JobOfferApi/" + topic;

            HttpResponseMessage response = Job.GetAsync(url).Result;

            response = Job.GetAsync("Location?Location=" + topic).Result;
            

            if (response.IsSuccessStatusCode)
                       {
                string res = response.Content.ReadAsStringAsync().Result;

                JobOfferViewModel tm = JsonConvert.DeserializeObject<JobOfferViewModel>(res);

                return View(JVM);
            }
            else
            {
                ViewBag.result = "ddqsdsdq";
            }
            return View();

        }

    
        [HttpPost]
        public ActionResult Edit(int id, JobOffer jo)
        {
            var url = "api/JobOfferApi/" + id;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:26945/");
            HttpResponseMessage responseMessage = client.PutAsJsonAsync(url, jo).Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }

        // GET: Candidate/Delete/5
        public ActionResult Delete(int id)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:26945/");
            JobOfferViewModel JVM = new JobOfferViewModel();

            var url = "api/JobOfferApi/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var jo = response.Content.ReadAsAsync<JobOffer>().Result;
                JVM.JobTitle = jo.JobTitle;
                JVM.Mission = jo.Mission;
                JVM.Reference = jo.Reference;
                JVM.DemanderProfile = jo.DemanderProfile;
                JVM.Location = jo.Location;
                JVM.ExpirationDate = jo.ExpirationDate;
                JVM.ContratType = (ContractType)jo.ContratType;


                return View(JVM);
            }
            else
            {
                ViewBag.result = "error";
            }
            return View();
        }
        [HttpPost]
        // GET: Candidate/Delete/5
        public ActionResult Delete(int id, JobOffer jo)
        {
            List<JobOfferViewModel> ListJob = new List<JobOfferViewModel>();
            var std = ListJob.Where(s => s.JobId == id).FirstOrDefault();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:26945/");

            var url = "api/JobOfferApi/" + id;

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

        //public List<object> GetChartData()
        //{
        //    string query = "SELECT COUNT ContratType FROM JobOffers WHERE ContratType = 1 GROUP BY Location ";
        //    string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        //    List<object> chartData = new List<object>();
        //    chartData.Add(new object[]
        //    {
        //"ContratType", "Location"
        //    });
        //    using (SqlConnection con = new SqlConnection(constr))
        //    {
        //        using (SqlCommand cmd = new SqlCommand(query))
        //        {
        //            cmd.CommandType = CommandType.Text;
        //            cmd.Connection = con;
        //            con.Open();
        //            using (SqlDataReader sdr = cmd.ExecuteReader())
        //            {
        //                while (sdr.Read())
        //                {
        //                    chartData.Add(new object[]
        //                    {
        //                sdr["ContratType"], sdr["Location"]
        //                    });
        //                }
        //            }
        //            con.Close();
        //            return chartData;
        //        }
        //    }
        //}


        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    FaceBookConnect.API_Key = "<Your API Key>";
        //    FaceBookConnect.API_Secret = "<Your API Secret>";

        //    if (!IsPostBack)
        //    {
        //        string code = Request.QueryString["code"];
        //        if (!string.IsNullOrEmpty(code))
        //        {
        //            ViewState["Code"] = code;
        //            pnlPost.Enabled = true;
        //            btnAuthorize.Enabled = false;
        //        }
        //    }
        //}

        //protected void Authorize(object sender, EventArgs e)
        //{
        //    FaceBookConnect.Authorize("publish_actions", Request.Url.AbsoluteUri);
        //}

        //protected void Post(object sender, EventArgs e)
        //{
        //    Dictionary<string, string> data = new Dictionary<string, string>();
        //    data.Add("link", "http://www.aspsnippets.com");
        //    data.Add("picture", "http://www.aspsnippets.com/images/Blue/Logo.png");
        //    data.Add("caption", "ASP Snippets");
        //    data.Add("name", "ASP Snippets");
        //    data.Add("message", "I like ASP Snippets");
        //    FaceBookConnect.Post(ViewState["Code"].ToString(), "me/feed", data);
        //}
    }
}
