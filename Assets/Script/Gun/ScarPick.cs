using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScarPick : Interactable
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
                gunswitch.haveScar = true;  //��ôӵ��ǹb
                gunswitch.haveMP5 = false; //ʧȥǹa

                if (gunswitch.MP5bool == true) //�����ʱ��ǹa
                {
                    gunswitch.ScarBool = true;   //����ǹB����
                    gunswitch.MP5bool = false;
                }


                Destroy(gameObject);
                Debug.Log("U can use SCAR now");

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
