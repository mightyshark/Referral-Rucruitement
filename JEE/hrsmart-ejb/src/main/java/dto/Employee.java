package dto;
 
import java.util.List;

 


 public class Employee extends User  {

	
 	  private int EmployeeId  ;
	  private String Direction  ;
	  private int Experience ;
	  private String Fonction ;
	  private int RewardPoints  ;
	  private int CHROId  ;

	  private   ChiefHumanRessources ChiefHumanRessources ;
	//  private  List<JobOffer> JobOffers ;	
      private  List<Candidate> Candidates ;
	public int getEmployeeId() {
		return EmployeeId;
	}
	public void setEmployeeId(int employeeId) {
		EmployeeId = employeeId;
	}
	public String getDirection() {
		return Direction;
	}
	public void setDirection(String direction) {
		Direction = direction;
	}
	public int getExperience() {
		return Experience;
	}
	public void setExperience(int experience) {
		Experience = experience;
	}
	public String getFonction() {
		return Fonction;
	}
	public void setFonction(String fonction) {
		Fonction = fonction;
	}
	public int getRewardPoints() {
		return RewardPoints;
	}
	public void setRewardPoints(int rewardPoints) {
		RewardPoints = rewardPoints;
	}
	public int getCHROId() {
		return CHROId;
	}
	public void setCHROId(int cHROId) {
		CHROId = cHROId;
	}
	public ChiefHumanRessources getChiefHumanRessources() {
		return ChiefHumanRessources;
	}
	public void setChiefHumanRessources(ChiefHumanRessources chiefHumanRessources) {
		ChiefHumanRessources = chiefHumanRessources;
	}
/*	public List<JobOffer> getJobOffers() {
		return JobOffers;
	}
	public void setJobOffers(List<JobOffer> jobOffers) {
		JobOffers = jobOffers;
	}
	
	*/
	public List<Candidate> getCandidates() {
		return Candidates;
	}
	public void setCandidates(List<Candidate> candidates) {
		Candidates = candidates;
	}
	public Employee() {
		super();
		// TODO Auto-generated constructor stub
	}
      
      
}
