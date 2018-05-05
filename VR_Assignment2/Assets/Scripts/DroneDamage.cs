using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneDamage : MonoBehaviour {

	public GameObject Player;
	private GameObject SoundManager;

	private PlayerController PlayerController;
	private AudioSource FxLazer;
	private Renderer renderer;
	private Color startColor;


	void Start() {
		PlayerController = Player.GetComponent<PlayerController>();
		SoundManager = GameObject.FindGameObjectWithTag("SoundManager");
		FxLazer = SoundManager.GetComponentInChildren<AudioSource>();
		renderer = GetComponent<Renderer>();
		startColor = renderer.material.color;
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			FxLazer.Play();
			renderer.material.color = Color.red;
			StartCoroutine(WaitAndPLayMusic());
		}
	}

	private IEnumerator WaitAndPLayMusic() {

		yield return new WaitForSeconds(0.5f);
		PlayerController.alert = true;

		yield return new WaitForSeconds(2.0f);
		PlayerController.alive = false;
		renderer.material.color = startColor;
	}
}
