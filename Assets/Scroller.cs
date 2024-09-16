using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    private Rigidbody2D rigid;
    private float bgSpeed = -1.5f;
    GameObject inpt;
    public bool isMoving = false;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = new Vector2(0, bgSpeed);
        inpt = GameObject.FindGameObjectWithTag("player");

    }
    private void Update()
    {
        if(inpt.gameObject.GetComponent<InputByTouch>().ableToMove == false)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }

        if (!isMoving)
        { 
            rigid.velocity = Vector2.zero;
        }
        else
        {
            if (this.transform.childCount != 0)
            {
                if (this.transform.GetChild(0).tag != "player")
                {
                    rigid.velocity = new Vector2(0, bgSpeed);   
                }
                else
                {
                    this.transform.GetChild(0).GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                }
            }
            else
            {
                rigid.velocity = new Vector2(0, bgSpeed);
            }
        }
    }
}
