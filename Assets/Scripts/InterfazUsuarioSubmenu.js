var LIB1;
var LIB2;
function OnGUI(){
	if(GUI.Button(Rect(Screen.width/2-50,70,100,30),"Multi-Player")){
		LIB1=true;
	}
	if(LIB1){
		if(GUI.Button(Rect(Screen.width/2-110,105,100,30),"J1: Fantamas")){
			Application.LoadLevel("loadFile");
		}
		if(GUI.Button(Rect(Screen.width/2+10,105,100,30),"J2: Visitantes")){
			Application.LoadLevel("loadFile");
		}	
	}
	
	if(GUI.Button(Rect(Screen.width/2-50,150,100,30),"Single-Player")){
		LIB2=true;
	}
	
	if(LIB2){
		if(GUI.Button(Rect(Screen.width/2-110,185,100,30),"Fantamas")){
			Application.LoadLevel("loadFile");
		}
		if(GUI.Button(Rect(Screen.width/2+10,185,100,30),"Visitantes")){
			Application.LoadLevel("loadFile");
		}	
	}
}