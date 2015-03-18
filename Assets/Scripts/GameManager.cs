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

	public int _nPaths;
	public List<string[]> _Paths;

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
			//globalEnergy += human_aux.GetComponent<HumanPlayer>().getLife();
		}
		humansAlive = humans.Count;
		ghosts = GameObject.FindGameObjectsWithTag("Ghost");

		initializeGhostModus(singleHuman); //If singleHuman==true ghosts are intelligen
		initializeHumanModus(singleGhost); //If singleGhost==true humans are intelligen
		initializeGhostsId ();
		initializeGhostsPositions ();
        //ghosts[ghost_selected].GetComponent<GhostController>().select();
        //initializeHumanModus(singleGhost);
		humansPassDoor = 0;
		//SendMessage ("createBar", globalEnergy);
		foreach (GameObject object_aux in ghost_objects) {
			object_aux.GetComponent<ObjectController>().initialize ();
		}
		GameObject.FindWithTag ("DoorIn").GetComponent<DoorInController> ().initialize ();
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
		Debug.Log ("humano seleccionado: " + human_selected);
	}

	public void changeGhostSelected(int i){
		ghosts [ghost_selected].GetComponent<GhostPlayer>().deselect ();
		ghost_selected = i;
		ghosts [ghost_selected].GetComponent<GhostPlayer>().select ();
	}

	void initializeGhostsId(){
		for (int i=0; i<ghosts.Length; i++) {
			ghosts [i].GetComponent<GhostController> ().setId (i);
			if (singleHuman)
				ghosts [i].GetComponent<GhostInteligence> ().setId (i);
			else
				ghosts [i].GetComponent<GhostPlayer> ().setId (i);
			//ghosts[i].GetComponent<GhostController>().setId(i);
		}
	}

	void initializeGhostsPositions(){
		for (int i=0; i<ghosts.Length; i++) {
			//ghost_objects [i].GetComponent<ObjectController>().ghostIn (ghosts [i].GetComponent<GhostPlayer> ().getId ());
			ghosts[i].GetComponent<GhostController>().setObjPosition(ghost_objects[i].GetComponent<ObjectController>().getPosition());
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
		if (!singleHuman)
        	//ghosts[ghost_selected].GetComponent<GhostInteligence>().setObjPosition(obj_position);
		//else
			ghosts[ghost_selected].GetComponent<GhostPlayer>().setObjPosition(obj_position);
		Debug.Log ("moviendo fantasma" + ghost_selected);
		for (int i=0; i<ghost_objects.Length; i++)
			ghost_objects[i].SendMessage ("ghostOut",ghost_selected);
	}

	public void humanDietoGhosts(int indexHuman){
		if (singleHuman) //If ghosts inteligents, they don't have to follow that human
			for (int i=0; i<ghosts.Length; i++)
				ghosts[i].SendMessage ("humanDie",indexHuman);
	}

	public void killHuman(GameObject object_aux)
	{
		Debug.Log ("humanos vivos antes: " + humans.Count);
		int index = humans.IndexOf (object_aux);
		humanDietoGhosts (index);
		humans.RemoveAt(index);
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
		//SendMessage ("reducirVida");
		int index = humans.IndexOf (object_aux);
		humans [index].GetComponent<HumanPlayer> ().hurt ();
		if (humans [index].GetComponent<HumanPlayer> ().getLife () <= 0)
			killHuman (object_aux);
	}

	public void addHumanOut(){
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
			ghost_objects[i].GetComponent<GhostController> ().enabled = false;
	}

	private void initializeHumanModus(bool intelligence){
		for (int i = 0; i < humans.Count; i++) {
			humans [i].GetComponent<HumanController> ().setInteligence(intelligence);
			if (intelligence){
				humans [i].GetComponent<HumanIntelligence> ().tileGroundEmpty = humans [i].GetComponent<HumanController> ().tileGroundEmpty;
				int randomNumber = Random.Range(0, _nPaths);
				humans[i].GetComponent<HumanIntelligence>().setPath(_Paths[randomNumber]);
				//humans[i].GetComponent<HumanIntelligence>().printX();
			}
		}
		if(!intelligence) //Not single gosht, so humans are controlled by the player
			humans[human_selected].GetComponent<HumanPlayer>().select();
	}

	public void addHumanScene(GameObject human){
		humans.Add(human);
	}

	public void removeHumanScene(GameObject human){
		int index = humans.IndexOf (human);
		humanDietoGhosts (index);
		humans.RemoveAt(index);
	}

}
