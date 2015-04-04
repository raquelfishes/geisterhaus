using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class GenerateCameras : MonoBehaviour {

	public GameObject humanCamera;
	private Vector3 positionCamera = new Vector3(6.5f,10.0f,-22.5f);
	private Quaternion rotationCamera = Quaternion.Euler(new Vector3(50.0f,0.0f,0.0f));
	public GameObject ghostCamera;
	private GameObject gameState;
	
	public GameObject ghostCounts;
	public GameObject humanCounts;

	void Awake() {
		gameState = GameObject.FindWithTag ("GameState");
		instantiateCameras ();
	}

	// Use this for initialization
	void Start () {
		//instantiateCameras();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void instantiateCameras(){
		if (gameState.GetComponent<GameState> ().getModeGame () == 0) {
			//Multiplayer = 2 camaras
			if (gameState.GetComponent<GameState> ().getPlayer1 () == 0){
				//Jugador 1 = pantalla superior humanos
				//Fijamos tamaño del espacio que renderiza las camaras
				humanCamera.GetComponent<Camera>().rect = new Rect (0.0f, 0.0f, 1.0f, 0.5f);
				ghostCamera.GetComponent<Camera>().rect = new Rect (0.0f, 0.5f, 1.0f, 0.5f);
				//Instanciamos las camaras
				var cam1 = Instantiate (humanCamera, positionCamera, rotationCamera) as GameObject;
				var cam2 = Instantiate (ghostCamera, positionCamera, rotationCamera) as GameObject;
				//Instanciamos los contadores como hijos del canvas
				//Fijamos la posicion de los contadores
				var aux = Instantiate (humanCounts, positionCamera, Quaternion.identity) as GameObject;
				aux.transform.parent = GameObject.Find ("Canvas").transform;
				aux.transform.position = cam1.GetComponent<Camera>().WorldToScreenPoint (new Vector3(0.0f,0.0f,0.0f));
				aux = Instantiate (ghostCounts, positionCamera, Quaternion.identity) as GameObject;
				aux.transform.parent = GameObject.Find ("Canvas").transform;
				aux.transform.position = cam2.GetComponent<Camera>().WorldToScreenPoint (new Vector3(0.0f,0.0f,0.0f));
			}
			} else if (gameState.GetComponent<GameState> ().getModeGame () == 1) {
				//Single ghost = camara del ghost ocupa todo
				ghostCamera.GetComponent<Camera>().rect = new Rect (0, 0, 1, 1);
				var cam = Instantiate (ghostCamera, positionCamera, rotationCamera) as GameObject;
				var aux = Instantiate (ghostCounts, positionCamera, Quaternion.identity) as GameObject;
				aux.transform.parent = GameObject.Find ("Canvas").transform;
				aux.transform.position = cam.GetComponent<Camera>().WorldToScreenPoint (new Vector3(0.0f,0.0f,0.0f));
			} else if (gameState.GetComponent<GameState> ().getModeGame () == 2) {
				//Single human = camara del human ocupa todo
				humanCamera.GetComponent<Camera>().rect = new Rect (0, 0, 1, 1);
				var cam = Instantiate (humanCamera, positionCamera, rotationCamera) as GameObject;
				var aux = Instantiate (humanCounts, positionCamera, Quaternion.identity) as GameObject;
				aux.transform.parent = GameObject.Find ("Canvas").transform;
				aux.transform.position = cam.GetComponent<Camera>().WorldToScreenPoint (new Vector3(0.0f,0.0f,0.0f));
			}

	}
}
