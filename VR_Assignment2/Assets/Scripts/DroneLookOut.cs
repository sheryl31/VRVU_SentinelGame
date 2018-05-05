using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneLookOut : MonoBehaviour {

	public float direction = 1;
	public float TargetAngle = 100;
	private float CurrentY = 0;
	private float step = 1;

	private GameObject Player;
	private PlayerController PlayerController;

	void Start() {
		Player = GameObject.FindGameObjectWithTag("Player");
		PlayerController = Player.GetComponent<PlayerController>();
	}

	void Update()
	{
		if (!PlayerController.alert) {
			
			CurrentY = transform.eulerAngles.y;
			if(CurrentY < 180.0f && CurrentY  > TargetAngle)
				direction = -step;
			else if(CurrentY > 180.0f && CurrentY < 360-TargetAngle)
				direction = step;

			transform.Rotate(0, direction * Time.deltaTime * 10, 0, Space.World);
		}
	}
}
