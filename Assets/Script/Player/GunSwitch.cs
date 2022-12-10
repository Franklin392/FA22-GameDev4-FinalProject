using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSwitch : MonoBehaviour
{
    public GameObject SCAR;
    public GameObject pistol;
    public GameObject Axe;
    public GameObject revolver;



    //按键bool
    public bool handgunBool;
    public bool ScarBool;
    public bool AXE;
    public bool R;

    //是否装备Bool
    public bool haveScar;
    public bool haveHandGun;
    public bool haveR;
    //public bool have;
    //public bool haveR;
    //public bool haveR;

    void Start()
    {
        SCAR.SetActive(true);


        pistol.SetActive(false);

        Axe.SetActive(false);


        revolver.SetActive(false);

        ScarBool = true;
        AXE = false;
        handgunBool = false;
        R = false;

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

    //--------------------------------------------------------------------------------------------------------------------

        //主武器按键
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ScarBool = true;


            handgunBool = false;
            R = false;
            AXE = false;

        }

        //副武器按键
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
          
            ScarBool = false;
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

        //近战按键
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
