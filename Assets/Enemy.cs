using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject appleSlicePreVertical;
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.transform.tag == "player")
        {

            Instantiate(appleSlicePreVertical, this.transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}

