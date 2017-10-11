using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	public bool isDestroyed;
	public int shotsToBreak = 1;
	public int maxHealth = 1;
	private int health = 0;
	public Material focusedMaterial;
	public Material builtMaterial;
	public Material destroyedMaterial;
	private Renderer rend;
	private Animator anim;

	public AudioSource audiosource;
	public AudioClip destroyclip;
	public AudioClip buildclip;

	void Awake(){

		rend = GetComponent<Renderer> ();
		health = maxHealth;
		anim = GetComponent<Animator> ();
	}


	void OnTriggerEnter(Collider col){
	
		if (col.tag == "Shot") {
		
			if (!isDestroyed) {

				Hit ();

				if (health <= 0) {
					Destroy ();
				}

				col.gameObject.GetComponent<Shot> ().Destroy ();

			}
		

		}
	
	}

	public void Hit(){
		health -= 1;
	}


	public void Destroy(){
	
		isDestroyed = true;
		rend.enabled = false;
		health = 0;

		EZCameraShake.CameraShaker.Instance.LongShake ();

		audiosource.PlayOneShot (destroyclip);
	
	}


	public void Build(){

		isDestroyed = false;
		rend.enabled = true;
		rend.material = builtMaterial;
		health = maxHealth;
		anim.SetTrigger ("Shine");

		audiosource.PlayOneShot (buildclip);

//		EZCameraShake.CameraShaker.Instance.ShortShake ();

	}


	public void Focus(){

		if (isDestroyed) {
			rend.enabled = true;
			rend.material = focusedMaterial;
		}

	}

	public void Unfocus(){

		if (isDestroyed) {
			rend.enabled = false;
		}

	}
}
