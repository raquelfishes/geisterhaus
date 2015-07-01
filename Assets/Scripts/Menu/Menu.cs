using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Menu : MonoBehaviour {

    public void loadMenuMulti()
    {
        Color col = new Color(159, 50, 50, 255);
        GameObject.Find("Jugar").GetComponentInChildren<Text>().color = col;
        Application.LoadLevel("MultiOrSingleMenu");
    }

    public void loadCredits()
    {
        Color col = new Color(159, 50, 50, 255);
        GameObject.Find("Credits").GetComponentInChildren<Text>().color = col;
        Application.LoadLevel("Credits");
    }

    public void loadExit()
    {
        Color col = new Color(159, 50, 50, 255);
        GameObject.Find("Salir").GetComponentInChildren<Text>().color = col;
        Application.Quit();
    }

    public void loadMainMenu()
    {
        Color col = new Color(159, 50, 50, 255);
        GameObject.Find("Quit").GetComponentInChildren<Text>().color = col;
        Application.LoadLevel("MainMenu");
    }
}
