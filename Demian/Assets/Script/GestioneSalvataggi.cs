using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GestioneSalvataggi : MonoBehaviour {

	public int salvataggioPiuAlto;
	public int ultimoSalvataggio;
	public GameObject Bottone;

	void Start () {
		salvataggioPiuAlto = PlayerPrefs.GetInt("NumeroSalvataggioPiuAlto");
		ultimoSalvataggio = PlayerPrefs.GetInt("NumeroSalvataggioCorrente");
		CreaBottoni();
	}

	void CreaBottoni(){
		int i;
		int posy;
		//CARICHIAMO TUTTI I SALVATAGGI CHE CI SONO
		for(i=1,posy = 1;i<=salvataggioPiuAlto;i++,posy++){
			if(PlayerPrefs.GetInt("Salvato"+i.ToString()) != 0){
				GameObject BottoneTMP = (GameObject)Instantiate(Bottone);
				BottoneTMP.transform.SetParent(this.transform,false);
				BottoneTMP.transform.localPosition = new Vector2(0,-60*posy+Screen.height/2);
				//NON SO PERCHE 
				int unNumero = i;
				BottoneTMP.GetComponent<Button>().onClick.AddListener(() => CaricaSalvataggio(unNumero));
				BottoneTMP.transform.GetChild(1).GetComponent<Text>().text = "Carica Salvataggio " + unNumero;
				//ADESSO MODIFICHIAMOGLI LA X IN PARTE
				BottoneTMP.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(() => EliminaSalvataggio(unNumero));
			}else{
				//SE ABBIAMO SALTATO UN BOTTONE TORNIAMO INDIETRO CON LA POSIZIONE CHE DEVE ESSERE STAMPATA
				posy--;
			}
		}
		//AGGIUNGIAMO UN BOTTONE ALLA FINE CHE AGGIUNGE UN NUOVO SALVATAGGIO
		GameObject BottoneTMP2 = (GameObject)Instantiate(Bottone);
		BottoneTMP2.transform.SetParent(this.transform,false);
		BottoneTMP2.transform.localPosition = new Vector2(0,-60*posy+Screen.height/2);
		BottoneTMP2.GetComponent<Button>().onClick.AddListener(() => {NuovoSalvataggio();});
		BottoneTMP2.transform.GetChild(1).GetComponent<Text>().text = "Nuovo Salvataggio";
		Destroy(BottoneTMP2.transform.GetChild(0).gameObject);
		//E ORA ALLUNGHIAMO IL PANNELLO
		transform.GetComponent<RectTransform>().sizeDelta = new Vector2(GetComponent<RectTransform>().sizeDelta.x, (float)60*i + 15); 
	}

	void Ricarica(){
		for(int i=1;i<transform.childCount;i++){
			Destroy(transform.GetChild(i).gameObject);
		}
		CreaBottoni();
	}

	public void CaricaSalvataggio(int salvataggioNumero){
		Debug.Log("Carico il salvataggio " + salvataggioNumero);
		PlayerPrefs.SetInt("NumeroSalvataggioCorrente",salvataggioNumero);
		Application.LoadLevel("Gioco");
	}

	public void NuovoSalvataggio(){
		//SE NON CI SONO SPAZI TRA I SALVATAGGI
		if(!ciSonoSpaziTraISalvataggi()){
		salvataggioPiuAlto++;
		PlayerPrefs.SetInt("NumeroSalvataggioPiuAlto",salvataggioPiuAlto);
		PlayerPrefs.SetInt("NumeroSalvataggioCorrente",salvataggioPiuAlto);
		Application.LoadLevel("Gioco");
		}else{
			PlayerPrefs.SetInt("NumeroSalvataggioCorrente",qualeSpazioELibero());
			Application.LoadLevel("Gioco");
		}
	}
	bool ciSonoSpaziTraISalvataggi(){
		bool controllo = false;
		for(int i=1;i<=salvataggioPiuAlto;i++){
			if(PlayerPrefs.GetInt("Salvato"+i.ToString()) == 0){
				controllo = true; //SI CI SONO SPAZI
			}
		}
		if(controllo)
			return true;
		else
			return false;
	}

	int qualeSpazioELibero(){
		//FUNZIONE PRINCIPALE
		for(int i=1;i<=salvataggioPiuAlto;i++){
			if(PlayerPrefs.GetInt("Salvato"+i.ToString()) == 0){
				return i;
			}
		}
		return 0;
	}

	public void EliminaSalvataggio(int numeroSalvataggio){
		PlayerPrefs.SetInt("Salvato"+numeroSalvataggio.ToString(),0);
		PlayerPrefs.SetFloat ("Risorse" + numeroSalvataggio + "Legno",3200);
		PlayerPrefs.SetFloat ("Risorse" + numeroSalvataggio + "Roccia",5000);
		PlayerPrefs.SetFloat ("Risorse" + numeroSalvataggio + "Ferro",0);
		PlayerPrefs.SetFloat ("Risorse" + numeroSalvataggio + "Oro",0);
		PlayerPrefs.SetFloat ("Risorse" + numeroSalvataggio + "Cibo",0);
		PlayerPrefs.SetFloat ("Risorse" + numeroSalvataggio + "Grano",0);
		PlayerPrefs.SetFloat ("Risorse" + numeroSalvataggio + "ErbeMedicinali",0);
		Ricarica();
	}
}
