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
using HRsmartDomain.Entities;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Newtonsoft.Json;

namespace HRsmartWeb.Controllers
{


    [Route("api/[controller]")]

    public class InterviewController : Controller
    {

        public ActionResult Generate(object sender, EventArgs e)
        {
            HttpClient Interviews = new HttpClient();
            Interviews.BaseAddress = new Uri("http://localhost:26945");
            Interviews.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = Interviews.GetAsync("api/InterviewAPI").Result;

            IEnumerable<Interview> liste = response.Content.ReadAsAsync<IEnumerable<Interview>>().Result;
            try
            {
                Document pdfDoc = new Document(PageSize.A4, 25, 10, 25, 10);
                PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.Open();
                pdfDoc.AddTitle("Liste des Interviews");
                pdfDoc.AddAuthor("Younes Nahali");
                pdfDoc.AddCreationDate();
                pdfDoc.AddHeader("haha", "hihi");
                pdfDoc.AddSubject("La liste des Interviews");
                Paragraph textAccueil = new Paragraph("********************************       La liste des Interviews       ********************************");
                Paragraph Espace1 = new Paragraph(" ");
                Paragraph Espace2 = new Paragraph(" ");
                pdfDoc.Add(textAccueil);
                pdfDoc.Add(Espace1);
                pdfDoc.Add(Espace2);
                foreach (Interview r in liste)
                {
                    Paragraph Text = new Paragraph(r.ToString());
                    Paragraph Espace = new Paragraph(" ");
                    pdfDoc.Add(Text);
                    pdfDoc.Add(Espace);
                }
                pdfWriter.CloseStream = false;
                pdfDoc.Close();
                Response.Buffer = true;
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=Reclamations.pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Write(pdfDoc);
                Response.End();
            }
            catch (Exception ex)
            { Response.Write(ex.Message); }
            return View(liste);
        }





        [HttpGet]
        public PartialViewResult SomeAction()
        {

            return PartialView();
        }


        public InterviewController()
        {

        }


        /*------------------------------------------------------------------------------Affichage-------------------------------------------*/

        // GET: Candidate
        public ActionResult Index(string subject)
        {
            HttpResponseMessage response;
            HttpClient Interview = new HttpClient();
            Interview.BaseAddress = new Uri("http://localhost:26945/");
            Interview.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            if (String.IsNullOrEmpty(subject))
            {
                response = Interview.GetAsync("api/InterviewAPI").Result;
            }
            else
            {
                response = Interview.GetAsync("api/InterviewAPI?Subject="+subject).Result;
            }

            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<Interview>>().Result;
            }
            else
            {
                ViewBag.result = "error";
            }

            return View();
        }


        /*------------------------------------------------------------------------------Affichage détaillé-------------------------------------------*/

        // GET: Interview/Details/5
        public ActionResult Details(int id)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:26945/");
            InterviewViewModel CVM = new InterviewViewModel();

            var url = "api/InterviewAPI/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var c = response.Content.ReadAsAsync<Interview>().Result;
                CVM.Subject = c.Subject;
                CVM.Description = c.Description;
                CVM.StartDate = c.StartDate;
                CVM.EndDate = c.EndDate;
                CVM.ResultHRInterview = c.ResultHRInterview;
                CVM.ResultTechnicalInterview = c.ResultTechnicalInterview;
                CVM.ResultQIInterview = c.ResultQIInterview;
                CVM.ResultSoftSkillsInterview = c.ResultSoftSkillsInterview;
                CVM.CandidateStates = (CandidateState)c.CandidateStates;
                CVM.FeedBack = c.FeedBack;

            }
            else
            {
                ViewBag.result = "error";
            }
            return View(CVM);


        }


        /*------------------------------------------------------------------------------Create-------------------------------------------*/



        // GET: Interview/Create
        public ActionResult Create(int id)
        {
            var JVM = new InterviewViewModel();
            //var id = Request["id"];
            Session["candidateId"] = id;
            IEnumerable<CandidateState> CandidateState = Enum.GetValues(typeof(CandidateState)).Cast<CandidateState>();

            JVM.State = from type in CandidateState
                        select new SelectListItem
                        {
                            Text = type.ToString(),
                            Value = ((int)type).ToString()
                        };


            return View(JVM);
        }


        [HttpPost]
        // GET: Candidate/Create
        public ActionResult Create(Interview c)

        {
            c.CandidateId = (int)Session["candidateId"];
            HttpClient Interviews = new HttpClient();
            Interviews.BaseAddress = new Uri("http://localhost:26945");
            Interviews.PostAsJsonAsync<Interview>("api/InterviewAPI", c).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());

            SMSController sms = new SMSController();
            sms.SendSms();
            return RedirectToAction("Index");


            //https://www.twilio.com/console/sms/getting-started/build
        }

        /*------------------------------------------------------------------------------Update-------------------------------------------*/



        // GET: Interveiw/Edit/5
        public ActionResult Edit(int id)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:26945/");
            InterviewViewModel CVM = new InterviewViewModel();

            var url = "api/InterviewAPI/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var c = response.Content.ReadAsAsync<Interview>().Result;
                CVM.Subject = c.Subject;
                CVM.Description = c.Description;
                CVM.StartDate = c.StartDate;
                CVM.EndDate = c.EndDate;
                CVM.ResultHRInterview = c.ResultHRInterview;
                CVM.ResultTechnicalInterview = c.ResultTechnicalInterview;
                CVM.ResultQIInterview = c.ResultQIInterview;
                CVM.ResultSoftSkillsInterview = c.ResultSoftSkillsInterview;
                CVM.CandidateStates = (CandidateState)c.CandidateStates;
                CVM.FeedBack = c.FeedBack;

                return View(CVM);
            }
            else
            {
                ViewBag.result = "error";
            }
            return View();

        }
        [HttpPost]
        public ActionResult Edit(int id, Interview c)
        {
            c.FinalResult = (c.ResultHRInterview + c.ResultQIInterview + c.ResultTechnicalInterview + c.ResultSoftSkillsInterview) / 4;

            var url = "api/InterviewAPI/" + id;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:26945/");
            HttpResponseMessage responseMessage = client.PutAsJsonAsync(url, c).Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }






        /*------------------------------------------------------------------------------Delete-------------------------------------------*/


        // GET: Interview/Delete/5
        public ActionResult Delete(int id)
        {


            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:26945/");
            InterviewViewModel CVM = new InterviewViewModel();

            var url = "api/InterviewAPI/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var c = response.Content.ReadAsAsync<Interview>().Result;
                CVM.Subject = c.Subject;
                CVM.Description = c.Description;
                CVM.StartDate = c.StartDate;
                CVM.EndDate = c.EndDate;
                CVM.ResultHRInterview = c.ResultHRInterview;
                CVM.ResultTechnicalInterview = c.ResultTechnicalInterview;
                CVM.ResultQIInterview = c.ResultQIInterview;
                CVM.ResultSoftSkillsInterview = c.ResultSoftSkillsInterview;
                CVM.CandidateStates = (CandidateState)c.CandidateStates;
                CVM.FeedBack = c.FeedBack;

            }
            else
            {
                ViewBag.result = "error";
            }
            return View(CVM);


        }
        [HttpPost]
        // GET: Interview/Delete/5
        public ActionResult Delete(int id, Interview JVM)
        {
            List<InterviewViewModel> ListInterview = new List<InterviewViewModel>();
            var std = ListInterview.Where(s => s.InterviewId == id).FirstOrDefault();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:26945/");

            var url = "api/InterviewAPI/" + id;

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

        //DROPDOWN WORK Starts here

        public ActionResult search(string Subject)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:26945/");
            InterviewViewModel JVM = new InterviewViewModel();
            HttpClient Job = new HttpClient();
            var url = "api/InterviewAPI/" + Subject;

            HttpResponseMessage response = Job.GetAsync(url).Result;

            response = Job.GetAsync("Subject?Subject=" + Subject).Result;


            if (response.IsSuccessStatusCode)
            {
                string res = response.Content.ReadAsStringAsync().Result;

                InterviewViewModel tm = JsonConvert.DeserializeObject<InterviewViewModel>(res);

                return View(JVM);
            }
            else
            {
                ViewBag.result = "ddqsdsdq";
            }
            return View();

        }


    }


}