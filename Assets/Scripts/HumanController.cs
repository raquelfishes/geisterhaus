using UnityEngine;
using System.Collections;

public class HumanController : MonoBehaviour {

	protected GameObject _gameManager = null;
	protected int _id;
	protected int _life;
	protected float _speed = 1.0f;
	public bool _isInteligent;

	// Use this for initialization
	void Start () {
		_gameManager = GameObject.Find("GameManager");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void downLife(){
		--_life;
	}
	
	public void setLife(int li){
		_life = li;
	}
	
	public int getLife(){
		return _life;
	}

	public void hurt(){
		_life -= 2;
	}

	public void setId(int i){
		_id = i;
	}
	
	public int getId(){
		return _id;
	}
	
	public void setInteligence(bool b){
		_isInteligent = b;
		if (_isInteligent){
			gameObject.AddComponent<HumanIntelligence>();
		}else{			
			gameObject.AddComponent<HumanPlayer>();
		}
	}
}
