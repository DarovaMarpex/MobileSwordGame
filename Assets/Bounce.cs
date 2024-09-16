using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    private Rigidbody2D rigid;
    public float knockbackSpeed;

    Vector2 lastVelocity;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        lastVelocity = rigid.velocity;
    }
   private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.transform.tag == "wall")
        {
            var speed = knockbackSpeed;
            var direction = Vector3.Reflect(lastVelocity.normalized, coll.contacts[0].normal);

            rigid.velocity = direction * Mathf.Max(speed, 0f);
        }

    }
}
