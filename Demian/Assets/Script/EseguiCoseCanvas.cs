using UnityEngine;
using System.Collections;

public class EseguiCoseCanvas : MonoBehaviour {

	private GestioneGioco GG;

	void Start () {
		GG = GameObject.FindObjectOfType<GestioneGioco>();
	}

	public void Crea(string cosa){
		GG.Createmi(cosa);
	}
}
