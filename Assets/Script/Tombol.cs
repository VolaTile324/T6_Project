using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tombol : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

	public AudioSource buttonSound;

	public void scale(float scale){
		transform.localScale = new Vector2 (1 / scale, 1 * scale);
		buttonSound.PlayOneShot (buttonSound.clip);
	}

	public void scene(string scene){
		Application.LoadLevel (scene);
		buttonSound.PlayOneShot (buttonSound.clip);
	}	

	// Update is called once per frame
	void Update () {

	}
}

