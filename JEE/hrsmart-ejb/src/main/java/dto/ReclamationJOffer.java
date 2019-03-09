package dto;

import java.io.Serializable;
import java.time.LocalDateTime;

public class ReclamationJOffer implements Serializable {
	private int IdjofferFK;
	private String IdUserFK;
	private String Objet;
	private String Contenu;
	private String Date;
	private boolean Traite;
	
	public ReclamationJOffer() {
		super();
	}
	
	public ReclamationJOffer(int idjofferFK, String idUserFK, String objet, String contenu, String date,
			boolean traite) {
		super();
		IdjofferFK = idjofferFK;
		IdUserFK = idUserFK;
		Objet = objet;
		Contenu = contenu;
		Date = LocalDateTime.now().toString();
		Traite = false;
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
	

}
