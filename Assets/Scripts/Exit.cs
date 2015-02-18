using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour {
	
	public void RunAction()
	{
		Debug.Log ("Exit");
		Application.Quit ();
	}
	
}
