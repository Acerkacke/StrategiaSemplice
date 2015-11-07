using UnityEngine;
using System.Collections;

public class GestioneGioco : MonoBehaviour {
	
	public GameObject MenuBosco;
	public GameObject MenuMontagna;
	public GameObject MenuLago;
	public GameObject MenuDescrizione;
	public GameObject MenuPausaDaAttivare;
	public float timeScale;
	public float gameTime;
	private float timeScaleFixed;
	private Vector2 dove;
	private MatriceBlocchi matrice;
	private Inventario inventario;
	void Start () {
		matrice = GetComponent<MatriceBlocchi>();
		inventario = GetComponent<Inventario>();
		timeScaleFixed = timeScale;
	}

	void Update () {
		//RAYCAST
		if(Input.GetMouseButtonDown(1)){
			if(!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()){
				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				if(Physics.Raycast(ray, out hit, 50f)){
					if(hit.transform.tag != null){
						//15.6 - 1 - 2 - 20 - 25
						float posx = (Mathf.Floor(hit.point.x/10))*10+5f; // COSI VA AL 0.5 PIU VICINO;
						float posz = (Mathf.Floor(hit.point.z/10))*10+5f;
						//ELIMINIAMO I CANVAS PRECENDENTI CHE ERANO SUL TERRENO
						if(GameObject.FindGameObjectWithTag("CanvasTerreno") != null){
							Destroy(GameObject.FindObjectOfType<Canvas>().gameObject);
						}
						//SE LA POSIZIONE NON è LA STESSA
						if((posx-5)/10 != dove.x || (posz-5)/10 != dove.y){
							GameObject daIstanziare = null;
							dove = new Vector2((posx-5)/10,(posz-5)/10);
							//SE è COLONIZZATO
							if(matrice.blocchi[(int)dove.x,(int)dove.y].colonizzato != null){
								MenuDescrizione.SetActive(true);
								MenuDescrizione.GetComponent<PannelloInformazioni>().Imposta(matrice.blocchi[(int)dove.x,(int)dove.y].colonizzato,(int)dove.x,(int)dove.y);
							}else{
								switch(matrice.blocchi[(int)dove.x,(int)dove.y].naturale.ToString()){
									case "Bosco":
										daIstanziare = MenuBosco;
										break;
									case "Pianura":
										daIstanziare = MenuBosco;
										break;
									case "Montagna":
										daIstanziare = MenuMontagna;
										break;
									case "Lago":
										daIstanziare = MenuLago;
										break;
								}
								Instantiate(daIstanziare,new Vector3(posx,5,posz),daIstanziare.transform.localRotation);
							}
						}else{
							dove = new Vector2(0,0);
						}
					}
				}
			}
		}
		//SE PREMO ESCI APRI IL MENU
		if(Input.GetKeyDown(KeyCode.Escape)){
			MenuPausa(!MenuPausaDaAttivare.activeSelf);
		}
	}

	public void MenuPausa(bool bol){
		MenuPausaDaAttivare.SetActive(bol);
		if(bol){
			timeScale = 0;
		}else{
			timeScale = timeScaleFixed;
		}
	}

	public void Createmi(string cosa){
		//Distruggi il gameobject associato a quel punto della matrice
		Destroy(matrice.gameObjects[(int)dove.x,(int)dove.y]);
		switch(cosa){
		case "Taglialegna": 
			matrice.blocchi[(int)dove.x,(int)dove.y].setColonizzato(new Taglialegna());
			Instantiate(new Taglialegna().gameObject,new Vector3(dove.x*10+5,0,dove.y*10+5),new Taglialegna().gameObject.transform.localRotation);
			break;
		case "Miniera":
			matrice.blocchi[(int)dove.x,(int)dove.y].setColonizzato(new Miniera());
			Instantiate(new Miniera().gameObject,new Vector3(dove.x*10+5,0,dove.y*10+5),new Miniera().gameObject.transform.localRotation);
			break;
		case "Villaggio":
			matrice.blocchi[(int)dove.x,(int)dove.y].setColonizzato(new Villaggio((int)dove.x,(int)dove.y));
			Instantiate(new Villaggio((int)dove.x,(int)dove.y).gameObject,new Vector3(dove.x*10+5,0,dove.y*10+5),new Villaggio((int)dove.x,(int)dove.y).gameObject.transform.localRotation);
			break;
		case "Pescatori":
			matrice.blocchi[(int)dove.x,(int)dove.y].setColonizzato(new Pescatori());
			Instantiate(new Pescatori().gameObject,new Vector3(dove.x*10+5,0,dove.y*10+5),new Pescatori().gameObject.transform.localRotation);
			break;
		default:
			Debug.LogError("NON ESISTE QUEL NOME DI COLONIZZATO");
			break;
		}
		Colonizzato col = trovaColonizzato(cosa);
		foreach(ReN ren in col.costoRisorse){
			inventario.Togli(ren.risorsa,ren.numero);
		}
		matrice.Salva();
		matrice.ControllaSeVicinoAVillaggio((int)dove.x,(int)dove.y);
	}

	public Colonizzato trovaColonizzato(string nome){
		switch(nome){
		case "Taglialegna": 
			return new Taglialegna();
		case "Miniera":
			return new Miniera();
		case "Villaggio":
			return new Villaggio();
		case "Pescatori":
			return new Pescatori();
		default:
			Debug.LogError("NON ESISTE QUEL NOME DI COLONIZZATO");
			break;
		}
		return new Colonizzato();
	}
}
