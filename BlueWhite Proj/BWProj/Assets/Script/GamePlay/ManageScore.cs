using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageScore : MonoBehaviour {

    private int _Score;

    public static int DEFAULT_SCORE;

    void Start()
    {
        Score = 0;
    }

    public int Score {
        get {
            return _Score;
        }
        set{
            _Score = value;
            this.GetComponent<Text>().text = Score.ToString();
        }
    }
}
