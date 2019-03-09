package ctr;

import java.io.IOException;

import javax.ejb.EJB;
import javax.faces.application.FacesMessage;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.SessionScoped;
import javax.faces.context.FacesContext;

import ejb.UserLocal;



@ManagedBean
@SessionScoped
public class Login {
	private String Id;
	 private String UserName;
	 private String Email;
	 private String PasswordHash;
	@EJB
	 UserLocal userService;
    
    
public String getId() {
		return Id;
	}

	public void setId(String id) {
		Id = id;
	}

	public String getUserName() {
		//System.out.println(UserName+"Getter");
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

public void login() {
        
        FacesContext context = FacesContext.getCurrentInstance();

        if(userService.doLogin(UserName, PasswordHash)!=null){
            context.getExternalContext().getSessionMap().put("user", userService.doLogin(UserName, PasswordHash));
            try {
context.getExternalContext().redirect("AddReclamation.jsf");
} catch (IOException e) {
e.printStackTrace();
}
        }
        else  {
                   //Send an error message on Login Failure 
            context.addMessage(null, new FacesMessage("Authentication Failed. Check username or password."));

        } 
    }

    public void logout() {
    	FacesContext context = FacesContext.getCurrentInstance();
    	context.getExternalContext().invalidateSession();
        try {
context.getExternalContext().redirect("Login.jsf");
} catch (IOException e) {
e.printStackTrace();
}
    }

}
