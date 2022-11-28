using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPad : Interactable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected override void Interact()//要交互的功能在这里写
    {
        Debug.Log("Interacter with 我很帅" + gameObject.name); //可以写想debug的文字+物体；

        Debug.Log(" 我很帅");
    }
}
