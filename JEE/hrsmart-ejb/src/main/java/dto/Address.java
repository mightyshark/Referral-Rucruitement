package dto;

 import java.util.List;




 public class Address  {
	
	//@Id
	//@GeneratedValue(strategy=GenerationType.AUTO)

	 private int id ;
	 private String city ;
	 private String country ;

	 private  List<CustomizeApp> customizeapps ;

	public int getId() {
		return id;
	}

	public void setId(int id) {
		this.id = id;
	}

	public String getCity() {
		return city;
	}

	public void setCity(String city) {
		this.city = city;
	}

	public String getCountry() {
		return country;
	}

	public void setCountry(String country) {
		this.country = country;
	}

	public List<CustomizeApp> getCustomizeapps() {
		return customizeapps;
	}

	public void setCustomizeapps(List<CustomizeApp> customizeapps) {
		this.customizeapps = customizeapps;
	}

	public Address() {
		super();
		// TODO Auto-generated constructor stub
	}
	 
	 
	
}
