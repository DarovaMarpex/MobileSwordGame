using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputByTouch : MonoBehaviour
{
    
    public bool ableToMove;
    public bool ableToLook;
    public float power = 10f;
    public Rigidbody2D RB;
    public LineRenderer LR;
    public GameObject aim;
    public GameObject objectToRotate;
    public GameObject targetToLookAt;
    public GameObject top1;
    public GameObject top2;
    public GameObject bot1;
    public GameObject bot2;
    private GameObject currentTop;
    private GameObject currentBot;
    public Collider2D colider;
    public float TimeRemaining;
    bool turnOffCollider = true;
    Transform currentParent;
    Vector3 vec;

    public RepeatingBackGround rep1;
    public RepeatingBackGround rep2;
    RepeatingBackGround currentRep;

    Vector3 dragStartPos;
    Touch touch;

    private void Start()
    {
        ableToMove = false;
        aim.gameObject.SetActive(false);
        RB.GetComponent<Rigidbody2D>();
        currentParent = RB.transform.parent;
        colider.GetComponent<Collider2D>();
        rep1.GetComponent<RepeatingBackGround>();
        rep2.GetComponent<RepeatingBackGround>();

    }
    private void Update()
    {
        GetCurrentPoints();
        if (RB.transform.position.y >= currentTop.transform.position.y)
        {

            //RB.transform.position = new Vector3(transform.position.x, currentBot.transform.position.y, 1);
            currentRep.RepeatBackGround();
            //if (currentRep  ==  rep1)
            //{
            //    rep2.transform.position = new Vector3(-1.6f, 8.21f, 100);
            //    rep1.transform.position = new Vector3(-1.6f, 18.27f, 100);
            //}
            //else
            //{
            //    rep1.transform.position = new Vector3(-1.6f, 8.21f, 100);
            //    rep2.transform.position = new Vector3(-1.6f, 18.27f, 100);
            //}
            //RB.transform.position = new Vector3(-0.67f, -2.2f, transform.position.z);
        }
        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                DragStart();
            }
            if (touch.phase == TouchPhase.Moved)
            {
                Dragging();
            }
            if (touch.phase == TouchPhase.Ended)
            {
                DragRelease();
            }
        }
        FaceDirection();
        if(!ableToMove)
        {
            RB.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        else
        {
            RB.constraints = RigidbodyConstraints2D.None;
        }
        if(TimeRemaining > 0)
        {
            TimeRemaining -= Time.deltaTime;
            colider.isTrigger = true;
        }
        else
        {
            colider.isTrigger = false;
        }
    }

    void DragStart()
    {
        aim.gameObject.SetActive(true);
        LookAtTarget();
    }
    void Dragging()
    {
        objectToRotate.transform.Rotate(0f, 0f, -touch.deltaPosition.x/3.5f);
    }
    void DragRelease()
    {
        if (turnOffCollider)
        {
            TimeRemaining = 0.018f;
        }
        ableToLook = true;
        ableToMove = true;
        RB.transform.SetParent(currentParent);
        RB.bodyType = RigidbodyType2D.Dynamic;
        Throw();
        aim.gameObject.SetActive(false);
        turnOffCollider = false;


    }
    void Throw()
    {
        RB.velocity = objectToRotate.transform.up * power;
    }
   
    void FaceDirection()
    {
        if (ableToLook)
        {
            float angle = Mathf.Atan2(RB.velocity.x, RB.velocity.y) * -Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

    }
    void LookAtTarget()
    {
        objectToRotate.transform.eulerAngles = new Vector3(0, 0, 0);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Log")
        {
            
            RB.transform.SetParent(collision.transform);
            RB.bodyType = RigidbodyType2D.Kinematic;
            ableToLook = false;
            turnOffCollider = true;
            

        }
    }
    void GetCurrentPoints()
    {
        if (top1.transform.position.y > top2.transform.position.y)
        {
            currentTop = top1;
            currentRep = rep2;
        }
        else
        {
            currentTop = top2;
            currentRep = rep1;
        }
        if (bot1.transform.position.y < bot2.transform.position.y)
        {
            currentBot = bot1;
        }
        else
        {
            currentBot = bot2;
        }
    }

}
