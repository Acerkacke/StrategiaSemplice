using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PannelloInformazioni : MonoBehaviour {

	public GameObject Nome;
	public GameObject Produce;
	public GameObject NumeroUomini;
	public GameObject Bottonepiu;
	public GameObject Bottonemeno;
	public GameObject UominiImpegnatiIntest;
	public Colonizzato bloccoAttuale;

	private int posx;
	private int posy;
	private bool eCambiatoQualcosa;
	private MatriceBlocchi matrice;
	private Inventario inventario;

	void Start(){
		matrice = GameObject.FindObjectOfType<MatriceBlocchi>();
		inventario = GameObject.FindObjectOfType<Inventario>();
	}

	public void Imposta(Colonizzato blocco,int x,int y){
		posx = x;
		posy = y;
		bloccoAttuale = blocco;
		SetInformazioni();
	}

	public void SetInformazioni(){
		Colonizzato blocco = bloccoAttuale;
		Nome.GetComponent<Text>().text = blocco.ToString();
		if(blocco.VillaggioVicino != null){
			if(blocco.risorseProdotte.Length > 0){
				Produce.GetComponent<Text>().text = "";
				foreach(Risorsa ris in blocco.risorseProdotte){
					Produce.GetComponent<Text>().text += ris.ToString() + "\n";
				}
			}else{
				Produce.GetComponent<Text>().text = "";
			}
			NumeroUomini.GetComponent<Text>().text = blocco.cittadiniCheCiLavorano.ToString();
			UominiImpegnatiIntest.GetComponent<Text>().text  = "Uomini impiegati";
			//SE IL VILLAGGIO HA DELLE PERSONE LIBERE GLI LASCIAMO AUMENTARE LE PERSONE SUL BLOCCO
			if(blocco.VillaggioVicino.personeLibere > 0){
				Bottonepiu.GetComponent<Button>().interactable = true;
			}else{
				Bottonepiu.GetComponent<Button>().interactable = false;
			}
			//SE HAI 0 PERSONE SU QUESTO BLOCCO NON PUOI PIU DIMINUIRE PERO
			if(blocco.cittadiniCheCiLavorano > 0){
				Bottonemeno.GetComponent<Button>().interactable = true;
			}else{
				Bottonemeno.GetComponent<Button>().interactable = false;
			}
		}else{
			Bottonepiu.GetComponent<Button>().interactable = false;
			Bottonemeno.GetComponent<Button>().interactable = false;
			Produce.GetComponent<Text>().text = "";
			if(bloccoAttuale.ToString() == "Villaggio"){
				Produce.GetComponent<Text>().text = "Cittadini";
				UominiImpegnatiIntest.GetComponent<Text>().text  = "Uomini liberi";
				Villaggio vil  = (Villaggio)bloccoAttuale;
				NumeroUomini.GetComponent<Text>().text = vil.personeLibere.ToString();
			}else{
				Produce.GetComponent<Text>().text = "Non ha un villaggio vicino!";
			}
		}
	}

	public void cambiaUomini(int quanto){
		if(bloccoAttuale != null){
			bloccoAttuale.cittadiniCheCiLavorano += quanto;
			bloccoAttuale.VillaggioVicino.personeUsate+=quanto;
			bloccoAttuale.VillaggioVicino.personeLibere-=quanto;
		}
		SetInformazioni();
		eCambiatoQualcosa = true;
	}

	public void Chiudi(){
		if(eCambiatoQualcosa){
			inventario.Controlla(posx,posy);
			matrice.SalvaUominiCheCiSono(posx,posy);
		}
		eCambiatoQualcosa = false;
		gameObject.SetActive(false);
	}
}
