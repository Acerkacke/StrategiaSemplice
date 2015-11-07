using UnityEngine;
using System.Collections;

public class Loading : MonoBehaviour {

	void Update () {
		if(Application.isLoadingLevel){
			Application.LoadLevel("Intro");
		}
	}
}
