using UnityEngine;
using System.Collections;

public class HumanPlayer : MonoBehaviour {

	private int life;
	public Vector3 direction;
	private bool isSelected=false;
	GameObject _gameManager = null;
	float speed = 1.0f;
	public bool isMoving=true;
	public bool isInScene=false;


	// Use this for initialization
	void Start () {
		_gameManager = GameObject.Find ("GameManager");
		direction = new Vector3 (0.0f, 0.0f, -1.0f);
		life = 10;
		isMoving = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (isSelected) {
			float horAxis = Input.GetAxisRaw ("Horizontal");
			if (horAxis != 0.0f)
				turnHorizontal(horAxis);
			float vertAxis = Input.GetAxisRaw ("Vertical");
			if (vertAxis != 0.0f)
				turnVertical(vertAxis);
		}
		if (isMoving)
			transform.Translate (direction * speed *Time.deltaTime);
		if (isSelected)
			gameObject.particleSystem.enableEmission = true;
		else
			gameObject.particleSystem.enableEmission = false;
	}

	void OnCollisionEnter(Collision collision){
		Debug.Log ("Cambio direccion"+ direction);
		direction = (-1.0f) * direction;
		Debug.Log (" a "+ direction);
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

	public void downLife(){
		--life;
	}

	public void setLife(int li){
		life = li;
	}

	public int getLife(){
		return life;
	}

	public void deselect(){
		isSelected = false;
	}

	public void select(){
		isSelected = true;
	}

	public void hurt(){
		life -= 2;
	}

	public void setMoving(bool b){
		isMoving = b;
	}

	public bool getMoving(){
		return isMoving;
	}

}
