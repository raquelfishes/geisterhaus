using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuMultiOrSingle : MonoBehaviour {
    
    public Texture2D loading;

	private GameObject _gameState;

    private int numHumans = 2;
    private int numGhosts = 1;

	
	void Awake () {
		DontDestroyOnLoad(transform.gameObject);
	}

	void Start()
    {
	}

    public void playMultiPlayer()
    {
        _gameState = GameObject.FindWithTag("GameState");
        Color col = new Color(159, 50, 50, 255);
        GameObject.Find("MultiPlayer").GetComponentInChildren<Text>().color = col;
        _gameState.GetComponent<GameState>().setModeGame(0);
        _gameState.GetComponent<GameState>().setPlayer1(0); //jugador 1 fantasma
        _gameState.GetComponent<GameState>().setNivel(0);
        _gameState.GetComponent<GameState>().setNumHumans(numHumans);
        _gameState.GetComponent<GameState>().setNumGhosts(numGhosts);
        Application.LoadLevel("loadFile");
        _gameState.GetComponent<GameState>().audio.Stop();
        _gameState.GetComponent<GameState>().loadNextLevel();
    }

    public void playSinglePlayer()
    {
        Color col = new Color(159, 50, 50, 255);
        GameObject.Find("SinglePlayer").GetComponentInChildren<Text>().color = col;
        GameObject.Find("SingleHuman").GetComponent<Button>().enabled = true;
        GameObject.Find("SingleHuman").GetComponentInChildren<Text>().enabled = true;
        GameObject.Find("SingleGhost").GetComponent<Button>().enabled = true;
        GameObject.Find("SingleGhost").GetComponentInChildren<Text>().enabled = true;
    }

    public void playSingleHuman()
    {
        _gameState = GameObject.FindWithTag("GameState");
        Color col = new Color(50, 159, 50, 255);
        GameObject.Find("SingleHuman").GetComponentInChildren<Text>().color = col;
        _gameState.GetComponent<GameState>().setModeGame(2);
        _gameState.GetComponent<GameState>().setPlayer1(-1); //jugador 1 humanos
        _gameState.GetComponent<GameState>().setNivel(0);
        _gameState.GetComponent<GameState>().setNumHumans(numHumans);
        _gameState.GetComponent<GameState>().setNumGhosts(numGhosts);
        Application.LoadLevel("loadFile");
        _gameState.GetComponent<GameState>().audio.Stop();
        _gameState.GetComponent<GameState>().loadNextLevel();
    }

    public void playSingleGhost()
    {
        _gameState = GameObject.FindWithTag("GameState");
        Color col = new Color(50, 159, 50, 255);
        GameObject.Find("SingleGhost").GetComponentInChildren<Text>().color = col;
        _gameState.GetComponent<GameState>().setModeGame(1);
        _gameState.GetComponent<GameState>().setPlayer1(-1); //jugador 1 fantasma
        _gameState.GetComponent<GameState>().setNivel(0);
        _gameState.GetComponent<GameState>().setNumHumans(numHumans);
        _gameState.GetComponent<GameState>().setNumGhosts(numGhosts);
        Application.LoadLevel("loadFile");
        _gameState.GetComponent<GameState>().audio.Stop();
        _gameState.GetComponent<GameState>().loadNextLevel();
    }

    public void loadBack()
    {
        Color col = new Color(159, 50, 50, 255);
        GameObject.Find("Volver").GetComponentInChildren<Text>().color = col;
        Application.LoadLevel("MainMenu");
    }
}