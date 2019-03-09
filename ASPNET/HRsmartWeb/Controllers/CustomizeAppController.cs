using HRsmartDomain;
using HRsmartWeb.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace HRsmartWeb.Controllers
{
    [Route("api/[controller]")]

    public class CustomizeAppController : Controller
    {



        [HttpGet]
        public PartialViewResult SomeAction()
        {

            return PartialView();
        }
        public ActionResult Map()
        {
            return View("Map");
        }
        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            HttpClient Users = new HttpClient();
            Users.BaseAddress = new Uri("http://localhost:26945");
            CustomizeAppModel UVM = new CustomizeAppModel();

            var url = "api/CustomizeAPI/" + id;
            HttpResponseMessage response = Users.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var u = response.Content.ReadAsAsync<CustomizeApp>().Result;


                UVM.Logo = u.Logo;
                UVM.Url = u.Url;
                UVM.WlcText = u.WlcText;
                UVM.address = u.address;
                UVM.CompF = (CompField)u.CompF;
                UVM.CompS = (CompState)u.CompS;
                UVM.CreationDate = u.CreationDate;
                return View(UVM);
            }
            else
            {
                ViewBag.result = "error";
            }
            return View();

        }
        public CustomizeAppController()
        {
        }
        // GET: JobOffer
        public ActionResult Index()
        {
            HttpClient customize = new HttpClient();
            customize.BaseAddress = new Uri("http://localhost:26945/");
            customize.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = customize.GetAsync("api/CustomizeAPI").Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<CustomizeApp>>().Result;
            }
            else
            {
                ViewBag.result = "error";
            }
            return View();
        }

        public ActionResult Welcome()
        {
            return View("Welcome");
        }

        [HttpGet]
        // GET: CustomizeApp/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(CustomizeApp u)
        {
            HttpClient Users = new HttpClient();
            Users.BaseAddress = new Uri("http://localhost:26945");
            Users.PostAsJsonAsync<CustomizeApp>("api/CustomizeAPI", u).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
            return RedirectToAction("Index");
        }



        // GET: CustomizeApp/Edit/5
        public ActionResult Edit(int id)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:26945/");
            CustomizeAppModel CVM = new CustomizeAppModel();

            var url = "api/CustomizeAPI/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                var c = response.Content.ReadAsAsync<CustomizeApp>().Result;
                CVM.Logo = c.Logo;
                CVM.Url = c.Url;
                CVM.WlcText = c.WlcText;
                CVM.address = c.address;

                return View(CVM);
            }
            else
            {
                ViewBag.result = "error";
            }
            return View();

        }
        [HttpPost]
        public ActionResult Edit(int id, CustomizeApp c)
        {
            var url = "api/CustomizeAPI/" + id;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:26945/");
            HttpResponseMessage responseMessage = client.PutAsJsonAsync(url, c).Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }
        public ActionResult Delete(int id)
        {
            return View();
        }
        [HttpPost]
        // GET: CustomizeApp/Delete/5
        public ActionResult Delete(int id, CustomizeApp JVM)
        {
            List<CustomizeAppModel> ListCandidate = new List<CustomizeAppModel>();
            var std = ListCandidate.Where(s => s.IdCustom == id).FirstOrDefault();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:26945/");

            var url = "api/CustomizeAPI/" + id;

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

        //        public JsonResult ImageUpload(CustomizeAppModel model)
        //        {

        //            var file = model.ImageFile;

        //            if (file != null)
        //            {

        //                var fileName = Path.GetFileName(file.FileName);
        //                var extention = Path.GetExtension(file.FileName);
        //                var filenamewithoutextension = Path.GetFileNameWithoutExtension(file.FileName);

        //                file.SaveAs(Server.MapPath("/UploadedImage/" + file.FileName));



        //            }

        //            return Json(file.FileName, JsonRequestBehavior.AllowGet);


        //    }


    }
    //}
}