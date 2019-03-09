package ejb;
import java.util.List;

import javax.ejb.Remote;

import dto.User;


@Remote
public interface UserRemote {
	public List<User>getUsers();
	public User doLogin(String Username,String password);

}
