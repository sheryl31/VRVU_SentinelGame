using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportObjectController : MonoBehaviour {


	private Vector3 startingPosition;
	private Renderer myRenderer;

	public Material inactiveMaterial;
	public Material gazedAtMaterial;

	private GameObject gazedObj;
	private float gazedTime = -1f;
	private bool check = false;
	private ParticleSystem particleSys;

	void Start() {
		startingPosition = transform.localPosition;
		myRenderer = GetComponent<Renderer>();
		particleSys = GetComponent<ParticleSystem>();
		SetGazedAt(false);
	}

	public void Update() {

		if (gazedObj != null) {

			if (Time.time - gazedTime > 3.0f) {
				gazedObj = null;
				gazedTime = -1f;
				Teleport();
			}
		}
	}

	public void SetGazedAt(bool gazedAt) {
		if (inactiveMaterial != null && gazedAtMaterial != null) {
			myRenderer.material = gazedAt ? gazedAtMaterial : inactiveMaterial;
			//return;
		}

		if (gazedAt) {
			gazedObj = gameObject;
			gazedTime = Time.time;
			particleSys.Play();

		} else {
			gazedObj = null;
			gazedTime = -1f;
			particleSys.Stop();
		}
	}

	public void Recenter() {
		#if !UNITY_EDITOR
		GvrCardboardHelpers.Recenter();
		#else
		if (GvrEditorEmulator.Instance != null) {
			GvrEditorEmulator.Instance.Recenter();
		}
		#endif  // !UNITY_EDITOR
	}

	public void Teleport() {

		// teleport player to gazed object
		GameObject.FindGameObjectWithTag("Player").transform.position = gameObject.transform.position;
		gameObject.SetActive(false);
		SetGazedAt(false);
	}
}
