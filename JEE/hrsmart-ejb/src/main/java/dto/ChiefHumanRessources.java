package dto;

 import java.util.List;



 


  
public class ChiefHumanRessources extends User  {

	
 	 
	private int CHROId;
	private String Grade;
	private  List<RecruitementManager> RecruitementManagers ;
	private  List<Employee> Employees ;
	public int getCHROId() {
		return CHROId;
	}
	public void setCHROId(int cHROId) {
		CHROId = cHROId;
	}
	public String getGrade() {
		return Grade;
	}
	public void setGrade(String grade) {
		Grade = grade;
	}
	public List<RecruitementManager> getRecruitementManagers() {
		return RecruitementManagers;
	}
	public void setRecruitementManagers(List<RecruitementManager> recruitementManagers) {
		RecruitementManagers = recruitementManagers;
	}
	public List<Employee> getEmployees() {
		return Employees;
	}
	public void setEmployees(List<Employee> employees) {
		Employees = employees;
	}
	public ChiefHumanRessources() {
		super();
		// TODO Auto-generated constructor stub
	}
	
	
	
}
