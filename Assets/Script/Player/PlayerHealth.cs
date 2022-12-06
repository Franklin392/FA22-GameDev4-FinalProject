using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private float health;
    private float lerpTimer;
    public float maxHealth = 100;
    public float chipSpeed = 2f;
    public Image frontHealthBar;
    public Image backHealthBar;


    public GameObject GameOver;
    void Start()
    {
        health = maxHealth;

        Time.timeScale = 1f;
        GameOver.SetActive(false);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateHealthUI();

        //if(Input.GetKeyDown(KeyCode.Q))
        //{
        //    TakeDamage(Random.Range(5, 10));
        //}
        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    //RestoreHealth(Random.Range(5, 10));
        //    RestoreHealth(2);
        //}

        if(health <= 0)
        {
            GameOver.SetActive(true);
            Time.timeScale = 0f;

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;


        }
    }
    public void UpdateHealthUI()
    {
        //Debug.Log(health);
        float fillF = frontHealthBar.fillAmount;
        float fillB = backHealthBar.fillAmount;
        float hFraction = health / maxHealth;

        if(fillB > hFraction) // taking damage;
        {
            frontHealthBar.fillAmount = hFraction;
            backHealthBar.color = Color.red;

            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;

            percentComplete = percentComplete * percentComplete;

            backHealthBar.fillAmount = Mathf.Lerp(fillB, hFraction, percentComplete);

        }
       
        if(fillF < hFraction) //²¹Ñª
        {
            backHealthBar.color = Color.green;
            backHealthBar.fillAmount = hFraction;

            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;

            percentComplete = percentComplete * percentComplete;

            frontHealthBar.fillAmount = Mathf.Lerp(fillF, backHealthBar.fillAmount, percentComplete);
        }

    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        lerpTimer = 0f;
    }
    public void RestoreHealth(float healAmount)
    {
        health += healAmount;
        lerpTimer = 0f;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bomb")
        {
            TakeDamage(3);
        }
        if (other.gameObject.tag == "Health")
        {
            RestoreHealth(60);
            Debug.Log("Get Back Health");
        }
    }

}
