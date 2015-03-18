function OnGUI(){
	//GUI.contentColor=Color.red;
	//GUI.backgroundColor=Color.yellow;
	
	if(GUI.Button(Rect(Screen.width/2-85,50,170,50),"Jugar")){
		Application.LoadLevel("interfazDeUsuarioBotonJugar");
	}
	
	if(GUI.Button(Rect(Screen.width/2-85,120,170,50),"Creditos")){
		
	}
	
	if(GUI.Button(Rect(Screen.width/2-85,190,170,50),"Salir")){
		Application.Quit();
	}
}