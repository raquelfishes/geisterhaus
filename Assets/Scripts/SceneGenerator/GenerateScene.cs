using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenerateScene : MonoBehaviour {

	public int _nRows = 0;
	public int _nColumns = 0;
	public int _nTyles = 0;

	public int numHumans=3;
	public int numGhosts=2;

	public bool singleGhost= true;
	public bool singleHuman= true;

	private List<List<Tile>> _myRoom;
	
	public GameObject[] tileGroundEmpty;
	public GameObject[] tilesObstacles;

	public GameObject[] tilesGroundPossesseds;
	public GameObject[] tilesWallPossesseds;

	public GameObject[] tileWallEmpty;
	
	public GameObject tileDoorIn;
	public GameObject tileDoorOut;

	public GameObject gameManager;
	public GameObject gameState;
	private int gameNivel;
	
	private float aumentoX;
	private float aumentoZ;

	private int _nPaths = 0;
	private List<string[]> _Paths;

	public GUIStyle scoreBoardStyle;
	public GameObject gameOverCamara;

	public void Start(){
		Renderer m_renderer = tileGroundEmpty[0].renderer;
		aumentoX = m_renderer.bounds.size.x;
		aumentoZ = m_renderer.bounds.size.z;
		gameState = GameObject.FindWithTag ("GameState");
		gameNivel = gameState.GetComponent<GameState>().getNivel();
	}
	public void Update(){}

	private void loadParameters(Vector3 v){
		_nRows = (int)v.x;
		_nColumns = (int)v.y;
		_nTyles = (int)v.z;
	}

	private void loadnPaths(int nPaths){
		_nPaths = nPaths;
	}
	
	private void loadPaths(List<string[]> Paths){
		_Paths = Paths;
		//instantiateGameManager ();
	}
	
	private void generateScene(List<List<int>> _roomIds){
		Renderer m_renderer = tileGroundEmpty[0].renderer;
		aumentoX = m_renderer.bounds.size.x;
		aumentoZ = m_renderer.bounds.size.z;
		instantiateCharacters ();
		createRoom ();
		generateTyles (_roomIds);
		instantiateTyles ();
		//instantiateCharacters();
		instantiateGameManager();
	}
	
	private void instantiateCharacters(){
		numHumans = gameState.GetComponent<GameState> ().getNumHumans ();
		int[] lifeHumans = gameState.GetComponent<GameState> ().getLifeHumans ();
		gameObject.GetComponent<GenerateCharacters>().instantiateCharacters(numHumans,lifeHumans,numGhosts);
	}

	private void instantiateGameManager(){
		gameState = GameObject.FindWithTag ("GameState");
		GameObject go = Instantiate(gameManager,Vector3.zero,Quaternion.identity) as GameObject;
		singleGhost = (gameState.GetComponent<GameState> ().getModeGame () == 1);
		singleHuman = (gameState.GetComponent<GameState> ().getModeGame () == 2);
		go.GetComponent<GameManager>().singleGhost = singleGhost;
		go.GetComponent<GameManager>().singleHuman = singleHuman;
		go.GetComponent<GameManager> ()._nPaths = _nPaths;
		go.GetComponent<GameManager> ()._Paths = _Paths;
		go.GetComponent<GameManager> ().scoreBoardStyle = scoreBoardStyle;
		go.GetComponent<GameManager> ().camara = gameOverCamara;
	}
	
	private void createRoom(){
		_myRoom = new List<List<Tile>> ();
		for (int i=0; i< _nRows; i++) {
			_myRoom.Add (new List<Tile> ());
			for (int j=0; j<_nColumns; j++){
				_myRoom[i].Add (new Tile());
			}
		}		
	}
	
	private void generateTyles(List<List<int>> _roomIds){
		for (int i=0; i<_nRows; i++) {
			for (int j=0; j<_nColumns; j++){
				generateTyle (_roomIds[i][j],i,j);
			}
		}
	}
	
	private void generateTyle(int id,int row, int col){
		switch (id){
		//Tiles de suelo
		case 1001:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.EMPTY;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.GROUND;
			_myRoom [row] [col]._myTypeGround = 1;
			break;
		case 1002:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.EMPTY;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.GROUND;
			_myRoom [row] [col]._myTypeGround = 2;
			break;
		case 1003:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.EMPTY;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.GROUND;
			_myRoom [row] [col]._myTypeGround = 3;
			break;
		case 1004:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.EMPTY;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.GROUND;
			_myRoom [row] [col]._myTypeGround = 4;
			break;
		case 1005:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.EMPTY;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.GROUND;
			_myRoom [row] [col]._myTypeGround = 5;
			break;
		case 1006:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.EMPTY;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.GROUND;
			_myRoom [row] [col]._myTypeGround = 6;
			break;
		case 1007:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.EMPTY;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.GROUND;
			_myRoom [row] [col]._myTypeGround = 7;
			break;
		case 1008:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.EMPTY;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.GROUND;
			_myRoom [row] [col]._myTypeGround = 8;
			break;
		//Tile alfombra
		case 1010:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.EMPTY;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.GROUND;
			_myRoom [row] [col]._myTypeGround = 9;
			break;
		// Jarron
		case 1020:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.POSSESSED;
			_myRoom [row] [col]._myTypePossessed = Tile.typePossessed.VASE;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.GROUND;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			break;
		// Mesa
		case 1021:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.POSSESSED;
			_myRoom [row] [col]._myTypePossessed = Tile.typePossessed.TABLE;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.GROUND;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.F;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			_myRoom [row] [col].horizontal = true;
			break;
		case 1022:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.POSSESSED;
			_myRoom [row] [col]._myTypePossessed = Tile.typePossessed.TABLE;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.GROUND;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.L;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			_myRoom [row] [col].horizontal = false;
			break;
		case 1023:
			//We don't have to instantiate a tyle here, but we need info of typeObstacle
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.POSSESSED;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.GROUND;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			break;
		//Acuario
		case 1024:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.OBSTACLE;
			_myRoom [row] [col]._myTypeObstacle = Tile.typeObstacle.AQUARIUM;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.GROUND;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			_myRoom [row] [col].horizontal = true;
			_myRoom[row][col]._myTypeOriented = Tile.typeOriented.F;
			break;
		case 1025:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.OBSTACLE;
			_myRoom [row] [col]._myTypeObstacle = Tile.typeObstacle.AQUARIUM;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.GROUND;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			_myRoom [row] [col].horizontal = false;
			_myRoom[row][col]._myTypeOriented = Tile.typeOriented.L;
			break;
		case 1026:
			//We don't have to instantiate a tyle here, but we need info of typeObstacle
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.OBSTACLE;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.GROUND;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			break;
		//Reloj de pared
		case 1027:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.POSSESSED;
			_myRoom [row] [col]._myTypePossessed = Tile.typePossessed.CLOCK;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.F;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.GROUND;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			break;
		case 1028:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.POSSESSED;
			_myRoom [row] [col]._myTypePossessed = Tile.typePossessed.CLOCK;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.L;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.GROUND;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			break;
		case 1029:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.POSSESSED;
			_myRoom [row] [col]._myTypePossessed = Tile.typePossessed.CLOCK;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.R;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.GROUND;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			break;
		//Sofa
		case 1030:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.POSSESSED;
			_myRoom [row] [col]._myTypePossessed = Tile.typePossessed.SOFA;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.F;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.GROUND;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			break;
		case 1031:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.POSSESSED;
			_myRoom [row] [col]._myTypePossessed = Tile.typePossessed.SOFA;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.L;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.GROUND;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			break;
		case 1032:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.POSSESSED;
			_myRoom [row] [col]._myTypePossessed = Tile.typePossessed.SOFA;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.R;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.GROUND;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			break;
		case 1033:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.POSSESSED;
			_myRoom [row] [col]._myTypePossessed = Tile.typePossessed.SOFA;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.B;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.GROUND;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			break;
		case 1034:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.POSSESSED;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.GROUND;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			break;
		//Sillon
		case 1035:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.OBSTACLE;
			_myRoom [row] [col]._myTypeObstacle = Tile.typeObstacle.ARMCHAIR;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.F;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.GROUND;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			break;
		case 1036:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.OBSTACLE;
			_myRoom [row] [col]._myTypeObstacle = Tile.typeObstacle.ARMCHAIR;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.L;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.GROUND;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			break;
		case 1037:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.OBSTACLE;
			_myRoom [row] [col]._myTypeObstacle = Tile.typeObstacle.ARMCHAIR;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.R;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.GROUND;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			break;
		case 1038:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.OBSTACLE;
			_myRoom [row] [col]._myTypeObstacle = Tile.typeObstacle.ARMCHAIR;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.B;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.GROUND;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			break;
		// Lampara
		case 1039:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.POSSESSED;
			_myRoom [row] [col]._myTypePossessed = Tile.typePossessed.LIGHT;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.GROUND;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			break;
		// Silla
		case 1040:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.OBSTACLE;
			_myRoom [row] [col]._myTypeObstacle = Tile.typeObstacle.CHAIR;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.F;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.GROUND;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			break;
		case 1041:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.OBSTACLE;
			_myRoom [row] [col]._myTypeObstacle = Tile.typeObstacle.CHAIR;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.L;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.GROUND;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			break;
		case 1042:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.OBSTACLE;
			_myRoom [row] [col]._myTypeObstacle = Tile.typeObstacle.CHAIR;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.R;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.GROUND;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			break;
		case 1043:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.OBSTACLE;
			_myRoom [row] [col]._myTypeObstacle = Tile.typeObstacle.CHAIR;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.B;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.GROUND;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			break;
		// Estatuas
		case 1044:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.POSSESSED;
			_myRoom [row] [col]._myTypePossessed = Tile.typePossessed.STATUE1;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.GROUND;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			break;
		case 1045:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.POSSESSED;
			_myRoom [row] [col]._myTypePossessed = Tile.typePossessed.STATUE2;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.GROUND;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			break;
		// Chimenea
		case 1046:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.POSSESSED;
			_myRoom [row] [col]._myTypePossessed = Tile.typePossessed.FIREPLACE;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.F;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.GROUND;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			break;
		case 1047:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.POSSESSED;
			_myRoom [row] [col]._myTypePossessed = Tile.typePossessed.FIREPLACE;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.L;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.GROUND;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			break;
		case 1048:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.POSSESSED;
			_myRoom [row] [col]._myTypePossessed = Tile.typePossessed.FIREPLACE;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.R;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.GROUND;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			break;
		case 1049:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.POSSESSED;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.GROUND;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			break;
        // Alfombra
        case 1050:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.POSSESSED;
            _myRoom[row][col]._myTypePossessed = Tile.typePossessed.COVER;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            _myRoom[row][col].horizontal = true;
            _myRoom[row][col]._myTypeOriented = Tile.typeOriented.F;
            break;
        case 1051:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.POSSESSED;
            _myRoom[row][col]._myTypePossessed = Tile.typePossessed.COVER;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            _myRoom[row][col].horizontal = false;
            _myRoom[row][col]._myTypeOriented = Tile.typeOriented.L;
            break;
        case 1052:
            //We don't have to instantiate a tyle here, but we need info of typeObstacle
            _myRoom[row][col]._myTypeTile = Tile.typeTile.POSSESSED;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            break;
        // Armario 1
        case 1053:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.OBSTACLE;
            _myRoom[row][col]._myTypeObstacle = Tile.typeObstacle.WARDROBE1;
            _myRoom[row][col]._myTypeOriented = Tile.typeOriented.F;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            break;
        case 1054:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.OBSTACLE;
            _myRoom[row][col]._myTypeObstacle = Tile.typeObstacle.WARDROBE1;
            _myRoom[row][col]._myTypeOriented = Tile.typeOriented.L;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            break;
        case 1055:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.OBSTACLE;
            _myRoom[row][col]._myTypeObstacle = Tile.typeObstacle.WARDROBE1;
            _myRoom[row][col]._myTypeOriented = Tile.typeOriented.R;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            break;
        case 1056:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.OBSTACLE;
            _myRoom[row][col]._myTypeObstacle = Tile.typeObstacle.WARDROBE1;
            _myRoom[row][col]._myTypeOriented = Tile.typeOriented.B;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            break;
        // Armario 2
        case 1057:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.OBSTACLE;
            _myRoom[row][col]._myTypeObstacle = Tile.typeObstacle.WARDROBE2;
            _myRoom[row][col]._myTypeOriented = Tile.typeOriented.F;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            break;
        case 1058:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.OBSTACLE;
            _myRoom[row][col]._myTypeObstacle = Tile.typeObstacle.WARDROBE2;
            _myRoom[row][col]._myTypeOriented = Tile.typeOriented.L;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            break;
        case 1059:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.OBSTACLE;
            _myRoom[row][col]._myTypeObstacle = Tile.typeObstacle.WARDROBE2;
            _myRoom[row][col]._myTypeOriented = Tile.typeOriented.R;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            break;
        case 1060:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.OBSTACLE;
            _myRoom[row][col]._myTypeObstacle = Tile.typeObstacle.WARDROBE2;
            _myRoom[row][col]._myTypeOriented = Tile.typeOriented.B;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            break;
        // boli
        case 1061:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.OBSTACLE;
            _myRoom[row][col]._myTypeObstacle = Tile.typeObstacle.PEN;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            break;
        // Cajones
        case 1062:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.POSSESSED;
            _myRoom[row][col]._myTypePossessed = Tile.typePossessed.DRAWER1;
            _myRoom[row][col]._myTypeOriented = Tile.typeOriented.F;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            break;
        case 1063:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.POSSESSED;
            _myRoom[row][col]._myTypePossessed = Tile.typePossessed.DRAWER1;
            _myRoom[row][col]._myTypeOriented = Tile.typeOriented.L;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            break;
        case 1064:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.POSSESSED;
            _myRoom[row][col]._myTypePossessed = Tile.typePossessed.DRAWER1;
            _myRoom[row][col]._myTypeOriented = Tile.typeOriented.R;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            break;
        case 1065:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.POSSESSED;
            _myRoom[row][col]._myTypePossessed = Tile.typePossessed.DRAWER1;
            _myRoom[row][col]._myTypeOriented = Tile.typeOriented.B;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            break;
        // Cama niños
        case 1066:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.OBSTACLE;
            _myRoom[row][col]._myTypeObstacle = Tile.typeObstacle.CHILDBED;
            _myRoom[row][col]._myTypeOriented = Tile.typeOriented.F;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            break;
        case 1067:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.OBSTACLE;
            _myRoom[row][col]._myTypeObstacle = Tile.typeObstacle.CHILDBED;
            _myRoom[row][col]._myTypeOriented = Tile.typeOriented.L;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            break;
        case 1068:
             _myRoom[row][col]._myTypeTile = Tile.typeTile.OBSTACLE;
            _myRoom[row][col]._myTypeObstacle = Tile.typeObstacle.CHILDBED;
            _myRoom[row][col]._myTypeOriented = Tile.typeOriented.R;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            break;
        case 1069:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.OBSTACLE;
            _myRoom[row][col]._myTypeObstacle = Tile.typeObstacle.CHILDBED;
            _myRoom[row][col]._myTypeOriented = Tile.typeOriented.B;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            break;
        case 1070:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.OBSTACLE;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            break;
        // Cama padres
        case 1071:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.POSSESSED;
            _myRoom[row][col]._myTypePossessed = Tile.typePossessed.PARENTSBED;
            _myRoom[row][col]._myTypeOriented = Tile.typeOriented.F;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            break;
        case 1072:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.POSSESSED;
            _myRoom[row][col]._myTypePossessed = Tile.typePossessed.PARENTSBED;
            _myRoom[row][col]._myTypeOriented = Tile.typeOriented.L;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            break;
        case 1073:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.POSSESSED;
            _myRoom[row][col]._myTypePossessed = Tile.typePossessed.PARENTSBED;
            _myRoom[row][col]._myTypeOriented = Tile.typeOriented.R;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            break;
        case 1074:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.POSSESSED;
            _myRoom[row][col]._myTypePossessed = Tile.typePossessed.PARENTSBED;
            _myRoom[row][col]._myTypeOriented = Tile.typeOriented.B;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            break;
        case 1075:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.POSSESSED;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            break;
        // Cojin
        case 1076:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.POSSESSED;
            _myRoom[row][col]._myTypePossessed = Tile.typePossessed.CUSHION;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            _myRoom[row][col].horizontal = true;
            _myRoom[row][col]._myTypeOriented = Tile.typeOriented.F;
            break;
        case 1077:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.POSSESSED;
            _myRoom[row][col]._myTypePossessed = Tile.typePossessed.CUSHION;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            _myRoom[row][col].horizontal = false;
            _myRoom[row][col]._myTypeOriented = Tile.typeOriented.L;
            break;
        // Cuna
        case 1078:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.POSSESSED;
            _myRoom[row][col]._myTypePossessed = Tile.typePossessed.COT;
            _myRoom[row][col]._myTypeOriented = Tile.typeOriented.F;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            break;
        case 1079:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.POSSESSED;
            _myRoom[row][col]._myTypePossessed = Tile.typePossessed.COT;
            _myRoom[row][col]._myTypeOriented = Tile.typeOriented.L;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            break;
        case 1080:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.POSSESSED;
            _myRoom[row][col]._myTypePossessed = Tile.typePossessed.COT;
            _myRoom[row][col]._myTypeOriented = Tile.typeOriented.R;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            break;
        case 1081:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.POSSESSED;
            _myRoom[row][col]._myTypePossessed = Tile.typePossessed.COT;
            _myRoom[row][col]._myTypeOriented = Tile.typeOriented.B;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            break;
        // Despertador
        case 1082:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.OBSTACLE;
            _myRoom[row][col]._myTypeObstacle = Tile.typeObstacle.ALARM;
            _myRoom[row][col]._myTypeOriented = Tile.typeOriented.F;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            break;
        case 1083:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.OBSTACLE;
            _myRoom[row][col]._myTypeObstacle = Tile.typeObstacle.ALARM;
            _myRoom[row][col]._myTypeOriented = Tile.typeOriented.L;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            break;
        case 1084:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.OBSTACLE;
            _myRoom[row][col]._myTypeObstacle = Tile.typeObstacle.ALARM;
            _myRoom[row][col]._myTypeOriented = Tile.typeOriented.R;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            break;
        case 1085:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.OBSTACLE;
            _myRoom[row][col]._myTypeObstacle = Tile.typeObstacle.ALARM;
            _myRoom[row][col]._myTypeOriented = Tile.typeOriented.B;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            break;
        // iPod
        case 1086:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.OBSTACLE;
            _myRoom[row][col]._myTypeObstacle = Tile.typeObstacle.IPOD;
            _myRoom[row][col]._myTypeOriented = Tile.typeOriented.F;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            break;
        case 1087:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.OBSTACLE;
            _myRoom[row][col]._myTypeObstacle = Tile.typeObstacle.IPOD;
            _myRoom[row][col]._myTypeOriented = Tile.typeOriented.L;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            break;
        case 1088:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.OBSTACLE;
            _myRoom[row][col]._myTypeObstacle = Tile.typeObstacle.IPOD;
            _myRoom[row][col]._myTypeOriented = Tile.typeOriented.R;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            break;
        case 1089:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.OBSTACLE;
            _myRoom[row][col]._myTypeObstacle = Tile.typeObstacle.IPOD;
            _myRoom[row][col]._myTypeOriented = Tile.typeOriented.B;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            break;
        // lampara2
        case 1090:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.OBSTACLE;
            _myRoom[row][col]._myTypeObstacle = Tile.typeObstacle.LAMP1;
            _myRoom[row][col]._myTypeOriented = Tile.typeOriented.F;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            break;
        // lamparaSuelo
        case 1091:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.POSSESSED;
            _myRoom[row][col]._myTypePossessed = Tile.typePossessed.LAMP2;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            _myRoom[row][col].horizontal = true;
            _myRoom[row][col]._myTypeOriented = Tile.typeOriented.F;
            break;
        // Estanteria
        case 1092:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.POSSESSED;
            _myRoom[row][col]._myTypePossessed = Tile.typePossessed.SHELVES;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            _myRoom[row][col].horizontal = true;
            _myRoom[row][col]._myTypeOriented = Tile.typeOriented.F;
            break;
        case 1093:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.POSSESSED;
            _myRoom[row][col]._myTypePossessed = Tile.typePossessed.SHELVES;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            _myRoom[row][col].horizontal = false;
            _myRoom[row][col]._myTypeOriented = Tile.typeOriented.L;
            break;
        // libro
        case 1094:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.POSSESSED;
            _myRoom[row][col]._myTypePossessed = Tile.typePossessed.BOOK;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            _myRoom[row][col].horizontal = true;
            _myRoom[row][col]._myTypeOriented = Tile.typeOriented.F;            
            break;
        case 1095:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.POSSESSED;
            _myRoom[row][col]._myTypePossessed = Tile.typePossessed.BOOK;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            _myRoom[row][col].horizontal = false;
            _myRoom[row][col]._myTypeOriented = Tile.typeOriented.L;
            break;
        // mesaEstudio
        case 1096:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.POSSESSED;
            _myRoom[row][col]._myTypePossessed = Tile.typePossessed.PARENTSBED;
            _myRoom[row][col]._myTypeOriented = Tile.typeOriented.F;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            break;
        case 1097:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.POSSESSED;
            _myRoom[row][col]._myTypePossessed = Tile.typePossessed.STUDYTABLE;
            _myRoom[row][col]._myTypeOriented = Tile.typeOriented.L;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            break;
        case 1098:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.POSSESSED;
            _myRoom[row][col]._myTypePossessed = Tile.typePossessed.STUDYTABLE;
            _myRoom[row][col]._myTypeOriented = Tile.typeOriented.R;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            break;
        case 1099:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.POSSESSED;
            _myRoom[row][col]._myTypePossessed = Tile.typePossessed.STUDYTABLE;
            _myRoom[row][col]._myTypeOriented = Tile.typeOriented.B;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            break;
        case 1100:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.POSSESSED;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            break;
        // mesita
        case 1101:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.POSSESSED;
            _myRoom[row][col]._myTypePossessed = Tile.typePossessed.NIGHTTABLE;
            _myRoom[row][col]._myTypeOriented = Tile.typeOriented.F;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            break;
        case 1102:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.POSSESSED;
            _myRoom[row][col]._myTypePossessed = Tile.typePossessed.NIGHTTABLE;
            _myRoom[row][col]._myTypeOriented = Tile.typeOriented.L;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            break;
        case 1103:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.POSSESSED;
            _myRoom[row][col]._myTypePossessed = Tile.typePossessed.NIGHTTABLE;
            _myRoom[row][col]._myTypeOriented = Tile.typeOriented.R;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            break;
        case 1104:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.POSSESSED;
            _myRoom[row][col]._myTypePossessed = Tile.typePossessed.NIGHTTABLE;
            _myRoom[row][col]._myTypeOriented = Tile.typeOriented.B;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            break;
        // organo
        case 1105:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.POSSESSED;
            _myRoom[row][col]._myTypePossessed = Tile.typePossessed.ORGAN;
            _myRoom[row][col]._myTypeOriented = Tile.typeOriented.F;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            break;
        case 1106:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.POSSESSED;
            _myRoom[row][col]._myTypePossessed = Tile.typePossessed.ORGAN;
            _myRoom[row][col]._myTypeOriented = Tile.typeOriented.L;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            break;
        case 1107:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.POSSESSED;
            _myRoom[row][col]._myTypePossessed = Tile.typePossessed.ORGAN;
            _myRoom[row][col]._myTypeOriented = Tile.typeOriented.R;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            break;
        case 1108:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.POSSESSED;
            _myRoom[row][col]._myTypePossessed = Tile.typePossessed.ORGAN;
            _myRoom[row][col]._myTypeOriented = Tile.typeOriented.B;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            break;
        case 1109:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.POSSESSED;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            break;
        // Tele
        case 1110:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.OBSTACLE;
            _myRoom[row][col]._myTypeObstacle = Tile.typeObstacle.TV;
            _myRoom[row][col]._myTypeOriented = Tile.typeOriented.F;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            break;
        case 1111:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.OBSTACLE;
            _myRoom[row][col]._myTypeObstacle = Tile.typeObstacle.TV;
            _myRoom[row][col]._myTypeOriented = Tile.typeOriented.L;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            break;
        case 1112:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.OBSTACLE;
            _myRoom[row][col]._myTypeObstacle = Tile.typeObstacle.TV;
            _myRoom[row][col]._myTypeOriented = Tile.typeOriented.R;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            break;
        case 1113:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.OBSTACLE;
            _myRoom[row][col]._myTypeObstacle = Tile.typeObstacle.TV;
            _myRoom[row][col]._myTypeOriented = Tile.typeOriented.B;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            break;
        // Portatil
        case 1114:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.POSSESSED;
            _myRoom[row][col]._myTypePossessed = Tile.typePossessed.PC;
            _myRoom[row][col]._myTypeOriented = Tile.typeOriented.F;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            break;
        case 1115:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.POSSESSED;
            _myRoom[row][col]._myTypePossessed = Tile.typePossessed.PC;
            _myRoom[row][col]._myTypeOriented = Tile.typeOriented.L;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            break;
        case 1116:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.POSSESSED;
            _myRoom[row][col]._myTypePossessed = Tile.typePossessed.PC;
            _myRoom[row][col]._myTypeOriented = Tile.typeOriented.R;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            break;
        case 1117:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.POSSESSED;
            _myRoom[row][col]._myTypePossessed = Tile.typePossessed.PC;
            _myRoom[row][col]._myTypeOriented = Tile.typeOriented.B;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            break;
        // Silla
        case 1118:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.POSSESSED;
            _myRoom[row][col]._myTypePossessed = Tile.typePossessed.CHAIR2;
            _myRoom[row][col]._myTypeOriented = Tile.typeOriented.F;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            break;
        case 1119:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.POSSESSED;
            _myRoom[row][col]._myTypePossessed = Tile.typePossessed.CHAIR2;
            _myRoom[row][col]._myTypeOriented = Tile.typeOriented.L;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            break;
        case 1120:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.POSSESSED;
            _myRoom[row][col]._myTypePossessed = Tile.typePossessed.CHAIR2;
            _myRoom[row][col]._myTypeOriented = Tile.typeOriented.R;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            break;
        case 1121:
            _myRoom[row][col]._myTypeTile = Tile.typeTile.POSSESSED;
            _myRoom[row][col]._myTypePossessed = Tile.typePossessed.CHAIR2;
            _myRoom[row][col]._myTypeOriented = Tile.typeOriented.B;
            _myRoom[row][col]._myTypeEmpty = Tile.typeEmpty.GROUND;
            _myRoom[row][col]._myTypeGround = gameNivel;
            break;
		////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		// Paredes
		// Paredes vacias
        // Tipo1
		case 2011:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.EMPTY;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.WALL;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.F;
			_myRoom [row] [col]._myTypeGround = gameNivel;
            _myRoom[row][col]._myTypeWall = 1;
			break;
		case 2012:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.EMPTY;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.WALL;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.L;
			_myRoom [row] [col]._myTypeGround = gameNivel;
            _myRoom[row][col]._myTypeWall = 1;
			break;
		case 2013:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.EMPTY;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.WALL;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.R;
			_myRoom [row] [col]._myTypeGround = gameNivel;
            _myRoom[row][col]._myTypeWall = 1;
			break;
		case 2014:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.EMPTY;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.WALL;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.B;
			_myRoom [row] [col]._myTypeGround = gameNivel;
            _myRoom[row][col]._myTypeWall = 1;
			break;
			// Tipo2
		case 2031:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.EMPTY;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.WALL;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.F;
			_myRoom [row] [col]._myTypeGround = gameNivel;
            _myRoom[row][col]._myTypeWall = 2;
			break;
		case 2032:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.EMPTY;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.WALL;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.L;
			_myRoom [row] [col]._myTypeGround = gameNivel;
            _myRoom[row][col]._myTypeWall = 2;
			break;
		case 2033:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.EMPTY;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.WALL;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.R;
			_myRoom [row] [col]._myTypeGround = gameNivel;
            _myRoom[row][col]._myTypeWall = 2;
			break;
		case 2034:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.EMPTY;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.WALL;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.B;
			_myRoom [row] [col]._myTypeGround = gameNivel;
            _myRoom[row][col]._myTypeWall = 2;
			break;
			// Tipo3
		case 2051:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.EMPTY;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.WALL;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.F;
			_myRoom [row] [col]._myTypeGround = gameNivel;
            _myRoom[row][col]._myTypeWall = 3;
			break;
		case 2052:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.EMPTY;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.WALL;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.L;
			_myRoom [row] [col]._myTypeGround = gameNivel;
            _myRoom[row][col]._myTypeWall = 3;
			break;
		case 2053:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.EMPTY;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.WALL;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.R;
			_myRoom [row] [col]._myTypeGround = gameNivel;
            _myRoom[row][col]._myTypeWall = 3;
			break;
		case 2054:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.EMPTY;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.WALL;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.B;
			_myRoom [row] [col]._myTypeGround = gameNivel;
            _myRoom[row][col]._myTypeWall = 3;
			break;
			// Tipo4
		case 2071:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.EMPTY;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.WALL;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.F;
			_myRoom [row] [col]._myTypeGround = gameNivel;
            _myRoom[row][col]._myTypeWall = 4;
			break;
		case 2072:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.EMPTY;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.WALL;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.L;
			_myRoom [row] [col]._myTypeGround = gameNivel;
            _myRoom[row][col]._myTypeWall = 4;
			break;
		case 2073:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.EMPTY;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.WALL;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.R;
			_myRoom [row] [col]._myTypeGround = gameNivel;
            _myRoom[row][col]._myTypeWall = 4;
			break;
		case 2074:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.EMPTY;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.WALL;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.B;
			_myRoom [row] [col]._myTypeGround = gameNivel;
            _myRoom[row][col]._myTypeWall = 4;
			break;
		// Paredes esquinas
		// Tipo 1
		case 2021:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.EMPTY;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.CORNER;
			_myRoom [row] [col]._myTypeCorner = Tile.typeCorner.LF;
			_myRoom [row] [col].esquina = true;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			_myRoom[row][col]._myTypeWall = 1;
			break;
		case 2022:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.EMPTY;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.CORNER;
			_myRoom [row] [col]._myTypeCorner = Tile.typeCorner.RF;
			_myRoom [row] [col].esquina = true;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			_myRoom[row][col]._myTypeWall = 1;
			break;
		case 2023:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.EMPTY;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.CORNER;
			_myRoom [row] [col]._myTypeCorner = Tile.typeCorner.LB;
			_myRoom [row] [col].esquina = true;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			_myRoom[row][col]._myTypeWall = 1;
			break;
		case 2024:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.EMPTY;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.CORNER;
			_myRoom [row] [col]._myTypeCorner = Tile.typeCorner.RB;
			_myRoom [row] [col].esquina = true;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			_myRoom[row][col]._myTypeWall = 1;
			break;
			// Tipo 2
		case 2041:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.EMPTY;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.CORNER;
			_myRoom [row] [col]._myTypeCorner = Tile.typeCorner.LF;
			_myRoom [row] [col].esquina = true;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			_myRoom[row][col]._myTypeWall = 2;

			break;
		case 2042:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.EMPTY;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.CORNER;
			_myRoom [row] [col]._myTypeCorner = Tile.typeCorner.RF;
			_myRoom [row] [col].esquina = true;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			_myRoom[row][col]._myTypeWall = 2;
			break;
		case 2043:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.EMPTY;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.CORNER;
			_myRoom [row] [col]._myTypeCorner = Tile.typeCorner.LB;
			_myRoom [row] [col].esquina = true;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			_myRoom[row][col]._myTypeWall = 2;
			break;
		case 2044:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.EMPTY;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.CORNER;
			_myRoom [row] [col]._myTypeCorner = Tile.typeCorner.RB;
			_myRoom [row] [col].esquina = true;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			_myRoom[row][col]._myTypeWall = 2;
			break;
			// Tipo 3
		case 2061:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.EMPTY;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.CORNER;
			_myRoom [row] [col]._myTypeCorner = Tile.typeCorner.LF;
			_myRoom [row] [col].esquina = true;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			_myRoom[row][col]._myTypeWall = 3;
			break;
		case 2062:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.EMPTY;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.CORNER;
			_myRoom [row] [col]._myTypeCorner = Tile.typeCorner.RF;
			_myRoom [row] [col].esquina = true;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			_myRoom[row][col]._myTypeWall = 3;
			break;
		case 2063:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.EMPTY;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.CORNER;
			_myRoom [row] [col]._myTypeCorner = Tile.typeCorner.LB;
			_myRoom [row] [col].esquina = true;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			_myRoom[row][col]._myTypeWall = 3;
			break;
		case 2064:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.EMPTY;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.CORNER;
			_myRoom [row] [col]._myTypeCorner = Tile.typeCorner.RB;
			_myRoom [row] [col].esquina = true;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			_myRoom[row][col]._myTypeWall = 3;
			break;
			// Tipo 4
		case 2081:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.EMPTY;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.CORNER;
			_myRoom [row] [col]._myTypeCorner = Tile.typeCorner.LF;
			_myRoom [row] [col].esquina = true;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			_myRoom[row][col]._myTypeWall = 4;
			break;
		case 2082:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.EMPTY;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.CORNER;
			_myRoom [row] [col]._myTypeCorner = Tile.typeCorner.RF;
			_myRoom [row] [col].esquina = true;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			_myRoom[row][col]._myTypeWall = 4;
			break;
		case 2083:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.EMPTY;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.CORNER;
			_myRoom [row] [col]._myTypeCorner = Tile.typeCorner.LB;
			_myRoom [row] [col].esquina = true;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			_myRoom[row][col]._myTypeWall = 4;
			break;
		case 2084:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.EMPTY;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.CORNER;
			_myRoom [row] [col]._myTypeCorner = Tile.typeCorner.RB;
			_myRoom [row] [col].esquina = true;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			_myRoom[row][col]._myTypeWall = 4;
			break;
		// cuadro 1
		case 2111:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.POSSESSED;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.WALL;
			_myRoom [row] [col]._myTypePossessed = Tile.typePossessed.CANVAS1;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.F;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			_myRoom [row] [col]._myTypeWall = gameNivel;
			break;
		case 2112:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.POSSESSED;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.WALL;
			_myRoom [row] [col]._myTypePossessed = Tile.typePossessed.CANVAS1;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.L;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			_myRoom [row] [col]._myTypeWall = gameNivel;
			break;
		case 2113:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.POSSESSED;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.WALL;
			_myRoom [row] [col]._myTypePossessed = Tile.typePossessed.CANVAS1;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.R;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			_myRoom [row] [col]._myTypeWall = gameNivel;
			break;
		case 2114:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.POSSESSED;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.WALL;
			_myRoom [row] [col]._myTypePossessed = Tile.typePossessed.CANVAS1;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.B;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			_myRoom [row] [col]._myTypeWall = gameNivel;
			break;
		// cuadro 2
		case 2121:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.POSSESSED;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.WALL;
			_myRoom [row] [col]._myTypePossessed = Tile.typePossessed.CANVAS2;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.F;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			_myRoom [row] [col]._myTypeWall = gameNivel;
			break;
		case 2122:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.POSSESSED;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.WALL;
			_myRoom [row] [col]._myTypePossessed = Tile.typePossessed.CANVAS2;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.L;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			_myRoom [row] [col]._myTypeWall = gameNivel;
			break;
		case 2123:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.POSSESSED;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.WALL;
			_myRoom [row] [col]._myTypePossessed = Tile.typePossessed.CANVAS2;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.R;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			_myRoom [row] [col]._myTypeWall = gameNivel;
			break;
		case 2124:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.POSSESSED;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.WALL;
			_myRoom [row] [col]._myTypePossessed = Tile.typePossessed.CANVAS2;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.B;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			_myRoom [row] [col]._myTypeWall = gameNivel;
			break;
		// Ventana
		case 2211:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.POSSESSED;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.WALL;
			_myRoom [row] [col]._myTypePossessed = Tile.typePossessed.WINDOW;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.F;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			_myRoom [row] [col]._myTypeWall = gameNivel;
			break;
		case 2212:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.POSSESSED;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.WALL;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.F;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			_myRoom [row] [col]._myTypeWall = gameNivel;
			break;
		case 2221:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.POSSESSED;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.WALL;
			_myRoom [row] [col]._myTypePossessed = Tile.typePossessed.WINDOW;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.L;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			_myRoom [row] [col]._myTypeWall = gameNivel;
			break;
		case 2222:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.POSSESSED;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.WALL;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.L;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			_myRoom [row] [col]._myTypeWall = gameNivel;
			break;
		case 2231:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.POSSESSED;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.WALL;
			_myRoom [row] [col]._myTypePossessed = Tile.typePossessed.WINDOW;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.R;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			_myRoom [row] [col]._myTypeWall = gameNivel;
			break;
		case 2132:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.POSSESSED;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.WALL;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.R;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			_myRoom [row] [col]._myTypeWall = gameNivel;
			break;
		// ENCHUFE
		case 2301:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.POSSESSED;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.WALL;
			_myRoom [row] [col]._myTypePossessed = Tile.typePossessed.SOCKET;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.F;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			_myRoom [row] [col]._myTypeWall = gameNivel;
			break;
		case 2302:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.POSSESSED;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.WALL;
			_myRoom [row] [col]._myTypePossessed = Tile.typePossessed.SOCKET;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.L;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			_myRoom [row] [col]._myTypeWall = gameNivel;
			break;
		case 2303:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.POSSESSED;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.WALL;
			_myRoom [row] [col]._myTypePossessed = Tile.typePossessed.SOCKET;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.R;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			_myRoom [row] [col]._myTypeWall = gameNivel;
			break;
		// iNTERRUPTOR
		case 2304:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.POSSESSED;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.WALL;
			_myRoom [row] [col]._myTypePossessed = Tile.typePossessed.SWITCH;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.F;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			_myRoom [row] [col]._myTypeWall = gameNivel;
			break;
		case 2305:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.POSSESSED;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.WALL;
			_myRoom [row] [col]._myTypePossessed = Tile.typePossessed.SWITCH;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.L;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			_myRoom [row] [col]._myTypeWall = gameNivel;
			break;
		case 2306:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.POSSESSED;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.WALL;
			_myRoom [row] [col]._myTypePossessed = Tile.typePossessed.SWITCH;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.R;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			_myRoom [row] [col]._myTypeWall = gameNivel;
			break;
		// RADIADOR
		case 2307:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.POSSESSED;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.WALL;
			_myRoom [row] [col]._myTypePossessed = Tile.typePossessed.RADIATOR;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.F;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			_myRoom [row] [col]._myTypeWall = gameNivel;
			break;
		case 2308:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.POSSESSED;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.WALL;
			_myRoom [row] [col]._myTypePossessed = Tile.typePossessed.RADIATOR;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.L;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			_myRoom [row] [col]._myTypeWall = gameNivel;
			break;
		case 2309:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.POSSESSED;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.WALL;
			_myRoom [row] [col]._myTypePossessed = Tile.typePossessed.RADIATOR;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.R;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			_myRoom [row] [col]._myTypeWall = gameNivel;
			break;
		// lamparaPared
		case 2310:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.POSSESSED;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.WALL;
			_myRoom [row] [col]._myTypePossessed = Tile.typePossessed.LAMP3;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.F;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			_myRoom [row] [col]._myTypeWall = gameNivel;
			break;
		case 2311:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.POSSESSED;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.WALL;
			_myRoom [row] [col]._myTypePossessed = Tile.typePossessed.LAMP3;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.L;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			_myRoom [row] [col]._myTypeWall = gameNivel;
			break;
		case 2312:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.POSSESSED;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.WALL;
			_myRoom [row] [col]._myTypePossessed = Tile.typePossessed.LAMP3;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.R;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			_myRoom [row] [col]._myTypeWall = gameNivel;
			break;
		//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		// Puertas
		// Puerta entrada
		case 501:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.DOOR;
			_myRoom [row] [col]._myTypeDoor = Tile.typeDoor.IN;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.F;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			break;
		case 502:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.DOOR;
			_myRoom [row] [col]._myTypeDoor = Tile.typeDoor.IN;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.L;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			break;
		case 503:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.DOOR;
			_myRoom [row] [col]._myTypeDoor = Tile.typeDoor.IN;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.R;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			break;
		case 504:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.DOOR;
			_myRoom [row] [col]._myTypeDoor = Tile.typeDoor.IN;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.B;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			break;
		// Puerta salida
		case 511:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.DOOR;
			_myRoom [row] [col]._myTypeDoor = Tile.typeDoor.OUT;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.F;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			break;
		case 512:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.DOOR;
			_myRoom [row] [col]._myTypeDoor = Tile.typeDoor.OUT;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.L;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			break;
		case 513:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.DOOR;
			_myRoom [row] [col]._myTypeDoor = Tile.typeDoor.OUT;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.R;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			break;
		case 514:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.DOOR;
			_myRoom [row] [col]._myTypeDoor = Tile.typeDoor.OUT;
			_myRoom [row] [col]._myTypeOriented = Tile.typeOriented.B;
			_myRoom [row] [col]._myTypeGround = gameNivel;
			break;
		default:
			break;
		}
	}

	private Quaternion getOrientation(Tile.typeOriented orient){
		Quaternion quater = Quaternion.identity;
		switch (orient) {
			case Tile.typeOriented.F:
				quater = Quaternion.identity;
				break;
			case Tile.typeOriented.B:
				quater = Quaternion.Euler(new Vector3(0,180,0));
				break;
			case Tile.typeOriented.R:
				quater = Quaternion.Euler(new Vector3(0,90,0));
				break;
			case Tile.typeOriented.L:
				quater = Quaternion.Euler(new Vector3(0,-90,0));
				break;
		}
		return quater;
	}
	
	private void instantiateObstacle(Tile t, Vector3 position){
		GameObject go;
		Quaternion quater;
		switch (t._myTypeObstacle) {
			case Tile.typeObstacle.CHAIR:
				quater = getOrientation(t._myTypeOriented);
				go=Instantiate(tilesObstacles[0],position,quater) as GameObject;
				break;
			case Tile.typeObstacle.ARMCHAIR:
				quater = getOrientation(t._myTypeOriented);
				go=Instantiate(tilesObstacles[1],position,quater) as GameObject;
				break;
			case Tile.typeObstacle.AQUARIUM:
				quater = getOrientation(t._myTypeOriented);
				go=Instantiate(tilesObstacles[2],position,quater) as GameObject;
				break;
            case Tile.typeObstacle.WARDROBE1:
                quater = getOrientation(t._myTypeOriented);
                go = Instantiate(tilesObstacles[3], position, quater) as GameObject;
                break;
            case Tile.typeObstacle.WARDROBE2:
                quater = getOrientation(t._myTypeOriented);
                go = Instantiate(tilesObstacles[4], position, quater) as GameObject;
                break;
            case Tile.typeObstacle.PEN:
                go = Instantiate(tilesObstacles[5], position, Quaternion.identity) as GameObject;
                break;
            case Tile.typeObstacle.CHILDBED:
                quater = getOrientation(t._myTypeOriented);
                go = Instantiate(tilesObstacles[6], position, quater) as GameObject;
                break;
            case Tile.typeObstacle.ALARM:
                quater = getOrientation(t._myTypeOriented);
                go = Instantiate(tilesObstacles[7], position, quater) as GameObject;
                break;
            case Tile.typeObstacle.IPOD:
                quater = getOrientation(t._myTypeOriented);
                go = Instantiate(tilesObstacles[8], position, quater) as GameObject;
                break;
            case Tile.typeObstacle.LAMP1:
                go = Instantiate(tilesObstacles[9], position, Quaternion.identity) as GameObject;
                break;
            case Tile.typeObstacle.TV:
                quater = getOrientation(t._myTypeOriented);
                go = Instantiate(tilesObstacles[10], position, quater) as GameObject;
                break;
		}
	}
	
	private void instantiatePossessedGround(Tile t, Vector3 position, Quaternion q){
		GameObject go;
		Quaternion quater;
		switch (t._myTypePossessed) {
			case Tile.typePossessed.VASE:
				go=Instantiate(tilesGroundPossesseds[0],position,Quaternion.identity) as GameObject;
				break;
			case Tile.typePossessed.CLOCK:
				quater = getOrientation(t._myTypeOriented);
				go=Instantiate(tilesGroundPossesseds[1],position,quater) as GameObject;
				break;
			case Tile.typePossessed.TABLE:
				quater = getOrientation(t._myTypeOriented);
				go=Instantiate(tilesGroundPossesseds[2],position,quater) as GameObject;
				break;
			case Tile.typePossessed.SOFA:
				quater = getOrientation(t._myTypeOriented);
				go=Instantiate(tilesGroundPossesseds[3],position,quater) as GameObject;
				break;
			case Tile.typePossessed.LIGHT:
				go=Instantiate(tilesGroundPossesseds[4],position,Quaternion.identity) as GameObject;
				break;
			case Tile.typePossessed.STATUE1:
				go=Instantiate(tilesGroundPossesseds[5],position,Quaternion.identity) as GameObject;
				break;
			case Tile.typePossessed.STATUE2:
				go=Instantiate(tilesGroundPossesseds[6],position,Quaternion.identity) as GameObject;
				break;
			case Tile.typePossessed.FIREPLACE:
				quater = getOrientation(t._myTypeOriented);
				go=Instantiate(tilesGroundPossesseds[7],position,quater) as GameObject;
				break;
            case Tile.typePossessed.COVER:
                quater = getOrientation(t._myTypeOriented);
                go = Instantiate(tilesGroundPossesseds[8], position, quater) as GameObject;
                break;
            case Tile.typePossessed.DRAWER1:
                quater = getOrientation(t._myTypeOriented);
                go = Instantiate(tilesGroundPossesseds[9], position, quater) as GameObject;
                break;
            case Tile.typePossessed.PARENTSBED:
                quater = getOrientation(t._myTypeOriented);
                go = Instantiate(tilesGroundPossesseds[10], position, quater) as GameObject;
                break;
            case Tile.typePossessed.CUSHION:
                quater = getOrientation(t._myTypeOriented);
                go = Instantiate(tilesGroundPossesseds[11], position, quater) as GameObject;
                break;
            case Tile.typePossessed.COT:
                quater = getOrientation(t._myTypeOriented);
                go = Instantiate(tilesGroundPossesseds[12], position, quater) as GameObject;
                break;
            case Tile.typePossessed.LAMP2:
                go = Instantiate(tilesGroundPossesseds[13], position, Quaternion.identity) as GameObject;
                break;
            case Tile.typePossessed.SHELVES:
                quater = getOrientation(t._myTypeOriented);
                go = Instantiate(tilesGroundPossesseds[14], position, quater) as GameObject;
                break;
            case Tile.typePossessed.BOOK:
                quater = getOrientation(t._myTypeOriented);
                go = Instantiate(tilesGroundPossesseds[15], position, quater) as GameObject;
                break;
            case Tile.typePossessed.STUDYTABLE:
                quater = getOrientation(t._myTypeOriented);
                go = Instantiate(tilesGroundPossesseds[16], position, quater) as GameObject;
                break;
            case Tile.typePossessed.NIGHTTABLE:
                quater = getOrientation(t._myTypeOriented);
                go = Instantiate(tilesGroundPossesseds[17], position, quater) as GameObject;
                break;
            case Tile.typePossessed.ORGAN:
                quater = getOrientation(t._myTypeOriented);
                go = Instantiate(tilesGroundPossesseds[18], position, quater) as GameObject;
                break;
            case Tile.typePossessed.PC:
                quater = getOrientation(t._myTypeOriented);
                go = Instantiate(tilesGroundPossesseds[19], position, quater) as GameObject;
                break;
            case Tile.typePossessed.CHAIR2:
                quater = getOrientation(t._myTypeOriented);
                go = Instantiate(tilesGroundPossesseds[20], position, quater) as GameObject;
                break;
		}
	}

	private void instantiatePossessedWall(Tile t, Vector3 position, Quaternion q){
		GameObject go;
		Quaternion quater;
		switch (t._myTypePossessed) {
			case Tile.typePossessed.CANVAS1:
				quater = getOrientation(t._myTypeOriented);
				go=Instantiate(tilesWallPossesseds[0],position,quater) as GameObject;
				break;
			case Tile.typePossessed.CANVAS2:
				quater = getOrientation(t._myTypeOriented);
				go=Instantiate(tilesWallPossesseds[1],position,quater) as GameObject;
				break;
			case Tile.typePossessed.WINDOW:
				quater = getOrientation(t._myTypeOriented);
				go=Instantiate(tilesWallPossesseds[2],position,quater) as GameObject;
				break;
            case Tile.typePossessed.SOCKET:
                quater = getOrientation(t._myTypeOriented);
                go = Instantiate(tilesWallPossesseds[3], position, quater) as GameObject;
                break;
            case Tile.typePossessed.SWITCH:
                quater = getOrientation(t._myTypeOriented);
                go = Instantiate(tilesWallPossesseds[4], position, quater) as GameObject;
                break;
            case Tile.typePossessed.RADIATOR:
                quater = getOrientation(t._myTypeOriented);
                go = Instantiate(tilesWallPossesseds[5], position, quater) as GameObject;
                break;
            case Tile.typePossessed.LAMP3:
                quater = getOrientation(t._myTypeOriented);
                go = Instantiate(tilesWallPossesseds[6], position, quater) as GameObject;
                break;
		}
	}
	
	private void instantiateCorner(Tile.typeCorner t, Vector3 position){
		//Debug.Log (position);
		Vector3 positionW = new Vector3(0.0f,0.0f,0.0f);;
        Quaternion quater = Quaternion.identity;
		switch (t) {
			case Tile.typeCorner.LF:
                instantiateWall(Tile.typeOriented.L, position, ref positionW, ref quater, gameNivel);
                instantiateWall(Tile.typeOriented.F, position, ref positionW, ref quater, gameNivel);
				break;
			case Tile.typeCorner.RF:
                instantiateWall(Tile.typeOriented.R, position, ref positionW, ref quater, gameNivel);
                instantiateWall(Tile.typeOriented.F, position, ref positionW, ref quater, gameNivel);
				break;
			case Tile.typeCorner.LB:
                instantiateWall(Tile.typeOriented.L, position, ref positionW, ref quater, gameNivel);
                instantiateWall(Tile.typeOriented.B, position, ref positionW, ref quater, gameNivel);
				break;
			case Tile.typeCorner.RB:
                instantiateWall(Tile.typeOriented.R, position, ref positionW, ref quater, gameNivel);
                instantiateWall(Tile.typeOriented.B, position, ref positionW, ref quater, gameNivel);
				break;
		}
	}

	private void instantiateGround(int indexGround, Vector3 positionG){
		GameObject go = Instantiate(tileGroundEmpty[indexGround-1],positionG,Quaternion.identity) as GameObject;
	}


	private void instantiateWall(Tile.typeOriented t, Vector3 positionG, ref Vector3 positionW, ref Quaternion quater, int indexWall){
		GameObject go;
		switch (t) {
			case Tile.typeOriented.F:
				quater = Quaternion.identity;
				go = Instantiate(tileWallEmpty[indexWall-1],positionG, quater) as GameObject;
				break;
			case Tile.typeOriented.L:
				quater = Quaternion.Euler(new Vector3(0,-90,0));
                go = Instantiate(tileWallEmpty[indexWall - 1], positionG, quater) as GameObject;
				break;
			case Tile.typeOriented.R:
				quater = Quaternion.Euler(new Vector3(0,90,0));
                go = Instantiate(tileWallEmpty[indexWall - 1], positionG, quater) as GameObject;
				break;
			case Tile.typeOriented.B:
				quater = Quaternion.Euler(new Vector3(0,180,0));
                go = Instantiate(tileWallEmpty[indexWall - 1], positionG, quater) as GameObject;
				break;
		}
	}

	private void instantiateDoor(Tile.typeDoor d , Tile.typeOriented t, Vector3 positionG){
        GameObject go;
		Quaternion quater;
		switch (t) {
		case Tile.typeOriented.F:
			quater = Quaternion.identity;
			if (d == Tile.typeDoor.IN){
				go = Instantiate(tileDoorIn,positionG, quater) as GameObject;
				go.GetComponent<DoorInController>().directionIn = Vector3.back;
				go.GetComponent<DoorInController>().orientationIn = quater;
			}
			else if (d == Tile.typeDoor.OUT)
				go = Instantiate(tileDoorOut,positionG, quater) as GameObject;
			break;
		case Tile.typeOriented.L:
			quater = Quaternion.Euler(new Vector3(0,-90,0));
			if (d == Tile.typeDoor.IN){
				go = Instantiate(tileDoorIn,positionG, quater) as GameObject;
				go.GetComponent<DoorInController>().directionIn = Vector3.right;
				go.GetComponent<DoorInController>().orientationIn = quater;
			}
			else if (d == Tile.typeDoor.OUT)
				go = Instantiate(tileDoorOut,positionG, quater) as GameObject;
			break;
		case Tile.typeOriented.R:
			quater = Quaternion.Euler(new Vector3(0,90,0));
			if (d == Tile.typeDoor.IN){
				go = Instantiate(tileDoorIn,positionG, quater) as GameObject;
				go.GetComponent<DoorInController>().directionIn = Vector3.left;
				go.GetComponent<DoorInController>().orientationIn = quater;
			}
			else if (d == Tile.typeDoor.OUT)
				go = Instantiate(tileDoorOut,positionG, quater) as GameObject;
			break;
		case Tile.typeOriented.B:
			quater = Quaternion.Euler(new Vector3(0,180,0));
			if (d == Tile.typeDoor.IN){
				go = Instantiate(tileDoorIn,positionG, quater) as GameObject;
				go.GetComponent<DoorInController>().directionIn = Vector3.forward;
				go.GetComponent<DoorInController>().orientationIn = quater;
			}
			else if (d == Tile.typeDoor.OUT)
				go = Instantiate(tileDoorOut,positionG, quater) as GameObject;
			break;
		}
	}

	private void instantiateTyles(){
		
		//creamos los nuevos tiles
		float posicionZ = 0;
		float posicionX = 0;
		
		for (int i=0; i<_nRows; i++) {
			for (int j=0; j<_nColumns; j++){
				//Vector positionG, wich has the center of the tile wher instantiate the ground tile
				//It's the position reference
				Vector3 positionG=new Vector3(posicionX+(j*aumentoX),0,posicionZ-(i*aumentoZ));
				//Vector wich will have the position of the wall.
				//This vector is returned by the method instantiate wall
				//It's is used to instantiate objects on the walls
				Vector3 positionW = new Vector3(0.0f,0.0f,0.0f);
				Quaternion quater = Quaternion.identity;
				GameObject go;
				
				switch(_myRoom[i][j]._myTypeTile){
					case Tile.typeTile.OBSTACLE:
						instantiateGround(_myRoom[i][j]._myTypeGround,positionG);
						//go=Instantiate(tileGround[_myRoom[i][j]._myTypeGround],positionG,Quaternion.identity) as GameObject;
						instantiateObstacle(_myRoom[i][j],positionG);
						break;
					case Tile.typeTile.POSSESSED:
						switch(_myRoom[i][j]._myTypeEmpty){
						case Tile.typeEmpty.GROUND:
							instantiateGround(_myRoom[i][j]._myTypeGround,positionG);
							instantiatePossessedGround(_myRoom[i][j],positionG,Quaternion.identity);
							break;
						case Tile.typeEmpty.WALL:
							instantiateGround(_myRoom[i][j]._myTypeGround,positionG);
							instantiateWall(_myRoom[i][j]._myTypeOriented,positionG,ref positionW, ref quater, _myRoom[i][j]._myTypeWall);
							instantiatePossessedWall(_myRoom[i][j],positionG,Quaternion.identity);
							break;
						}
						break;
					case Tile.typeTile.EMPTY:
						switch(_myRoom[i][j]._myTypeEmpty){
						case Tile.typeEmpty.GROUND:
							instantiateGround(_myRoom[i][j]._myTypeGround,positionG);
							//go=Instantiate(tileGroundEmpty,positionG,Quaternion.identity) as GameObject;
							break;
						case Tile.typeEmpty.WALL:
							go=Instantiate(tileGroundEmpty[0],positionG,Quaternion.identity) as GameObject;
                            instantiateWall(_myRoom[i][j]._myTypeOriented, positionG, ref positionW, ref quater, _myRoom[i][j]._myTypeWall);
							break;
						case Tile.typeEmpty.CORNER:
							go=Instantiate(tileGroundEmpty[0],positionG,Quaternion.identity) as GameObject;
							instantiateCorner(_myRoom[i][j]._myTypeCorner,positionG);
							break;
						}
						break;
					case Tile.typeTile.DOOR:
						go = Instantiate(tileGroundEmpty[0],positionG,Quaternion.identity) as GameObject;
						instantiateDoor(_myRoom[i][j]._myTypeDoor, _myRoom[i][j]._myTypeOriented, positionG);
					break;
					default:
						break;
				}			
			}
		}
	}
}
