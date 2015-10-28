using UnityEngine;
using System.Collections;

public class Taglialegna : Colonizzato {

	public Taglialegna(){
		gameObject = Resources.Load<GameObject>("GameObjects/Taglialegna");
	}
	public override string ToString(){
		return "Taglialegna";
	}
}
