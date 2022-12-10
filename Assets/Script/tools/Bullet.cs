using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 20;
    public GameObject Blood;
    private void Awake()
    {
        Destroy(gameObject, life);
    }

    private void Start()
    {
        Blood.SetActive(false);
    }
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
            Blood.SetActive(true);
            zombie1Script.TakeDamageNow(other);
           //gameoverappear.SetActive(true);

           Debug.Log("Bullet Hit normal zombie!");
        }
        if (FatBody != null)
        {
            Blood.SetActive(true);
            FatBody.TakeDamageNow(other);
            //gameoverappear.SetActive(true);

            Debug.Log("Bullet Hit! fatzombie");
        }
        if (ChickenBody != null)
        {
            Blood.SetActive(true);
            ChickenBody.TakeDamageNow(other);
            //gameoverappear.SetActive(true);

            Debug.Log("Bullet Hit! chicken zombie ");
        }
        if (TankBody != null)
        {
            Blood.SetActive(true);
            TankBody.TakeDamageNow(other);
            //gameoverappear.SetActive(true);

            Debug.Log("Bullet Hit tank zombie!");
        }





    }
}
