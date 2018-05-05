using UnityEngine;
using System.Collections;

public class TurretController : MonoBehaviour
{


    public Rigidbody rocket;
    public Transform[] rocketSpawn;
    public float rocketSpeed;
    public float delay=1f;
    private float nextFire = 0.0f;

    int rocketIndex = 0;
    void Update()
    {
        nextFire += Time.deltaTime;
        if (Input.GetKey(KeyCode.Mouse0) && nextFire>delay)
        {
            if (rocketIndex == 16)
            {
                rocketIndex = 0;
            }
            Shoot();
            Debug.Log(rocketIndex);
        }

    }

    void Shoot()
    {

        nextFire = 0.0f;
            Rigidbody rig = Instantiate(rocket, rocketSpawn[rocketIndex].position, rocket.transform.rotation) as Rigidbody;
            rig.AddForce(Vector3.left * rocketSpeed * Time.deltaTime);
            rocketIndex += 1;
        
    }
      


}
