using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject[] humans;
	public GameObject[] ghosts;
	public GameObject[] ghost_objects;
	private int human_selected = 0;

	// Use this for initialization
	void Start () {
		humans = GameObject.FindGameObjectsWithTag("Human");
		humans [human_selected].GetComponent<HumanPlayer>().select();
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


}
