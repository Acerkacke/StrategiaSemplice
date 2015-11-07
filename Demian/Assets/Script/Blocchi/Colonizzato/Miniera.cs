using UnityEngine;
using System.Collections;

public class Miniera : Colonizzato {
	
	public Miniera(){
		gameObject = Resources.Load<GameObject>("GameObjects/Miniera");
		risorseProdotte = new Risorsa[3];
		risorseProdotte[0] = Risorsa.Roccia;
		risorseProdotte[1] = Risorsa.Ferro;
		risorseProdotte[2] = Risorsa.Oro;
		costoRisorse = new ReN[2];
		costoRisorse[0] = new ReN(Risorsa.Legno, 1500);
		costoRisorse[1] = new ReN(Risorsa.Roccia, 600);
		maxCittadini = 10;
	}
	public override string ToString(){
		return "Miniera";
	}
}
