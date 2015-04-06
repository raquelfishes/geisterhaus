using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class LoadSceneFile : MonoBehaviour {

	private List<List<int>> _roomIds = new List<List<int>> ();	
	private string filename = "./Assets/FilesScenes/scene.txt";

	private int _nTyles;
	private int _nRows;
	private int _nCols;

	void Start () {
	//LoadSceneFile(string filename){
		filename = "./Assets/FilesScenes/scene" + GameObject.FindWithTag ("GameState").GetComponent<GameState> ().getNivel () + ".txt";
		_roomIds = new List<List<int>> ();
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
						//Tiles del suelo
					case "g_001":
						auxRow.Add (1001);
						break;
					case "g_002":
						auxRow.Add (1002);
						break;
					case "g_003":
						auxRow.Add (1003);
						break;
					case "g_004":
						auxRow.Add (1004);
						break;
					case "g_005":
						auxRow.Add (1005);
						break;
					case "g_006":
						auxRow.Add (1006);
						break;
					case "g_007":
						auxRow.Add (1007);
						break;
					case "g_008":
						auxRow.Add (1008);
						break;
					//Tile alfombra
					case "g_010":
						auxRow.Add (1010);
						break;
					//Jarron
					case "g_020":
						auxRow.Add (1020);
						break;
					// Mesa
					case "g_021":
						auxRow.Add (1021);
						break;
					case "g_022":
						auxRow.Add (1022);
						break;
					case "g_023":
						auxRow.Add (1023);
						break;
					// acuario
					case "g_024":
						auxRow.Add (1024);
						break;
					case "g_025":
						auxRow.Add (1025);
						break;
					case "g_026":
						auxRow.Add (1026);
						break;
					// reloj de pared
					case "g_027":
						auxRow.Add (1027);
						break;
					case "g_028":
						auxRow.Add (1028);
						break;
					case "g_029":
						auxRow.Add (1029);
						break;
					// sofa
					case "g_030":
						auxRow.Add (1030);
						break;
					case "g_031":
						auxRow.Add (1031);
						break;
					case "g_032":
						auxRow.Add (1032);
						break;
					case "g_033":
						auxRow.Add (1033);
						break;
					case "g_034":
						auxRow.Add (1034);
						break;
					// Sillon
					case "g_035":
						auxRow.Add (1035);
						break;
					case "g_036":
						auxRow.Add (1036);
						break;
					case "g_037":
						auxRow.Add (1037);
						break;
					case "g_038":
						auxRow.Add (1038);
						break;
					// Lampara
					case "g_039":
						auxRow.Add (1039);
						break;
					// Silla
					case "g_040":
						auxRow.Add (1040);
						break;
					case "g_041":
						auxRow.Add (1041);
						break;
					case "g_042":
						auxRow.Add (1042);
						break;
					case "g_043":
						auxRow.Add (1043);
						break;
					// estatuas
					case "g_044":
						auxRow.Add (1044);
						break;
					case "g_045":
						auxRow.Add (1045);
						break;
					// Chimenea
					case "g_046":
						auxRow.Add (1046);
						break;
					case "g_047":
						auxRow.Add (1047);
						break;
					case "g_048":
						auxRow.Add (1048);
						break;
					case "g_049":
						auxRow.Add (1049);
						break;
					//Paredes vacias
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
					//Paredes esquinas
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
					//Pared cuadro 1
					case "w_111":
						auxRow.Add (2111);
						break;
					case "w_112":
						auxRow.Add (2112);
						break;
					case "w_113":
						auxRow.Add (2113);
						break;
					case "w_114":
						auxRow.Add (2114);
						break;
					// Pared cuadro 2
					case "w_121":
						auxRow.Add (2121);
						break;
					case "w_122":
						auxRow.Add (2122);
						break;
					case "w_123":
						auxRow.Add (2123);
						break;
					case "w_124":
						auxRow.Add (2124);
						break;
					// Pared ventana
					case "w_211":
						auxRow.Add (2211);
						break;
					case "w_212":
						auxRow.Add (2212);
						break;
					case "w_221":
						auxRow.Add (2221);
						break;
					case "w_222":
						auxRow.Add (2222);
						break;
					case "w_231":
						auxRow.Add (2231);
						break;
					case "w_232":
						auxRow.Add (2232);
						break;
					// Puerta entrada
					case "d_01":
						auxRow.Add (501);
						break;
					case "d_02":
						auxRow.Add (502);
						break;
					case "d_03":
						auxRow.Add (503);
						break;
					case "d_04":
						auxRow.Add (504);
						break;
					// Puerta salida
					case "d_11":
						auxRow.Add (511);
						break;
					case "d_12":
						auxRow.Add (512);
						break;
					case "d_13":
						auxRow.Add (513);
						break;
					case "d_14":
						auxRow.Add (514);
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
