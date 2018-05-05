using UnityEngine;
using System.Collections;

public class GunController : MonoBehaviour {

    public AudioSource audio;
    public AudioClip shoot;
    public GameObject FireParticle;
    public Light fireLight;
    public float delay;
    float fireTime;
    float effectsDisplayTime = 0.2f;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        fireTime += Time.deltaTime;
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Shoot();
        }

        if (fireTime >= delay * effectsDisplayTime)
        {
            // ... disable the effects.
            Enabled();
        }

    }


    void Shoot()
    {
        if (fireTime > delay)
        {
            fireTime = 0;
            audio.PlayOneShot(shoot);
            FireParticle.SetActive(true);
            fireLight.enabled = true;
        }
    }

    void Enabled()
    {
        FireParticle.SetActive(false);
        fireLight.enabled = false;
    }
}
