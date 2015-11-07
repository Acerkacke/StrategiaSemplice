using UnityEngine;
using System.Collections;
[System.Serializable]
public class Taglialegna : Colonizzato {

	public Taglialegna(){
		gameObject = Resources.Load<GameObject>("GameObjects/Taglialegna");
		setCostoRisorse();
		setRisorseProdotte();
		maxCittadini = 8;
	}
	void setRisorseProdotte(){
		risorseProdotte = new Risorsa[3];
		risorseProdotte[0] = Risorsa.Legno;
		risorseProdotte[1] = Risorsa.Grano;
		risorseProdotte[2] = Risorsa.ErbeMedicinali;
	}
	void setCostoRisorse(){
		costoRisorse = new ReN[2];
		costoRisorse[0] = new ReN(Risorsa.Legno, 1200);
		costoRisorse[1] = new ReN(Risorsa.Roccia, 800);
	}
	public override string ToString(){
		return "Taglialegna";
	}
}
