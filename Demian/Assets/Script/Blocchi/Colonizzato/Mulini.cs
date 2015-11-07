using UnityEngine;
using System.Collections;
[System.Serializable]
public class Mulini : Colonizzato {
	
	public Mulini(){
		gameObject = Resources.Load<GameObject>("GameObjects/Mulini");
		risorseProdotte = new Risorsa[1];
		risorseProdotte[0] = Risorsa.Cibo;
	}
	public override string ToString(){
		return "Mulini";
	}
}
