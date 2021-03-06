﻿using UnityEngine;
using UnityEngine.UI;
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
	private int initHumans;
	private int killedHumans=0;

	public int _nPaths;
	public List<string[]> _Paths;

    public bool singleGhost = false;
    public bool singleHuman = false;

	public GUIText finishMsg;
	public Texture2D loading_level;

	//private int globalEnergy;

	public GameObject camara;

	public GameObject gameState;

	public GameObject interfaceHumans;
	public GameObject interfaceGhosts;

    private bool fin = false;

	// Use this for initialization
	void Start () {
		gameState = GameObject.FindWithTag ("GameState");
		ghost_objects = GameObject.FindGameObjectsWithTag("GhostObject");
		GameObject[] humans_aux = GameObject.FindGameObjectsWithTag("Human");
		foreach (GameObject human_aux in humans_aux) {
			humans.Add (human_aux);
		}
		humansAlive = humans.Count;
		ghosts = GameObject.FindGameObjectsWithTag("Ghost");

		initializeGhostModus(singleHuman); //If singleHuman==true ghosts are intelligen
		initializeHumanModus(singleGhost); //If singleGhost==true humans are intelligen
		initializeGhostsId ();
		initializeGhostsPositions ();
       
		humansPassDoor = 0;
		foreach (GameObject object_aux in ghost_objects) {
			object_aux.GetComponent<ObjectController>().initialize ();
		}
		GameObject.FindWithTag ("DoorIn").GetComponent<DoorInController> ().initialize ();
		initHumans = humans.Count;
		interfaceHumans = GameObject.FindWithTag ("CountHumans");
		if (interfaceHumans != null)
			interfaceHumans.GetComponentInChildren<Text> ().text = 0 + " / " + initHumans;
		interfaceGhosts = GameObject.FindWithTag ("CountGhosts");
		if (interfaceGhosts != null)
			interfaceGhosts.GetComponentInChildren<Text> ().text = 0 + " / " + initHumans;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("ChangeH"))
			nextSelectedHuman ();
        //Debug.Log(humans.Count);
		if (humans.Count == 0 && !fin) { //Se acaba el juego!!!!!!!!!!!!
            fin = true;
			finishLevel();
		}

		if (human_selected > humans.Count-1){
			--human_selected;
		}

	}

	void nextSelectedHuman(){
		if (humans.Count > 0 && !singleGhost) {
			humans [human_selected].GetComponent<HumanPlayer> ().deselect ();
			human_selected = (human_selected + 1) % humans.Count;
			humans [human_selected].GetComponent<HumanPlayer> ().select ();
		}
	}

	public void changeGhostSelected(int i){
		ghosts [ghost_selected].GetComponent<GhostPlayer>().deselect ();
		ghost_selected = i;
		ghosts [ghost_selected].GetComponent<GhostPlayer>().select ();
        ghosts[ghost_selected].GetComponent<SoundGhostController>().soundSelect();
	}

	void initializeGhostsId(){
		for (int i=0; i<ghosts.Length; i++) {
			ghosts [i].GetComponent<GhostController> ().setId (i);
			if (singleHuman)
				ghosts [i].GetComponent<GhostInteligence> ().setId (i);
			else
				ghosts [i].GetComponent<GhostPlayer> ().setId (i);
		}
	}

	void initializeGhostsPositions(){
		for (int i=0; i<ghosts.Length; i++) {
            ghosts[i].transform.position = ghost_objects[i].transform.position;
			ghosts[i].GetComponent<GhostController>().setObj(ghost_objects[i]);
            if (singleHuman)
				ghosts[i].GetComponent<GhostInteligence>().setObj(ghost_objects[i]);
			else
				ghosts[i].GetComponent<GhostPlayer>().setObj(ghost_objects[i]);
		}
	}

	public int getGhostSelected(){
		return ghost_selected;
	}

	public void moveGhostHere(GameObject obj){
		if (!singleHuman)
			ghosts[ghost_selected].GetComponent<GhostPlayer>().setObj(obj);
		for (int i=0; i<ghost_objects.Length; i++)
			ghost_objects[i].SendMessage ("ghostOut",ghost_selected);
	}

	public void humanDietoGhosts(int indexHuman){
		if (singleHuman) //If ghosts inteligents, they don't have to follow that human
			for (int i=0; i<ghosts.Length; i++)
				ghosts[i].SendMessage ("humanDie",indexHuman);
	}

	public void killHuman(GameObject human){

        int index = humans.IndexOf(human);

		if (index != -1) {
			humans.RemoveAt (index);
			humanDietoGhosts (index);
			if (index==human_selected && !singleGhost) nextSelectedHuman();
		}

        human.GetComponent<SoundHumanController>().soundKill();
        human.GetComponent<HumanController>().destroyHealthBar();
        human.GetComponentInChildren<CharacterController>().MuereInsensato();
		--humansAlive;
		if (index<human_selected) --human_selected;
	}

	public void hurtHuman(GameObject object_aux){
		int index = humans.IndexOf (object_aux);
		humans [index].GetComponent<HumanController> ().hurt ();
		if (humans [index].GetComponent<HumanController> ().getLife () <= 0) {
			++killedHumans;
			if (interfaceGhosts != null)
				interfaceGhosts.GetComponentInChildren<Text> ().text = killedHumans + " / " + initHumans;
			killHuman (object_aux);
		}
	}

    private void initializeGhostModus(bool b){
        for (int i = 0; i < ghosts.Length; i++)
            ghosts[i].GetComponent<GhostController>().setInteligence(b);
        if (!b) //Not single human, so ghosts are controlled by the player
            ghosts[ghost_selected].GetComponent<GhostPlayer>().select();
    }

	private void initializeHumanModus(bool intelligence){
		for (int i = 0; i < humans.Count; i++) {
			humans [i].GetComponent<HumanController> ().setInteligence(intelligence);
			if (intelligence){
				humans [i].GetComponent<HumanIntelligence> ().tileGroundEmpty = humans [i].GetComponent<HumanController> ().tileGroundEmpty;
				int randomNumber = Random.Range(0, _nPaths);
				humans[i].GetComponent<HumanIntelligence>().setPath(_Paths[randomNumber]);
			}
		}
		if(!intelligence) //Not single gosht, so humans are controlled by the player
			humans[human_selected].GetComponent<HumanPlayer>().select();
	}

	public void addHumanOut(GameObject human){
        human.GetComponent<SoundHumanController>().soundOut();
		gameState.GetComponent<GameState>().setLifeHuman(humansPassDoor,human.GetComponent<HumanController>().getLife());
		++humansPassDoor;
		gameState.GetComponent<GameState>().setNumHumans(humansPassDoor);
		//update marcador
		if (interfaceHumans != null)
			interfaceHumans.GetComponentInChildren<Text> ().text = humansPassDoor + " / " + initHumans;
	}

	public void finishLevel(){
		if (humansPassDoor > 0) {
			//Ganan los humanos
			Debug.Log ("HUMANS WINS!");
			//Desactivar canvas (marcadores, etc...)
            GameObject.Find("Canvas").SetActive(false);
            //Cargar el siguiente nivel
            gameState.GetComponent<GameState>().loadNextLevel();
		} else {
			//Ganan los fantasmas
			Debug.Log ("GHOSTS WINS!");
            //Desactivar canvas (marcadores, etc...)
            GameObject.Find("Canvas").SetActive(false);
            //Cargar gameOver
            gameState.GetComponent<GameState>().gameOver(true,false);
		}
	}

	private void exitGame(){
		for (int i=0; i<ghost_objects.Length; i++)
			ghost_objects[i].GetComponent<GhostController> ().enabled = false;
	}
}
