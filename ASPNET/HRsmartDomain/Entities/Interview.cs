using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRsmartDomain.Entities
{
    public class Interview
    {
        [Key]
        public int InterId { get; set; }
        public String Subject { get; set; }

        public String Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
        public int ResultHRInterview { get; set; }
        public int ResultTechnicalInterview { get; set; }
        public int ResultQIInterview { get; set; }
        public int ResultSoftSkillsInterview { get; set; }
        public int FinalResult { get; set; }


        public CandidateState CandidateStates { get; set; }  // les etats du candidat         Accepted, Refused, Waiting


        [ForeignKey("CandidateId")]
        public virtual Candidate candidat { get; set; }

        public string FeedBack { get; set; }  //lorsqu'on clique sur le bouton update interview, un fedback sera envoyé a l'employé qui a fait la reference.


        public int? CandidateId { get; set; }


        public Interview()
        {

        }

        public Interview(String Subject, String Description, DateTime StartDate, DateTime EndDate, int ResultHRInterview, int ResultTechnicalInterview, int ResultQIInterview, int ResultSoftSkillsInterview, int CandidateId, String FeFeedBack, CandidateState CandidateState)
        {

            this.Subject = Subject;
            this.Description = Description;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.ResultHRInterview = ResultHRInterview;
            this.ResultQIInterview = ResultQIInterview;
            this.ResultSoftSkillsInterview = ResultSoftSkillsInterview;
            this.ResultTechnicalInterview = ResultTechnicalInterview;
            this.CandidateId = CandidateId;
            this.FeedBack = FeedBack;
            this.CandidateStates = (CandidateState)CandidateState;
        }

        public override string ToString()
        {
            return "InterviewId : " + InterId + " Subject : " + Subject + " Description : " + Description + " StartDate : " + StartDate + " EndDate : " + EndDate + " ResultHRInterview : " + ResultHRInterview + " ResultTechnicalInterview : " + ResultTechnicalInterview + " ResultQIInterview : " + ResultQIInterview + " ResultSoftSkillsInterview : " + ResultSoftSkillsInterview;
        }
    }
}