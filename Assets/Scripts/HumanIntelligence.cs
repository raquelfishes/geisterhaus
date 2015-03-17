using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HumanIntelligence : HumanController {

	private string _Path="DDDRRRRRRDDDLLLDDDRRRDDDRRRUUULLL";
	//private string _Path;
	public GameObject tileGroundEmpty;
	private float aumentoX;
	private float aumentoZ;
	private Vector3 position;
	private int destiny = 0;

	void Start () {
		Renderer m_renderer = tileGroundEmpty.renderer;
		aumentoX = m_renderer.bounds.size.x;
		aumentoZ = m_renderer.bounds.size.z;
		position = transform.position;
	}

	void Update () {

		bool iguales=(transform.position.x==position.x)&&(transform.position.z==position.z);
		//Debug.Log (transform.position.x+"=="+position.x+" -> "+transform.position.z+"=="+position.z+" ? "+iguales);
		if (iguales){
			pathEvaluate ();
			if (destiny<_Path.Length-1) ++destiny;
		}
		transform.position = Vector3.MoveTowards(transform.position, position, 0.03f);
		//Debug.Log (transform.position);
	}

	public void pathEvaluate(){
		switch (_Path[destiny]){
		case 'D':	position=transform.position-new Vector3(0.0f,0.0f,aumentoZ);
			break;
		case 'U':	position=transform.position+new Vector3(0.0f,0.0f,aumentoZ);
			break;
		case 'L':	position=transform.position-new Vector3(aumentoX,0.0f,0.0f);
			break;
		case 'R':	position=transform.position+new Vector3(aumentoX,0.0f,0.0f);
			break;
		default:	break;
		}
	}

	public void setPath(string Path){
		_Path = Path;
	}
}
