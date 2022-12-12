using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour
{
    public float life = 10;
    void Start()
    {
        Destroy(gameObject, life);
    }
}
