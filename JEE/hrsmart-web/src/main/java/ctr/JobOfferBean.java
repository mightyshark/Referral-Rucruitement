package ctr;

import java.util.List;

import javax.annotation.PostConstruct;
import javax.ejb.EJB;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.SessionScoped;
import javax.ws.rs.core.Response;

import dto.JobOffer;
import ejb.JobLocal;
import ejb.JobOfferService;

 
@ManagedBean
@SessionScoped
public class JobOfferBean {
    
    @EJB
    JobLocal JOEJB;
    
    private int ido;
    private JobOffer jo ;
    
    
    public int getIdo() {
		return ido;
	}

	public void setIdo(int ido) {
		this.ido = ido;
	}

	public JobOffer getJo() {
        return jo;
    }

    public void setJo(JobOffer jo) {
        this.jo = jo;
    }
    
    @PostConstruct
    public void init(){
        jo = new JobOffer();
    }
    
    //Get ALL
    public List<JobOffer> findAll() {
        
        return JOEJB.getAll();
    }
    
    
    //Delete JO
  /*  public Response doDelete(int id) {
        return JOEJB.delete(id);
    }
    
    //Create JO
    public Response doAdd(JobOffer j) 
    {    System.out.println("the error is here");
        System.out.println(jo.toString());
        return JOEJB.addJob1(j);
    }

    */
    public String goToupdate(JobOffer j ) {

    	this.jo.setLocation(j.getLocation());
    	this.jo.setJobTitle(j.getJobTitle());
    	this.jo.setMission(j.getMission());
    	this.jo.setReference(j.getReference());
    	this.jo.setJobId(j.getJobId());
    	int id = j.getJobId();
     return "update.xhtml?faces-redirect=trueid=" + id;
    
     }
    

  /*  //Update JO
    public Response doUpdate(JobOffer j, int id) {
        System.out.println("the error is here");
        ido = j.getJobId();
        System.out.print("Haaaaaww"+ido);
        return JOEJB.update(j,ido);
 
    }
    */
    
     public String goToList( ) {
        
    	 
        
        return "test.xhmtl";
        
        
     }
    
    
}
