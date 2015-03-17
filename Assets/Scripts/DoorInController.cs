using UnityEngine;
using System.Collections;
using System.Threading;

public class DoorInController : MonoBehaviour {

	GameObject _gameManager = null;
	GameObject[] humans;
	private int indexHuman = 0;
	public Vector3 directionIn = new Vector3(0.0f,0.0f,1.0f);
	public Quaternion orientationIn = Quaternion.identity;

	// Use this for initialization
	void Start () {
		_gameManager = GameObject.FindWithTag ("GameManager");
		//humans = GameObject.FindGameObjectsWithTag("Human");
		//takeHumanToDoor();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void initialize(){
		humans = GameObject.FindGameObjectsWithTag("Human");
		takeHumanToDoor();
	}

	void OnTriggerEnter (Collider other) {
		Debug.Log ("humano entra " + other.gameObject.tag);
		//open door
		//_gameManager.GetComponent<GameManager>().addHumanScene(other.gameObject);
		//_gameManager.GetComponent<GameManager> ().addHumanCount ();
	}

	void OnTriggerExit (Collider other){
		waitBetweenHumans ();
		//_gameManager.GetComponent<GameManager>().addHumanScene(other.gameObject);
		if (indexHuman < humans.Length-1){
			++indexHuman;
			takeHumanToDoor();
		}
	}

	IEnumerator waitBetweenHumans(){
		print("time: " + Time.time);
		yield return new WaitForSeconds(10);
		print(Time.time);
	}

	private void takeHumanToDoor(){
		waitBetweenHumans ();
		GameObject go = humans[indexHuman];
		go.transform.position = gameObject.transform.position+new Vector3(0.0f,1.0f,0.0f);
		go.transform.rotation = orientationIn;
		go.GetComponent<HumanPlayer>().setDirection(directionIn);
		go.GetComponent<HumanPlayer>().setMoving(true);
		go.GetComponent<HumanPlayer> ().isInScene = true;
	}
}
