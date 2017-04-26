using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBar : MonoBehaviour {

    public float timer;
    float tempTimer;

    public Transform TimerInternal;

    bool checkAnswer;
    bool gotoCorrection;
    public static bool answerCorrect;

	void OnEnable () {
        answerCorrect = false;
        timer = timer / Time.timeScale;
        tempTimer = timer;
        checkAnswer = false;
        gotoCorrection = false;

        ManageScore.DEFAULT_SCORE = GameObject.Find("Score").transform.GetChild(0).GetComponent<ManageScore>().Score;

    }
	
	void Update () {

        if (!checkAnswer)
        {
            tempTimer -= Time.deltaTime;
            TimerInternal.GetComponent<Image>().fillAmount = tempTimer / timer;
        }

        if (TimerInternal.GetComponent<Image>().fillAmount == 0)
        {
            checkAnswer = true;
            gotoCorrection = true;
            if (gotoCorrection)
            {
                Correction();
                gotoCorrection = false;
            }   
        }
	}

    void Correction()
    {
        /*
            0 - Rock
            1 - Paper
            2 - Scissors
        */
        if (GiveQuestion.GivenQ == 0) // ROCK
        {
            if (BtnPress.Answer == 2)
            {
                GameObject.Find("Corrections").transform.GetChild(0).gameObject.SetActive(true);
                answerCorrect = true;
            }
        }
        else if (GiveQuestion.GivenQ == 1) // PAPER
        {
            if (BtnPress.Answer == 0)
            {
                GameObject.Find("Corrections").transform.GetChild(0).gameObject.SetActive(true);
                answerCorrect = true;
            }
        }
        else if (GiveQuestion.GivenQ == 2) // SCISSORS
        {
            if (BtnPress.Answer == 1)
            {
                GameObject.Find("Corrections").transform.GetChild(0).gameObject.SetActive(true);
                answerCorrect = true;
            }
        }

        if (answerCorrect)
        {
            Invoke("ResetRound", 1.0f);
            answerCorrect = false;
        }
    }

    void ResetRound()
    {
        GameObject.Find("Corrections").transform.GetChild(0).gameObject.SetActive(false);
        if (GameObject.Find("Signals") != null && GameObject.Find("Signals").gameObject.activeSelf)
            GameObject.Find("Signals").gameObject.SetActive(false);
        if (GameObject.Find("TimerBar") != null && GameObject.Find("TimerBar").gameObject.activeSelf)
            GameObject.Find("TimerBar").gameObject.SetActive(false);
        GameObject.Find("CountDown").GetComponent<CountDown>().CallEnableSignals();

        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Question"))
        {
            if (obj != null)
                Destroy(obj);
        }

        answerCorrect = false;

        if (ManageScore.DEFAULT_SCORE == GameObject.Find("Score").transform.GetChild(0).GetComponent<ManageScore>().Score)
            GameObject.Find("Score").transform.GetChild(0).GetComponent<ManageScore>().Score += 1;
    }
}
