using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackGround : MonoBehaviour
{
    private BoxCollider2D backGroundColider;
    private float backGroundSize;

    // Start is called before the first frame update
    private void Start()
    {
        backGroundColider = GetComponent<BoxCollider2D>();
        backGroundSize = backGroundColider.bounds.size.y;
    }
    void Update()
    {
        if (transform.position.y < -backGroundSize)
        {
            RepeatBackGround();
        }
    }

    // Update is called once per frame
    public void RepeatBackGround()
    {
        Vector3 backGroundOffset = new Vector3(0, backGroundSize * 1.97f, -1);
        transform.position = (Vector3)transform.position + backGroundOffset;
        //transform.parent.gameObject.transform.position = new Vector3(1.3f, -9.3f, 100);
        //Debug.Log(transform.parent.gameObject.transform.position);
    }
}
