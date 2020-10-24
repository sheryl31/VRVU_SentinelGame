using UnityEngine;
using System.Collections;

public class DestroyObject : MonoBehaviour {


    public float lifeTime;

	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, lifeTime);
	}
}
