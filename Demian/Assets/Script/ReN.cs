using UnityEngine;
using System.Collections;
[System.Serializable]
public class ReN{
	public Risorsa risorsa;
	public float numero;
	public ReN(Risorsa risorsa, float quantoAlSecondo){
		this.risorsa = risorsa;
		this.numero = quantoAlSecondo;
	}
	public override string ToString(){
		return numero.ToString() + " al secondo di " + risorsa.ToString();
	}
}
