using UnityEngine;
using System.Collections;

public class Bosco : Naturale {
	public Bosco(){
		gameObject = Resources.Load<GameObject>("GameObjects/Bosco");
		naturale = this;
		risorse = new ReN[2];
		risorse[0] = new ReN(Risorsa.Legno,15);
		risorse[1] = new ReN(Risorsa.ErbeMedicinali,0.05f);
	}
	public override string ToString(){
		return "Bosco";
	}
}
