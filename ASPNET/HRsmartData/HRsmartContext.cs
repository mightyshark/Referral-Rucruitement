using HRsmartData.Configurations;
using HRsmartDomain;
using HRsmartDomain.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRsmartData
{
    public class HRsmartContext : IdentityDbContext<User>
    {
        public HRsmartContext() : base("Name=DefaultConnection")
        {
           Database.SetInitializer<HRsmartContext>(new HRsmartContextInitializer());

        }


        public DbSet<Role> Roles { get; set; }
        public DbSet<ReclamationJOffer> ReclamationJOffer { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
       public DbSet<JobOffer> JobOffers { get; set; }
        public DbSet<Interview> Interviews { get; set; }
        public DbSet<CustomizeApp> CustomizeApps { get; set; }
        public DbSet<Suggestion> Suggestions { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        // public DbSet<User> Users { get; set; }

        // public DbSet<Recommandation> Recommandations { get; set; }

        public DbSet<NotifcationRecom> NotifcationRecoms { get; set; }
        public DbSet<NotificationJO> UserNotifcationJOs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new EmployeeConfigurations());
            modelBuilder.Configurations.Add(new JobOfferConfigurations());
            modelBuilder.Configurations.Add(new RmConfigurations());
            modelBuilder.Configurations.Add(new AddressConfigurations());

            //modelBuilder.Conventions.Add(new DateTimeConvention());

        }

        public class HRsmartContextInitializer : DropCreateDatabaseIfModelChanges<HRsmartContext>
        {
            protected override void Seed(HRsmartContext ctx)
            {
                base.Seed(ctx);
            }
        }
    }
}
