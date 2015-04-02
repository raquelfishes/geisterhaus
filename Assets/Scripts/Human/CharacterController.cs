using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {
	
	private Animator anim;
	
	// Use this for initialization
	void Awake () {
		anim = GetComponent<Animator>();

	}
	
	public void setGrounded(bool g){
		anim.SetBool ("isGrounded", g);
		anim.speed = 0.3f;
	}
	
	public void setJumping(bool g){
		if (!anim.GetBool("isJumping")) {
			anim.SetBool ("isJumping", g);
			anim.SetTrigger("SaltaInsentato");
		}
	}
	
	public void MuereInsensato()
	{
		anim.SetTrigger("Death");
	}
}
