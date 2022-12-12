using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSystem : Interactable
{
    public ScoreManager ScoreGet;
    public GameObject ShopMENU;
    public GameObject HealthBag;
    public GameObject ammoBag;

    public Transform Gun;

    public GameObject PREFABhealth;
    public GameObject PREFABammo;
    public GameObject PREFABmp5;
    public GameObject PREFABhandgun;
    public GameObject PREFABscar;
    public GameObject PREFABrevolver;

    public bool CanBuyNOW;
    void Start()
    {
        
        ShopMENU.SetActive(false);
        HealthBag.SetActive(false);
        ammoBag.SetActive(false);

        CanBuyNOW = false;

        Transform Ammo = ammoBag.transform;
        Transform Health = HealthBag.transform;
    }

    // Update is called once per frame
    void Update()
    {  

        if(CanBuyNOW == true)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                Debug.Log("buy AMMO");
                BuyAmmo();

            }
            if (Input.GetKeyDown(KeyCode.Y))
            {
                Debug.Log("buy health");
                BuyHealth();

            }

            if (Input.GetKeyDown(KeyCode.U))
            {
                Debug.Log("buy mp5");
                BuyMP5();

            }

            if (Input.GetKeyDown(KeyCode.I))
            {
                Debug.Log("buy revolver");
                Buyrevolver();

            }

            if (Input.GetKeyDown(KeyCode.O))
            {
                Debug.Log("buy handgun");
                BuyHandGun();

            }

            if (Input.GetKeyDown(KeyCode.P))
            {
                Debug.Log("buy SCAR");
                BuySCAR();

            }
        }
       
    }
    protected override void Interact()//要交互的功能在这里写
    {
        Debug.Log("Shop now " );

        if (Input.GetKeyDown(KeyCode.E))
        {

            ShopMENU.SetActive(true);
            CanBuyNOW = true;
        }
        
    }
    public void BuyMP5()
    {
        ScoreGet.BuyMP5();
        Instantiate(PREFABmp5, Gun.position, Gun.rotation);



    }
    public void Buyrevolver()
    {
        ScoreGet.Buyrevolver();
        Instantiate(PREFABrevolver, Gun.position, Gun.rotation);

    }
    public void BuySCAR()
    {
        ScoreGet.BuySCAR();
        Instantiate(PREFABscar, Gun.position, Gun.rotation);




    }
    public void BuyHandGun()
    {
        ScoreGet.BuyHandGun();
        Instantiate(PREFABhandgun, Gun.position, Gun.rotation);





    }
    public void BuyAmmo()
    {
        ScoreGet.BuyAmmo();
        HealthBag.SetActive(true);
        Transform Health = HealthBag.transform;
        Instantiate(PREFABammo, Health.position, Health.rotation);
    }
    public void BuyHealth()
    {
        ScoreGet.BuyHealth();
        ammoBag.SetActive(true);
        Transform Ammo = ammoBag.transform;
        Instantiate(PREFABhealth, Ammo.position, Ammo.rotation);
    }
}
