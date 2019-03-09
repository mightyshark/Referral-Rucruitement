package ejb;

import java.util.List;

import javax.ejb.Local;

import dto.JobOffer;

@Local
public interface JobLocal {
	 public List<JobOffer> getAll();
}
