using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PannelloCosto : MonoBehaviour {

	public GameObject PannelloCosti;

	void Start () {
	
	}

	public void setCosto(Colonizzato col){
		PannelloCosti.SetActive(true);
		PannelloCosti.transform.FindChild("CostoLegno").GetComponent<Text>().text = "";
		PannelloCosti.transform.FindChild("CostoRoccia").GetComponent<Text>().text = "";
		PannelloCosti.transform.FindChild("CostoFerro").GetComponent<Text>().text = "";
		PannelloCosti.transform.FindChild("CostoOro").GetComponent<Text>().text = "";
		foreach(ReN ren in col.costoRisorse){
			Risorsa ris = ren.risorsa;
			float costo = ren.numero;
			Text testo;
			switch(ris){
			case Risorsa.Legno:
				testo = PannelloCosti.transform.FindChild("CostoLegno").GetComponent<Text>();
				testo.text = costo.ToString();
				break;
			case Risorsa.Roccia:
				testo = PannelloCosti.transform.FindChild("CostoRoccia").GetComponent<Text>();
				testo.text = costo.ToString();
				break;
			case Risorsa.Ferro:
				testo = PannelloCosti.transform.FindChild("CostoFerro").GetComponent<Text>();
				testo.text = costo.ToString();
				break;
			case Risorsa.Oro:
				testo = PannelloCosti.transform.FindChild("CostoOro").GetComponent<Text>();
				testo.text = costo.ToString();
				break;
			}
		}
	}

	public void ChiudiPannello(){
		PannelloCosti.SetActive(false);
	}
}
