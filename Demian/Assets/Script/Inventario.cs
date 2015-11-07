using UnityEngine;
using System.Collections;


public class Inventario : MonoBehaviour {

	public float Legno;
	public float Roccia;
	public float Ferro;
	public float Oro;
	public float Cibo;
	public float Grano;
	public float ErbeMedicinali;

	private float LegnoAlSec;
	private float RocciaAlSec;
	private float FerroAlSec;
	private float OroAlSec;
	private float CiboAlSec;
	private float GranoAlSec;
	private float ErbeMedicinaliAlSec;

	private float ogniQuantoRaccolta = 1;
	private float proxRaccolta;
	private float ogniQuantoControllo = 20.2f;
	private float proxControllo;
	private MatriceBlocchi matrice;
	private GestioneGioco GG;
	private float tempoUltimoFrame;
	void Start () {
		//IF CARICA ELSE = 0;
		matrice = GetComponent<MatriceBlocchi>();
		GG = GetComponent<GestioneGioco>();
		GG.gameTime += Time.time;
		//proxContGetComponent<MatriceBlocchi>();rollo = Time.time + ogniQuantoControllo;
		proxRaccolta = Time.time + ogniQuantoRaccolta;
		tempoUltimoFrame = Time.time;
		Carica ();
	}

	void FixedUpdate(){
		GG.gameTime += (Time.time - tempoUltimoFrame) * GG.timeScale;
		tempoUltimoFrame = Time.time;
		if(GG.gameTime >= proxRaccolta){
			proxRaccolta = GG.gameTime + ogniQuantoRaccolta;
			Raccogli();
		}
		if(GG.gameTime >= proxControllo){
			proxControllo = GG.gameTime + ogniQuantoControllo;
			Controlla();
		}
	}

	void Raccogli(){
		Legno += LegnoAlSec;
		Roccia += RocciaAlSec;
		Ferro += FerroAlSec;
		Oro += OroAlSec;
		Cibo += CiboAlSec;
		Grano += GranoAlSec;
		ErbeMedicinali += ErbeMedicinaliAlSec;
		Salva ();
	}

	public void Controlla(){
		SvuotaAlSec();
		for(int i=0;i<50;i++){
			for(int j=0;j<50;j++){
				//se il questo blocco c'è un colonizzato
				if(matrice.blocchi[i,j].colonizzato != null){
					//se produce qualcosa
					if(matrice.blocchi[i,j].risorse.Length > 0){
						//per ogni risorsa nel blocco naturale aggiungo quanto produce
						//Debug.Log(matrice.blocchi[i,j].risorse[0] + " con dentro " + matrice.blocchi[i,j].colonizzato.cittadiniCheCiLavorano + " uomini");
						foreach(ReN ren in matrice.blocchi[i,j].risorse){
							//Per ogni cittadino che ci lavora dentro aggiungo risorsa al secondo
							for(int f=0;f<matrice.blocchi[i,j].colonizzato.cittadiniCheCiLavorano;f++){
								Aggiungi(ren.risorsa, ren.numero);
							}
						}
					}
				}
			}
		}
	}

	public void Controlla(int i,int j){
		if(matrice.blocchi[i,j].colonizzato != null){
			//se produce qualcosa
			if(matrice.blocchi[i,j].risorse.Length > 0){
				//per ogni risorsa nel blocco naturale aggiungo quanto produce
				foreach(ReN ren in matrice.blocchi[i,j].risorse){
					//Per ogni cittadino che ci lavora dentro aggiungo risorsa al secondo
					for(int f=0;f<matrice.blocchi[i,j].colonizzato.cittadiniCheCiLavorano;f++){
						Aggiungi(ren.risorsa, ren.numero);
					}
				}
			}
		}
	}
	
	private void Aggiungi(Risorsa cosa,float quanto){
		switch(cosa){
		case Risorsa.Legno:
			LegnoAlSec+=quanto;
			break;
		case Risorsa.Roccia:
			RocciaAlSec+=quanto;
			break;
		case Risorsa.Ferro:
			FerroAlSec+=quanto;
			break;
		case Risorsa.Oro:
			OroAlSec+=quanto;
			break;
		case Risorsa.Cibo:
			CiboAlSec+=quanto;
			break;
		case Risorsa.Grano:
			GranoAlSec+=quanto;
			break;
		case Risorsa.ErbeMedicinali:
			ErbeMedicinaliAlSec+=quanto;
			break;
		}
	}

	void SvuotaAlSec(){
		LegnoAlSec = 0;
		RocciaAlSec = 0;
		FerroAlSec = 0;
		OroAlSec = 0;
		CiboAlSec = 0;
		GranoAlSec = 0;
		ErbeMedicinaliAlSec = 0;
	}

	public void Togli(Risorsa cosa,float quanto){
		switch(cosa){
		case Risorsa.Legno:
			if(Legno-quanto >= 0){
				Legno-=quanto;
			}else{
				Debug.LogError("NON HAI ABBASTANZA MATERIALI");
			}
			break;
		case Risorsa.Roccia:
			if(Roccia-quanto >= 0){
				Roccia-=quanto;
			}else{
				Debug.LogError("NON HAI ABBASTANZA MATERIALI");
			}
			break;
		case Risorsa.Ferro:
			if(Ferro-quanto >= 0){
				Ferro-=quanto;
			}else{
				Debug.LogError("NON HAI ABBASTANZA MATERIALI");
			}
			break;
		case Risorsa.Oro:
			if(Oro-quanto >= 0){
				Oro-=quanto;
			}else{
				Debug.LogError("NON HAI ABBASTANZA MATERIALI");
			}
			break;
		case Risorsa.Cibo:
			if(Cibo-quanto >= 0){
				Cibo-=quanto;
			}else{
				Debug.LogError("NON HAI ABBASTANZA MATERIALI");
			}
			break;
		case Risorsa.Grano:
			if(Grano-quanto >= 0){
				Grano-=quanto;
			}else{
				Debug.LogError("NON HAI ABBASTANZA MATERIALI");
			}
			break;
		case Risorsa.ErbeMedicinali:
			if(ErbeMedicinali-quanto >= 0){
				ErbeMedicinali-=quanto;
			}else{
				Debug.LogError("NON HAI ABBASTANZA MATERIALI");
			}
			break;
		}
	}

	void Salva(){
		int salvat = PlayerPrefs.GetInt("NumeroSalvataggioCorrente");;
		PlayerPrefs.SetFloat ("Risorse" + salvat + "Legno",Legno);
		PlayerPrefs.SetFloat ("Risorse" + salvat + "Roccia",Roccia);
		PlayerPrefs.SetFloat ("Risorse" + salvat + "Ferro",Ferro);
		PlayerPrefs.SetFloat ("Risorse" + salvat + "Oro",Oro);
		PlayerPrefs.SetFloat ("Risorse" + salvat + "Cibo",Cibo);
		PlayerPrefs.SetFloat ("Risorse" + salvat + "Grano",Grano);
		PlayerPrefs.SetFloat ("Risorse" + salvat + "ErbeMedicinali",ErbeMedicinali);
	}

	void Carica(){
		int salvat = PlayerPrefs.GetInt("NumeroSalvataggioCorrente");;
		Legno = PlayerPrefs.GetFloat ("Risorse" + salvat + "Legno");
		Roccia = PlayerPrefs.GetFloat ("Risorse" + salvat + "Roccia");
		Ferro = PlayerPrefs.GetFloat ("Risorse" + salvat + "Ferro");
		Oro = PlayerPrefs.GetFloat ("Risorse" + salvat + "Oro");
		Cibo = PlayerPrefs.GetFloat ("Risorse" + salvat + "Cibo");
		Grano = PlayerPrefs.GetFloat ("Risorse" + salvat + "Grano");
		ErbeMedicinali = PlayerPrefs.GetFloat ("Risorse" + salvat + "ErbeMedicinali");
	}
}
