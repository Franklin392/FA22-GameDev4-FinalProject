using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSwitch : MonoBehaviour
{
    public GameObject SCAR;
    public GameObject pistol;
    public GameObject Axe;



    //bool
    public bool handgunBool;
    public bool ScarBool;
    public bool AXE;
    void Start()
    {
        SCAR.SetActive(true);


        pistol.SetActive(false);

        Axe.SetActive(false);

        ScarBool = true;
        AXE = false;
        handgunBool = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (ScarBool == true)
        {
            SCAR.SetActive(true);
        }
        else
        {
            SCAR.SetActive(false);
        }


        if (handgunBool == true)
        {
            pistol.SetActive(true);
        }
        else
        {
            pistol.SetActive(false);
        }

        if (AXE == true)
        {
            Axe.SetActive(true);
        }
        else
        {
            Axe.SetActive(false);
        }





        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
           handgunBool = true;

            ScarBool = false;
            AXE = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ScarBool = true;


            handgunBool = false;
            AXE = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            AXE = true;

            ScarBool = false;
            handgunBool = false;
            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
    }
}
