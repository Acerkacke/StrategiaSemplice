using UnityEngine;
using System.Collections;

public class Villaggio : Colonizzato {

	public int personeLibere;
	public int personeUsate;

	public Villaggio(int x,int y){
		gameObject = Resources.Load<GameObject>("GameObjects/Villaggio");
		risorseProdotte = new Risorsa[0];
		setCostoRisorse();
		int numeroSalvataggio = GameObject.FindObjectOfType<MatriceBlocchi>().numeroSalvataggio;
		personeLibere = PlayerPrefs.GetInt("MatriceBlocchiColonizzatiUominiCheCiSono" + numeroSalvataggio + "x" + y + "y" + x);
		if(personeLibere == 0){
			personeLibere = 10;
		}else if(personeLibere == -1){
			personeLibere = 0;
		}
		personeUsate = 10 - personeLibere;
	}
	void setCostoRisorse(){
		costoRisorse = new ReN[2];
		costoRisorse[0] = new ReN(Risorsa.Legno, 2000);
		costoRisorse[1] = new ReN(Risorsa.Roccia, 3000);
	}

	public Villaggio(){
		gameObject = Resources.Load<GameObject>("GameObjects/Villaggio");
		risorseProdotte = new Risorsa[0];
		setCostoRisorse();
		if(personeLibere == 0){
			personeLibere = 10;
		}else if(personeLibere == -1){
			personeLibere = 0;
		}
		personeUsate = 10 - personeLibere;
	}
	public override string ToString(){
		return "Villaggio";
	}
}
