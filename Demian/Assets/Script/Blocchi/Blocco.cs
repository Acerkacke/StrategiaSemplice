using UnityEngine;
using System.Collections;

[System.Serializable]
public class Blocco{
	public GameObject gameObject;
	public Naturale naturale;
	public Colonizzato colonizzato;
	public ReN[] risorse;

	public Blocco(Naturale natural){
		naturale = natural;
		gameObject = natural.gameObject;
		risorse = natural.risorse;
		colonizzato = null;
	}
	public Blocco(Naturale natural,Colonizzato colon){
		naturale = natural;
		colonizzato = colon;
		gameObject = colon.gameObject;
		risorse = natural.risorse;
	}
	public Blocco(){

	}

	public void setColonizzato(Colonizzato colonia){
		gameObject = colonia.gameObject;
		colonizzato = colonia;
	}
}
