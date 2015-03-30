using UnityEngine;
using System.Collections;

public class MenuMultiOrSingle : MonoBehaviour {

	private bool LIB1=false;
	private bool LIB2=false;
	private AsyncOperation async;
	public Texture2D returnButton;

	public Texture2D loading;
	private int loadProgress =0;
	public GameObject text;
	public GameObject progressBar;
	public GameObject background;

	
	void Awake () {
		DontDestroyOnLoad(transform.gameObject);
	}

	void Start(){
		text.SetActive (false);
		progressBar.SetActive (false);
		background.SetActive (false);
	}

	void OnGUI () {

		if(GUI.Button(new Rect(Screen.width-80,40,60,50),returnButton)){
			Application.LoadLevel("MainMenu");
		}

		if(GUI.Button(new Rect(Screen.width/2-50,120,100,30),"Multi-Player")){
			LIB1=true;
			LIB2=false;
		}
		if(LIB1){
			if(GUI.Button(new Rect(Screen.width/2-110,155,100,30),"J1: Fantamas")){
				//StartCoroutine(loadingScreen("loadFile"));
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
				//async=Application.LoadLevelAsync("loadFile");
				Application.LoadLevel("loadFile");
			}
			if(GUI.Button(new Rect(Screen.width/2+10,265,100,30),"Visitantes")){
				Application.LoadLevel("loadFile");
			}	
		}

		if(Application.isLoadingLevel)
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), loading);
	}

	IEnumerator loadingScreen(string mode){
		text.SetActive (true);
		progressBar.SetActive (true);
		background.SetActive (true);

		progressBar.transform.localScale = new Vector3(loadProgress,progressBar.transform.position.y,progressBar.transform.position.z);
		text.guiText.text= "Loading... "+loadProgress+"%";

		async=Application.LoadLevelAsync(mode);
		while (!async.isDone) {
			loadProgress= (int)(async.progress*100);
			progressBar.transform.localScale = new Vector3(loadProgress,progressBar.transform.position.y,progressBar.transform.position.z);
			yield return null;
		}
	}
}
