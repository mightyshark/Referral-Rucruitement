package dto;

 
import java.util.Date;

import enumerations.CompField;


 

 
public class CustomizeApp  {

	
 
	private int IdCustom ;

	private String Logo ;

	private String WlcText ;
	private String Url ;

	private Address address ;

	private Date CreationDate ;

	private CompField CompF ;

	public int getIdCustom() {
		return IdCustom;
	}

	public void setIdCustom(int idCustom) {
		IdCustom = idCustom;
	}

	public String getLogo() {
		return Logo;
	}

	public void setLogo(String logo) {
		Logo = logo;
	}

	public String getWlcText() {
		return WlcText;
	}

	public void setWlcText(String wlcText) {
		WlcText = wlcText;
	}

	public String getUrl() {
		return Url;
	}

	public void setUrl(String url) {
		Url = url;
	}

	public Address getAddress() {
		return address;
	}

	public void setAddress(Address address) {
		this.address = address;
	}

	public Date getCreationDate() {
		return CreationDate;
	}

	public void setCreationDate(Date creationDate) {
		CreationDate = creationDate;
	}

	public CompField getCompF() {
		return CompF;
	}

	public void setCompF(CompField compF) {
		CompF = compF;
	}

	public CustomizeApp() {
		super();
		// TODO Auto-generated constructor stub
	}

	
	
}
