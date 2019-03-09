package dto;

 
import java.util.Date;

import enumerations.CandidateState;

 ;

 
public class Interview  {

 
	private int InterId ;
	private String Subject;

	private String Description ;

	private Date StartDate ;

	private Date EndDate ;
	private int ResultHRInterview ;
	private int ResultTechnicalInterview ;
	private int ResultQIInterview ;
	private int ResultSoftSkillsInterview;
	private int FinalResult;


	private CandidateState CandidateStates ;  // les etats du candidat         Accepted, Refused, Waiting


	     
	private  Candidate candidat ;

	private String FeedBack ; //lorsqu'on clique sur le bouton update interview, un fedback sera envoyé a l'employé qui a fait la reference.


	private int CandidateId ;


	public Interview() {
		super();
		// TODO Auto-generated constructor stub
	}


	public int getInterId() {
		return InterId;
	}


	public void setInterId(int interId) {
		InterId = interId;
	}


	public String getSubject() {
		return Subject;
	}


	public void setSubject(String subject) {
		Subject = subject;
	}


	public String getDescription() {
		return Description;
	}


	public void setDescription(String description) {
		Description = description;
	}


	public Date getStartDate() {
		return StartDate;
	}


	public void setStartDate(Date startDate) {
		StartDate = startDate;
	}


	public Date getEndDate() {
		return EndDate;
	}


	public void setEndDate(Date endDate) {
		EndDate = endDate;
	}


	public int getResultHRInterview() {
		return ResultHRInterview;
	}


	public void setResultHRInterview(int resultHRInterview) {
		ResultHRInterview = resultHRInterview;
	}


	public int getResultTechnicalInterview() {
		return ResultTechnicalInterview;
	}


	public void setResultTechnicalInterview(int resultTechnicalInterview) {
		ResultTechnicalInterview = resultTechnicalInterview;
	}


	public int getResultQIInterview() {
		return ResultQIInterview;
	}


	public void setResultQIInterview(int resultQIInterview) {
		ResultQIInterview = resultQIInterview;
	}


	public int getResultSoftSkillsInterview() {
		return ResultSoftSkillsInterview;
	}


	public void setResultSoftSkillsInterview(int resultSoftSkillsInterview) {
		ResultSoftSkillsInterview = resultSoftSkillsInterview;
	}


	public int getFinalResult() {
		return FinalResult;
	}


	public void setFinalResult(int finalResult) {
		FinalResult = finalResult;
	}


	public CandidateState getCandidateStates() {
		return CandidateStates;
	}


	public void setCandidateStates(CandidateState candidateStates) {
		CandidateStates = candidateStates;
	}


	public Candidate getCandidat() {
		return candidat;
	}


	public void setCandidat(Candidate candidat) {
		this.candidat = candidat;
	}


	public String getFeedBack() {
		return FeedBack;
	}


	public void setFeedBack(String feedBack) {
		FeedBack = feedBack;
	}


	public int getCandidateId() {
		return CandidateId;
	}


	public void setCandidateId(int candidateId) {
		CandidateId = candidateId;
	}
	
	
	
	
	
}




