using UnityEngine;
using System.Collections;

public class HumanPlayer : MonoBehaviour {

	private int life;
	public Vector3 direction;
	private bool selected=false;
	GameObject _gameManager = null;
	float speed = 1.0f;


	// Use this for initialization
	void Start () {
		_gameManager = GameObject.Find ("GameManager");
		direction = new Vector3 (0.0f, 0.0f, -1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		if (selected) {
			float horAxis = Input.GetAxisRaw ("Horizontal");
			if (horAxis != 0.0f)
				turnHorizontal(horAxis);
			float vertAxis = Input.GetAxisRaw ("Vertical");
			if (vertAxis != 0.0f)
				turnVertical(vertAxis);
		}
		transform.Translate (direction * speed *Time.deltaTime);
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
		selected = false;
	}

	public void select(){
		selected = true;
	}

}
