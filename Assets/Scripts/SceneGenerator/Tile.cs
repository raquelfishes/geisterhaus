﻿using UnityEngine;
using System.Collections;

public class Tile {

	public enum typeTile{NOT,EMPTY,OBSTACLE,POSSESSED,DOOR};
	public enum typeObstacle{NOT,CHAIR,ARMCHAIR,AQUARIUM}
	public enum typeEmpty{NOT,GROUND,WALL,CORNER}
	public enum typePossessed{NOT,VASE,CANVAS1,CANVAS2,CLOCK,TABLE,SOFA,LIGHT,STATUE1,STATUE2,WINDOW,FIREPLACE}
	//RF = right front -- LF = right left -- RB = right back -- LB = back left
	public enum typeCorner{RF,LF,RB,LB,NOT}
	public enum typeOriented{R,L,F,B,NOT}
	public enum typeDoor{IN,OUT, NOT}

	public typeTile _myTypeTile;
	public typeObstacle _myTypeObstacle;
	public typeEmpty _myTypeEmpty;
	public typePossessed _myTypePossessed;
	public typeCorner _myTypeCorner;
	public typeOriented _myTypeOriented;
	public typeDoor _myTypeDoor;
	public bool horizontal;
	public bool esquina;
	public int _myTypeGround;

	public Tile(){
		_myTypeTile = typeTile.NOT;
		_myTypeObstacle = typeObstacle.NOT;
		_myTypeEmpty = typeEmpty.NOT;
		_myTypePossessed = typePossessed.NOT;
		_myTypeCorner = typeCorner.NOT;
		_myTypeOriented = typeOriented.NOT;
		_myTypeDoor = typeDoor.NOT;
		horizontal = true;
		esquina = false;
		_myTypeGround = -1;
	}

	void instantiate(float x, float y, float z){
	
	}

}
