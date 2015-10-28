using UnityEngine;
using System.Collections;

public class MatriceBlocchi : MonoBehaviour {

	public Blocco[,] blocchi = new Blocco[50,50];
	public GameObject[,] gameObjects = new GameObject[50,50];
	public int numeroSalvataggio = 1;

	void Start () {
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
					}else if(numero >= 50){
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
					}
				}
				PlayerPrefs.SetInt("MatriceBlocchiNaturali" + numeroSalvataggio + "x" + j + "y" + i,primoNumero);
				PlayerPrefs.SetInt("MatriceBlocchiColonizzati" + numeroSalvataggio + "x" + j + "y" + i,secondoNumero);
			}
		}
		PlayerPrefs.SetInt("Salvato" + numeroSalvataggio,1);
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
					}
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
	}
}
