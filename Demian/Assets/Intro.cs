using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour {

	public float quantoTempoCiVuole = 5f;

	void Start () {
		quantoTempoCiVuole += Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > quantoTempoCiVuole){
			Application.LoadLevel("Menu");
		}
	}
}
