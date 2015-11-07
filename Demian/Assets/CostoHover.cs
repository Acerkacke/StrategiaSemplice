using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class CostoHover : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler {

	public string nome;
	private PannelloCosto PC;
	private GestioneGioco GG;

	void Start(){
		PC = transform.parent.GetComponent<PannelloCosto>();
		GG = GameObject.FindObjectOfType<GestioneGioco>();
	}

	void Update () {

	}
	public void OnPointerEnter(PointerEventData eventData){
		PC.setCosto(GG.trovaColonizzato(nome));
	}
	public void OnPointerExit(PointerEventData eventData){
		PC.ChiudiPannello();
	}
}
