using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twilio;
using Twilio.Types;
using Twilio.Rest.Api.V2010.Account;
using Twilio.AspNet.Mvc;
using System.Configuration;


namespace HRsmartWeb.Controllers
{
    public class SMSController : TwilioController
    {
        public ActionResult SendSms()
        {

            //var accountSid = "AC7f754aefea9363106577407a7525450a";
            //var authToken = "02f5ea3e96b325d145d054c53ad0bdf1";
            //TwilioClient.Init(accountSid, authToken);
            //var to = new PhoneNumber("+21696819820");
            //var from = new PhoneNumber("+21696819820");
            //var message = MessageResource.Create(to: to, from: from,
            //    body: "Cher partenaire! on vous informe que votre demande de partenariat a été accepté. Merci pour votre fidélité.");

            //return Content(message.Sid);

            var accountSid = "AC91b36c6f03129c54d9883b964c524094";
            var authToken = "899036aecfb549b4fb8847500f6edc9d";
            TwilioClient.Init(accountSid, authToken);
            var to = new PhoneNumber("+21696819820");
            var from = new PhoneNumber("+13862065902");
            var message = MessageResource.Create(to: to, from: from,
                body: "Hi, We Are HRSmart Comapany ! Congratulations, You are invited to pass an Interview in one Week");
            return Content(message.Sid);

        }

        // GET: Sms
        public ActionResult Index()
        {
            return View();
        }

        // GET: Sms/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Sms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sms/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sms/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Sms/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sms/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Sms/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
