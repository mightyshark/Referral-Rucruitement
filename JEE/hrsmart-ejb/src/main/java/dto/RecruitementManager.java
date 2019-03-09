package dto;
 
import java.util.List;

 


 
public class RecruitementManager   {

	 
	private int RMId ;
    private int Experience ;
    private  ChiefHumanRessources ChiefHumanRessources ;
    private  List<JobOffer> JobOffers ;
    private int EmployeeId ;
    private int CHROId ;
	public int getRMId() {
		return RMId;
	}
	public void setRMId(int rMId) {
		RMId = rMId;
	}
	public int getExperience() {
		return Experience;
	}
	public void setExperience(int experience) {
		Experience = experience;
	}
	public ChiefHumanRessources getChiefHumanRessources() {
		return ChiefHumanRessources;
	}
	public void setChiefHumanRessources(ChiefHumanRessources chiefHumanRessources) {
		ChiefHumanRessources = chiefHumanRessources;
	}
	public List<JobOffer> getJobOffers() {
		return JobOffers;
	}
	public void setJobOffers(List<JobOffer> jobOffers) {
		JobOffers = jobOffers;
	}
	public int getEmployeeId() {
		return EmployeeId;
	}
	public void setEmployeeId(int employeeId) {
		EmployeeId = employeeId;
	}
	public int getCHROId() {
		return CHROId;
	}
	public void setCHROId(int cHROId) {
		CHROId = cHROId;
	}
	public RecruitementManager() {
		super();
		// TODO Auto-generated constructor stub
	}
    
    

}
