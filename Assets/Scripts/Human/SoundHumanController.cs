using UnityEngine;
using System.Collections;

public class SoundHumanController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void soundOut() {
        AudioSource[] audios = gameObject.GetComponentsInChildren<AudioSource>();
        foreach (AudioSource audio in audios) {
            if (audio.name == "soundOut")
                audio.Play();
        }
    }

    public void soundHurt() {
        AudioSource[] audios = gameObject.GetComponentsInChildren<AudioSource>();
        foreach (AudioSource audio in audios)
        {
            if (audio.name == "soundHurt")
                audio.Play();
        }
    }


    public void soundKill() {
        AudioSource[] audios = gameObject.GetComponentsInChildren<AudioSource>();
        foreach (AudioSource audio in audios)
        {
            if (audio.name == "soundKill")
                audio.Play();
        }
    }
}
