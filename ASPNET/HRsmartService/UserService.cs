using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

using System.Net;
using System.Net.Mail;
using System.Data;
using System.Data.SqlClient;
using HRsmartDomain;
using HRsmartData;
using Service.Pattern;

namespace HRsmartService
{
    public class UserService : Services<User>, IUserService
    {

        private static DatabaseFactory DbFactory = new DatabaseFactory();
        private static UnitOfWork utw = new UnitOfWork(DbFactory);


        public UserService() : base(utw)
        { }
        //affichage avancé selon role 
        public IEnumerable<User> getUserByRole(string n)
        {
            return utw.GetRepository<User>().GetMany(x => x.Role.Equals("n") );
        }

        //test si le username exist deja
        public IEnumerable<User> getUserByName(string n)
        {

            return utw.GetRepository<User>().GetMany(x => x.UserName == n);

        }






        //Metiers
        protected void Page_Load(object sender, EventArgs e)
        {
            GeneratePassword();
        }
       
        public string GeneratePassword()
        {
            string PasswordLength = "8";
            string NewPassword = "";

            string allowedChars = "";
            allowedChars = "1,2,3,4,5,6,7,8,9,0";
            allowedChars += "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,";
            allowedChars += "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,";


            char[] sep = {
            ','
        };
            string[] arr = allowedChars.Split(sep);


            string IDString = "";
            string temp = "";

            Random rand = new Random();

            for (int i = 0; i < Convert.ToInt32(PasswordLength); i++)
            {
                temp = arr[rand.Next(0, arr.Length)];
                IDString += temp;
                NewPassword = IDString;

            }
            return NewPassword;
        }



    }
}
