package ejb;
import java.util.List;

import javax.ejb.Local;

import dto.User;





@Local
public interface UserLocal {
	public List<User>getUsers();
	public User doLogin(String Username,String password);

}
