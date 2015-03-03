using UnityEngine;
using System.Collections;

public class Tile {

	public enum typeTile{NOT,EMPTY,OBSTACLE,POSSESSED,DOOR};
	public enum typeObstacle{NOT,TABLE}
	public enum typeEmpty{NOT,GROUND,WALL}
	public enum typePossessed{NOT,VASE,CANVAS1,CANVAS2}

	public typeTile _myTypeTile;
	public typeObstacle _myTypeObstacle;
	public typeEmpty _myTyleEmpty;
	public typePossessed _myTylePossessed;
	public bool horizontal;

	public Tile(){
		_myTypeTile = typeTile.NOT;
		_myTypeObstacle = typeObstacle.NOT;
		_myTyleEmpty = typeEmpty.NOT;
		_myTylePossessed = typePossessed.NOT;
		horizontal = true;
	}

	void instantiate(float x, float y, float z){
	
	}

}
