using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseAttack : MonoBehaviour
{
    public PlayerHealth playerhealth;
    public float attacknumber;
    void Start()
    {
        
    }
    private void Awake()
    {

        //find player
        playerhealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Hit player");
            playerhealth.TakeDamage(attacknumber);
        }


    }



  }
