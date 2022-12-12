using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTransfom : MonoBehaviour
{
    public Transform Player;
    void Start()
    {
        //find player
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
