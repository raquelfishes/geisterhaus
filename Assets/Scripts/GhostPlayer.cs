using UnityEngine;
using System.Collections;

public class GhostPlayer : GhostController {

	//GameObject _gameManager = null;
	//public Vector3 obj_position;
    private bool _isSelected = false;
    int id;

	// Use this for initialization
	void Start () {
		//_gameManager = GameObject.Find ("GameManager");
	}
	
	// Update is called once per frame
	public void updateGhost () {
        //transform.position = Vector3.MoveTowards(transform.position, _objPosition, 0.05f);
	}

	void OnMouseDown(){
        if (!_isSelected)
        {
			select ();
			_gameManager.GetComponent<GameManager>().changeGhostSelected(id);
		}
	}

	public void deselect(){
        _isSelected = false;
	}
	
	public void select(){
        _isSelected = true;
	}
}
