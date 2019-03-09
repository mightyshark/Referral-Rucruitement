package ejb;

import java.util.List;

import javax.ejb.Local;

import dto.JobOffer;
import dto.ReclamationJOffer;

@Local
public interface ReclamationJOLocal {
 public void ajoutRecJO(ReclamationJOffer r);
 public List<ReclamationJOffer> getAllRecJOU(String idUser);
 public List<JobOffer> getJobOfferByid(int id);
 public List<JobOffer> findAll();
	
}
