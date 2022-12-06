using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 20;
    private void Awake()
    {
        Destroy(gameObject, life);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        zombie1 zombie1Script = other.GetComponentInParent<zombie1>();
        FatZombie FatBody = other.GetComponentInParent<FatZombie>();
        ChickenZombie ChickenBody = other.GetComponentInParent<ChickenZombie>();
        TankZombie TankBody = other.GetComponentInParent<TankZombie>();

        if (zombie1Script != null)
        {
            zombie1Script.TakeDamageNow(other);
           //gameoverappear.SetActive(true);

           Debug.Log("Bullet Hit normal zombie!");
        }
        if (FatBody != null)
        {
            FatBody.TakeDamageNow(other);
            //gameoverappear.SetActive(true);

            Debug.Log("Bullet Hit! fatzombie");
        }
        if (ChickenBody != null)
        {
            ChickenBody.TakeDamageNow(other);
            //gameoverappear.SetActive(true);

            Debug.Log("Bullet Hit! chicken zombie ");
        }
        if (TankBody != null)
        {
            TankBody.TakeDamageNow(other);
            //gameoverappear.SetActive(true);

            Debug.Log("Bullet Hit tank zombie!");
        }





    }
}
