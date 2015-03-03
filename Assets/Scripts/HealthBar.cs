using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

	//Apariencia de la barra de vida
	public GUIStyle healthBar;
	//Imagen de fondo
	public Texture2D imagenFondo;
	//Imagen de frente
	public Texture2D imagenFrente;
	//Energia del jugador
	public float playerEnergy=38;

	/*//Para que la energia del jugador disminuya con el tiempo
	void Update(){
		playerEnergy=playerEnergy-(Time.deltaTime*30.0f);
	}*/

	

	//Se ejecuta en cada instante del juego
	void OnGUI(){
		//Empezamos pequeño grupo de componentes (Invocamos a BeginGroup. Ponemos una nueva recta)
		GUI.BeginGroup (new Rect (10, 10, 38, 10));
		//Creamos una caja que va a contener la imagen de fondo, y se une inmediatamente al grupo de antes
		GUI.Box (new Rect(0,0,38,10),imagenFondo,healthBar);

		GUI.BeginGroup (new Rect (0, 0, playerEnergy, 10));

		GUI.Box (new Rect(0,0,38,10),imagenFrente,healthBar);

		GUI.EndGroup();
		GUI.EndGroup();
	}

	//Para reducir la vida
	void reducirVida(){
		GameObject muerte = GameObject.Find ("GameManager");

		if (playerEnergy >= 0) {
			playerEnergy -= 2.0f;//la vida se reduce 2 unidades
		}else{
			//muerte.SendMessage("killHuman");
		}
	}
}
