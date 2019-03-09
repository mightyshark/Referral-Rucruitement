package ctr;


import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.List;

import javax.ejb.EJB;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.SessionScoped;

import dto.JobOffer;
import dto.ReclamationJOffer;
import ejb.ReclamationJOLocal;

@SessionScoped
@ManagedBean
public class ReclamationJOBean {
	
	private int IdjofferFK;
	private String IdUserFK;
	private String Objet;
	private String Contenu;
	private String Date= LocalDateTime.now().toString();
	private boolean Traite = false;
	private int idFkh;
	
	public int getIdFkh() {
		return idFkh;
	}
	public void setIdFkh(int idFkh) {
		this.idFkh = idFkh;
	}
	public int getIdjofferFK() {
		return IdjofferFK;
	}
	public void setIdjofferFK(int idjofferFK) {
		IdjofferFK = idjofferFK;
	}
	public String getIdUserFK() {
		return IdUserFK;
	}
	public void setIdUserFK(String idUserFK) {
		IdUserFK = idUserFK;
	}
	public String getObjet() {
		return Objet;
	}
	public void setObjet(String objet) {
		Objet = objet;
	}
	public String getContenu() {
		return Contenu;
	}
	public void setContenu(String contenu) {
		Contenu = contenu;
	}
	public String getDate() {
		return Date;
	}
	public void setDate(String date) {
		Date = date;
	}
	public boolean isTraite() {
		return Traite;
	}
	public void setTraite(boolean traite) {
		Traite = traite;
	}
@EJB
ReclamationJOLocal RecJO;
public List<ReclamationJOffer> getRecs(String idUser) {
	List<ReclamationJOffer> ListeRec=new ArrayList<ReclamationJOffer>();
	ListeRec=RecJO.getAllRecJOU(idUser);
	return ListeRec;
}
public String AddReclamation (String idUser){
	ReclamationJOffer reclam = new ReclamationJOffer(this.IdjofferFK,idUser,Objet,Contenu,Date,Traite);
	
	//OfferDto Selectedoffer = reclamationservice.FindOffreById(selectedidoffer);
	//Selectedoffer.setIdOffer(selectedidoffer);
	//reclam.setOfferId(selectedidoffer);
	//reclam.setOffre(Selectedoffer);
	RecJO.ajoutRecJO(reclam);
	return "/ReclamationA?faces-redirect=true";
	//System.out.println("offerid"+reclam.getOfferId());
	//System.out.println("Selected offer id "+selectedidoffer);
	//System.out.println(Selectedoffer);
	//System.out.println("Added");
	
}
public List<JobOffer> findAll()
{       
	  System.out.println("FOund All offerrs");
	
   return RecJO.findAll();	        
}


}
