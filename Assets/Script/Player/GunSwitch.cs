using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSwitch : MonoBehaviour
{
    public GameObject SCAR;
    public GameObject pistol;
    public GameObject Axe;
    public GameObject revolver;



    //����bool
    public bool handgunBool;
    public bool ScarBool;
    public bool AXE;
    public bool R;

    //�Ƿ�װ��Bool
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

        //��ʼװ������scar �� ��ǹ 
        haveHandGun = true;
        haveScar = true;
    }

    // Update is called once per frame
    void Update()
    {   
        //װ��ǹ
        //SCAR ��ǹ
        if (ScarBool == true)
        {
            SCAR.SetActive(true);
        }
        else
        {
            SCAR.SetActive(false);
        }

        //��ǹ

        if (handgunBool == true)
        {
            pistol.SetActive(true);
        }
        else
        {
            pistol.SetActive(false);
        }
        //��ͷ
        if (AXE == true)
        {
            Axe.SetActive(true);
        }
        else
        {
            Axe.SetActive(false);
        }

        //����
        if (R == true)
        {
            revolver.SetActive(true);
        }
        else
        {
            revolver.SetActive(false);
        }

    //--------------------------------------------------------------------------------------------------------------------

        //����������
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ScarBool = true;


            handgunBool = false;
            R = false;
            AXE = false;

        }

        //����������
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
          
            ScarBool = false;
            AXE = false;
            //�Ƿ�����ǹ
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
            //�Ƿ�������
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

        //��ս����
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
