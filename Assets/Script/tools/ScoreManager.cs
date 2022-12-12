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

        scoreText.text = score.ToString() + "Points";


        //TextTime.GetComponent<Text>().text = "Time Left:" + TimeLeft;
        //StartCoroutine(TimerTake());


    }
    void Update()
    {
        

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
    //public void ResetRotation()
    //{
    //    Reset.SetActive(true);
    //    Debug.Log("Reset");

    //}
    //public void FalseReset()
    //{
    //    Reset.SetActive(false);
    //}

}
