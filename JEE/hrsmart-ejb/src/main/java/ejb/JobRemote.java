package ejb;

import java.util.List;

import javax.ejb.Remote;

import dto.JobOffer;

@Remote
public interface JobRemote {
	 public List<JobOffer> getAll();

}
