using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenerateScene : MonoBehaviour {

	public int _nRows = 0;
	public int _nColumns = 0;
	public int _nTyles = 0;
	
	private List<List<Tile>> _myRoom;
	
	private float ultimaPosicionX=0;
	
	public GameObject tileGroundEmpty;
	public GameObject[] tilesGroundObstacles;
	public GameObject[] tilesGroundPossesseds;
	
	public GameObject tileWallEmpty;
	public GameObject[] tilesWallPossesseds;
	
	public GameObject tileDoorIn;
	public GameObject tileDoorOut;

	public void Start(){}
	public void Update(){}

	private void loadParameters(Vector3 v){
		_nRows = (int)v.x;
		_nColumns = (int)v.y;
		_nTyles = (int)v.z;
	}
	
	private void generateScene(List<List<int>> _roomIds){
		createRoom ();
		generateTyles (_roomIds);
		instantiateTyles ();
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
			_myRoom [row] [col]._myTyleEmpty = Tile.typeEmpty.GROUND;
			break;
		case 11:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.POSSESSED;
			_myRoom [row] [col]._myTyleEmpty = Tile.typeEmpty.GROUND;
			_myRoom [row] [col]._myTylePossessed = Tile.typePossessed.VASE;
			break;
		case 121:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.OBSTACLE;
			_myRoom [row] [col]._myTyleEmpty = Tile.typeEmpty.GROUND;
			_myRoom [row] [col]._myTypeObstacle = Tile.typeObstacle.TABLE;
			_myRoom [row] [col].horizontal = true;
			break;
		case 122:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.OBSTACLE;
			_myRoom [row] [col]._myTyleEmpty = Tile.typeEmpty.GROUND;
			_myRoom [row] [col]._myTypeObstacle = Tile.typeObstacle.TABLE;
			_myRoom [row] [col].horizontal = false;
			break;
		case 123:
			//We don't have to instantiate a tyle here, but we need info of typeObstacle
			_myRoom [row] [col]._myTypeObstacle = Tile.typeObstacle.TABLE;
			break;
		case 20:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.EMPTY;
			_myRoom [row] [col]._myTyleEmpty = Tile.typeEmpty.WALL;
			break;
		case 211:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.POSSESSED;
			_myRoom [row] [col]._myTyleEmpty = Tile.typeEmpty.WALL;
			_myRoom [row] [col]._myTylePossessed = Tile.typePossessed.CANVAS1;
			break;
		case 212:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.POSSESSED;
			_myRoom [row] [col]._myTyleEmpty = Tile.typeEmpty.WALL;
			_myRoom [row] [col]._myTylePossessed = Tile.typePossessed.CANVAS2;
			break;
		case 50:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.DOOR;
			break;
		case 51:
			_myRoom [row] [col]._myTypeTile = Tile.typeTile.DOOR;
			break;
		default:
			break;
		}
	}
	
	private void instantiateObstacle(Tile t, float x, float z){
		Vector3 posicion= new Vector3(x,0,z);
		GameObject go;
		switch (t._myTypeObstacle) {
		case Tile.typeObstacle.TABLE:
			go=Instantiate(tilesGroundObstacles[0],posicion,Quaternion.identity) as GameObject;
			break;
		}
	}
	
	private void instantiatePossessed(Tile.typePossessed t, float x, float z, Quaternion q){
		Vector3 posicion= new Vector3(x,0,z);
		GameObject go;
		switch (t) {
		case Tile.typePossessed.VASE:
			go=Instantiate(tilesGroundPossesseds[0],posicion,Quaternion.identity) as GameObject;
			break;
		case Tile.typePossessed.CANVAS1:
			go=Instantiate(tilesWallPossesseds[0],posicion,q) as GameObject;
			break;
		case Tile.typePossessed.CANVAS2:
			go=Instantiate(tilesWallPossesseds[1],posicion,q) as GameObject;
			break;
		}
	}
	
	private void instantiateTyles(){
		Renderer m_renderer = tileGroundEmpty.renderer;
		float aumentoX = m_renderer.bounds.size.x;
		float aumentoZ = m_renderer.bounds.size.z;
		
		//creamos los nuevos tiles
		float posicionZ = aumentoZ / 2;
		float posicionX = ultimaPosicionX;
		
		for (int i=0; i<_nRows; i++) {
			for (int j=0; j<_nColumns; j++){
				Vector3 posicion= new Vector3(posicionX+i,0,posicionZ+j);
				GameObject go;
				
				//Calculate angle rotation with i,j
				// i=0; j=0; Front wall; angle=0
				// i!=0; j=0; left wall; angle=90	
				// i!=0; j=max; right wall; angle=-90
				// i=max; j=max; back wall; angle=180
				Quaternion q=Quaternion.identity;
				if (i>0 && j==0) q=Quaternion.Euler (new Vector3(0,90,0));
				else if (i>0 && j==_nColumns-1) q=Quaternion.Euler (new Vector3(0,-90,0));
				else if (i==_nRows-1 && j==_nColumns-1) q=Quaternion.Euler (new Vector3(0,180,0));
				
				switch(_myRoom[i][j]._myTypeTile)
				{
				case Tile.typeTile.OBSTACLE:
					switch(_myRoom[i][j]._myTypeObstacle){
					case Tile.typeObstacle.TABLE:
						go=Instantiate(tileGroundEmpty,posicion,Quaternion.identity) as GameObject;
						instantiateObstacle(_myRoom[i][j],posicionX,posicionZ);
						break;
					}
					break;
				case Tile.typeTile.POSSESSED:
					switch(_myRoom[i][j]._myTylePossessed){
					case Tile.typePossessed.VASE:
						go=Instantiate(tileGroundEmpty,posicion,Quaternion.identity) as GameObject;
						instantiatePossessed(_myRoom[i][j]._myTylePossessed,posicionX,posicionZ,Quaternion.identity);
						break;
					case Tile.typePossessed.CANVAS1:
						go=Instantiate(tileWallEmpty,posicion,Quaternion.identity) as GameObject;
						instantiatePossessed(_myRoom[i][j]._myTylePossessed,posicionX,posicionZ,q);
						break;
					case Tile.typePossessed.CANVAS2:
						go=Instantiate(tileWallEmpty,posicion,Quaternion.identity) as GameObject;
						instantiatePossessed(_myRoom[i][j]._myTylePossessed,posicionX,posicionZ,q);
						break;
					}
					break;
				case Tile.typeTile.EMPTY:
					switch(_myRoom[i][j]._myTyleEmpty){
					case Tile.typeEmpty.GROUND:
						go=Instantiate(tileGroundEmpty,posicion,Quaternion.identity) as GameObject;
						break;
					case Tile.typeEmpty.WALL:
						go=Instantiate(tileWallEmpty,posicion,Quaternion.identity) as GameObject;
						break;
					}
					break;
				default:
					break;
				}
				//posicionZ+= aumentoZ;				
			}
			//posicionX+=aumentoX;
			//ultimaPosicionX = posicionX;
		}
	}
}
