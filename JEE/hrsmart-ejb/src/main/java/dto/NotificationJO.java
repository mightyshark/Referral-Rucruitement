
package dto;


 
  
public class NotificationJO   {

 
	        private int NotificationJOId ;
	        private int UserId ;
	        private int JobId ;

	        private  RecruitementManager RecruitementManager ;
	        private  JobOffer JobOffer;
			public int getNotificationJOId() {
				return NotificationJOId;
			}
			public void setNotificationJOId(int notificationJOId) {
				NotificationJOId = notificationJOId;
			}
			public int getUserId() {
				return UserId;
			}
			public void setUserId(int userId) {
				UserId = userId;
			}
			public int getJobId() {
				return JobId;
			}
			public void setJobId(int jobId) {
				JobId = jobId;
			}
			public RecruitementManager getRecruitementManager() {
				return RecruitementManager;
			}
			public void setRecruitementManager(RecruitementManager recruitementManager) {
				RecruitementManager = recruitementManager;
			}
			public JobOffer getJobOffer() {
				return JobOffer;
			}
			public void setJobOffer(JobOffer jobOffer) {
				JobOffer = jobOffer;
			}
			public NotificationJO() {
				super();
				// TODO Auto-generated constructor stub
			}
	        
	        

}