using HRsmartData;
using HRsmartDomain;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace HRsmartWebApi.Controllers
{
    public class CustomizeAPIController : ApiController
    {


        IServices<CustomizeApp> serv = new Services<CustomizeApp>(new UnitOfWork(new DatabaseFactory()));

        // GET : api/CustomizeAPI
        public List<CustomizeApp> Get()
        {
            return serv.Recuperer().ToList<CustomizeApp>();
        }

        // GET: api/CustomizeAPI/5
        public CustomizeApp Get(int id)
        {
            return serv.RechercherById(id);
        }
        // POST: api/CustomizeApi
        //public CustomizeApp Post(CustomizeApp c, HttpPostedFileBase Picture)
        //{
        //    Enum.GetValues(typeof(CompState));
        //    Enum.GetValues(typeof(CompField));

        //    if (!ModelState.IsValid || Picture == null || Picture.ContentLength == 0)
        //    {
        //        return c;
        //    }

        //    c.Logo = Picture.FileName;
        //    c.IdCustom = 5;

        //    var fileName = Path.GetFileName(Picture.FileName);
        //    var extention = Path.GetExtension(Picture.FileName);
        //    var filenamewithoutextension = Path.GetFileNameWithoutExtension(Picture.FileName);

        //    var path = Path.Combine(HttpContext.Current.Request.MapPath("~/Content/UploadImage/"), Picture.FileName);
        //    Picture.SaveAs(path);


        //    serv.Create(c);
        //    serv.Commit();
        //    return c;
   // }
            public CustomizeApp Post(CustomizeApp c)
            {

                c.IdCustom = 5;
                serv.Create(c);
                serv.Commit();
                return c;
            }
    //PUT: api/CustomizeAPI/5

    public CustomizeApp Put(int id, CustomizeApp t)
        {

            CustomizeApp instance = serv.RechercherById(id);
            instance.Logo = t.Logo;
            instance.Url = t.Url;
            instance.WlcText = t.WlcText;
            instance.address = t.address;



            serv.MettreAJour(instance);
            serv.Commit();
            return instance;
        }
        public void Delete(int id)
        {

            serv.Supprimer(serv.RechercherById(id));
            serv.Commit();
        }

    }
}