using UnityEngine;
using System.Collections;

public class Rotar : MonoBehaviour {
	
	public Transform objetoCentroDeRotacion;
	public float rotacionPorSegundo = 75f; // En grados
	
	public float radioActual = 2f;
	public float incrementoRadioPorSegundo = 0.5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		radioActual += incrementoRadioPorSegundo * Time.deltaTime;

		transform.position = new Vector3 (objetoCentroDeRotacion.position.x, transform.position.y, objetoCentroDeRotacion.position.z);
		transform.Translate (-radioActual, 0, 0);
		
		transform.RotateAround (objetoCentroDeRotacion.position, Vector3.up, rotacionPorSegundo * Time.deltaTime);
	}
}
