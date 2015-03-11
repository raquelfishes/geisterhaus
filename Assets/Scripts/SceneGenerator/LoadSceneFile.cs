using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class LoadSceneFile : MonoBehaviour {

	private List<List<int>> _roomIds = new List<List<int>> ();	
	private string filename = "C:/Users/Raquel/Documents/master/TJ/geisterhaus/Assets/FilesScenes/scene1.txt";

	private int _nTyles;
	private int _nRows;
	private int _nCols;

	void Start () {
	//LoadSceneFile(string filename){
		StreamReader inputStream = new StreamReader(filename);
		int nLine = 0;
		while(!inputStream.EndOfStream)
		{
			string inputLine = inputStream.ReadLine( );
			if (nLine==0)
			{
				//Case first line of the file which has number of totalTiles, numberRows and numberColumns
				string[] numbersControl = inputLine.Split(new char[] {' ','\t'});
				_nTyles = int.Parse (numbersControl[0]);
				_nRows = int.Parse (numbersControl[1]);
				_nCols = int.Parse (numbersControl[2]);
				//initLists();
			}
			else if (nLine>1)
			{
				//Case lines which has the tiles
				string[] tylesIds = inputLine.Split(new char[] {' ','\t'});
				List<int> auxRow = new List<int>();
				foreach(string tyleId in tylesIds){
					switch (tyleId){
					case "g_0":
						auxRow.Add (10);
						break;
					case "g_1":
						auxRow.Add (11);
						break;
					case "g_21":
						auxRow.Add (121);
						break;
					case "g_22":
						auxRow.Add (122);
						break;
					case "g_23":
						auxRow.Add (123);
						break;
					case "w_011":
						auxRow.Add (2011);
						break;
					case "w_012":
						auxRow.Add (2012);
						break;
					case "w_013":
						auxRow.Add (2013);
						break;
					case "w_014":
						auxRow.Add (2014);
						break;
					case "w_021":
						auxRow.Add (2021);
						break;
					case "w_022":
						auxRow.Add (2022);
						break;
					case "w_023":
						auxRow.Add (2023);
						break;
					case "w_024":
						auxRow.Add (2024);
						break;
					case "w_11":
						auxRow.Add (211);
						break;
					case "w_12":
						auxRow.Add (212);
						break;
					case "d_0":
						auxRow.Add (50);
						break;
					case "d_1":
						auxRow.Add (51);
						break;
					case "null":
						auxRow.Add (-1);
						break;
					default:
						break;
					}
				}
				_roomIds.Add (auxRow);
			}
			++nLine;
			Debug.Log (inputLine);
		}	
		printList();
		inputStream.Close( ); 
		gameObject.SendMessage ("loadParameters", new Vector3(_nRows, _nCols, _nTyles));
		gameObject.SendMessage ("generateScene", _roomIds);
	}

	private void initLists(){
		_roomIds = new List<List<int>> ();
		for(int i=0;i< _nRows ;i++)
			_roomIds.Add (new List<int> ());
		
	}

	private void printList(){
		for (int i=0; i<_nRows; i++) {
			for (int j=0; j<_nCols; j++){
				//Debug.Log (_roomIds[i][j]);
			}
		}
	}
}
