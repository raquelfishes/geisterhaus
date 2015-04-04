using UnityEngine;
using System.Collections;

public class BackMenu : MonoBehaviour {
	
	void Start () {	}

	void Update () { }

	public void backMenu(){
		Application.LoadLevel("MainMenu");
	}
}
