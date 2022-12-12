using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HGpickUp : Interactable
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
                gunswitch.haveHandGun = true;  //��ôӵ��ǹb
                gunswitch.haveR = false; //ʧȥǹa

                if (gunswitch.R == true) //�����ʱ��ǹa
                {
                    gunswitch.handgunBool = true;   //����ǹB����
                    gunswitch.R = false;
                }


                Destroy(gameObject);
                Debug.Log("U can use HANDGUN now");

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
