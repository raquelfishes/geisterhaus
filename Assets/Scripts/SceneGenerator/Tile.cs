using UnityEngine;
using System.Collections;

public class Tile {

	public enum typeTile{NOT,EMPTY,OBSTACLE,POSSESSED,DOOR};
	public enum typeObstacle{NOT,TABLE}
	public enum typeEmpty{NOT,GROUND,WALL,CORNER}
	public enum typePossessed{NOT,VASE,CANVAS1,CANVAS2}
	//RF = right front -- LF = right left -- RB = right back -- LB = back left
	public enum typeCorner{RF,LF,RB,LB,NOT}
	public enum typeWall{R,L,F,B,NOT}
	public enum typeDoor{IN,OUT, NOT}

	public typeTile _myTypeTile;
	public typeObstacle _myTypeObstacle;
	public typeEmpty _myTypeEmpty;
	public typePossessed _myTypePossessed;
	public typeCorner _myTypeCorner;
	public typeWall _myTypeWall;
	public typeDoor _myTypeDoor;
	public bool horizontal;
	public bool esquina;

	public Tile(){
		_myTypeTile = typeTile.NOT;
		_myTypeObstacle = typeObstacle.NOT;
		_myTypeEmpty = typeEmpty.NOT;
		_myTypePossessed = typePossessed.NOT;
		_myTypeCorner = typeCorner.NOT;
		_myTypeWall = typeWall.NOT;
		_myTypeDoor = typeDoor.NOT;
		horizontal = true;
		esquina = false;
	}

	void instantiate(float x, float y, float z){
	
	}

}
