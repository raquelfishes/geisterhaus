using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject[] humans;
	public GameObject[] ghosts;
	public GameObject[] ghost_objects;
	private int human_selected = 0;
	private int ghost_selected = 0;
	private int humansPassDoor = 0;
	private int humansAlive;

	public GUIText finishMsg;

	// Use this for initialization
	void Start () {
		ghost_objects = GameObject.FindGameObjectsWithTag("GhostObject");
		humans = GameObject.FindGameObjectsWithTag("Human");
		humansAlive = humans.Length;
		humans [human_selected].GetComponent<HumanPlayer>().select();
		ghosts = GameObject.FindGameObjectsWithTag("Ghost");
		initializeGhostsId ();
		initializeGhostsPositions ();
		ghosts [ghost_selected].GetComponent<GhostPlayer>().select();
		humansPassDoor = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("ChangeH"))
			nextSelectedHuman ();
	}

	void nextSelectedHuman(){
		humans [human_selected].GetComponent<HumanPlayer>().deselect ();
		human_selected = (human_selected+1)%humans.Length;
		humans [human_selected].GetComponent<HumanPlayer>().select ();
	}

	public void changeGhostSelected(int i){
		ghosts [ghost_selected].GetComponent<GhostPlayer>().deselect ();
		ghost_selected = i;
	}

	void initializeGhostsId(){
		for (int i=0; i<ghosts.Length; i++)
			ghosts [i].GetComponent<GhostPlayer> ().setId (i);
	}

	void initializeGhostsPositions(){
		for (int i=0; i<ghosts.Length; i++) {
			ghost_objects [i].GetComponent<ObjectController>().ghostIn (ghosts [i].GetComponent<GhostPlayer> ().getId ());
			ghosts [i].GetComponent<GhostPlayer> ().setObjPosition (ghost_objects [i].GetComponent<ObjectController>().getPosition ());
		}
	}

	public int getGhostSelected(){
		return ghost_selected;
	}

	public void moveGhostHere(Vector3 obj_position){
		ghosts [ghost_selected].GetComponent<GhostPlayer> ().setObjPosition (obj_position);
		for (int i=0; i<ghost_objects.Length; i++)
			ghost_objects[i].SendMessage ("ghostOut",ghost_selected);
	}

	public void killHuman(GameObject object_aux)
	{
		for (int i=0; i<humans.Length; i++)
			if (humans [i] == object_aux) 
				for (int j=i+1; j<humans.Length; j++)
					humans [i] = humans [j];

		humans [humans.Length - 1] = null;
		Destroy (object_aux);
		--humansAlive;
		Debug.Log ("humanos vivos: " + humansAlive);
		if (humansAlive == 0) {
			Debug.Log ("Todos muertos!!!!");
			finishMsg.gameObject.SetActive (true);
			finishMsg.gameObject.guiText.text = "GHOSTS WINS!";
		}
	}

	public void addHumanCount(){
		++humansPassDoor;
		if (humansPassDoor >= humans.Length) {
			finishMsg.gameObject.SetActive (true);
			finishMsg.gameObject.guiText.text = "HUMANS WINS!";
		}
	}


}
