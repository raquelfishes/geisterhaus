using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	void OnGUI () {
		if(GUI.Button(new Rect(Screen.width/2-85,120,170,50),"Jugar")){
			Application.LoadLevel("MultiOrSingleMenu");
		}

		if(GUI.Button(new Rect(Screen.width/2-85,210,170,50),"Creditos")){

		}
		
		if(GUI.Button(new Rect(Screen.width/2-85,280,170,50),"Salir")){
			Application.Quit();
		}
	
	}
}
