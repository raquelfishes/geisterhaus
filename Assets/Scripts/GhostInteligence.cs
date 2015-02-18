using UnityEngine;
using System.Collections;

public class GhostInteligence : MonoBehaviour {

	public enum Estado{ESPERANDO, CAMBIO, ASUSTANDO};
	public Estado estado;
	public GameObject gameManager = null;
	public Vector3 obj_position;
	//private bool selected=false;
	int id;

	// Use this for initialization
	void Start () {
		estado= Estado.ESPERANDO;
	}
	
	// Update is called once per frame
	void Update () {
		switch (estado) {
			case Estado.ESPERANDO:		
				
			break;
			case Estado.CAMBIO:

			break;
			case Estado.ASUSTANDO:
			
			break;
		}
	}

	public void setObjPosition(Vector3 position){
		obj_position = position;
	}
}
