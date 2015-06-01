using UnityEngine;
using System.Collections;
using System.Threading;

public class DoorInController : MonoBehaviour {
	
	GameObject[] humans;
	public Vector3 directionIn = new Vector3(0.0f,0.0f,1.0f);
	public Quaternion orientationIn = Quaternion.identity;

	// Use this for initialization
	void Start () {
		//humans = GameObject.FindGameObjectsWithTag("Human");
		//takeHumanToDoor();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void initialize(){
		humans = GameObject.FindGameObjectsWithTag("Human");
		StartCoroutine(waitBetweenHumans(0));
	}

	IEnumerator waitBetweenHumans(int index){
		yield return new WaitForSeconds(3);
		takeHumanToDoor (index);
	}

	private void takeHumanToDoor(int indexHuman){
		//StartCoroutine(waitBetweenHumans());
		GameObject go = humans[indexHuman];
		go.transform.position = gameObject.transform.position+new Vector3(0.0f,0.45f,0.0f);
		go.transform.rotation = orientationIn;
        go.SendMessage("setMoving", true);
		if (go.GetComponent<HumanController> ()._isInteligent) {
			//go.GetComponent<HumanIntelligence> ().setDirection (directionIn);
			go.GetComponent<HumanIntelligence> ().isInScene = true;
			go.GetComponent<HumanIntelligence> ().position = gameObject.transform.position+new Vector3(0.0f,0.45f,0.0f);;
		} 
		else {
			go.GetComponent<HumanPlayer> ().setDirection (-directionIn);
			go.transform.rotation = Quaternion.Euler (new Vector3 (0,orientationIn.y+180,0));
			go.GetComponent<HumanPlayer> ().isInScene = true;
		}
		//recursive method
		if (indexHuman < humans.Length-1){
			++indexHuman;
			StartCoroutine(waitBetweenHumans(indexHuman));
		}
	}
}
