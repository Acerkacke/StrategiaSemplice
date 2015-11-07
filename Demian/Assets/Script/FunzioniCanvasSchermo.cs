using UnityEngine;
using System.Collections;

public class FunzioniCanvasSchermo : MonoBehaviour {

	public GameObject Risorse;

	void Start () {
	
	}
	/**
	 *	Sposta il pannello delle risorse in giu e in su;
	 * 
	 */
	public void VisualizzaRisorse(){
		Risorse.GetComponent<RectTransform>().anchoredPosition = new Vector2 (0,-Risorse.GetComponent<RectTransform>().anchoredPosition.y);
	}
}
