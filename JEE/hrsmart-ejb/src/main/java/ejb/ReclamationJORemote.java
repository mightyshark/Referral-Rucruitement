package ejb;

import java.util.List;

import javax.ejb.Remote;

import dto.JobOffer;
import dto.ReclamationJOffer;

@Remote
public interface ReclamationJORemote {
	public void ajoutRecJO(ReclamationJOffer r);
	 public List<ReclamationJOffer> getAllRecJOU(String idUser);
	 public List<JobOffer> getJobOfferByid(int id);
	
}
