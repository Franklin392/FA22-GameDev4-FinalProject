using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI scoreText;


    //计分器
    public int score = 0;

    public bool CanBuy;

    //计时器
    //public GameObject TextTime;
    //public int TimeLeft = 80;
    //public bool takingAway = false;

    //重置字母
    //public GameObject Reset;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {

        //Reset.SetActive(false);
        score = 2000;
        scoreText.text = score.ToString() + "Points";


        //TextTime.GetComponent<Text>().text = "Time Left:" + TimeLeft;
        //StartCoroutine(TimerTake());
        

    }
    void Update()
    {
        if(score > 0)
        {
            CanBuy = true;
        }
        else
        {
            CanBuy = false;
        }

    }
    public void AddCoinPoint()
    {
        score += 20;
        scoreText.text = score.ToString() + "Points";
    }
    public void AddCoinPoint2()
    {
        score += 50;
        scoreText.text = score.ToString() + "Points";
    }
    public void AddCoinPoint3()
    {
        score += 30;
        scoreText.text = score.ToString() + "Points";
    }
    public void AddCoinPoint4()
    {
        score += 100;
        scoreText.text = score.ToString() + "Points";
    }

    public void BuyMP5()
    {
        if (CanBuy == true)
        {
            score -= 200;
            scoreText.text = score.ToString() + "Points";
        }
    }
    public void Buyrevolver()
    {
        if (CanBuy == true)
        {
            score -= 80;
            scoreText.text = score.ToString() + "Points";
        }
    }
    public void BuySCAR()
    {
        if (CanBuy == true)
        {
            score -= 150;
            scoreText.text = score.ToString() + "Points";
        }
    }
    public void BuyHandGun()
    {
        if (CanBuy == true)
        {
            score -= 100;
            scoreText.text = score.ToString() + "Points";
        }
    }

    public void BuyAmmo()
    {   
        if(CanBuy == true)
        {
            score -= 50;
            scoreText.text = score.ToString() + "Points";
        }
        
    }
    public void BuyHealth()
    {
        if (CanBuy == true)
        {
            score -= 100;
            scoreText.text = score.ToString() + "Points";
        }

    }

}
