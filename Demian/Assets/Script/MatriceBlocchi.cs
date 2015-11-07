using UnityEngine;
using System.Collections;

public class MatriceBlocchi : MonoBehaviour {

	public Blocco[,] blocchi = new Blocco[50,50];
	public GameObject[,] gameObjects = new GameObject[50,50];
	public int numeroSalvataggio = 0;

	void Start () {
		numeroSalvataggio = PlayerPrefs.GetInt("NumeroSalvataggioCorrente");
		if(PlayerPrefs.GetInt("Salvato" + numeroSalvataggio) != 0){
			Carica();
		}else{
			for(int i=0;i<50;i++){
				for(int j=0;j<50;j++){
					int numero = Random.Range(1,100);
					if(numero >= 95){
						blocchi[i,j] = new Blocco(new Lago());
					}else if(numero >= 85){
						blocchi[i,j] = new Blocco(new Montagna());
					}else if(numero >= 45){
						blocchi[i,j] = new Blocco(new Pianura());
					}else{
						blocchi[i,j] = new Blocco(new Bosco());
					}
					switch(numero){
					case 1:
						blocchi[i,j] = new Blocco(new Bosco());
						break;
					case 2:
						blocchi[i,j] = new Blocco(new Pianura());
						break;
					case 3:
						blocchi[i,j] = new Blocco(new Montagna());
						break;
					case 4:
						blocchi[i,j] = new Blocco(new Lago());
						break;
					}
					if(blocchi[i,j].gameObject != null){
						gameObjects[i,j] = (GameObject)Instantiate(blocchi[i,j].gameObject, new Vector3(i*10+5,0,j*10+5), blocchi[i,j].gameObject.transform.localRotation);
					}
				}
			}
			Salva();
		}
	}

	public void Salva(){
		for(int i=0;i<50;i++){
			for(int j=0;j<50;j++){
				int primoNumero = 0;
				int secondoNumero = 0;
				//SALVA BLOCCHI NATURALI
				switch(blocchi[i,j].naturale.ToString()){
				case "Bosco":
					primoNumero = 1;
					break;
				case "Pianura":
					primoNumero = 2;
					break;
				case "Montagna":
					primoNumero = 3;
					break;
				case "Lago":
					primoNumero = 4;
					break;
				}
				//SALVA BLOCCHI COLONI SE CE NE SONO
				if(blocchi[i,j].colonizzato != null){
					switch(blocchi[i,j].colonizzato.ToString()){
					case "Taglialegna":
						secondoNumero = 1;
						break;
					case "Miniera":
						secondoNumero = 2;
						break;
					case "Villaggio":
						secondoNumero = 3;
						break;
					}
				}
				PlayerPrefs.SetInt("MatriceBlocchiNaturali" + numeroSalvataggio + "x" + j + "y" + i,primoNumero);
				PlayerPrefs.SetInt("MatriceBlocchiColonizzati" + numeroSalvataggio + "x" + j + "y" + i,secondoNumero);

			}
		}
		SalvaUominiCheCiSono();
		PlayerPrefs.SetInt("Salvato" + numeroSalvataggio,1);
	}

	public void SalvaUominiCheCiSono(){
		int uominiCheCiLavorano = 0;
		for(int i=0;i<50;i++){
			for(int j=0;j<50;j++){
				if(blocchi[i,j].colonizzato != null){
					if(blocchi[i,j].colonizzato.ToString() == "Villaggio"){
						Villaggio vil  = (Villaggio)blocchi[i,j].colonizzato;
						uominiCheCiLavorano = vil.personeLibere;
					}else{
						uominiCheCiLavorano = blocchi[i,j].colonizzato.cittadiniCheCiLavorano;
					}
				}
				PlayerPrefs.SetInt("MatriceBlocchiColonizzatiUominiCheCiSono" + numeroSalvataggio + "x" + j + "y" + i,uominiCheCiLavorano);
			}
		}
	}

	public void SalvaUominiCheCiSono(int x,int y){
		int uominiCheCiLavorano = 0;
		for(int i=x-1;i<x+2;i++){
			for(int j=y-1;j<y+2;j++){
				if(blocchi[i,j].colonizzato != null){
					if(blocchi[i,j].colonizzato.ToString() == "Villaggio"){
						Villaggio vil  = (Villaggio)blocchi[i,j].colonizzato;
						if(vil.personeLibere == 0){
							if(PlayerPrefs.GetInt("MatriceBlocchiColonizzatiUominiCheCiSono" + numeroSalvataggio + "x" + j + "y" + i) != 0){
								uominiCheCiLavorano = -1;
							}else{
								uominiCheCiLavorano = 0;
							}
						}else{
							uominiCheCiLavorano = vil.personeLibere;
						}
					}else{
						uominiCheCiLavorano = blocchi[i,j].colonizzato.cittadiniCheCiLavorano;
					}
					PlayerPrefs.SetInt("MatriceBlocchiColonizzatiUominiCheCiSono" + numeroSalvataggio + "x" + j + "y" + i,uominiCheCiLavorano);
				}
			}
		}
	}

	public void Carica(){
		for(int i=0;i<50;i++){
			for(int j=0;j<50;j++){
				int numeroBloccoNaturale = PlayerPrefs.GetInt("MatriceBlocchiNaturali" + numeroSalvataggio + "x" + j + "y" + i);
				int numeroBloccoColonizzato = PlayerPrefs.GetInt("MatriceBlocchiColonizzati" + numeroSalvataggio + "x" + j + "y" + i);
				Colonizzato colon = null;
				// SE HA UN COLONIZZATO ALLORA CARICALO SENNO CHISSENE
				if(numeroBloccoColonizzato != 0){

					switch(numeroBloccoColonizzato){
					case 1:
						colon = new Taglialegna();
						break;
					case 2:
						colon = new Miniera();
						break;
					case 3:
						colon = new Villaggio(i,j);
						break;
					}
					//E QUANTI UOMINI CI SONO DENTRO?
					colon.cittadiniCheCiLavorano = PlayerPrefs.GetInt("MatriceBlocchiColonizzatiUominiCheCiSono" + numeroSalvataggio + "x" + j + "y" + i);
					switch(numeroBloccoNaturale){
					case 1:
						blocchi[i,j] = new Blocco(new Bosco(),colon);
						break;
					case 2:
						blocchi[i,j] = new Blocco(new Pianura(),colon);
						break;
					case 3:
						blocchi[i,j] = new Blocco(new Montagna(),colon);
						break;
					case 4:
						blocchi[i,j] = new Blocco(new Lago(),colon);
						break;
					}
				}else{
					switch(numeroBloccoNaturale){
					case 1:
						blocchi[i,j] = new Blocco(new Bosco());
						break;
					case 2:
						blocchi[i,j] = new Blocco(new Pianura());
						break;
					case 3:
						blocchi[i,j] = new Blocco(new Montagna());
						break;
					case 4:
						blocchi[i,j] = new Blocco(new Lago());
						break;
					}
				}
				if(blocchi[i,j].gameObject != null){
					gameObjects[i,j] = (GameObject)Instantiate(blocchi[i,j].gameObject, new Vector3(i*10+5,0,j*10+5), blocchi[i,j].gameObject.transform.localRotation);
				}
			}
		}
		ControllaSeVicinoAVillaggio();
	}

	public void ControllaSeVicinoAVillaggio(){
		for(int i=0;i<48;i++){
			for(int j=0;j<48;j++){
				//CHE CI SIA QUALCOSA SOPRA
				if(blocchi[i,j].colonizzato != null){
					//HA UN VILLAGGIO VICINO E SOPRATTUTTO, E SE STESSO UN VILLAGGIO?
					if(blocchi[i,j].colonizzato.VillaggioVicino == null && blocchi[i,j].colonizzato.ToString() != "Villaggio"){
						//ORA CICLO PER I 9-1 BLOCCHI CHE CI SONO INTORNO
						for(int i1=-1;i1<2;i1++){
							for(int j1=-1;j1<2;j1++){
								//CHE NON SIA IO
								if(i1 != 0 || j1 != 0){
									//CHE CI SIA UN COLONIZZATO
									if(blocchi[i+i1,j+j1].colonizzato != null){
										//CONTROLLIAMO CHE SIA UN VILLAGGIO
										if(blocchi[i+i1,j+j1].colonizzato.ToString() == "Villaggio"){
											blocchi[i,j].colonizzato.VillaggioVicino =  (Villaggio)blocchi[i+i1,j+j1].colonizzato;
										}
									}
								}
							}
						}
					}
				}
			}
		}
	}
	public void ControllaSeVicinoAVillaggio(int x,int y){
		for(int i=x-1;i<x+2;i++){
			for(int j=y-1;j<y+2;j++){
				//CHE CI SIA QUALCOSA SOPRA
				if(blocchi[i,j].colonizzato != null){
					//HA UN VILLAGGIO VICINO E SOPRATTUTTO, E SE STESSO UN VILLAGGIO?
					if(blocchi[i,j].colonizzato.VillaggioVicino == null && blocchi[i,j].colonizzato.ToString() != "Villaggio"){
						//ORA CICLO PER I 9-1 BLOCCHI CHE CI SONO INTORNO
						for(int i1=-1;i1<2;i1++){
							for(int j1=-1;j1<2;j1++){
								//CHE NON SIA IO
								if(i1 != 0 || j1 != 0){
									//CHE CI SIA UN COLONIZZATO
									if(blocchi[i+i1,j+j1].colonizzato != null){
										//CONTROLLIAMO CHE SIA UN VILLAGGIO
										if(blocchi[i+i1,j+j1].colonizzato.ToString() == "Villaggio"){
											blocchi[i,j].colonizzato.VillaggioVicino =  (Villaggio)blocchi[i+i1,j+j1].colonizzato;
										}
									}
								}
							}
						}
					}
				}
			}
		}
	}
}
