package dto;

 
 
public class NotifcationRecom   {

	
	
 
		        private int NotifcationRecomId ;

		        private int UserId ;

		        private int CandidateId ;

		        private  Employee Employee;
		        private  Candidate Candidate ;
				public NotifcationRecom() {
					super();
					// TODO Auto-generated constructor stub
				}
				public int getNotifcationRecomId() {
					return NotifcationRecomId;
				}
				public void setNotifcationRecomId(int notifcationRecomId) {
					NotifcationRecomId = notifcationRecomId;
				}
				public int getUserId() {
					return UserId;
				}
				public void setUserId(int userId) {
					UserId = userId;
				}
				public int getCandidateId() {
					return CandidateId;
				}
				public void setCandidateId(int candidateId) {
					CandidateId = candidateId;
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
