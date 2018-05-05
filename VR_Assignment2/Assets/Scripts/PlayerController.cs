using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public bool alive = true;
	public bool alert = false;
	private Vector3 startPos;
	private Vector3 endPos;
	public GameObject endObj;
	private GameObject[] allPortals;
	public GameObject winPanel;

	void Start() {
		allPortals = GameObject.FindGameObjectsWithTag("Portal");
		startPos = transform.position;
		winPanel.SetActive(false);
		endPos = endObj.transform.position;
	}

	void Update () {

		if (!alive) {
			transform.position = startPos;

			foreach(GameObject portal in allPortals) {
				portal.SetActive(true);
			}
			alive = true;
			alert = false;
		}

		if (Vector3.Distance(transform.position, endPos) == 0f) {
			winPanel.SetActive(true);
		}
	}
}
