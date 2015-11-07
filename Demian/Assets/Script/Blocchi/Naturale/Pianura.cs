using UnityEngine;
using System.Collections;

public class Pianura : Naturale {
	public Pianura(){
		naturale = this;
		gameObject = Resources.Load<GameObject>("GameObjects/Pianura");
		risorse = new ReN[2];
		risorse[0] = new ReN(Risorsa.Legno,8);
		risorse[1] = new ReN(Risorsa.Grano,0.1f);
	}
	public override string ToString(){
		return "Pianura";
	}
}
