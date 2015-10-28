using UnityEngine;
using System.Collections;

public class Lago : Naturale {
	public Lago(){
		naturale = this;
		gameObject = Resources.Load<GameObject>("GameObjects/Lago");
	}
	public override string ToString(){
		return "Lago";
	}
}
