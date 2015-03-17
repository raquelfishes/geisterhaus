using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class LoadPathsFile : MonoBehaviour {

	private List<string[]> _Paths = new List<string[]> ();	
	private string filename = "./Assets/FilesScenes/scene1Paths.txt";
	
	private int _nPaths;

	// Use this for initialization
	void Start () {
		StreamReader inputStream = new StreamReader(filename);

		//Case first line
		string inputLine = inputStream.ReadLine( );
		string[] numbersControl = inputLine.Split(new char[] {' ','\t'});
		_nPaths = int.Parse (numbersControl[0]);

		for(int i=0; i<_nPaths; i++){
			inputLine = inputStream.ReadLine ();
			string[] move = inputLine.Split (new char[] {' ','\t'});
			_Paths.Add (move);
		}
		inputStream.Close( ); 
		gameObject.SendMessage ("loadnPaths", _nPaths);
		gameObject.SendMessage ("loadPaths", _Paths);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
