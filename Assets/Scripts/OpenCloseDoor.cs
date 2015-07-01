using UnityEngine;
using System.Collections;

public class OpenCloseDoor : MonoBehaviour {

	// Use this for initialization
	void Start () { }
	
	// Update is called once per frame
	void Update () { }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Human")
            gameObject.transform.Rotate(new Vector3(0.0f, 90.0f, 0.0f));
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Human")
            gameObject.transform.Rotate(new Vector3(0.0f, -90.0f, 0.0f));
    }
}
