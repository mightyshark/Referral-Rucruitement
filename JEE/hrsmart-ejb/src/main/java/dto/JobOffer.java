package dto;

import com.fasterxml.jackson.annotation.JsonProperty;

import java.util.Date;
import enumerations.ContractType;



public class JobOffer   {

     public JobOffer() {
        super();
    }

    
    public JobOffer(String jobTitle, String reference, String mission, String demanderProfile, String location) {
        JobTitle = jobTitle;
        Reference = reference;
        Mission = mission;
        DemanderProfile = demanderProfile;
        Location = location;
    }


   /* @JsonProperty("RmId")

    private int RmId; */
    
    
    @JsonProperty("JobId")
    private int JobId ;

    
   /* @JsonProperty("Employee")

    private Employee Employee ; */
    
    
    /* @JsonProperty("EmployeeId")
    
    
    private int EmployeeId ; */

    
    
    
    @JsonProperty("JobTitle")
    private String JobTitle ;  
    
    
    @JsonProperty("Reference")
    private String Reference ;
    
    
    @JsonProperty("Mission")

    private String Mission;
    
    @JsonProperty("DemanderProfile")
    private String DemanderProfile ;
 
    
    @JsonProperty("Location")
    private String Location ;
  
  
    @JsonProperty("ExpirationDate")
    private Date ExpirationDate ;
    
   /* @JsonProperty("ContratType")
    private ContractType ContratType; */
    
    /* @JsonProperty("RecruitementManager")
    private  RecruitementManager RecruitementManager; */
  
     
     
    public int getJobId() {
        return JobId;
    }
    public void setJobId(int jobId) {
        JobId = jobId;
    }
    public String getJobTitle() {
        return JobTitle;
    }
    public void setJobTitle(String jobTitle) {
        JobTitle = jobTitle;
    }
    public String getReference() {
        return Reference;
    }
    public void setReference(String reference) {
        Reference = reference;
    }
    public String getMission() {
        return Mission;
    }
    public void setMission(String mission) {
        Mission = mission;
    }
    public String getDemanderProfile() {
        return DemanderProfile;
    }
    public void setDemanderProfile(String demanderProfile) {
        DemanderProfile = demanderProfile;
    }
    public String getLocation() {
        return Location;
    }
    public void setLocation(String location) {
        Location = location;
    }
    public Date getExpirationDate() {
        return ExpirationDate;
    }
    public void setExpirationDate(Date expirationDate) {
        ExpirationDate = expirationDate;
    }
     /* public ContractType getContratType() {
        return ContratType;
    }
    public void setContratType(ContractType contratType) {
        ContratType = contratType;
    }
    public RecruitementManager getRecruitementManager() {
        return RecruitementManager;
    }
    public void setRecruitementManager(RecruitementManager recruitementManager) {
        RecruitementManager = recruitementManager;
    } */


    @Override
    public String toString() {
        return "id is "+JobId+"job title :"+JobTitle+"mission is "+Mission+"reference is "+Reference+"location is "+Location;
    }
     
    
    
    
}