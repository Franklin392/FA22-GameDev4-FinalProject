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
    protected override void Interact()//Ҫ�����Ĺ���������д
    {
        Debug.Log("Yaw got a " + gameObject.name); //����д��debug������+���壻


        if (Input.GetKeyDown(KeyCode.E))
        {
            if (PickUp == true) //�������ʰȡ
            {
                gunswitch.haveMP5 = true;  //��ôӵ��ǹb
                gunswitch.haveScar = false; //ʧȥǹa

                if (gunswitch.ScarBool == true) //�����ʱ��ǹa
                {
                    gunswitch.MP5bool = true;   //����ǹB����
                    gunswitch.ScarBool = false;
                }


                Destroy(gameObject);
                Debug.Log("U can use MP5 now");

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