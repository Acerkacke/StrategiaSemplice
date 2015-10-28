using UnityEngine;
using System.Collections;

public class SpostaVisuale : MonoBehaviour {

	public float vel = 5;
	public float velatt;
	private int ultimoInput;
	private Event e;

	void Update () {

		if(Input.GetKey(KeyCode.RightArrow)){
			if(ultimoInput == 1 || ultimoInput == 3 || ultimoInput == 4){
				if(velatt < 50)
				velatt+=velatt/30;
			}else{
				velatt = vel;
			}
			transform.Translate(Vector3.right*Time.deltaTime*velatt,Space.World);
			ultimoInput = 1;
		}
		if(Input.GetKey(KeyCode.LeftArrow) ){
			if(ultimoInput == 2 || ultimoInput == 3 || ultimoInput == 4){
				if(velatt < 50)
				velatt+=velatt/30;
			}else{
				velatt = vel;
			}
			transform.Translate(-Vector3.right*Time.deltaTime*velatt,Space.World);
			ultimoInput = 2;
		}
		if(Input.GetKey(KeyCode.DownArrow)){
			if(ultimoInput == 3 || ultimoInput == 1 || ultimoInput == 2){
				if(velatt < 50)
				velatt+=velatt/30;
			}else{
				velatt = vel;
			}
			transform.Translate(-Vector3.forward*Time.deltaTime*velatt,Space.World);
			ultimoInput = 3;
		}
		if(Input.GetKey(KeyCode.UpArrow)){
			if(ultimoInput == 4 || ultimoInput == 1 || ultimoInput == 2){
				if(velatt < 50)
				velatt+=velatt/30;
			}else{
				velatt = vel;
			}
			transform.Translate(Vector3.forward*Time.deltaTime*velatt,Space.World);
			ultimoInput = 4;
		}
	}
	void OnGUI(){
		e = Event.current;
		if(e.isKey && e.type == EventType.keyUp){
			velatt = vel;
		}
	}
}
