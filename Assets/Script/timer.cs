using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour{
    public Text TextTimer;
	public float waktu = 100;// 01:30
	public bool GameAktif =true;
	public GameObject CanvasKalah;

    void SetText()
	{
		int menit = Mathf.FloorToInt (waktu / 30);// 01
		int detik = Mathf.FloorToInt (waktu % 30);// 30
		TextTimer.text = menit.ToString("00") +":"+ detik.ToString("00");
	}

	float s;

	private void Update()
	{
		if (GameAktif) {
			s += Time.deltaTime;
			if (s > 1) {
				waktu--;
				s = 0;
			}
		}
		if (GameAktif && waktu <= 0) {
			Debug.Log ("Game Selesai");
			CanvasKalah.SetActive (true);
			GameAktif = false;
		}

		

		SetText ();


		}
	}

