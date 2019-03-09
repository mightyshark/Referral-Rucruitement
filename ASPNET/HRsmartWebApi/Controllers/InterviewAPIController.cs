using HRsmartData;
using HRsmartDomain.Entities;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace HRsmartWebApi.Controllers
{
    public class InterviewAPIController : ApiController
    {


        IServices<Interview> serv = new Services<Interview>(new UnitOfWork(new DatabaseFactory()));

        /*------------------------------------------------------------------Affichage ----------------------------------------------------*/

        // GET : api/InterviewAPI
        public List<Interview> Get()
        {
            return serv.Recuperer().ToList<Interview>();
        }

        /*------------------------------------------------------------------Affichage Detaillé----------------------------------------------------*/


        // GET: api/CandidateAPI/5
        public Interview Get(int id)
        {
            return serv.RechercherById(id);
        }


        /*------------------------------------------------------------------Ajouter----------------------------------------------------*/

        // POST: api/InterviewAPI
        public Interview Post(Interview c)
        {
            c.InterId = 5;
            serv.Create(c);
            serv.Commit();
            return c;

        }


        [System.Web.Http.HttpGet]
        public List<Interview> Get(string subject)
        {
            return serv.Recuperer(x => x.Subject == subject).ToList<Interview>();
        }

        /*------------------------------------------------------------------Modifier----------------------------------------------------*/

        // PUT: api/InterviewAPI/5
        public Interview Put(int id, Interview t)
        {

            Interview instance = serv.RechercherById(id);
            instance.Subject = t.Subject;
            instance.Description = t.Description;
            instance.StartDate = t.StartDate;
            instance.EndDate = t.EndDate;
            instance.ResultHRInterview = t.ResultHRInterview;
            instance.FeedBack = t.FeedBack;

            instance.ResultTechnicalInterview = t.ResultTechnicalInterview;
            instance.ResultQIInterview = t.ResultQIInterview;
            instance.ResultSoftSkillsInterview = t.ResultSoftSkillsInterview;
            instance.CandidateStates = t.CandidateStates;
            instance.FeedBack = t.FeedBack;






            serv.MettreAJour(instance);
            serv.Commit();
            return instance;
        }


        /*------------------------------------------------------------------Supprimer----------------------------------------------------*/

        // DELETE: api/InterviewAPI/5
        public void Delete(int id)
        {

            serv.Supprimer(serv.RechercherById(id));
            serv.Commit();
        }


    }
}
