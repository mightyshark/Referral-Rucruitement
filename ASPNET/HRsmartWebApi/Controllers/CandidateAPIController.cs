using HRsmartData;
using HRsmartDomain;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.UI;

namespace HRsmartWebApi.Controllers
{
    public class CandidateAPIController : ApiController
    {
        IServices<Candidate> serv = new Services<Candidate>(new UnitOfWork(new DatabaseFactory()));

        // GET : api/CandidateAPI


        public List<Candidate> Get()
        {
            return serv.Recuperer().ToList<Candidate>();
        }


        // GET: api/CandidateAPI/5
        public Candidate Get(int id)
        {
            return serv.RechercherById(id);
        }





        //  POST: api/CandidateApi
        public Candidate Post(Candidate c)
        {
            c.CandidateId = 5;
            serv.Create(c);
            serv.Commit();
            return c;

        }
        //PUT: api/CandidateAPI/5

        public Candidate Put(int id, Candidate t)
        {

            Candidate instance = serv.RechercherById(id);
            instance.Cin = t.Cin;
            instance.FirstName = t.FirstName;
            instance.LastName = t.LastName;
            instance.Adresse = t.Adresse;
            instance.Age = t.Age;
            instance.ContactNumber = t.ContactNumber;
            instance.Email = t.Email;
            instance.LinkedInProfile = t.LinkedInProfile;
            instance.FaceBookProfile = t.FaceBookProfile;
            instance.Recommandations = t.Recommandations;

            serv.MettreAJour(instance);
            serv.Commit();
            return instance;
        }


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
