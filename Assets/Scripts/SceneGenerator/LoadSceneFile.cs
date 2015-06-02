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
                    // Alfombra
                    case "g_050":
                        auxRow.Add(1050);
                        break;
                    case "g_051":
                        auxRow.Add(1051);
                        break;
                    case "g_052":
                        auxRow.Add(1052);
                        break;
                    // Armario 1
                    case "g_053":
                        auxRow.Add(1053);
                        break;
                    case "g_054":
                        auxRow.Add(1054);
                        break;
                    case "g_055":
                        auxRow.Add(1055);
                        break;
                    case "g_056":
                        auxRow.Add(1056);
                        break;
                    // Armario 2
                    case "g_057":
                        auxRow.Add(1057);
                        break;
                    case "g_058":
                        auxRow.Add(1058);
                        break;
                    case "g_059":
                        auxRow.Add(1059);
                        break;
                    case "g_060":
                        auxRow.Add(1060);
                        break;
                    // Boli
                    case "g_061":
                        auxRow.Add(1061);
                        break;
                    // Cajones
                    case "g_062":
                        auxRow.Add(1062);
                        break;
                    case "g_063":
                        auxRow.Add(1063);
                        break;
                    case "g_064":
                        auxRow.Add(1064);
                        break;
                    case "g_065":
                        auxRow.Add(1065);
                        break;
                    // Cama niños
                    case "g_066":
                        auxRow.Add(1066);
                        break;
                    case "g_067":
                        auxRow.Add(1067);
                        break;
                    case "g_068":
                        auxRow.Add(1068);
                        break;
                    case "g_069":
                        auxRow.Add(1069);
                        break;
                    case "g_070":
                        auxRow.Add(1070);
                        break;
                    // Cama padres
                    case "g_071":
                        auxRow.Add(1071);
                        break;
                    case "g_072":
                        auxRow.Add(1072);
                        break;
                    case "g_073":
                        auxRow.Add(1073);
                        break;
                    case "g_074":
                        auxRow.Add(1074);
                        break;
                    case "g_075":
                        auxRow.Add(1075);
                        break;
                    // Cojin
                    case "g_076":
                        auxRow.Add(1076);
                        break;
                    case "g_077":
                        auxRow.Add(1077);
                        break;
                    // Cuna
                    case "g_078":
                        auxRow.Add(1078);
                        break;
                    case "g_079":
                        auxRow.Add(1079);
                        break;
                    case "g_080":
                        auxRow.Add(1080);
                        break;
                    case "g_081":
                        auxRow.Add(1081);
                        break;
                    // Despertador
                    case "g_082":
                        auxRow.Add(1082);
                        break;
                    case "g_083":
                        auxRow.Add(1083);
                        break;
                    case "g_084":
                        auxRow.Add(1084);
                        break;
                    case "g_085":
                        auxRow.Add(1085);
                        break;
                    // iPod
                    case "g_086":
                        auxRow.Add(1086);
                        break;
                    case "g_087":
                        auxRow.Add(1087);
                        break;
                    case "g_088":
                        auxRow.Add(1088);
                        break;
                    case "g_089":
                        auxRow.Add(1089);
                        break;
                    // Lampara2
                    case "g_090":
                        auxRow.Add(1090);
                        break;
                    // LamparaSuelo
                    case "g_091":
                        auxRow.Add(1091);
                        break;
                    // Estanteria
                    case "g_092":
                        auxRow.Add(1092);
                        break;
                    case "g_093":
                        auxRow.Add(1093);
                        break;
                    // Libro
                    case "g_094":
                        auxRow.Add(1094);
                        break;
                    case "g_095":
                        auxRow.Add(1095);
                        break;
                    // mesaEstudio
                    case "g_096":
                        auxRow.Add(1096);
                        break;
                    case "g_097":
                        auxRow.Add(1097);
                        break;
                    case "g_098":
                        auxRow.Add(1098);
                        break;
                    case "g_099":
                        auxRow.Add(1099);
                        break;
                    case "g_100":
                        auxRow.Add(1100);
                        break;
                    // mesita
                    case "g_101":
                        auxRow.Add(1101);
                        break;
                    case "g_102":
                        auxRow.Add(1102);
                        break;
                    case "g_103":
                        auxRow.Add(1103);
                        break;
                    case "g_104":
                        auxRow.Add(1104);
                        break;
                    // organo
                    case "g_105":
                        auxRow.Add(1105);
                        break;
                    case "g_106":
                        auxRow.Add(1106);
                        break;
                    case "g_107":
                        auxRow.Add(1107);
                        break;
                    case "g_108":
                        auxRow.Add(1108);
                        break;
                    case "g_109":
                        auxRow.Add(1109);
                        break;
                    // tele
                    case "g_110":
                        auxRow.Add(1110);
                        break;
                    case "g_111":
                        auxRow.Add(1111);
                        break;
                    case "g_112":
                        auxRow.Add(1112);
                        break;
                    case "g_113":
                        auxRow.Add(1113);
                        break;
                    // portatil
                    case "g_114":
                        auxRow.Add(1114);
                        break;
                    case "g_115":
                        auxRow.Add(1115);
                        break;
                    case "g_116":
                        auxRow.Add(1116);
                        break;
                    case "g_117":
                        auxRow.Add(1117);
                        break;
                    // silla2
                    case "g_118":
                        auxRow.Add(1118);
                        break;
                    case "g_119":
                        auxRow.Add(1119);
                        break;
                    case "g_120":
                        auxRow.Add(1120);
                        break;
                    case "g_121":
                        auxRow.Add(1121);
                        break;
                    /////////////////////////////////////////
					//Paredes vacias
                    // Tipo 1
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
                    // Tipo 2
                    case "w_031":
                        auxRow.Add(2031);
                        break;
                    case "w_032":
                        auxRow.Add(2032);
                        break;
                    case "w_033":
                        auxRow.Add(2033);
                        break;
                    case "w_034":
                        auxRow.Add(2034);
                        break;
                    // Tipo 3
                    case "w_051":
                        auxRow.Add(2051);
                        break;
                    case "w_052":
                        auxRow.Add(2052);
                        break;
                    case "w_053":
                        auxRow.Add(2053);
                        break;
                    case "w_054":
                        auxRow.Add(2054);
                        break;
                    // Tipo 4
                    case "w_071":
                        auxRow.Add(2071);
                        break;
                    case "w_072":
                        auxRow.Add(2072);
                        break;
                    case "w_073":
                        auxRow.Add(2073);
                        break;
                    case "w_074":
                        auxRow.Add(2074);
                        break;
					//Paredes esquinas
                    // Tipo 1
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
                    // Tipo 2
                    case "w_041":
                        auxRow.Add(2041);
                        break;
                    case "w_042":
                        auxRow.Add(2042);
                        break;
                    case "w_043":
                        auxRow.Add(2043);
                        break;
                    case "w_044":
                        auxRow.Add(2044);
                        break;
                    // Tipo 3
                    case "w_061":
                        auxRow.Add(2061);
                        break;
                    case "w_062":
                        auxRow.Add(2062);
                        break;
                    case "w_063":
                        auxRow.Add(2063);
                        break;
                    case "w_064":
                        auxRow.Add(2064);
                        break;
                    // Tipo 4
                    case "w_081":
                        auxRow.Add(2081);
                        break;
                    case "w_082":
                        auxRow.Add(2082);
                        break;
                    case "w_083":
                        auxRow.Add(2083);
                        break;
                    case "w_084":
                        auxRow.Add(2084);
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
                    // Enchufe
                    case "w_2301":
                        auxRow.Add(2301);
                        break;
                    case "w_2302":
                        auxRow.Add(2302);
                        break;
                    case "w_2303":
                        auxRow.Add(2303);
                        break;
                    // Interruptor
                    case "w_2304":
                        auxRow.Add(2304);
                        break;
                    case "w_2305":
                        auxRow.Add(2305);
                        break;
                    case "w_2306":
                        auxRow.Add(2306);
                        break;
                    // Radiador
                    case "w_2307":
                        auxRow.Add(2307);
                        break;
                    case "w_2308":
                        auxRow.Add(2308);
                        break;
                    case "w_2309":
                        auxRow.Add(2309);
                        break;
                    // LamparaPared
                    case "w_2310":
                        auxRow.Add(2310);
                        break;
                    case "w_2311":
                        auxRow.Add(2311);
                        break;
                    case "w_2312":
                        auxRow.Add(2312);
                        break;
                    ///////////////////////////////////////
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
