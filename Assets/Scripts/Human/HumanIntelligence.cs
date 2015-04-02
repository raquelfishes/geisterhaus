using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HumanIntelligence : HumanController {

	//private string _Path="DDDRRRRRRDDDLLLDDDRRRDDDRRRUUULLL";
	private string[] _Path;
	private float aumentoX;
	private float aumentoZ;
	public Vector3 position;
	private int destiny = 0;
	private float inix;
	private float iniz;
	private bool inicial=true;
	private bool collis=false;

	void Start () {
		Renderer m_renderer = tileGroundEmpty.renderer;
		aumentoX = m_renderer.bounds.size.x;
		aumentoZ = m_renderer.bounds.size.z;
		inix = aumentoX / 2;
		iniz = aumentoZ / 2;
	}

	void Update () {
	  if (isInScene) {
			if(inicial){pathEvaluateIni (); inicial=!inicial;transform.position = Vector3.MoveTowards (transform.position, position, 0.03f);++destiny;}
			bool iguales = (transform.position.x == position.x) && (transform.position.z == position.z);
			if (iguales) {
				pathEvaluate ();
				if (destiny < _Path.Length - 1)	++destiny;
			}
			transform.position = Vector3.MoveTowards (transform.position, position, 0.03f);
	  }
	}

	public void pathEvaluate(){
		switch (_Path[destiny]){
			case "D":	position=transform.position-new Vector3(0.0f,0.0f,aumentoZ);
				gameObject.transform.rotation = Quaternion.Euler (new Vector3 (0,180,0));
				break;
			case "U":	position=transform.position+new Vector3(0.0f,0.0f,aumentoZ);
				gameObject.transform.rotation = Quaternion.Euler (new Vector3 (0,0,0));
				break;
			case "L":	position=transform.position-new Vector3(aumentoX,0.0f,0.0f);
				gameObject.transform.rotation = Quaternion.Euler (new Vector3 (0,-90,0));
				break;
			case "R":	position=transform.position+new Vector3(aumentoX,0.0f,0.0f);
				gameObject.transform.rotation = Quaternion.Euler (new Vector3 (0,90,0));
				break;
			default:	break;
		}
	}

	public void pathEvaluateIni(){
		switch (_Path[destiny]){
		case "D":	position=transform.position-new Vector3(0.0f,0.0f,iniz);
			gameObject.transform.rotation = Quaternion.Euler (new Vector3 (0,180,0));
			break;
		case "U":	position=transform.position+new Vector3(0.0f,0.0f,iniz);
			gameObject.transform.rotation = Quaternion.Euler (new Vector3 (0,0,0));
			break;
		case "L":	position=transform.position-new Vector3(inix,0.0f,0.0f);
			gameObject.transform.rotation = Quaternion.Euler (new Vector3 (0,-90,0));
			break;
		case "R":	position=transform.position+new Vector3(inix,0.0f,0.0f);
			gameObject.transform.rotation = Quaternion.Euler (new Vector3 (0,90,0));
			break;
		default:	break;
		}
	}

	void OnCollisionEnter(Collision colision){
		if (_Path[destiny]=="U"){
			position=transform.position-new Vector3(0.0f,0.0f,0.3f);
		}
		if(_Path[destiny]=="L"){
			position=transform.position+new Vector3(0.3f,0.0f,0.0f);
		}
		while(transform.position != position)
			transform.position = Vector3.MoveTowards (transform.position, position, 0.03f);
	}

	public void setPath(string[] Path){
		_Path = Path;
	}
}
