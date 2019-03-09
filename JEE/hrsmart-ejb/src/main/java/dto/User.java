package dto;
import java.io.Serializable;


 
public class User implements Serializable  {
 
	private String Id;
	private String UserName;
	private String Email;
	private String PasswordHash;
	public String getId() {
		return Id;
	}
	public void setId(String id) {
		Id = id;
	}
	public String getUserName() {
		return UserName;
	}
	public void setUserName(String userName) {
		UserName = userName;
	}
	public String getEmail() {
		return Email;
	}
	public void setEmail(String email) {
		Email = email;
	}
	public String getPasswordHash() {
		return PasswordHash;
	}
	public void setPasswordHash(String passwordHash) {
		PasswordHash = passwordHash;
	}
	public User(String id, String userName, String email, String passwordHash) {
		super();
		Id = id;
		UserName = userName;
		Email = email;
		PasswordHash = passwordHash;
	}
	public User() {
		super();
	}
	  
	  
}
