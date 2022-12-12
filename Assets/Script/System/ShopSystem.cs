using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSystem : Interactable
{
    public ScoreManager ScoreGet;
    public GameObject ShopMENU;
    public GameObject HealthBag;
    public GameObject ammoBag;

    public bool CanBuyNOW;
    void Start()
    {
        
        ShopMENU.SetActive(false);
        HealthBag.SetActive(false);
        ammoBag.SetActive(false);

        CanBuyNOW = false;
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

    }
    public void Buyrevolver()
    {

    }
    public void BuyAmmo()
    {
        ScoreGet.BuyAmmo();
        HealthBag.SetActive(true);
    }
    public void BuyHealth()
    {
        ScoreGet.BuyHealth();
        ammoBag.SetActive(true);
    }
}
