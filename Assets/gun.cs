using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    float angle = 0;
    public GameObject fpc;
    public Rigidbody2D rigid;
    public Camera cam;
    void LookAtMouse()
    {
        Vector3 temp;
        temp.x = 0;
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (fpc.transform.rotation.z > 0.7)
        {
            Debug.Log("1");
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log(fpc.transform.rotation);
                //Debug.Log(temp.x);
            }
        }
        else
        {
            Debug.Log("2");
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log(fpc.transform.rotation);

            }
        }
        fpc.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 180));

    }
    void LookAtMouse2()
    {
        Vector2 mousePos;

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = mousePos - rigid.position;
        float angel = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 180;
        rigid.rotation = angel;
    }
    private void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
           LookAtMouse2();
        //}
    }
}
