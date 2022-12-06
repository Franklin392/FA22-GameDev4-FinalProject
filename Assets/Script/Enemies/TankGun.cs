using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankGun : MonoBehaviour
{
    Transform Player;
    public float dist;//distance
    public float MaxDistance;

    public Transform head, barrel;
    public GameObject projecttile;

    public float BulletSpeed;
    public float fireRate, nextFire;

    public AudioSource Shot;
    public AudioClip Bullet;

   

    public int CoolingTime;


    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;

        

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        dist = Vector3.Distance(Player.position, transform.position);

        if (dist <= MaxDistance)
        {

           
                head.LookAt(Player);

                if (Time.time >= nextFire)
                {
                    nextFire = Time.time + 1f / fireRate;
                    shoot();
                }
            

            

        }
        else
        {
            CoolingTime = 4;
        }

    }

    public void shoot()
    {
        CoolingTime -= 1;

        if (CoolingTime <= 0)
        {
            Shot.PlayOneShot(Bullet);
            GameObject clone = Instantiate(projecttile, barrel.position, head.rotation);

            clone.GetComponent<Rigidbody>().AddForce(head.forward * BulletSpeed);
            Destroy(clone, 5);
        }


    }
   
}
