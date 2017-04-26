using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnPress : MonoBehaviour
{
    public static int Answer;

    public Sprite[] btnTransition;

    private int AnswAnim = Animator.StringToHash("_perform_ans");
    private Animator animator;

    void Start()
    {
        animator = GameObject.Find("Character").GetComponent<Animator>();
        Answer = 3;
    }

    void OnMouseDown()
    {
        animator.SetInteger(AnswAnim, 1);

        if (this.gameObject.tag == "Rock")
        {
            Answer = 0;
        }
        else if (this.gameObject.tag == "Paper")
        {
            Answer = 1;
        }
        else if (this.gameObject.tag == "Scissor")
        {
            Answer = 2;
        }



        this.GetComponent<SpriteRenderer>().sortingOrder = 1;
        this.GetComponent<SpriteRenderer>().sprite = btnTransition[1];
    }

    void OnMouseUp()
    {
        animator.SetInteger(AnswAnim, 0);
        //GameObject.Find("Testing").GetComponent<SpriteRenderer>().color = new Color(Red, Green, Blue, 1.0f);
        Answer = 3;
        this.GetComponent<SpriteRenderer>().sortingOrder = 0;
        this.GetComponent<SpriteRenderer>().sprite = btnTransition[0];
    }
}