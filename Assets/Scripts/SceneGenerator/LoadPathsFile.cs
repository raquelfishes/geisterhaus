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

		while (!inputStream.EndOfStream) {

			inputLine = inputStream.ReadLine ();
			//Case lines which has the tiles
			string[] move = inputLine.Split (new char[] {' ','\t'});
			_Paths.Add (move);
	
		}
		inputStream.Close( ); 
		gameObject.SendMessage ("loadParameters", _nPaths);
		gameObject.SendMessage ("generateScene", _Paths);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
