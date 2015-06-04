using UnityEngine;
using System.Collections;

public class SoundGhostController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void soundSelect()
    {
        AudioSource[] audios = gameObject.GetComponentsInChildren<AudioSource>();
        foreach (AudioSource audio in audios)
        {
            if (audio.name == "soundSelect")
                audio.Play();
        }
    }
}
