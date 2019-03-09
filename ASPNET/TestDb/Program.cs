using HRsmartData;
using HRsmartDomain;
using HRsmartService;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDb
{
    public class Program
    {
        static void Main(string[] args)
        {

            //Candidate c = new Candidate
            //{
            //    CandidateId = 10,
            //    Email = "ok10000 ",
            //    Adresse = "ok10000",
            //    Age = 10,
            //    Cin = "y",
            //    ContactNumber = 10,
            //    FirstName = "yy",
            //    LastName = "yyy",
            //    LinkedInProfile = "xx",
            //    FaceBookProfile = "xx",
            //    Recommandations = "xx",
            //};
            //User e = new User
            //{
            //    UserId = 2,
            //    Cin = "0549752",
            //    Matricule = "ok",
            //    FirstName = "zied",
            //    LastName = "ok",
            //    Age = 1,
            //    Gender = Gender.Female,
            //    Adresse = "ok",
            //    Email = "zied.ghamgui@esprit.tn",
            //    UserName = "zied",
            //    Password = "00001111",
            //    VerifPassword = "00001111",
            //    Role = Role.Employee
            //    // Role = Role.Employee,
            //};
            //JobOffer j = new JobOffer
            //{
            //    JobId = 2,
            //    JobTitle = "Test",
            //    Reference = "Test",
            //    DemanderProfile = "Test",
            //    Location = "Test",
            //    Mission = "Test",
            //};
            //Employee e = new Employee
            //{
            //    EmployeeId = 1,
            //    Direction = "okokokok",
            //        Experience=2,


            //CustomizeApp cu = new CustomizeApp
            //{
            //    IdCustom = 5,
            //    Url = "ok.png",
            //    WlcText = "yyyyyy",


            //};
            User u = new User

            {
                Id = "2",
                UserName = " Najla",
                Email = "najla@gmail.com",
                


            };
            IServices<User> serv = new Services<User>(new UnitOfWork(new DatabaseFactory()));

            //IServices<JobOffer> serv = new Services<JobOffer>(new UnitOfWork(new DatabaseFactory()));
            //IServices<JobOffer> serv2 = new Services<JobOffer>(new UnitOfWork(new DatabaseFactory()));
        //IServices<User> serv2 = new Services<User>(new UnitOfWork(new DatabaseFactory()));

            serv.Create(u);
            serv.Commit();
            //serv2.Create(e);
            //serv2.Commit();
            Console.WriteLine("ajout succés ");
            Console.ReadKey();
        }
    }
}
