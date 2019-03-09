namespace HRsmartData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ic1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Candidates",
                c => new
                    {
                        CandidateId = c.Int(nullable: false, identity: true),
                        Cin = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Age = c.Int(nullable: false),
                        Gender = c.Int(nullable: false),
                        Adresse = c.String(),
                        Email = c.String(),
                        ContactNumber = c.Int(nullable: false),
                        LinkedInProfile = c.String(),
                        FaceBookProfile = c.String(),
                        Recommandations = c.String(),
                        CandidateState = c.Int(nullable: false),
                        InterviewSteps = c.Int(nullable: false),
                        SkypeId = c.String(),
                        JobOffreId = c.Int(),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CandidateId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .ForeignKey("dbo.JobOffers", t => t.JobOffreId)
                .Index(t => t.JobOffreId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        Direction = c.String(),
                        Experience = c.Int(nullable: false),
                        Fonction = c.String(),
                        RewardPoints = c.Int(nullable: false),
                        CHROId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.ChiefHumanRessources", t => t.CHROId)
                .Index(t => t.CHROId);
            
            CreateTable(
                "dbo.ChiefHumanRessources",
                c => new
                    {
                        CHROId = c.Int(nullable: false, identity: true),
                        Grade = c.String(),
                    })
                .PrimaryKey(t => t.CHROId);
            
            CreateTable(
                "dbo.RecruitementManagers",
                c => new
                    {
                        RMId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        CHROId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RMId)
                .ForeignKey("dbo.ChiefHumanRessources", t => t.CHROId)
                .Index(t => t.CHROId);
            
            CreateTable(
                "dbo.JobOffers",
                c => new
                    {
                        JobId = c.Int(nullable: false, identity: true),
                        JobTitle = c.String(),
                        Reference = c.String(nullable: false),
                        Mission = c.String(nullable: false),
                        DemanderProfile = c.String(),
                        Location = c.String(nullable: false),
                        ExpirationDate = c.DateTime(nullable: false),
                        ContratType = c.Int(nullable: false),
                        EmployeeId = c.Int(),
                        RmId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.JobId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .ForeignKey("dbo.RecruitementManagers", t => t.RmId)
                .Index(t => t.EmployeeId)
                .Index(t => t.RmId);
            
            CreateTable(
                "dbo.Suggestions",
                c => new
                    {
                        SuggestionId = c.Int(nullable: false, identity: true),
                        SuggestionTitle = c.String(),
                        Departement = c.String(),
                        Mission = c.String(),
                        DemandedProfile = c.String(),
                        Raison = c.String(),
                        SuggestionStates = c.Int(nullable: false),
                        EmployeeId = c.Int(),
                        RmId = c.Int(),
                    })
                .PrimaryKey(t => t.SuggestionId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .ForeignKey("dbo.RecruitementManagers", t => t.RmId)
                .Index(t => t.EmployeeId)
                .Index(t => t.RmId);
            
            CreateTable(
                "dbo.CustomizeApps",
                c => new
                    {
                        IdCustom = c.Int(nullable: false, identity: true),
                        Logo = c.String(),
                        WlcText = c.String(nullable: false),
                        Url = c.String(),
                        address_id = c.Int(nullable: false),
                        address_city = c.String(),
                        address_country = c.String(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        CompF = c.Int(nullable: false),
                        CompS = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdCustom);
            
            CreateTable(
                "dbo.Interviews",
                c => new
                    {
                        InterId = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        Description = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        ResultHRInterview = c.Int(nullable: false),
                        ResultTechnicalInterview = c.Int(nullable: false),
                        ResultQIInterview = c.Int(nullable: false),
                        ResultSoftSkillsInterview = c.Int(nullable: false),
                        FinalResult = c.Int(nullable: false),
                        CandidateStates = c.Int(nullable: false),
                        FeedBack = c.String(),
                        CandidateId = c.Int(),
                    })
                .PrimaryKey(t => t.InterId)
                .ForeignKey("dbo.Candidates", t => t.CandidateId)
                .Index(t => t.CandidateId);
            
            CreateTable(
                "dbo.NotifcationRecoms",
                c => new
                    {
                        NotifcationRecomId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        CandidateId = c.Int(nullable: false),
                        Employee_EmployeeId = c.Int(),
                    })
                .PrimaryKey(t => new { t.NotifcationRecomId, t.UserId, t.CandidateId })
                .ForeignKey("dbo.Candidates", t => t.CandidateId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeeId)
                .Index(t => t.CandidateId)
                .Index(t => t.Employee_EmployeeId);
            
            CreateTable(
                "dbo.ReclamationJOffers",
                c => new
                    {
                        IdjofferFK = c.Int(nullable: false),
                        IdUserFK = c.String(nullable: false, maxLength: 128),
                        Objet = c.String(nullable: false),
                        Contenu = c.String(nullable: false),
                        Date = c.String(nullable: false),
                        Traite = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdjofferFK, t.IdUserFK })
                .ForeignKey("dbo.JobOffers", t => t.IdjofferFK, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.IdUserFK, cascadeDelete: true)
                .Index(t => t.IdjofferFK)
                .Index(t => t.IdUserFK);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.NotificationJOes",
                c => new
                    {
                        NotificationJOId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        JobId = c.Int(nullable: false),
                        RecruitementManager_RMId = c.Int(),
                    })
                .PrimaryKey(t => new { t.NotificationJOId, t.UserId, t.JobId })
                .ForeignKey("dbo.JobOffers", t => t.JobId, cascadeDelete: true)
                .ForeignKey("dbo.RecruitementManagers", t => t.RecruitementManager_RMId)
                .Index(t => t.JobId)
                .Index(t => t.RecruitementManager_RMId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NotificationJOes", "RecruitementManager_RMId", "dbo.RecruitementManagers");
            DropForeignKey("dbo.NotificationJOes", "JobId", "dbo.JobOffers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ReclamationJOffers", "IdUserFK", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ReclamationJOffers", "IdjofferFK", "dbo.JobOffers");
            DropForeignKey("dbo.NotifcationRecoms", "Employee_EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.NotifcationRecoms", "CandidateId", "dbo.Candidates");
            DropForeignKey("dbo.Interviews", "CandidateId", "dbo.Candidates");
            DropForeignKey("dbo.Candidates", "JobOffreId", "dbo.JobOffers");
            DropForeignKey("dbo.Employees", "CHROId", "dbo.ChiefHumanRessources");
            DropForeignKey("dbo.Suggestions", "RmId", "dbo.RecruitementManagers");
            DropForeignKey("dbo.Suggestions", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.JobOffers", "RmId", "dbo.RecruitementManagers");
            DropForeignKey("dbo.JobOffers", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.RecruitementManagers", "CHROId", "dbo.ChiefHumanRessources");
            DropForeignKey("dbo.Candidates", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.NotificationJOes", new[] { "RecruitementManager_RMId" });
            DropIndex("dbo.NotificationJOes", new[] { "JobId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.ReclamationJOffers", new[] { "IdUserFK" });
            DropIndex("dbo.ReclamationJOffers", new[] { "IdjofferFK" });
            DropIndex("dbo.NotifcationRecoms", new[] { "Employee_EmployeeId" });
            DropIndex("dbo.NotifcationRecoms", new[] { "CandidateId" });
            DropIndex("dbo.Interviews", new[] { "CandidateId" });
            DropIndex("dbo.Suggestions", new[] { "RmId" });
            DropIndex("dbo.Suggestions", new[] { "EmployeeId" });
            DropIndex("dbo.JobOffers", new[] { "RmId" });
            DropIndex("dbo.JobOffers", new[] { "EmployeeId" });
            DropIndex("dbo.RecruitementManagers", new[] { "CHROId" });
            DropIndex("dbo.Employees", new[] { "CHROId" });
            DropIndex("dbo.Candidates", new[] { "EmployeeId" });
            DropIndex("dbo.Candidates", new[] { "JobOffreId" });
            DropTable("dbo.NotificationJOes");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.ReclamationJOffers");
            DropTable("dbo.NotifcationRecoms");
            DropTable("dbo.Interviews");
            DropTable("dbo.CustomizeApps");
            DropTable("dbo.Suggestions");
            DropTable("dbo.JobOffers");
            DropTable("dbo.RecruitementManagers");
            DropTable("dbo.ChiefHumanRessources");
            DropTable("dbo.Employees");
            DropTable("dbo.Candidates");
        }
    }
}
