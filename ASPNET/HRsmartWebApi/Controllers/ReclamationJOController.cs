using HRsmartDomain;
using HRsmartService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace HRsmartWebApi.Controllers
{
    public class ReclamationJOController : ApiController
    {
        [HttpGet]
        [Route("reclamation/getReclamationJO/{idUser}/{idReclamation}")]
        public IHttpActionResult GetJOffer([FromUri]string idUser, [FromUri]int idReclamation)
        {

            GestionReclamationJO gc = new GestionReclamationJO();

            IEnumerable<ReclamationJOffer> list = gc.GetAll(x => x.IdUserFK == idUser && x.IdjofferFK == idReclamation);


            return Ok(list);
        }
        [Route("reclamation/addReclamationJO/")]
        [HttpPost]
        public void add([FromBody]ReclamationJOffer t)
        {
            GestionReclamationJO gt = new GestionReclamationJO();

            gt.Create(t);
            gt.Commit();


        }
        [HttpPut]
        [Route("reclamation/UpdateReclamationJO/{idUser}/{idJO}")]
        public void UpdateJO([FromUri]string idUser, [FromUri]int idJO, [FromBody]ReclamationJOffer t)
        {

            GestionReclamationJO gt = new GestionReclamationJO();
            t.IdUserFK = idUser;
            t.IdjofferFK = idJO;



            try
            {
                if (!(idJO.Equals(null)) && !(t.IdjofferFK.Equals(null)))
                {
                    gt.Edit(t);
                }

            }
            catch
            { }


        }
        [Route("reclamation/get/")]
        public IHttpActionResult getAllReclamations()
        {

            GestionReclamationJO gt = new GestionReclamationJO();


            IEnumerable<ReclamationJOffer> list = gt.GetAll();


            return Ok(list);

        }
        [Route("reclamation/get/{idUser}")]
        public IHttpActionResult getAllReclamationsbyid([FromUri]string idUser)
        {

            GestionReclamationJO gt = new GestionReclamationJO();


            IEnumerable<ReclamationJOffer> list = gt.GetAll(x=>x.IdUserFK== idUser);


            return Ok(list);

        }
        [Route("reclamation/getOneJO/{id}")]
        public IHttpActionResult getJO([FromUri]int id)
        {

            JobOfferService gt = new JobOfferService();
            IEnumerable<JobOffer> list = gt.GetAll(x => x.JobId == id);
            return Ok(list);
        }

    }
}