using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveQuestion : MonoBehaviour {

    public GameObject[] questions;

    GameObject selectedQ;

    public static int GivenQ;

    /*
        0 - Rock
        1 - Paper
        2 - Scissor
    */
	public void HandQuestion () {
        int rand = Random.Range(0, 3);
        GivenQ = rand;
        selectedQ = (GameObject)Instantiate(questions[rand], new Vector2(0.0f, 3.2f), Quaternion.identity);
	}
}
