﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HumanController : MonoBehaviour {

	protected GameObject _gameManager = null;
	protected int _id;
	protected int _life;
	protected int _hurtSize = 5;
	protected float _speed = 1.0f;
	public bool _isMoving=false;
	public bool isInScene=false;
	public bool _isInteligent;
	public GameObject tileGroundEmpty;
	public GameObject soul;

	public Slider healthBar;

	// Use this for initialization
	void Start () {
		_gameManager = GameObject.FindWithTag("GameManager");
		_life = 10;
		_isMoving = false;
		soul.GetComponent<CharacterController>().setGrounded(true);
		healthBar.value = 100;
	}
	
	// Update is called once per frame
	void Update () {
		soul.GetComponent<CharacterController>().setGrounded(true);
	}

	public void downLife(){
		--_life;
		healthBar.value -= _hurtSize;
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
