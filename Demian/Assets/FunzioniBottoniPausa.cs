using UnityEngine;
using System.Collections;

public class FunzioniBottoniPausa : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	public void TornaAlMenu(){
		Application.LoadLevel("Menu");
	}

	public void Riprendi(){
		GameObject.FindObjectOfType<GestioneGioco>().MenuPausa(false);
	}
}
