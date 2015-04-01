using UnityEngine;
using System.Collections;
using System;

public class GhostInteligence : GhostController {

	const float MINRADIUS=3;

	public enum Estado{ESPERANDO, CAMBIO, ASUSTANDO};
	public Estado estado;
	public double actionRadius;
	public double nearHuman, nearObject;
	public GameObject[] humans;
	public GameObject[] ghost_objects;
	public int idHuman = -1;
	public int idObject= -1;

	// Use this for initialization
	void Start () {
		estado= Estado.ESPERANDO;
		humans= GameObject.FindGameObjectsWithTag("Human");
		ghost_objects= GameObject.FindGameObjectsWithTag("GhostObject");
	}
	
	// Update is called once per frame
	void Update () {
		switch (estado) {
			case Estado.ESPERANDO:
				int i=0;
				if(humans[0]!=null)
					actionRadius= modulo(transform.position-humans[0].transform.position);
				nearHuman=actionRadius;
				idHuman=0;
				while((i<humans.Length)&&(estado==Estado.ESPERANDO)){
					if(humans[i]!=null)
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
				int numObjets=ghost_objects.Length;
				double[] distancias= new double[numObjets];
				int[] indices=new int[numObjets];

				for(int j=0;j<numObjets;j++){
					if(humans[idHuman]!=null){
						distancias[j]=modulo(ghost_objects[j].transform.position-humans[idHuman].transform.position);;
						indices[j]=j;
					}
				}

				Array.Sort(distancias,indices);

				if (indices[0] == idObject && distancias[0] < MINRADIUS){
					estado=Estado.ASUSTANDO;
				}else if (indices[0] != idObject){
					int libre=0;
					bool encontrado=false;
					while ((libre<numObjets)&& !encontrado){
					if(ghost_objects[libre].GetComponent<ObjectController>().getidGhost()!=-1 || ghost_objects[libre].GetComponent<ObjectController>().getAsignado())
							++libre;
						else 
							encontrado=true;
					}
					if (encontrado){
						setObj(ghost_objects[indices[libre]]);
						idObject = indices[libre];
					}
				}
			break;

			case Estado.ASUSTANDO:
				if(humans[idHuman]!=null)
					actionRadius= modulo(transform.position-humans[idHuman].transform.position);
				if(actionRadius > MINRADIUS){
					estado=Estado.ESPERANDO;
					idHuman=-1;
				}
			break;
		}
		transform.position = Vector3.MoveTowards(transform.position, _obj.transform.position, 0.05f);
	}

	double modulo(Vector3 vector){
		return Math.Abs(Math.Sqrt (Math.Pow(vector.x,2)+Math.Pow(vector.y,2)+Math.Pow(vector.z,2)));;
	}

	void humanDie(int indexHuman){
		if (idHuman == indexHuman)
			estado = Estado.ESPERANDO;
		else if (idHuman > indexHuman)
			--idHuman;
	}
}
