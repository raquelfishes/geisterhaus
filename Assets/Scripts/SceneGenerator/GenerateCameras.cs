using UnityEngine;
using System.Collections;
public class GenerateCameras : MonoBehaviour {

	public GameObject humanCamera;
	private Vector3 positionCamera = new Vector3(6.5f,10.0f,-22.5f);
	private Quaternion rotationCamera = Quaternion.Euler(new Vector3(50.0f,0.0f,0.0f));
	public GameObject ghostCamera;
	private GameObject gameState;

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
		GameObject cam;
		if (gameState.GetComponent<GameState> ().getModeGame () == 0) {
			//Multiplayer = 2 camaras
			if (gameState.GetComponent<GameState> ().getPlayer1 () == 0){
				//Jugador 1 = pantalla superior humanos
				humanCamera.GetComponent<Camera>().rect = new Rect (0.0f, 0.0f, 1.0f, 0.5f);
				ghostCamera.GetComponent<Camera>().rect = new Rect (0.0f, 0.5f, 1.0f, 0.5f);
				cam = Instantiate (humanCamera, positionCamera, rotationCamera) as GameObject;
				cam = Instantiate (ghostCamera, positionCamera, rotationCamera) as GameObject;
			}else if (gameState.GetComponent<GameState> ().getPlayer1 () == 1){
				//Jugador 1 = pantalla superior fantasmas
				ghostCamera.GetComponent<Camera>().rect = new Rect (0.0f, 0.0f, 1.0f, 0.5f);
				humanCamera.GetComponent<Camera>().rect = new Rect (0.0f, 0.5f, 1.0f, 0.5f);
				cam = Instantiate (humanCamera, positionCamera, rotationCamera) as GameObject;
				cam = Instantiate (ghostCamera, positionCamera, rotationCamera) as GameObject;
			}
		} else if (gameState.GetComponent<GameState> ().getModeGame () == 1) {
			//Single ghost = camara del ghost ocupa todo
			ghostCamera.GetComponent<Camera>().rect = new Rect (0, 0, 1, 1);
			cam = Instantiate (ghostCamera, positionCamera, rotationCamera) as GameObject;
		} else if (gameState.GetComponent<GameState> ().getModeGame () == 2) {
			//Single human = camara del human ocupa todo
			humanCamera.GetComponent<Camera>().rect = new Rect (0, 0, 1, 1);
			cam = Instantiate (humanCamera, positionCamera, rotationCamera) as GameObject;
		}

	}
}
