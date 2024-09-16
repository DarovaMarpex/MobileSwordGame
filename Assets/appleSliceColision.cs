using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class appleSliceColision : MonoBehaviour
{
    Collider2D swordColider;
    void Start()
    {
        GameObject gos;
        gos = GameObject.FindGameObjectWithTag("player");
         swordColider = gos.GetComponent<Collider2D>();
        
    }
    void Update()
    {
        Physics2D.IgnoreCollision(swordColider, this.GetComponent<Collider2D>());
    }
}
