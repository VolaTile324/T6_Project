using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keluar : MonoBehaviour
{
    public void scale(float scale){
		transform.localScale = new Vector2 (1 / scale, 1 * scale);
	}

	public void scene(string scene){
		Application.LoadLevel (scene);
	}

	public void Quit() {
		Application.Quit ();
		Debug.Log ("Quit");
	}
}

