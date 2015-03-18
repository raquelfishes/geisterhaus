using UnityEngine;
using System.Collections;

public class HumanPlayer : HumanController {
	
	public Vector3 direction;
	private bool isSelected=false;

	// Use this for initialization
	void Start () {
		direction = direction = Vector3.back;
		_gameManager = GameObject.FindWithTag("GameManager");
		_life = 10;
		_isMoving = false;
		_speed = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {

		if (isSelected) {
			gameObject.particleSystem.enableEmission = true;
			float horAxis = Input.GetAxisRaw ("Horizontal");
			if (horAxis != 0.0f)
				turnHorizontal (horAxis);
			float vertAxis = Input.GetAxisRaw ("Vertical");
			if (vertAxis != 0.0f)
				turnVertical (vertAxis);
		} 
		else {
			gameObject.particleSystem.enableEmission = false;
		}
		if (_isMoving)
			transform.Translate (direction * _speed *Time.deltaTime);
	}

	void OnCollisionEnter(Collision collision){
		direction = (-1.0f) * direction;
	}

	private void turnHorizontal(float axis){
		if (axis > 0.0f)
			//Turn right
			direction = Vector3.right;
		else
			//Turn left
			direction = Vector3.left;
	}

	private void turnVertical(float axis){
		if (axis > 0.0f)
			//Turn forward
			direction = Vector3.forward;
		else
			//Turn back
			direction = Vector3.back;
	}

	public void setDirection(Vector3 vec){
		direction = vec;
	}

	public Vector3 getDirection(){
		return direction;
	}

	public void deselect(){
		isSelected = false;
	}

	public void select(){
		isSelected = true;
	}

}
