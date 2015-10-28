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
	public float Acqua;
	public float CittadiniLiberi;

	private float LegnoAlSec;
	private float RocciaAlSec;
	private float FerroAlSec;
	private float OroAlSec;
	private float CiboAlSec;
	private float GranoAlSec;
	private float ErbeMedicinaliAlSec;
	private float AcquaAlSec;
	private float CittadiniLiberiAlSec;

	private float ogniQuantoRaccolta = 1;
	private float proxRaccolta;
	private float ogniQuantoControllo = 20.2f;
	private float proxControllo;
	private MatriceBlocchi matrice;
	void Start () {
		matrice = GameObject.FindObjectOfType<MatriceBlocchi>();
		proxRaccolta = Time.time + ogniQuantoRaccolta;
		CaricaRisorse();
	}

	void FixedUpdate(){
		if(Time.time >= proxRaccolta){
			proxRaccolta = Time.time + ogniQuantoRaccolta;
			Raccogli();
		}
		if(Time.time >= proxControllo){
			proxControllo = Time.time + ogniQuantoControllo;
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
		Acqua += AcquaAlSec;
		CittadiniLiberi += CittadiniLiberiAlSec;
		SalvaRisorse();
	}

	public void Controlla(){
		SvuotaAlSec();
		for(int i=0;i<50;i++){
			for(int j=0;j<50;j++){
				if(matrice.blocchi[i,j].colonizzato != null){
					foreach(ReN ren in matrice.blocchi[i,j].naturale.risorse){
						Aggiungi(ren.risorsa.ToString(), ren.quantoAlSecondo);

					}
				}
			}
		}
	}

	public void Aggiungi(string cosa,float quanto){
		switch(cosa){
		case "Legno":
			LegnoAlSec+=quanto;
			break;
		case "Roccia":
			RocciaAlSec+=quanto;
			break;
		case "Ferro":
			FerroAlSec+=quanto;
			break;
		case "Oro":
			OroAlSec+=quanto;
			break;
		case "Cibo":
			CiboAlSec+=quanto;
			break;
		case "Grano":
			GranoAlSec+=quanto;
			break;
		case "ErbeMedicinali":
			ErbeMedicinaliAlSec+=quanto;
			break;
		case "Acqua":
			AcquaAlSec+=quanto;
			break;
		case "CittadiniLiberi":
			CittadiniLiberiAlSec+=quanto;
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
		AcquaAlSec = 0;
		CittadiniLiberiAlSec = 0;
	}

	void CaricaRisorse(){
		Legno = PlayerPrefs.GetFloat("Inventario" + matrice.numeroSalvataggio + "Legno");
		Roccia = PlayerPrefs.GetFloat("Inventario" + matrice.numeroSalvataggio + "Roccia");
		Ferro = PlayerPrefs.GetFloat("Inventario" + matrice.numeroSalvataggio + "Ferro");
		Oro = PlayerPrefs.GetFloat("Inventario" + matrice.numeroSalvataggio + "Oro");
		Cibo = PlayerPrefs.GetFloat("Inventario" + matrice.numeroSalvataggio + "Cibo");
		Grano = PlayerPrefs.GetFloat("Inventario" + matrice.numeroSalvataggio + "Grano");
		ErbeMedicinali = PlayerPrefs.GetFloat("Inventario" + matrice.numeroSalvataggio + "ErbeMedicinali");
		Acqua = PlayerPrefs.GetFloat("Inventario" + matrice.numeroSalvataggio + "Acqua");
		CittadiniLiberi = PlayerPrefs.GetFloat("Inventario" + matrice.numeroSalvataggio + "CittadiniLiberi");
	}

	void SalvaRisorse(){
		PlayerPrefs.SetFloat("Inventario" + matrice.numeroSalvataggio + "Legno",Legno);
		PlayerPrefs.SetFloat("Inventario" + matrice.numeroSalvataggio + "Roccia",Roccia);
		PlayerPrefs.SetFloat("Inventario" + matrice.numeroSalvataggio + "Ferro",Ferro);
		PlayerPrefs.SetFloat("Inventario" + matrice.numeroSalvataggio + "Oro",Oro);
		PlayerPrefs.SetFloat("Inventario" + matrice.numeroSalvataggio + "Cibo",Cibo);
		PlayerPrefs.SetFloat("Inventario" + matrice.numeroSalvataggio + "Grano",Grano);
		PlayerPrefs.SetFloat("Inventario" + matrice.numeroSalvataggio + "ErbeMedicinali",ErbeMedicinali);
		PlayerPrefs.SetFloat("Inventario" + matrice.numeroSalvataggio + "Acqua",Acqua);
		PlayerPrefs.SetFloat("Inventario" + matrice.numeroSalvataggio + "CittadiniLiberi",CittadiniLiberi);
	}
}
