using UnityEngine;
using System.Collections;

public class Montagna : Naturale {
	public Montagna(){
		naturale = this;
		gameObject = Resources.Load<GameObject>("GameObjects/Montagna");
	}
	public override string ToString(){
		return "Montagna";
	}
}
