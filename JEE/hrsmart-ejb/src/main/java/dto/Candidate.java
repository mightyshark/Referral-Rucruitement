package dto;
import enumerations.*;

 


 public class Candidate  {

	

	//@Id
//	@GeneratedValue(strategy=GenerationType.AUTO)
	private  Integer CandidateId;
	private String Cin;	 
	private String FirstName ;
	private String LastName;
	private int Age  ;
	private Gender Gender  ;
	private String Adresse  ;
	private String Email  ;

	private int ContactNumber  ;
	private String LinkedInProfile ; 
	private String FaceBookProfile  ;
    private String Recommandations  ;
    private CandidateState CandidateState ; 
     private String SkypeId  ;

     private int JobOffreId; //Foreing Key JobOffer
     private int EmployeeId;  //Foreing Key Employe
     
     private  Employee Employee; //Objet Employee
     private  JobOffer JobOffer; //Objet JobOffer
	public Integer getCandidateId() {
		return CandidateId;
	}
	public void setCandidateId(Integer candidateId) {
		CandidateId = candidateId;
	}
	public String getCin() {
		return Cin;
	}
	public void setCin(String cin) {
		Cin = cin;
	}
	public String getFirstName() {
		return FirstName;
	}
	public void setFirstName(String firstName) {
		FirstName = firstName;
	}
	public String getLastName() {
		return LastName;
	}
	public void setLastName(String lastName) {
		LastName = lastName;
	}
	public int getAge() {
		return Age;
	}
	public void setAge(int age) {
		Age = age;
	}
	public Gender getGender() {
		return Gender;
	}
	public void setGender(Gender gender) {
		Gender = gender;
	}
	public String getAdresse() {
		return Adresse;
	}
	public void setAdresse(String adresse) {
		Adresse = adresse;
	}
	public String getEmail() {
		return Email;
	}
	public void setEmail(String email) {
		Email = email;
	}
	public int getContactNumber() {
		return ContactNumber;
	}
	public void setContactNumber(int contactNumber) {
		ContactNumber = contactNumber;
	}
	public String getLinkedInProfile() {
		return LinkedInProfile;
	}
	public void setLinkedInProfile(String linkedInProfile) {
		LinkedInProfile = linkedInProfile;
	}
	public String getFaceBookProfile() {
		return FaceBookProfile;
	}
	public void setFaceBookProfile(String faceBookProfile) {
		FaceBookProfile = faceBookProfile;
	}
	public String getRecommandations() {
		return Recommandations;
	}
	public void setRecommandations(String recommandations) {
		Recommandations = recommandations;
	}
	public CandidateState getCandidateState() {
		return CandidateState;
	}
	public void setCandidateState(CandidateState candidateState) {
		CandidateState = candidateState;
	}
	public String getSkypeId() {
		return SkypeId;
	}
	public void setSkypeId(String skypeId) {
		SkypeId = skypeId;
	}
	public int getJobOffreId() {
		return JobOffreId;
	}
	public void setJobOffreId(int jobOffreId) {
		JobOffreId = jobOffreId;
	}
	public int getEmployeeId() {
		return EmployeeId;
	}
	public void setEmployeeId(int employeeId) {
		EmployeeId = employeeId;
	}
	public Employee getEmployee() {
		return Employee;
	}
	public void setEmployee(Employee employee) {
		Employee = employee;
	}
	public JobOffer getJobOffer() {
		return JobOffer;
	}
	public void setJobOffer(JobOffer jobOffer) {
		JobOffer = jobOffer;
	}
	public Candidate() {
		super();
		// TODO Auto-generated constructor stub
	}

     
     


}
