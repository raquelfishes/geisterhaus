using UnityEngine;
using System.Collections;

public class GhostPlayer : GhostController {
	
    private bool _isSelected = false;

	// Use this for initialization
	void Start () {
		_gameManager = GameObject.FindWithTag("GameManager");
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, _objPosition, 0.05f);
	}

	void OnMouseDown(){
		Debug.Log ("seleccion fantasma  "+ _isSelected+"  "+_id);
        if (!_isSelected)
        {
			select ();
			Debug.Log(_gameManager);
			_gameManager.GetComponent<GameManager>().changeGhostSelected(_id);
		}
	}

	public void deselect(){
        _isSelected = false;
	}
	
	public void select(){
        _isSelected = true;
	}
}
