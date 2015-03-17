using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenerateScene : MonoBehaviour {

	public int _nRows = 0;
	public int _nColumns = 0;
	public int _nTyles = 0;

	public int numHumans=3;
	public int numGhosts=2;
	
	private List<List<Tile>> _myRoom;
	
	private float ultimaPosicionX=0;
	
	public GameObject tileGroundEmpty;
	public GameObject[] tilesGroundObstacles;
	public GameObject[] tilesGroundPossesseds;
	
	public GameObject tileWallEmpty;
	public GameObject[] tilesWallPossesseds;
	
	public GameObject tileDoorIn;
	public GameObject tileDoorOut;

	public GameObject gameManager;
	
	private float aumentoX;
	private float aumentoZ;

	public void Start(){
		Renderer m_renderer = tileGroundEmpty.renderer;
		aumentoX = m_renderer.bounds.size.x;
		aumentoZ = m_renderer.bounds.size.z;
	}
	public void Update(){}

	private void loadParameters(Vector3 v){
		_nRows = (int)v.x;
		_nColumns = (int)v.y;
		_nTyles = (int)v.z;
	}
	
	private void generateScene(List<List<int>> _roomIds){
		Renderer m_renderer = tileGroundEmpty.renderer;
		aumentoX = m_renderer.bounds.size.x;
		aumentoZ = m_renderer.bounds.size.z;
		//instantiateCameras();
		createRoom ();
		generateTyles (_roomIds);
		instantiateTyles ();
		instantiateCharacters();
		instantiateGameManager();
	}

	private void instantiateCameras(){
		gameObject.GetComponent<GenerateCameras>().instantiateCameras();
	}

	private void instantiateCharacters(){
		gameObject.GetComponent<GenerateCharacters>().instantiateCharacters(numHumans,numGhosts);
	}

	private void instantiateGameManager(){
		GameObject go = Instantiate(gameManager,Vector3.zero,Quaternion.identity) as GameObject;
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
		case 10:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.EMPTY;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.GROUND;
			break;
		case 11:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.POSSESSED;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.GROUND;
			_myRoom [row] [col]._myTypePossessed = Tile.typePossessed.VASE;
			break;
		case 121:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.OBSTACLE;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.GROUND;
			_myRoom [row] [col]._myTypeObstacle = Tile.typeObstacle.TABLE;
			_myRoom [row] [col].horizontal = true;
			break;
		case 122:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.OBSTACLE;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.GROUND;
			_myRoom [row] [col]._myTypeObstacle = Tile.typeObstacle.TABLE;
			_myRoom [row] [col].horizontal = false;
			break;
		case 123:
			//We don't have to instantiate a tyle here, but we need info of typeObstacle
			_myRoom [row] [col]._myTypeObstacle = Tile.typeObstacle.TABLE;
			break;
		case 2011:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.EMPTY;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.WALL;
			_myRoom [row] [col]._myTypeWall = Tile.typeWall.F;
			break;
		case 2012:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.EMPTY;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.WALL;
			_myRoom [row] [col]._myTypeWall = Tile.typeWall.L;
			break;
		case 2013:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.EMPTY;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.WALL;
			_myRoom [row] [col]._myTypeWall = Tile.typeWall.R;
			break;
		case 2014:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.EMPTY;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.WALL;
			_myRoom [row] [col]._myTypeWall = Tile.typeWall.B;
			break;
		case 2021:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.EMPTY;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.CORNER;
			_myRoom [row] [col]._myTypeCorner = Tile.typeCorner.LF;
			_myRoom [row] [col].esquina = true;
			break;
		case 2022:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.EMPTY;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.CORNER;
			_myRoom [row] [col]._myTypeCorner = Tile.typeCorner.RF;
			_myRoom [row] [col].esquina = true;
			break;
		case 2023:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.EMPTY;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.CORNER;
			_myRoom [row] [col]._myTypeCorner = Tile.typeCorner.LB;
			_myRoom [row] [col].esquina = true;
			break;
		case 2024:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.EMPTY;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.CORNER;
			_myRoom [row] [col]._myTypeCorner = Tile.typeCorner.RB;
			_myRoom [row] [col].esquina = true;
			break;
		case 2111:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.POSSESSED;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.WALL;
			_myRoom [row] [col]._myTypePossessed = Tile.typePossessed.CANVAS1;
			_myRoom [row] [col]._myTypeWall = Tile.typeWall.F;
			break;
		case 2112:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.POSSESSED;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.WALL;
			_myRoom [row] [col]._myTypePossessed = Tile.typePossessed.CANVAS1;
			_myRoom [row] [col]._myTypeWall = Tile.typeWall.L;
			break;
		case 2113:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.POSSESSED;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.WALL;
			_myRoom [row] [col]._myTypePossessed = Tile.typePossessed.CANVAS1;
			_myRoom [row] [col]._myTypeWall = Tile.typeWall.R;
			break;
		case 2114:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.POSSESSED;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.WALL;
			_myRoom [row] [col]._myTypePossessed = Tile.typePossessed.CANVAS1;
			_myRoom [row] [col]._myTypeWall = Tile.typeWall.B;
			break;
		case 2121:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.POSSESSED;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.WALL;
			_myRoom [row] [col]._myTypePossessed = Tile.typePossessed.CANVAS2;
			_myRoom [row] [col]._myTypeWall = Tile.typeWall.F;
			break;
		case 2122:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.POSSESSED;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.WALL;
			_myRoom [row] [col]._myTypePossessed = Tile.typePossessed.CANVAS2;
			_myRoom [row] [col]._myTypeWall = Tile.typeWall.L;
			break;
		case 2123:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.POSSESSED;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.WALL;
			_myRoom [row] [col]._myTypePossessed = Tile.typePossessed.CANVAS2;
			_myRoom [row] [col]._myTypeWall = Tile.typeWall.R;
			break;
		case 2124:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.POSSESSED;
			_myRoom [row] [col]._myTypeEmpty = Tile.typeEmpty.WALL;
			_myRoom [row] [col]._myTypePossessed = Tile.typePossessed.CANVAS2;
			_myRoom [row] [col]._myTypeWall = Tile.typeWall.B;
			break;
		case 501:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.DOOR;
			_myRoom [row] [col]._myTypeDoor = Tile.typeDoor.IN;
			_myRoom [row] [col]._myTypeWall = Tile.typeWall.F;
			break;
		case 502:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.DOOR;
			_myRoom [row] [col]._myTypeDoor = Tile.typeDoor.IN;
			_myRoom [row] [col]._myTypeWall = Tile.typeWall.L;
			break;
		case 503:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.DOOR;
			_myRoom [row] [col]._myTypeDoor = Tile.typeDoor.IN;
			_myRoom [row] [col]._myTypeWall = Tile.typeWall.R;
			break;
		case 504:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.DOOR;
			_myRoom [row] [col]._myTypeDoor = Tile.typeDoor.IN;
			_myRoom [row] [col]._myTypeWall = Tile.typeWall.B;
			break;
		case 511:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.DOOR;
			_myRoom [row] [col]._myTypeDoor = Tile.typeDoor.OUT;
			_myRoom [row] [col]._myTypeWall = Tile.typeWall.F;
			break;
		case 512:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.DOOR;
			_myRoom [row] [col]._myTypeDoor = Tile.typeDoor.OUT;
			_myRoom [row] [col]._myTypeWall = Tile.typeWall.L;
			break;
		case 513:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.DOOR;
			_myRoom [row] [col]._myTypeDoor = Tile.typeDoor.OUT;
			_myRoom [row] [col]._myTypeWall = Tile.typeWall.R;
			break;
		case 514:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.DOOR;
			_myRoom [row] [col]._myTypeDoor = Tile.typeDoor.OUT;
			_myRoom [row] [col]._myTypeWall = Tile.typeWall.B;
			break;
		default:
			break;
		}
	}
	
	private void instantiateObstacle(Tile t, Vector3 position){
		GameObject go;
		switch (t._myTypeObstacle) {
			case Tile.typeObstacle.TABLE:
				go=Instantiate(tilesGroundObstacles[0],position,Quaternion.identity) as GameObject;
				break;
		}
	}
	
	private void instantiatePossessed(Tile.typePossessed t, Vector3 position, Quaternion q){
		GameObject go;
		switch (t) {
			case Tile.typePossessed.VASE:
				go=Instantiate(tilesGroundPossesseds[0],position,Quaternion.identity) as GameObject;
				break;
			case Tile.typePossessed.CANVAS1:
				go=Instantiate(tilesWallPossesseds[0],position,q) as GameObject;
				break;
			case Tile.typePossessed.CANVAS2:
				go=Instantiate(tilesWallPossesseds[1],position,q) as GameObject;
				break;
		}
	}
	
	private void instantiateCorner(Tile.typeCorner t, Vector3 position){
		//Debug.Log (position);
		Vector3 positionW = new Vector3(0.0f,0.0f,0.0f);;
		Quaternion quater = Quaternion.identity;
		GameObject go;
		switch (t) {
			case Tile.typeCorner.LF:
				instantiateWall(Tile.typeWall.L, position, ref positionW, ref quater);
				instantiateWall(Tile.typeWall.F, position, ref positionW, ref quater);
				break;
			case Tile.typeCorner.RF:
				instantiateWall(Tile.typeWall.R, position, ref positionW, ref quater);
				instantiateWall(Tile.typeWall.F, position, ref positionW, ref quater);
				break;
			case Tile.typeCorner.LB:
				instantiateWall(Tile.typeWall.L, position, ref positionW, ref quater);
				instantiateWall(Tile.typeWall.B, position, ref positionW, ref quater);
				break;
			case Tile.typeCorner.RB:
				instantiateWall(Tile.typeWall.R, position, ref positionW, ref quater);
				instantiateWall(Tile.typeWall.B, position, ref positionW, ref quater);
				break;
		}
	}

	private void instantiateWall(Tile.typeWall t, Vector3 positionG, ref Vector3 positionW, ref Quaternion quater){
		GameObject go;
		switch (t) {
			case Tile.typeWall.F:
				positionW = new Vector3(positionG.x,positionG.y-(float)0.2,positionG.z+aumentoZ/2);
				quater = Quaternion.identity;
				go = Instantiate(tileWallEmpty,positionW, quater) as GameObject;
				break;
			case Tile.typeWall.L:
				positionW = new Vector3(positionG.x-aumentoX/2,positionG.y-(float)0.2,positionG.z);
				quater = Quaternion.Euler(new Vector3(0,-90,0));
				go = Instantiate(tileWallEmpty,positionW,quater) as GameObject;
				break;
			case Tile.typeWall.R:
				positionW = new Vector3(positionG.x+aumentoX/2,positionG.y-(float)0.2,positionG.z);
				quater = Quaternion.Euler(new Vector3(0,90,0));
				go = Instantiate(tileWallEmpty,positionW,quater) as GameObject;
				break;
			case Tile.typeWall.B:
				positionW = new Vector3(positionG.x,positionG.y-(float)0.2,positionG.z-aumentoZ/2);
				quater = Quaternion.Euler(new Vector3(0,180,0));
				go = Instantiate(tileWallEmpty,positionW,quater) as GameObject;
				break;
		}
	}

	private void instantiateDoor(Tile.typeDoor d , Tile.typeWall t, Vector3 positionG){
		GameObject go;
		Vector3 positionW;
		Quaternion quater;
		switch (t) {
		case Tile.typeWall.F:
			positionW = new Vector3(positionG.x,positionG.y,positionG.z+aumentoZ/2);
			quater = Quaternion.identity;
			if (d == Tile.typeDoor.IN){
				go = Instantiate(tileDoorIn,positionW, quater) as GameObject;
				go.GetComponent<DoorInController>().directionIn = Vector3.back;
				go.GetComponent<DoorInController>().orientationIn = quater;
			}
			else if (d == Tile.typeDoor.OUT)
				go = Instantiate(tileDoorOut,positionW, quater) as GameObject;
			break;
		case Tile.typeWall.L:
			positionW = new Vector3(positionG.x-aumentoX/2,positionG.y,positionG.z);
			quater = Quaternion.Euler(new Vector3(0,-90,0));
			if (d == Tile.typeDoor.IN){
				go = Instantiate(tileDoorIn,positionW, quater) as GameObject;
				go.GetComponent<DoorInController>().directionIn = Vector3.right;
				go.GetComponent<DoorInController>().orientationIn = quater;
			}
			else if (d == Tile.typeDoor.OUT)
				go = Instantiate(tileDoorOut,positionW, quater) as GameObject;
			break;
		case Tile.typeWall.R:
			positionW = new Vector3(positionG.x+aumentoX/2,positionG.y,positionG.z);
			quater = Quaternion.Euler(new Vector3(0,90,0));
			if (d == Tile.typeDoor.IN){
				go = Instantiate(tileDoorIn,positionW, quater) as GameObject;
				go.GetComponent<DoorInController>().directionIn = Vector3.left;
				go.GetComponent<DoorInController>().orientationIn = quater;
			}
			else if (d == Tile.typeDoor.OUT)
				go = Instantiate(tileDoorOut,positionW, quater) as GameObject;
			break;
		case Tile.typeWall.B:
			positionW = new Vector3(positionG.x,positionG.y,positionG.z-aumentoZ/2);
			quater = Quaternion.Euler(new Vector3(0,180,0));
			if (d == Tile.typeDoor.IN){
				go = Instantiate(tileDoorIn,positionW, quater) as GameObject;
				go.GetComponent<DoorInController>().directionIn = Vector3.forward;
				go.GetComponent<DoorInController>().orientationIn = quater;
			}
			else if (d == Tile.typeDoor.OUT)
				go = Instantiate(tileDoorOut,positionW, quater) as GameObject;
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
						switch(_myRoom[i][j]._myTypeObstacle){
						case Tile.typeObstacle.TABLE:
							go=Instantiate(tileGroundEmpty,positionG,Quaternion.identity) as GameObject;
							instantiateObstacle(_myRoom[i][j],positionG);
							break;
						}
						break;
					case Tile.typeTile.POSSESSED:
						switch(_myRoom[i][j]._myTypePossessed){
						case Tile.typePossessed.VASE:
							go=Instantiate(tileGroundEmpty,positionG,Quaternion.identity) as GameObject;
							instantiatePossessed(_myRoom[i][j]._myTypePossessed,positionG,Quaternion.identity);
							break;
						case Tile.typePossessed.CANVAS1:
							go=Instantiate(tileGroundEmpty,positionG,Quaternion.identity) as GameObject;
							instantiateWall(_myRoom[i][j]._myTypeWall,positionG,ref positionW, ref quater);
							instantiatePossessed(_myRoom[i][j]._myTypePossessed,new Vector3(positionW.x,positionW.y+(float)2.5,positionW.z-(float)0.3),quater);
							break;
						case Tile.typePossessed.CANVAS2:
							go=Instantiate(tileGroundEmpty,positionG,Quaternion.identity) as GameObject;
							instantiateWall(_myRoom[i][j]._myTypeWall,positionG,ref positionW, ref quater);
							instantiatePossessed(_myRoom[i][j]._myTypePossessed,new Vector3(positionW.x,positionW.y+(float)2.5,positionW.z-(float)0.3),quater);
							break;
						}
						break;
					case Tile.typeTile.EMPTY:
						switch(_myRoom[i][j]._myTypeEmpty){
						case Tile.typeEmpty.GROUND:
							go=Instantiate(tileGroundEmpty,positionG,Quaternion.identity) as GameObject;
							break;
						case Tile.typeEmpty.WALL:
							go=Instantiate(tileGroundEmpty,positionG,Quaternion.identity) as GameObject;
							instantiateWall(_myRoom[i][j]._myTypeWall,positionG, ref positionW, ref quater);
							break;
						case Tile.typeEmpty.CORNER:
							go=Instantiate(tileGroundEmpty,positionG,Quaternion.identity) as GameObject;
							instantiateCorner(_myRoom[i][j]._myTypeCorner,positionG);
							break;
						}
						break;
					case Tile.typeTile.DOOR:
						go = Instantiate(tileGroundEmpty,positionG,Quaternion.identity) as GameObject;
						instantiateDoor(_myRoom[i][j]._myTypeDoor, _myRoom[i][j]._myTypeWall, positionG);
					break;
					default:
						break;
				}			
			}
		}
	}
}
