using HRsmartData;
using HRsmartDomain;
using HRsmartService;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HRsmartWebApi.Controllers
{
    public class UserAPIController : ApiController
    {
        IServices<User> serv = new Services<User>(new UnitOfWork(new DatabaseFactory()));
        UserService US = null;
        public UserAPIController()
        {
            UserService US = new UserService();
        }
        // GET: api/User
        public List<User> Get()
        {
            return serv.Recuperer().ToList<User>();
        }

        [System.Web.Http.HttpGet]
        public List<User> Get(string name)
        {
            return serv.Recuperer(x => x.UserName == name).ToList<User>();
        }
        // GET: api/User/5
        public User Get(int id)
        {
            return serv.RechercherById(id);
        }

        // POST: api/User
        public User Post(User u)
        {
            Enum.GetValues(typeof(Role));
            u.Id = "5555";
            serv.Create(u);
            serv.Commit();
            return u;


        }
        // PUT: api/User/5
        public User Put(int id, User u)
        {
            User instance = serv.RechercherById(id);
            instance.Email = u.Email;
            instance.UserName = u.UserName;

            instance.Email = u.Email;
            instance.Role = u.Role;
            

            serv.MettreAJour(instance);
            serv.Commit();
            return instance;
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
            serv.Supprimer(serv.RechercherById(id));
            serv.Commit();
        }
    }
}
