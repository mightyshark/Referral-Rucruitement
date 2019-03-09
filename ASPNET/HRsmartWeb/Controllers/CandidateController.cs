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

namespace HRsmartWeb.Controllers
{
    [Route("api/[controller]")]

    public class CandidateController : Controller
    {


        [HttpGet]
        public PartialViewResult SomeAction()
        {

            return PartialView();
        }



        public CandidateController()
        {
        }

        /*----------------------------------------CandidateList----------------------------*/

        // GET: Candidate
        public ActionResult Index()
        {
            HttpClient Candidates = new HttpClient();
            Candidates.BaseAddress = new Uri("http://localhost:26945");
            Candidates.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Candidates.GetAsync("api/CandidateApi").Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<Candidate>>().Result;
            }
            else
            {
                ViewBag.result = "error";
            }
            return View();
        }
        /*-----------------------------GetDetails-----------------------------------*/
        // GET: Candidate/Details/5
        public ActionResult Details(int id)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:26945/");
            CandidateViewModel CVM = new CandidateViewModel();

            var url = "api/CandidateApi/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var c = response.Content.ReadAsAsync<Candidate>().Result;
                CVM.CandidateId = c.CandidateId;
                CVM.Cin = c.Cin;
                CVM.FirstName = c.FirstName;
                CVM.LastName = c.LastName;
                CVM.Age = c.Age;
                CVM.Adresse = c.Adresse;
                CVM.Gender = (Gender)c.Gender;
                CVM.Email = c.Email;
                CVM.ContactNumber = c.ContactNumber;
                CVM.LinkedInProfile = c.LinkedInProfile;
                CVM.FaceBookProfile = c.FaceBookProfile;
                CVM.Recommandations = c.Recommandations;
                CVM.SkypeId = c.SkypeId;

            }
            else
            {
                ViewBag.result = "error";
            }
            return View(CVM);


        }


        [HttpGet]
        // GET: Candidate/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(Candidate c)
        {
            HttpClient Candidates = new HttpClient();
            Candidates.BaseAddress = new Uri("http://localhost:26945");
            Candidates.PostAsJsonAsync<Candidate>("api/CandidateApi", c).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
            return RedirectToAction("Index");
        }


        // GET: Candidate/Edit/5
        public ActionResult Edit(int id)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:26945/");
            CandidateViewModel CVM = new CandidateViewModel();

            var url = "api/CandidateApi/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var c = response.Content.ReadAsAsync<Candidate>().Result;
                CVM.Cin = c.Cin;
                CVM.FirstName = c.FirstName;
                CVM.LastName = c.LastName;
                CVM.Age = c.Age;
                CVM.Adresse = c.Adresse;
                CVM.Gender = (Gender)c.Gender;
                CVM.Email = c.Email;
                CVM.ContactNumber = c.ContactNumber;
                CVM.LinkedInProfile = c.LinkedInProfile;
                CVM.FaceBookProfile = c.FaceBookProfile;
                CVM.Recommandations = c.Recommandations;
                CVM.CandidateState = (CandidateState)c.CandidateState;
                CVM.InterviewSteps = (InterviewSteps)c.InterviewSteps;
                return View(CVM);
            }
            else
            {
                ViewBag.result = "error";
            }
            return View();

        }
        [HttpPost]
        public ActionResult Edit(int id, Candidate c)
        {
            var url = "api/CandidateApi/" + id;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:26945/");
            HttpResponseMessage responseMessage = client.PutAsJsonAsync(url, c).Result;
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
            CandidateViewModel CVM = new CandidateViewModel();

            var url = "api/CandidateApi/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var c = response.Content.ReadAsAsync<Candidate>().Result;
                CVM.CandidateId = c.CandidateId;
                CVM.Cin = c.Cin;
                CVM.FirstName = c.FirstName;
                CVM.LastName = c.LastName;
                CVM.Age = c.Age;
                CVM.Adresse = c.Adresse;
                CVM.Gender = (Gender)c.Gender;
                CVM.Email = c.Email;
                CVM.ContactNumber = c.ContactNumber;
                CVM.LinkedInProfile = c.LinkedInProfile;
                CVM.FaceBookProfile = c.FaceBookProfile;
                CVM.Recommandations = c.Recommandations;
                CVM.SkypeId = c.SkypeId;

            }
            else
            {
                ViewBag.result = "error";
            }
            return View(CVM);

        }
        [HttpPost]
        // GET: Candidate/Delete/5
        public ActionResult Delete(int id, Candidate JVM)
        {
            List<CandidateViewModel> ListCandidate = new List<CandidateViewModel>();
            var std = ListCandidate.Where(s => s.CandidateId == id).FirstOrDefault();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:26945/");

            var url = "api/CandidateApi/" + id;

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
    }
}
