using UnityEngine;
using System.Collections;

public class GhostController : MonoBehaviour {

    protected GameObject _gameManager = null;
    protected Vector3 _objPosition;
    protected int _id;
    public bool _isInteligent;

	// Use this for initialization
	void Start () {
        _gameManager = GameObject.Find("GameManager");
	}
	
	// Update is called once per frame
	void Update () {
		//if (!_isInteligent)
        //    gameObject.GetComponent<GhostPlayer>().updateGhost();
        //else
		//	gameObject.GetComponent<GhostInteligence>().updateGhost();

        //transform.position = Vector3.MoveTowards(transform.position, _objPosition, 0.05f);
	}

    public void setId(int i)
    {
        _id = i;
    }

    public int getId()
    {
        return _id;
    }

    public void setObjPosition(Vector3 position)
    {
        _objPosition = position;
    }

    public void setInteligence(bool b)
    {
        _isInteligent = b;
        if (_isInteligent)
        {
			gameObject.AddComponent<GhostInteligence>();
        }
        else
        {
			
			gameObject.AddComponent<GhostPlayer>();
        }
    }
}
