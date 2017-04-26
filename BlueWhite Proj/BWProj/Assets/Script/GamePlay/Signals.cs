using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signals : MonoBehaviour {

    float DEFAULT_TIMER;

    private float timer;

    private bool startSignal = false;
    bool[] signalLights = new bool[4];

    public GameObject TimerBar_;

    void OnEnable()
    {
        DEFAULT_TIMER = 4.0f / Time.timeScale;
        timer = DEFAULT_TIMER;
        ResetSignals();
        startSignal = true;
    }
    void Update()
    {
        if (startSignal)
        {
            timer -= Time.deltaTime;
            if (timer < DEFAULT_TIMER * 0.75f && !signalLights[0])
            {
                this.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.yellow;
                signalLights[0] = true;
            }
            else if (timer < DEFAULT_TIMER * 0.5f && !signalLights[1])
            {
                this.transform.GetChild(1).GetComponent<SpriteRenderer>().color = Color.yellow;
                signalLights[1] = true;
            }
            else if (timer < DEFAULT_TIMER * 0.25f && !signalLights[2])
            {
                this.transform.GetChild(2).GetComponent<SpriteRenderer>().color = Color.blue;
                signalLights[2] = true;
                TimerBar_.SetActive(true);
                GameObject.Find("QuestionGiver").GetComponent<GiveQuestion>().HandQuestion();
            }
            else if(timer < 0.0f )
            {
                if (TimerBar.answerCorrect)
                {
                    this.transform.GetChild(3).GetComponent<SpriteRenderer>().color = Color.green;
                }
            }
        }
    }

    void ResetSignals()
    {
        for (int i = 0; i < 3; i++)
        {
            signalLights[i] = false;
        }
        this.transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.white;
        this.transform.GetChild(1).GetComponent<SpriteRenderer>().color = Color.white;
        this.transform.GetChild(2).GetComponent<SpriteRenderer>().color = Color.white;
    }
}
