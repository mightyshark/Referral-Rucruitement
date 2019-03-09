package ejb;
import java.util.List;
import java.util.stream.Collectors;

import javax.ejb.Stateless;
import javax.json.JsonArray;
import javax.json.JsonObject;
import javax.ws.rs.client.Client;
import javax.ws.rs.client.ClientBuilder;
import javax.ws.rs.client.WebTarget;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;

import dto.User;



@Stateless
public class UserService implements UserLocal,UserRemote{

	@Override
	public List<User> getUsers() {
		Client client = ClientBuilder.newClient();
		WebTarget target=client.target("http://localhost:17468/role/getUsers");
		Response response=target.request(MediaType.APPLICATION_JSON).get();
	 
		JsonArray result=response.readEntity(JsonArray.class);
	
		List<User> users = result.stream().map(e -> {
			User user = new User();
	      
	   user.setId(((JsonObject) e).getString("Id"));
	   //user.setEmail(((JsonObject) e).getString("Email"));
	   user.setUserName(((JsonObject) e).getString("UserName"));
	   user.setPasswordHash(((JsonObject) e).getString("PasswordHash"));
	 
	     
	       
	      
	      
	        return  user;
	    }).collect(Collectors.toList());
		
		
		response.close();
		
		return users;
	}

	@Override
	public User doLogin(String UserName, String password) {
		for(User user : getUsers())
		{
			if(user.getUserName().equals(UserName))
			{
				if(user.getPasswordHash().equals(password))
				{
					return user;
				}
				
			}
			
			
		}
		
		return null;
	}

}
