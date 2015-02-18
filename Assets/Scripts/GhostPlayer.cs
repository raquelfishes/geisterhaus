using UnityEngine;
using System.Collections;

public class GhostPlayer : MonoBehaviour {

	GameObject _gameManager = null;
	public Vector3 obj_position;
	private bool selected=false;
	int id;

	// Use this for initialization
	void Start () {
		_gameManager = GameObject.Find ("GameManager");
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards (transform.position, obj_position, 0.05f);
	}

	void OnMouseDown(){
		if (!selected) {
			select ();
			_gameManager.GetComponent<GameManager>().changeGhostSelected(id);
		}
	}

	public void deselect(){
		selected = false;
	}
	
	public void select(){
		selected = true;
	}

	public void setId(int i){
		id = i;
	}

	public int getId(){
		return id;
	}

	public void setObjPosition(Vector3 position){
		obj_position = position;
	}
}
