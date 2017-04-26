using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetButtons : MonoBehaviour {

    public GameObject CtrlBtn;

    GameObject BtnRock;
    GameObject BtnPaper;
    GameObject BtnScis;

    public GameObject Rock;
    public GameObject Paper;
    public GameObject Scissor;

    GameObject RockChild;
    GameObject PaperChild;
    GameObject ScissorChild;

    void Start () {
        CtrlBtn.transform.localScale = new Vector2(0.3f, 1.0f);

        BtnRock = (GameObject)Instantiate(CtrlBtn, new Vector2(-1.85f, -3.2f), Quaternion.identity);
        BtnPaper = (GameObject)Instantiate(CtrlBtn, new Vector2(0.0f, -3.2f), Quaternion.identity);
        BtnScis = (GameObject)Instantiate(CtrlBtn, new Vector2(1.85f, -3.2f), Quaternion.identity);

        RockChild = (GameObject)Instantiate(Rock, new Vector2(0.0f, 0.0f), Quaternion.identity);
        PaperChild = (GameObject)Instantiate(Paper, new Vector2(0.0f, 0.0f), Quaternion.identity);
        ScissorChild = (GameObject)Instantiate(Scissor, new Vector2(0.0f, 0.0f), Quaternion.identity);

        RockChild.transform.parent = BtnRock.transform;
        PaperChild.transform.parent = BtnPaper.transform;
        ScissorChild.transform.parent = BtnScis.transform;

        RockChild.transform.localPosition = Vector2.zero;
        PaperChild.transform.localPosition = Vector2.zero;
        ScissorChild.transform.localPosition = Vector2.zero;

        BtnRock.gameObject.tag = "Rock";
        BtnPaper.gameObject.tag = "Paper";
        BtnScis.gameObject.tag = "Scissor";
    }
}
