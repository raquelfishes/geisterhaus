using UnityEngine;
using System.Collections;

public class HumanPlayer : HumanController {
	
	public Vector3 direction;
	private bool isSelected=false;
	private Quaternion quater;

	// Use this for initialization
	void Start () {
		direction = Vector3.forward;
		quater = Quaternion.Euler (new Vector3 (0,180,0));
		gameObject.transform.rotation = quater;
		_gameManager = GameObject.FindWithTag("GameManager");
		_life = 10;
		_isMoving = false;
		_speed = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
		direction = Vector3.forward;
		if (isSelected) {
			gameObject.GetComponentInChildren<SpriteRenderer>().enabled = true;
			//gameObject.particleSystem.enableEmission = true;
			float horAxis = Input.GetAxisRaw ("Horizontal");
			if (horAxis != 0.0f)
				turnHorizontal (horAxis);
			float vertAxis = Input.GetAxisRaw ("Vertical");
			if (vertAxis != 0.0f)
				turnVertical (vertAxis);
		} 
		else {
			gameObject.GetComponentInChildren<SpriteRenderer>().enabled= false;
			//gameObject.particleSystem.enableEmission = false;
		}
		if (_isMoving) {
			transform.Translate (Vector3.forward*Time.deltaTime*_speed);
			transform.rotation = quater;
		}
	}

	void OnCollisionEnter(Collision collision){
		//direction = (-1.0f) * direction;
		quater = Quaternion.Euler (new Vector3 (0,gameObject.transform.eulerAngles.y+180,0));
		//gameObject.transform.rotation = Quaternion.Euler (new Vector3 (0,gameObject.transform.eulerAngles.y+180,0));
	}

	private void turnHorizontal(float axis){
		if (axis > 0.0f) {
			//Turn right
			//direction = Vector3.right;
			//gameObject.transform.rotation = Quaternion.Euler (new Vector3 (0,90,0));
			quater = Quaternion.Euler (new Vector3 (0.0f,90.0f,0.0f));
		} else {
			//Turn left
			//direction = Vector3.left;
			//gameObject.transform.rotation = Quaternion.Euler (new Vector3 (0,-90,0));
			quater = Quaternion.Euler (new Vector3 (0.0f,-90.0f,0.0f));
		}
	}

	private void turnVertical(float axis){
		if (axis > 0.0f) {
			//Turn forward
			//direction = Vector3.forward;
			//gameObject.transform.rotation = Quaternion.Euler (new Vector3 (0,0,0));
			quater = Quaternion.Euler (new Vector3 (0.0f,0.0f,0.0f));
		} else {
			//Turn back
			//direction = Vector3.back;
			//gameObject.transform.rotation = Quaternion.Euler (new Vector3 (0,180,0));
			quater = Quaternion.Euler (new Vector3 (0.0f,180.0f,0.0f));
		}
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
