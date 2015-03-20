using UnityEngine;
using System.Collections;

public class MenuMultiOrSingle : MonoBehaviour {

	private bool LIB1=false;
	private bool LIB2=false;
	public Texture2D house;
	//public  GUIStyle customGuiStyle;

	void OnGUI () {

		if(GUI.Button(new Rect(Screen.width/3-50,140,120,80),house)){
			Application.LoadLevel("MainMenu");
		}

		if(GUI.Button(new Rect(Screen.width/2-50,120,100,30),"Multi-Player")){
			LIB1=true;
			LIB2=false;
		}
		if(LIB1){
			if(GUI.Button(new Rect(Screen.width/2-110,155,100,30),"J1: Fantamas")){
				Application.LoadLevel("loadFile");
			}
			if(GUI.Button(new Rect(Screen.width/2+10,155,100,30),"J2: Visitantes")){
				Application.LoadLevel("loadFile");
			}	
		}
		
		if(GUI.Button(new Rect(Screen.width/2-50,230,100,30),"Single-Player")){
			LIB2=true;
			LIB1=false;
		}
		
		if(LIB2){
			if(GUI.Button(new Rect(Screen.width/2-110,265,100,30),"Fantamas")){
				Application.LoadLevel("loadFile");
			}
			if(GUI.Button(new Rect(Screen.width/2+10,265,100,30),"Visitantes")){
				Application.LoadLevel("loadFile");
			}	
		}
	}
}
