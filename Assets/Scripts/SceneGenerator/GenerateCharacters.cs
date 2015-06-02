#pragma warning disable 0219

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GenerateCharacters : MonoBehaviour {

	public Vector3 positionFirstHuman = new Vector3 (0.0f, 0.45f, 0.0f);
	public GameObject[] ghosts;
	public GameObject[] humans;
	public GameObject healthBar;
	
	void Start (){}

	void Update (){}

	public void instantiateCharacters(int numHumans, int[] lifeHumans, int numGhosts){
		createHumans(numHumans,lifeHumans);
		createGhosts(numGhosts);
	}

	private void createHumans(int num, int[] lifeHumans){
		GameObject gameState = GameObject.FindWithTag("GameState");
		Vector3 pos = positionFirstHuman;
		Vector3 aux = new Vector3(2.0f,0.0f,0.0f);
		//pos = pos - aux * num;
		for (int i=0; i<num; i++) {
			var aux_human = Instantiate (humans[i%humans.Length], pos, Quaternion.identity) as GameObject;
			if (gameState.GetComponent<GameState> ().getModeGame () == 0) {
				var aux_healthBarHuman = Instantiate (healthBar, pos, Quaternion.identity) as GameObject;
				var aux_healthBarGhost = Instantiate (healthBar, pos, Quaternion.identity) as GameObject;
				aux_healthBarHuman.transform.parent = GameObject.Find ("Canvas").transform;
				aux_healthBarGhost.transform.parent = GameObject.Find ("Canvas").transform;
				aux_human.GetComponent<HumanController>().setHealthBarHuman(aux_healthBarHuman);
				aux_human.GetComponent<HumanController>().setHealthBarGhost(aux_healthBarGhost);
			} else if (gameState.GetComponent<GameState> ().getModeGame () == 1) {
				var aux_healthBarGhost = Instantiate (healthBar, pos, Quaternion.identity) as GameObject;
				aux_healthBarGhost.transform.parent = GameObject.Find ("Canvas").transform;
				aux_human.GetComponent<HumanController>().setHealthBarGhost(aux_healthBarGhost);
			} else if (gameState.GetComponent<GameState> ().getModeGame () == 2) {
				var aux_healthBarHuman = Instantiate (healthBar, pos, Quaternion.identity) as GameObject;
				aux_healthBarHuman.transform.parent = GameObject.Find ("Canvas").transform;
				aux_human.GetComponent<HumanController>().setHealthBarHuman(aux_healthBarHuman);
			}
			aux_human.GetComponent<HumanController>().setLife(lifeHumans[i]);
			pos = pos + aux;
		}
	}

	private void createGhosts(int num){
		Vector3 pos= new Vector3(0.0f,0.0f,0.0f);
		for (int i=0; i<num; i++) {
			GameObject aux_ghost = Instantiate (ghosts[i%ghosts.Length], pos, Quaternion.identity) as GameObject;
		}
	}
}
