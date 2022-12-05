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

        if (zombie1Script != null)
        {
            zombie1Script.TakeDamageNow(other);
           //gameoverappear.SetActive(true);

           Debug.Log("Bullet Hit!");
        }





    }
}
