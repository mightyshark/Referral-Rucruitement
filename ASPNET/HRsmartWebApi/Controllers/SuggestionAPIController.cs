using HRsmartData;
using HRsmartDomain;
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
    public class SuggestionAPIController : ApiController
    {


        IServices<Suggestion> serv = new Services<Suggestion>(new UnitOfWork(new DatabaseFactory()));

        /*------------------------------------------------------------------Affichage ----------------------------------------------------*/

        // GET : api/InterviewAPI
        public List<Suggestion> Get()
        {
            return serv.Recuperer().ToList<Suggestion>();
        }

        /*------------------------------------------------------------------Affichage Detaillé----------------------------------------------------*/


        // GET: api/CandidateAPI/5
        public Suggestion Get(int id)
        {
            return serv.RechercherById(id);
        }


        /*------------------------------------------------------------------Ajouter----------------------------------------------------*/

        // POST: api/InterviewAPI
        public Suggestion Post(Suggestion c)
        {
            c.SuggestionId = 5;
            serv.Create(c);
            serv.Commit();
            return c;

        }


   /*     [System.Web.Http.HttpGet]
        public List<Interview> Get(string subject)
        {
            return serv.Recuperer(x => x.Subject == subject).ToList<Interview>();
        }
*/
        /*------------------------------------------------------------------Modifier----------------------------------------------------*/

        // PUT: api/InterviewAPI/5
        public Suggestion Put(int id, Suggestion t)
        {

            Suggestion instance = serv.RechercherById(id);
             instance.SuggestionTitle = t.SuggestionTitle;
            instance.Departement = t.Departement;
            instance.Mission = t.Mission;
            instance.DemandedProfile = t.DemandedProfile;
            instance.Raison = t.Raison;
            instance.SuggestionStates = t.SuggestionStates;
 





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
