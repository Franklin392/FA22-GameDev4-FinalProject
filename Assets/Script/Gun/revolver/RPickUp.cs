using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPickUp : Interactable
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
    protected override void Interact()//Ҫ�����Ĺ���������д
    {
        Debug.Log("Yaw got a " + gameObject.name); //����д��debug������+���壻
        

        if (Input.GetKeyDown(KeyCode.E))
        {
            if(PickUp == true) //�������ʰȡ
            {
                gunswitch.haveR = true;  //��ôӵ��ǹb
                gunswitch.haveHandGun = false; //ʧȥǹa

                if(gunswitch.handgunBool == true) //�����ʱ��ǹa
                {
                    gunswitch.R = true;   //����ǹB����
                    gunswitch.handgunBool = false;
                }
                

                Destroy(gameObject);
                Debug.Log("U can use revolver now");

            }
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PickUp = true;
        }
    }
}