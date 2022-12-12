using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public Vector3 roatation;
    public float speed;

    //public int coins;
    //public ScoreManager SM;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(roatation * speed * Time.deltaTime);
    }
  
}
