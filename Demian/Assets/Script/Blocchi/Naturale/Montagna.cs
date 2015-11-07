using UnityEngine;
using System.Collections;

public class Montagna : Naturale {
	public Montagna(){
		naturale = this;
		gameObject = Resources.Load<GameObject>("GameObjects/Montagna");
		risorse = new ReN[3];
		risorse[0] = new ReN(Risorsa.Roccia,20);
		risorse[1] = new ReN(Risorsa.Ferro,1f);
		risorse[2] = new ReN(Risorsa.Oro,0.08f);
	}
	public override string ToString(){
		return "Montagna";
	}
}
