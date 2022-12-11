using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MP5PickUp : Interactable
{
    public bool PickUp;
    public GameObject Player;
    GunSwitch gunswitch;
    void Start()
    {
        PickUp = false;
        Player = GameObject.FindWithTag("Player");
        gunswitch = Player.GetComponent<GunSwitch>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected override void Interact()//要交互的功能在这里写
    {
        Debug.Log("Yaw got a " + gameObject.name); //可以写想debug的文字+物体；


        if (Input.GetKeyDown(KeyCode.E))
        {
            if (PickUp == true) //如果可以拾取
            {
                gunswitch.haveR = true;  //那么拥有枪b
                gunswitch.haveHandGun = false; //失去枪a

                if (gunswitch.handgunBool == true) //如果此时有枪a
                {
                    gunswitch.R = true;   //就让枪B激活
                    gunswitch.handgunBool = false;
                }


                Destroy(gameObject);
                Debug.Log("U can use revolver now");

            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PickUp = true;
        }
    }
}
