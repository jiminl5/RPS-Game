using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextOrder : MonoBehaviour {

    public GameObject[] Texts;
    GameObject txt;

    void OnEnable()
    {
        /*
         0 - Blue
         1 - White
         2 - Both
         3 - None   
        */
        int rand = Random.Range(0, 4);

        txt = (GameObject)Instantiate(Texts[rand], Vector2.zero, Quaternion.identity);
        txt.transform.parent = this.transform;
        txt.transform.localPosition = Vector2.zero;
    }
}
