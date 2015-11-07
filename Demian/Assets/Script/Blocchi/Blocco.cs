using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
		risorse = risorseCompatibili(natural.risorse,colon.risorseProdotte);
	}
	public Blocco(){
	}

	public void setColonizzato(Colonizzato colonia){
		gameObject = colonia.gameObject;
		colonizzato = colonia;
		risorse = risorseCompatibili(risorse,colonia.risorseProdotte);
	}

	ReN[] risorseCompatibili(ReN[] ris1, Risorsa[] ris2){
		ReN[] risorseCompat = new ReN[0];
		int numeroRis = 0;
		for(int i=0;i<ris1.Length;i++){
			for(int e=0;e<ris2.Length;e++){
				if(ris1[i].risorsa == ris2[i]){
					ReN[] temp = new ReN[numeroRis];
					//COPIA DENTRO TEMP I VALORI DI RISORSE COMPATIBILI
					for(int f=0;f<numeroRis;f++){
						temp[f] = risorseCompat[f];
					}
					//AGGIUNGE UN POSCO A RISORSE
					risorseCompat = new ReN[numeroRis+1];
					//RICOPIA DENTRO RISORSE LE COSE VECCHIE DI TEMP
					for(int f=0;f<numeroRis;f++){
						risorseCompat[f] = temp[f];
					}
					//METTE ALLA FINE SU QUELLO NUOVO LA NUOVA RISORSA
					risorseCompat[numeroRis] = ris1[i];
					numeroRis++;
				}
			}
		}
		return risorseCompat;
	}
}
