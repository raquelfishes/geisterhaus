﻿using UnityEngine;
using System.Collections;
using System;
using System.Threading;

public class GhostInteligence : GhostController {

	const float MINRADIUS=3;

	public enum Estado{ESPERANDO, CAMBIO, ASUSTANDO};
	public Estado estado;
	//public GameObject gameManager = null;
	//public Vector3 obj_position;
	double actionRadius;
	double nearHuman, nearObject;
	GameObject[] humans;
	GameObject[] ghost_objects;
	int idHuman = -1;
	int idObject= -1;

	// Use this for initialization
	void Start () {
		estado= Estado.ESPERANDO;
		humans= GameObject.FindGameObjectsWithTag("Human");
		ghost_objects= GameObject.FindGameObjectsWithTag("GhostObject");
        //_gameManager = GameObject.FindGameObjectWithTag("GameManager");
	}
	
	// Update is called once per frame
	public void update () {
		//Thread.Sleep(1500); // Comprobamos cada 1.5 segundos

		switch (estado) {
			case Estado.ESPERANDO:
				int i=0;
				actionRadius= modulo(transform.position-humans[0].transform.position);
				nearHuman=actionRadius;
				while((i<humans.Length)&&(estado==Estado.ESPERANDO)){
					actionRadius= modulo(transform.position-humans[i].transform.position);
					if(actionRadius<MINRADIUS){
						estado=Estado.ASUSTANDO;
						idHuman=i;
					}else if(actionRadius< nearHuman){
						nearHuman=actionRadius;
						idHuman=i;
					}
					i++;
				}
				if(estado==Estado.ESPERANDO){
					estado=Estado.CAMBIO;
				}
			break;

			case Estado.CAMBIO:
				nearObject= modulo(ghost_objects[0].transform.position-humans[idHuman].transform.position);
				idObject=0;
				for(int j=1;j<ghost_objects.Length;j++){
					actionRadius=modulo(ghost_objects[j].transform.position-humans[idHuman].transform.position);
					if(actionRadius<nearObject){
						nearObject=actionRadius;
						idObject=j;
					}	
				}
				if(nearObject<MINRADIUS){
					estado=Estado.ASUSTANDO;
				}else{
					//transform.position = Vector3.MoveTowards (transform.position, ghost_objects[idObject].transform.position, 0.05f);
                    _objPosition = ghost_objects[idObject].transform.position;
				}
				
			break;

			case Estado.ASUSTANDO:
				actionRadius= modulo(transform.position-humans[idHuman].transform.position);
				if(actionRadius > MINRADIUS){
					estado=Estado.ESPERANDO;
					idHuman=-1;
				}
			break;
		}
		transform.position = Vector3.MoveTowards(transform.position, _objPosition, 0.05f);
	}

	double modulo(Vector3 vector){
		return Math.Abs(Math.Sqrt (Math.Pow(vector.x,2)+Math.Pow(vector.y,2)+Math.Pow(vector.z,2)));;
	}
}
