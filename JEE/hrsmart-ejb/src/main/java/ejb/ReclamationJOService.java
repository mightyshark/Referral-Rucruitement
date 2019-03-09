package ejb;

import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;

import javax.ejb.Stateless;
import javax.json.JsonArray;
import javax.json.JsonObject;
import javax.ws.rs.client.Client;
import javax.ws.rs.client.ClientBuilder;
import javax.ws.rs.client.Entity;
import javax.ws.rs.client.Invocation;
import javax.ws.rs.client.WebTarget;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;
import javax.ws.rs.core.Response.Status;

import dto.JobOffer;
import dto.ReclamationJOffer;

@Stateless
public class ReclamationJOService implements ReclamationJOLocal,ReclamationJORemote {

	@Override
	public void ajoutRecJO(ReclamationJOffer r) {
		Client client=ClientBuilder.newClient();
		WebTarget target=client.target("http://localhost:17468/reclamation/addReclamationJO/");
			
		Invocation.Builder invocationBuilder  = target.request(MediaType.APPLICATION_JSON);
		Response response  = invocationBuilder.post
				(Entity.entity(r, MediaType.APPLICATION_JSON));
		
		Response resultat = response.status(Status.OK).build();
		System.out.println(resultat);
		response.close();
		
	}

	@Override
	public List<ReclamationJOffer> getAllRecJOU(String idUser) {
		Client client = ClientBuilder.newClient();
		WebTarget target=client.target("http://localhost:17468/reclamation/get/"+idUser);
		Response response=target.request(MediaType.APPLICATION_JSON).get();
	 
		JsonArray result=response.readEntity(JsonArray.class);
		
	
	//	
		
		List<ReclamationJOffer> recs = result.stream().map(e -> {
			ReclamationJOffer rec = new ReclamationJOffer();
	      
	       
	       rec.setIdUserFK(((JsonObject) e).getString("IdUserFK"));
	       rec.setIdjofferFK(((JsonObject) e).getInt("IdjofferFK"));
	       rec.setObjet(((JsonObject) e).getString("Objet"));
	       rec.setContenu(((JsonObject) e).getString("Contenu"));
	       rec.setDate(((JsonObject) e).getString("Date"));
	       rec.setTraite(((JsonObject) e).getBoolean("Traite"));
	      
	       
	      
	      
	        return rec;
	    }).collect(Collectors.toList());
		//
		
		response.close();
		
		return recs;
	}

	@Override
	public List<JobOffer> getJobOfferByid(int id) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public List<JobOffer> findAll() {
		List<JobOffer> list = new ArrayList<JobOffer>();
        Client client = ClientBuilder.newClient();
        WebTarget webTarget = client.target("http://localhost:17468/api/JobOfferApi/") ;
         
        Invocation.Builder invocationBuilder =  webTarget.request(MediaType.APPLICATION_JSON);
        
        Response response = invocationBuilder.get();
         
        JobOffer[] posts =  response.readEntity(JobOffer[].class);
             
        response.close();
        for (int index = 0; index < posts.length; index++) {
            //System.out.println(posts[index]);
            list.add(posts[index]);
            
        }
        
    return list;
	}

}
