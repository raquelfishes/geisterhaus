using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameState : MonoBehaviour {

	private int modeGame; 		// Modo de juego: 0 multiplayer  // 1 single ghost: humanos listos // 2 single humans: fantasmas listos
	private int player1;		// Tipo de jugador 1 (para el caso del multiplayer) : 0 fantasma  // 1 humanos // -1 uno de los dos es inteligente
	private int nivel; 			// Indice del nivel en el que nos encontramos
	private int numHumans; 		// Numero de humanos que quedan vivos
	private int[] lifeHumans = new int[50];	// Vida de cada uno de los humanos - Definimos un maximo de 50 y no nos tenemos que preocupar de inicializaciones

    private int maxNivel = 3;   // Maximo de niveles en el juego

    public Texture2D[] loading;
    public Texture2D gameOverText;
    public

	// Load game state in all scenes
	void Awake () {
		DontDestroyOnLoad(gameObject);
		for (int i=0; i<50; i++) {
			lifeHumans[i]=100;
		}
	}

	// Use this for initialization
	void Start () {
		Application.LoadLevel("MainMenu");
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape)) { 
			Application.LoadLevel ("MainMenu");
            GameObject go = GameObject.Find("CanvasAux");
            go.GetComponentInChildren<RawImage>().enabled = false;
            go.GetComponentInChildren<Text>().enabled = false;
            //go.GetComponentInChildren<RawImage>().enabled = true;
			gameObject.audio.Play();
            for (int i= 0; i< 50; i++){ lifeHumans[i]=100; }
		}
	}

	public int getModeGame() { return modeGame; }
	public int getPlayer1() { return player1; }
	public int getPlayer2() { return 1 - player1; }
	public int getNivel() { return nivel; }
	public int getNumHumans() { return numHumans; }
	public int[] getLifeHumans() { return lifeHumans; }
	public int getLifeHuman(int i) { return lifeHumans [i]; }

	public void setModeGame(int mode) { modeGame = mode; }
	public void setPlayer1(int mode) { player1 = mode; }
	public void setNivel(int niv) { nivel = niv; }
	public void setNumHumans(int num) { numHumans = num;}
	public void setLifeHumans(int[] life) { lifeHumans = life; }
	public void setLifeHuman(int i, int life) { lifeHumans[i] = life; }

    public void loadNextLevel(){
        ++nivel;
        if (nivel > maxNivel) {
            // Mostrar fin del juego
            gameOver(false, true);
        }
        else {
            GameObject go = GameObject.Find("CanvasAux");
            //go.SetActive(true);
            go.GetComponentInChildren<RawImage>().texture = loading[nivel-1];
            go.GetComponentInChildren<RawImage>().enabled = true;
            Application.LoadLevel("loadFile");
            StartCoroutine(waitLoadScene());
        }
    }

    IEnumerator waitLoadScene() {
        yield return new WaitForSeconds(1);
        if (Application.isLoadingLevel) {
            waitLoadScene();
        }
        GameObject go = GameObject.Find("CanvasAux");
        go.GetComponentInChildren<RawImage>().enabled = false;
        //go.SetActive(false);
    }

    public void gameOver(bool ghostWin, bool humanWin){
        GameObject go = GameObject.Find("CanvasAux");
        //go.SetActive(true);
        go.GetComponentInChildren<RawImage>().texture = gameOverText;
        if (ghostWin)
            go.GetComponentInChildren<Text>().text = "Ghosts win!!!";
        else
            go.GetComponentInChildren<Text>().text = "Humans win!!!";
        go.GetComponentInChildren<Text>().text += "\n\n Press esc to go back to main menu";
        go.GetComponentInChildren<RawImage>().enabled = true;
        go.GetComponentInChildren<Text>().enabled = true;
    }
}
