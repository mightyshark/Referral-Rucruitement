//using HRsmartDomain;
//using HRsmartService;
//using HRsmartWeb.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace HRsmartWeb.Controllers
//{
//    public class JobCandidateController : Controller
//    {
//        // GET: JobCandidate

//        CandidatService CS = null;
//        JobOfferService JS = null;
        

//        public JobCandidateController()
//        {
//            CS = new CandidatService();
//            JS = new JobOfferService();

//        }
//        public ActionResult Index()
//        {
//            List<CandidateViewModel> ListCandidate = new List<CandidateViewModel>();
//            List<Candidate> LC = new List<Candidate>(); //


//            LC = CS.GetAll().ToList();

//            foreach (var item in LC)
//            {
//             //   JobOffer jf = new JobOffer { JobTitle=  }; 

//                CandidateViewModel CVM = new CandidateViewModel();
 
//                CVM.FirstName = item.FirstName;
//                CVM.LastName = item.LastName;
//                CVM.Age = item.Age;
//                CVM.Adresse = item.Adresse;
//                CVM.ContactNumber = item.ContactNumber;
//                CVM.Email = item.Email;
//                CVM.LinkedInProfile = item.LinkedInProfile;
//          //      CVM.JobOffer.JobTitle = item.JobOffer.JobTitle;
//           //     CVM.Employee.LastName = item.Employee.LastName ;
//             //   CVM.Employee.FirstName = item.Employee.FirstName ; 


//                ListCandidate.Add(CVM);
//            }

//            return View(ListCandidate);
//        }

//        // GET: JobCandidate/Details/5
//        public ActionResult Details(int id)
//        {
//            List<CandidateViewModel> ListCandidate = new List<CandidateViewModel>();
//            List<Candidate> LC = new List<Candidate>(); //
//            LC = CS.GetAll().ToList();
//            CandidateViewModel CVM = new CandidateViewModel();
//            foreach (var item in LC)
//            {

//                CVM.Cin = item.Cin;
//                CVM.FirstName = item.FirstName;
//                CVM.LastName = item.LastName;
//                CVM.Age = item.Age;
//                CVM.Adresse = item.Adresse;
//                CVM.Gender = (Gender)item.Gender;
//                CVM.Email = item.Email;
//                CVM.ContactNumber = item.ContactNumber;
//                CVM.LinkedInProfile = item.LinkedInProfile;
//                CVM.FaceBookProfile = item.FaceBookProfile;
//             //   CVM.Recommandations = item.Recommandations;
//                CVM.CandidateState = (CandidateState)item.CandidateState;
//                CVM.InterviewSteps = (InterviewSteps)item.InterviewSteps;
//                ListCandidate.Add(CVM);
//            }

//            return View(CVM);
//        }

//        // GET: JobCandidate/Create
//        public ActionResult Create()
//        {

//            return View();
//        }

//        // POST: JobCandidate/Create
//        [HttpPost]
//        public ActionResult Create(FormCollection collection)
//        {
//            try
//            {
//                // TODO: Add insert logic here

//                return RedirectToAction("Index");
//            }
//            catch
//            {
//                return View();
//            }
//        }

  
//        //-------------------------------------------------////
//        // GET: JobCandidate/Edit/5
//        public ActionResult Edit(int id)
//        {
//            return RedirectToAction("Index");
//        }

//        // POST: JobCandidate/Edit/5
//        [HttpPost]
//        public ActionResult Edit(int id, FormCollection collection)
//        {
//            try
//            {
//                // TODO: Add update logic here

//                return RedirectToAction("Index");
//            }
//            catch
//            {
//                return View();
//            }
//        }

//        // GET: JobCandidate/Delete/5
//        public ActionResult Delete(int id)
//        {
//            return View();
//        }

//        // POST: JobCandidate/Delete/5
//        [HttpPost]
//        public ActionResult Delete(int id, FormCollection collection)
//        {
//            try
//            {
//                // TODO: Add delete logic here

//                return RedirectToAction("Index");
//            }
//            catch
//            {
//                return View();
//            }
//        }
//    }
//}
