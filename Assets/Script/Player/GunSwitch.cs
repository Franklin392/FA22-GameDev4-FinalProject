using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSwitch : MonoBehaviour
{
    public GameObject SCAR;
    public GameObject pistol;
    public GameObject Axe;
    public GameObject revolver;
    public GameObject MP5;



    //按键bool
    public bool handgunBool;
    public bool ScarBool;
    public bool AXE;
    public bool R;
    public bool MP5bool;

    //是否装备Bool
    public bool haveScar;
    public bool haveHandGun;
    public bool haveR;
    public bool haveMP5;
    //public bool have;
    //public bool haveR;
    //public bool haveR;

    void Start()
    {
        SCAR.SetActive(true);


        pistol.SetActive(false);

        Axe.SetActive(false);


        revolver.SetActive(false);
        MP5.SetActive(false);

        ScarBool = true;
        AXE = false;
        handgunBool = false;
        R = false;
        MP5bool = false;
        //初始装备：有scar 和 手枪 
        haveHandGun = true;
        haveScar = true;
    }

    // Update is called once per frame
    void Update()
    {   
        //装备枪
        //SCAR 步枪
        if (ScarBool == true)
        {
            SCAR.SetActive(true);
        }
        else
        {
            SCAR.SetActive(false);
        }

        //手枪

        if (handgunBool == true)
        {
            pistol.SetActive(true);
        }
        else
        {
            pistol.SetActive(false);
        }
        //斧头
        if (AXE == true)
        {
            Axe.SetActive(true);
        }
        else
        {
            Axe.SetActive(false);
        }

        //左轮
        if (R == true)
        {
            revolver.SetActive(true);
        }
        else
        {
            revolver.SetActive(false);
        }

        // MP5
        if (    MP5bool == true)
        {
            MP5.SetActive(true);
        }
        else
        {
            MP5.SetActive(false);
        }

        //--------------------------------------------------------------------------------------------------------------------

        //主武器按键 primary weapon
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {   
            //first weapon

            //ScarBool = true;
            if (haveScar == true)
            {
                ScarBool = true;
                haveMP5 = false;

            }
            else
            {
                ScarBool = false;
                haveMP5 = true;
            }
            //是否有左轮
            if (haveMP5 == true)
            {
                MP5bool = true;
                ScarBool = false;
            }
            else
            {
                MP5bool = false;
               ScarBool = true;
            }



            //SECOND WEAPON
            handgunBool = false;
            R = false;
            //third weapon
            AXE = false;

        }

        //副武器按键 secondary weapon 
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
          
            ScarBool = false;
            MP5bool = false;
            AXE = false;
            //是否有手枪
            if(haveHandGun == true)
            {
                handgunBool = true;
                haveR = false;

            }
            else
            {
                handgunBool = false;
                haveR = true;
            }
            //是否有左轮
            if (haveR == true)
            {
                R = true;
                handgunBool = false;
            }
            else
            {
                R = false;
                handgunBool = true;
            }
        }

        //近战按键 third close weapon
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            AXE = true;

            ScarBool = false;
            handgunBool = false;
            MP5bool = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {

    }
}
