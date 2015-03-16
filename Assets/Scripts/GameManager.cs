using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public List<GameObject> humans;
	public GameObject[] ghosts;
	public GameObject[] ghost_objects;
	private int human_selected = 0;
	private int ghost_selected = 0;
	private int humansPassDoor = 0;
	private int humansAlive;

    public bool singleGhost = false;
    public bool singleHuman = false;

	public GUIText finishMsg;

	private int globalEnergy;

	// Use this for initialization
	void Start () {
		ghost_objects = GameObject.FindGameObjectsWithTag("GhostObject");
		GameObject[] humans_aux = GameObject.FindGameObjectsWithTag("Human");
		foreach (GameObject human_aux in humans_aux) {
			humans.Add (human_aux);
			globalEnergy += human_aux.GetComponent<HumanPlayer>().getLife();
		}
		humansAlive = humans.Count;
		humans [human_selected].GetComponent<HumanPlayer>().select();
		ghosts = GameObject.FindGameObjectsWithTag("Ghost");

		initializeGhostModus(singleHuman);
		initializeGhostsId ();
		initializeGhostsPositions ();
        //ghosts[ghost_selected].GetComponent<GhostController>().select();
        //initializeHumanModus(singleGhost);
		humansPassDoor = 0;
		SendMessage ("createBar", globalEnergy);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("ChangeH"))
			nextSelectedHuman ();
	}

	void nextSelectedHuman(){
		humans [human_selected].GetComponent<HumanPlayer>().deselect ();
		human_selected = (human_selected+1)%humans.Count;
		humans [human_selected].GetComponent<HumanPlayer>().select ();
	}

	public void changeGhostSelected(int i){
		ghosts [ghost_selected].GetComponent<GhostPlayer>().deselect ();
		ghost_selected = i;
	}

	void initializeGhostsId(){
		for (int i=0; i<ghosts.Length; i++)
			if (singleHuman)
				ghosts[i].GetComponent<GhostInteligence>().setId(i);
			else
				ghosts[i].GetComponent<GhostPlayer>().setId(i);
		//ghosts[i].GetComponent<GhostController>().setId(i);
	}

	void initializeGhostsPositions(){
		for (int i=0; i<ghosts.Length; i++) {
			//ghost_objects [i].GetComponent<ObjectController>().ghostIn (ghosts [i].GetComponent<GhostPlayer> ().getId ());
            if (singleHuman)
				ghosts[i].GetComponent<GhostInteligence>().setObjPosition(ghost_objects[i].GetComponent<ObjectController>().getPosition());
			else
				ghosts[i].GetComponent<GhostPlayer>().setObjPosition(ghost_objects[i].GetComponent<ObjectController>().getPosition());
		}
	}

	public int getGhostSelected(){
		return ghost_selected;
	}

	public void moveGhostHere(Vector3 obj_position){
		if (singleHuman)
        	ghosts[ghost_selected].GetComponent<GhostInteligence>().setObjPosition(obj_position);
		else
			ghosts[ghost_selected].GetComponent<GhostPlayer>().setObjPosition(obj_position);
		for (int i=0; i<ghost_objects.Length; i++)
			ghost_objects[i].SendMessage ("ghostOut",ghost_selected);
	}

	public void humanDietoGhosts(int indexHuman){
		for (int i=0; i<ghosts.Length; i++)
			ghosts[i].SendMessage ("humanDie",indexHuman);
	}

	public void killHuman(GameObject object_aux)
	{
		Debug.Log ("humanos vivos antes: " + humans.Count);
		int index = humans.IndexOf (object_aux);
		humanDietoGhosts (index);
		humans.RemoveAt(humans.IndexOf (object_aux));
		Destroy (object_aux);
		--humansAlive;
		Debug.Log ("humanos vivos despues: " + humans.Count);
		if (humansAlive == 0) {
			Debug.Log ("Todos muertos!!!!");
			finishMsg.gameObject.SetActive (true);
			finishMsg.gameObject.guiText.text = "GHOSTS WINS!";
			Application.Quit();
		}
	}

	public void hurtHuman(GameObject object_aux){
		SendMessage ("reducirVida");
		int index = humans.IndexOf (object_aux);
		humans [index].GetComponent<HumanPlayer> ().hurt ();
		if (humans [index].GetComponent<HumanPlayer> ().getLife () <= 0)
			killHuman (object_aux);
	}

	public void addHumanCount(){
		++humansPassDoor;
		if (humansPassDoor >= humans.Count) {
			finishMsg.gameObject.SetActive (true);
			finishMsg.gameObject.guiText.text = "HUMANS WINS!";
			exitGame();
		}
	}

    private void initializeGhostModus(bool b){
        for (int i = 0; i < ghosts.Length; i++)
            ghosts[i].GetComponent<GhostController>().setInteligence(b);
        if (!b) //Not single human, so ghosts are controlled by the player
            ghosts[ghost_selected].GetComponent<GhostPlayer>().select();
    }

	private void exitGame(){
		for (int i=0; i<ghost_objects.Length; i++)
			ghost_objects [i].GetComponent<GhostController> ().enabled = false;
	}


}
