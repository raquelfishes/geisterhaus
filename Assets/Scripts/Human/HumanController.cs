using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HumanController : MonoBehaviour {

	protected GameObject _gameManager = null;
	protected int _id;
	public int _life=100;
	protected int _hurtSize = 25;
	protected float _speed = 1.0f;
	public bool _isMoving=false;
	public bool isInScene=false;
	public bool _isInteligent;
	public GameObject tileGroundEmpty;
	public GameObject soul;
	public Slider _healthBarHuman;
	public Slider _healthBarGhost;

	public Camera _humanCamera;
	public Camera _ghostCamera;

	// Use this for initialization
	void Start () {
		//_life = 100;
		_gameManager = GameObject.FindWithTag("GameManager");
		GameObject gameState = GameObject.FindWithTag("GameState");
		if (gameState.GetComponent<GameState> ().getModeGame () == 0) {
			_humanCamera = GameObject.FindWithTag("HumanCamera").GetComponent<Camera>();
			_ghostCamera = GameObject.FindWithTag("GhostCamera").GetComponent<Camera>();
			_healthBarHuman.GetComponent<Slider>().value = _life;
			_healthBarGhost.GetComponent<Slider>().value = _life;
		} else if (gameState.GetComponent<GameState> ().getModeGame () == 1) {
			_ghostCamera = GameObject.FindWithTag("GhostCamera").GetComponent<Camera>();
			_healthBarGhost.GetComponent<Slider>().value = _life;
		} else if (gameState.GetComponent<GameState> ().getModeGame () == 2) {
			_humanCamera = GameObject.FindWithTag("HumanCamera").GetComponent<Camera>();
			_healthBarHuman.GetComponent<Slider>().value = _life;
		}

		_isMoving = false;
		soul.GetComponent<CharacterController>().setGrounded(true);

	}
	
	// Update is called once per frame
	void Update () {
		soul.GetComponent<CharacterController>().setGrounded(true);
		updateHealthBar ();
	}

	public void updateHealthBar(){
		if (_humanCamera != null && _healthBarHuman != null) {
			_healthBarHuman.transform.position = _humanCamera.WorldToScreenPoint (gameObject.transform.position + new Vector3(0.0f,1.5f,0.0f));
			//_healthBarHuman.transform.position += new Vector3(0.0f,5.0f,0.0f);
		}
		if (_ghostCamera != null && _healthBarGhost != null) {
			_healthBarGhost.transform.position = _ghostCamera.WorldToScreenPoint (gameObject.transform.position + new Vector3(0.0f,1.5f,0.0f));
			//_healthBarGhost.transform.position += new Vector3(0.0f,5.0f,0.0f);
		}
	}

	public void destroyHealthBar(){
		if (_humanCamera != null) {
			Destroy (_healthBarHuman);
			//_healthBarHuman.enabled=false;
		}
		if (_ghostCamera != null) {
			Destroy (_healthBarGhost);
			//_healthBarGhost.enabled=false;
		}
		gameObject.SendMessage ("setMoving",false);
	}

	public void setHealthBarHuman(Slider bar){
		_healthBarHuman = bar;
	}
	public void setHealthBarGhost(Slider bar){
		_healthBarGhost = bar;
	}

	public void downLife(){
		_life -= _hurtSize;
		if (_humanCamera != null)
			_healthBarHuman.GetComponent<Slider>().value -= _hurtSize;
		if (_ghostCamera != null)
			_healthBarGhost.GetComponent<Slider>().value -= _hurtSize;
	}
	
	public void setLife(int li){
		_life = li;
		if (_humanCamera != null)
			_healthBarHuman.GetComponent<Slider>().value = _life;
		if (_ghostCamera != null)
			_healthBarGhost.GetComponent<Slider>().value = _life;
	}
	
	public int getLife(){
		return _life;
	}

	public void hurt(){
		_life -= _hurtSize;
		if (_humanCamera != null)
			_healthBarHuman.GetComponent<Slider>().value -= _hurtSize;
		if (_ghostCamera != null)
			_healthBarGhost.GetComponent<Slider>().value -= _hurtSize;
	}

	public void setId(int i){
		_id = i;
	}
	
	public int getId(){
		return _id;
	}

	public void setMoving(bool b){
		_isMoving = b;
	}
	
	public bool getMoving(){
		return _isMoving;
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
