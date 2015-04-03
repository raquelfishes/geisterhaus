using UnityEngine;
using System.Collections;

public class GhostController : MonoBehaviour {

    protected GameObject _gameManager = null;
    protected Vector3 _objPosition;
	protected GameObject _obj;
    protected int _id;
    public bool _isInteligent;

	// Use this for initialization
	void Start () {
        _gameManager = GameObject.FindWithTag("GameManager");
	}
	
	// Update is called once per frame
	void Update (){

	}

    public void setId(int i){
        _id = i;
    }

    public int getId(){
        return _id;
    }

    //public void setObjPosition(Vector3 position){
    //    _objPosition = position;
    //}

	public void setObj(GameObject obj){
		if (_obj != null)
			_obj.GetComponent<ObjectController> ().setAsignado (false);
		_obj = obj;
		_objPosition = obj.transform.position;
		_obj.GetComponent<ObjectController> ().setAsignado (true);
	}

    public void setInteligence(bool b){
        _isInteligent = b;
        if (_isInteligent){
			gameObject.AddComponent<GhostInteligence>();
        }else{	
			gameObject.AddComponent<GhostPlayer>();
        }
    }
}
