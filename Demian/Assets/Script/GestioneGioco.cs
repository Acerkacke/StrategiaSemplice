using UnityEngine;
using System.Collections;

public class GestioneGioco : MonoBehaviour {
	
	public GameObject Menu;
	private Vector2 dove;
	private MatriceBlocchi matrice;
	private Inventario inventario;
	void Start () {
		matrice = GetComponent<MatriceBlocchi>();
		inventario = GetComponent<Inventario>();
	}

	void Update () {
		//RAYCAST
		if(Input.GetMouseButtonDown(0)){
			if(!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()){
				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				if(Physics.Raycast(ray, out hit, 50f)){
					if(hit.transform.tag != null){
						//15.6 - 1 - 2 - 20 - 25
						float posx = (Mathf.Floor(hit.point.x/10))*10+5f; // COSI VA AL 0.5 PIU VICINO;
						float posz = (Mathf.Floor(hit.point.z/10))*10+5f;
						if(GameObject.FindObjectOfType<Canvas>() != null){
							Destroy(GameObject.FindObjectOfType<Canvas>().gameObject);
						}
						Instantiate(Menu,new Vector3(posx,5,posz),Menu.transform.localRotation);
						dove = new Vector2((posx-5)/10,(posz-5)/10);
					}
				}
			}
		}
	}

	public void Createmi(string cosa){
		switch(cosa){
		case "Taglialegna": 
			//???????????? SEI ARRIVATO FINO A QUI ???? dovevi mettere che il blocco oltre al naturale avesse anche il colonizzato
			Destroy(matrice.gameObjects[(int)dove.x,(int)dove.y]);
			matrice.blocchi[(int)dove.x,(int)dove.y].setColonizzato(new Taglialegna());
			Instantiate(new Taglialegna().gameObject,new Vector3(dove.x*10+5,0,dove.y*10+5),new Taglialegna().gameObject.transform.localRotation);
			matrice.Salva();
			inventario.Controlla();
			break;
		case "Roccia":

			break;
		case "Ferro":

			break;
		case "Oro":

			break;
		case "Cibo":

			break;
		case "Grano":

			break;
		case "ErbeMedicinali":

			break;
		case "Acqua":

			break;
		case "CittadiniLiberi":

			break;
		}
	}
}
