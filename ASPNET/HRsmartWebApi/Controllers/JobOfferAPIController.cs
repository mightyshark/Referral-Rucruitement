using HRsmartData;
using HRsmartDomain;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace HRsmartWebApi.Controllers
{
    public class JobOfferAPIController : ApiController
    {
        IServices<JobOffer> serv = new Services<JobOffer>(new UnitOfWork(new DatabaseFactory()));


        // GET : api/CandidateAPI
        public List<JobOffer> Get()
        {

            return serv.Recuperer().ToList<JobOffer>();
        }

        // GET : api/JobOffreApi/Order

        [System.Web.Http.AcceptVerbs("GET", "POST")]
        [System.Web.Http.Route("api/JobOfferApi/Order")]
        [System.Web.Http.HttpGet]
        public List<JobOffer> Order()
        {
            return serv.Recuperer(x => x.ContratType == ContractType.FixedTerm).ToList<JobOffer>();
        }
        // GET: api/CandidateAPI/5
        public JobOffer Get(int id)
        {
            return serv.RechercherById(id);
        }
        [System.Web.Http.HttpGet]
        public List<JobOffer> Get(string location)
        {
            return serv.Recuperer(x => x.Location == location).ToList<JobOffer>();
        }

        //  POST: api/CandidateApi
        public JobOffer Post(JobOffer jo)
        {

            jo.JobId = 5;
            serv.Create(jo);
            serv.Commit();
            return jo;

        }
        //PUT: api/CandidateAPI/5

        public JobOffer Put(int id, JobOffer jo)
        {

            JobOffer instance = serv.RechercherById(id);
            instance.JobTitle = jo.JobTitle;
            instance.Mission = jo.Mission;
            instance.Reference = jo.Reference;
            instance.DemanderProfile = jo.DemanderProfile;
            instance.Location = jo.Location;
            instance.ExpirationDate = jo.ExpirationDate;
            instance.ContratType = jo.ContratType;


            serv.MettreAJour(instance);
            serv.Commit();
            return instance;
        }

        //public List<JobOffer> Search(CustomerModel customer)
        //{
        //    NorthwindEntities entities = new NorthwindEntities();
        //    return (from c in entities.Customers.Take(10)
        //            where c.ContactName.StartsWith(customer.Name)
        //            select c).ToList();
        //}

        ////PUT: api/CandidateAPI/5
        ////public void Put(int id, [FromBody]string value)
        ////{
        ////}

        // DELETE: api/CandidateAPI/5
        public void Delete(int id)
        {

            serv.Supprimer(serv.RechercherById(id));
            serv.Commit();
        }

    }
}
