package ejb;


import java.util.ArrayList;
import java.util.List;
import javax.ejb.LocalBean;
import javax.ejb.Stateless;

import javax.ws.rs.client.Client;
import javax.ws.rs.client.ClientBuilder;
import javax.ws.rs.client.Entity;
import javax.ws.rs.client.Invocation;
import javax.ws.rs.client.WebTarget;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;

import dto.JobOffer;


@Stateless

public class JobOfferService implements JobLocal,JobRemote {
    
    Client client;
    WebTarget target;
    
    public JobOfferService() {
        
        client = ClientBuilder.newClient();
        target = client.target("http://localhost:26945/api/"); 
        //target = client.target("http://jsonplaceholder.typicode.com/"); 

    }
    

        //Get All
        public List<JobOffer> getAll(){
            
            List<JobOffer> list = new ArrayList<JobOffer>();
            Client client = ClientBuilder.newClient();
            WebTarget webTarget = client.target("http://localhost:17468/api/JobOfferApi/") ;
             
            Invocation.Builder invocationBuilder =  webTarget.request(MediaType.APPLICATION_JSON);
            
            Response response = invocationBuilder.get();
             
            JobOffer[] posts =  response.readEntity(JobOffer[].class);
                 
        //    System.out.println("Status : " + response.getStatus());
            
            for (int index = 0; index < posts.length; index++) {
                //System.out.println(posts[index]);
                list.add(posts[index]);
                
            }
        return list;
    }
        
    
        //Delete by id
        public Response delete(int id) 
        {
            
            WebTarget hello = target.path("JobOfferAPI/"+id);
            Response res=hello.request(MediaType.APPLICATION_JSON).delete();
            
            System.out.println(res.getStatusInfo().getStatusCode());
        //System.out.println(res.readEntity(String.class));
         
         
        return res;
        }
        
        //Update JO
        public Response update( JobOffer j, int id) 
        {
            
            WebTarget hello = target.path("JobOfferAPI/"+id);
            Response res=hello.request(MediaType.APPLICATION_JSON).put(Entity.json(j));
            System.out.println("status code = "+res.getStatus());
            System.out.println(j.toString());
         
            return res;
        }
        
        
        //Create JO
        public Response addJob(JobOffer j) 
        {
            Client client = ClientBuilder.newClient();
            target = client.target("http://localhost:26945/api/"); 
            WebTarget hello = target.path("JobOfferApi/");
            Response res=hello.request(MediaType.APPLICATION_JSON).post(Entity.json(j));
            System.out.println("res is : ****** " +res +"*******");
            System.out.println(j.toString());

                System.out.println("status code = "+res.getStatus());
            
        return res;
        }                
        
        public Response addJob1(JobOffer j) 
        {
            Client client = ClientBuilder.newClient();
            WebTarget webTarget = client.target("http://localhost:26945/api/JobOfferApi/") ;
             
            Invocation.Builder invocationBuilder =  webTarget.request(MediaType.APPLICATION_JSON);
            
            Response response = invocationBuilder.post(Entity.json(j));

            System.out.println("res is : ****** " +response +"*******");
            System.out.println(j.toString());
            
                System.out.println("status code = "+response.getStatus());
            
        return response;
        }    
        
        
        
}
