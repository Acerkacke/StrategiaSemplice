using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScriviRisorse : MonoBehaviour {
	
	public GameObject[] ListaRisorse = new GameObject[7];
	private Inventario inv;
	private float proxAgg;
	private float ogniQuanto = 1;
	private GestioneGioco GG;

	void Start(){
		inv = GameObject.FindObjectOfType<Inventario> ();
		GG = GameObject.FindObjectOfType<GestioneGioco>();
	}

	void Update(){
		if (GG.gameTime > proxAgg) {
			proxAgg = GG.gameTime + ogniQuanto;
			Aggiorna();
		}
	}

	void Aggiorna(){
		ListaRisorse[0].GetComponent<Text>().text = Mathf.Floor(inv.Legno).ToString();
		ListaRisorse[1].GetComponent<Text>().text = Mathf.Floor(inv.Roccia).ToString();
        ListaRisorse[2].GetComponent<Text>().text = Mathf.Floor(inv.Ferro).ToString();
        ListaRisorse[3].GetComponent<Text>().text = Mathf.Floor(inv.Oro).ToString();
        ListaRisorse[4].GetComponent<Text>().text = Mathf.Floor(inv.Cibo).ToString();
        ListaRisorse[5].GetComponent<Text>().text = Mathf.Floor(inv.Grano).ToString();
        ListaRisorse[6].GetComponent<Text>().text = Mathf.Floor(inv.ErbeMedicinali).ToString();
	}
}
