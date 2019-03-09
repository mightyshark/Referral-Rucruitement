package dto;

 
import java.util.Date;

import enumerations.CandidateState;


 
public class Recommandation  {
	
 
		        private int EmployeeFK; 
		        
		        private int CandidatetFK ;
		        
		        private CandidateState candidatestate ;
		        private Date DateRecommandation ;
		     
		        private  Employee Employee ;
		        private  Candidate Candidate;
		        
		        
		        
		        
		        
				public int getEmployeeFK() {
					return EmployeeFK;
				}
				
				
				public void setEmployeeFK(int employeeFK) {
					EmployeeFK = employeeFK;
				}
				public int getCandidatetFK() {
					return CandidatetFK;
				}
				public void setCandidatetFK(int candidatetFK) {
					CandidatetFK = candidatetFK;
				}
				public CandidateState getCandidatestate() {
					return candidatestate;
				}
				public void setCandidatestate(CandidateState candidatestate) {
					this.candidatestate = candidatestate;
				}
				public Date getDateRecommandation() {
					return DateRecommandation;
				}
				public void setDateRecommandation(Date dateRecommandation) {
					DateRecommandation = dateRecommandation;
				}
				public Employee getEmployee() {
					return Employee;
				}
				public void setEmployee(Employee employee) {
					Employee = employee;
				}
				public Candidate getCandidate() {
					return Candidate;
				}
				public void setCandidate(Candidate candidate) {
					Candidate = candidate;
				}


		        
}
