using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour {

    public GameObject countDown;

    string countDownTxt;
    int countDownInt;

    private float timer = 0.3f;
    private float animationTimer = 0.03f;
    private float setTimer = 0.5f;
    private Vector2 initialVector;

    public GameObject Signals;

    public GameObject Character;

	void Start () {
        countDownTxt = countDown.GetComponent<Text>().text;
        initialVector = new Vector2(0.0f, 0.0f);
	}
	
	void Update () {
        timer -= Time.deltaTime;
		if (countDown.transform.localScale.x < 1.0f && timer < 0.0f)
        {
            animationTimer -= Time.deltaTime;
            if (animationTimer < 0.0f)
            {
                countDown.transform.localScale = new Vector2(countDown.transform.localScale.x + 0.1f, countDown.transform.localScale.y + 0.1f);
                animationTimer = 0.03f;
                int.TryParse(countDownTxt, out countDownInt);
                setTimer = 0.5f;
            }
        }
        else if (countDown.transform.localScale.x >= 1.0f)
        {
            setTimer -= Time.deltaTime;
            if (setTimer < 0.0f)
            {
                if (countDownTxt == "GO!")
                {                  
                    GameObject.Find("Main Camera").GetComponent<SetButtons>().enabled = true;
                    countDown.gameObject.SetActive(false);
                    countDown.transform.parent.GetComponent<CountDown>().enabled = false;
                    if (!countDown.transform.parent.GetComponent<CountDown>().enabled)
                    {
                        Character.gameObject.SetActive(true);
                        GameObject.Find("Score").transform.GetChild(0).gameObject.SetActive(true);
                        Invoke("EnableSignals", 1.5f);
                    }
                }
                if (countDownInt > 1)
                {
                    countDownTxt = (countDownInt - 1).ToString();
                    countDown.GetComponent<Text>().text = countDownTxt;
                }
                else if (countDownInt <= 1)
                {
                    countDownTxt = "GO!";
                    countDown.GetComponent<Text>().fontSize = 3;
                    countDown.GetComponent<Text>().text = countDownTxt;
                }
                countDown.transform.localScale = initialVector;
            }
        }
	}

    void EnableSignals()
    {
        Signals.SetActive(true);
    }

    public void CallEnableSignals()
    {
        Invoke("EnableSignals", 0.5f);
    }
}
