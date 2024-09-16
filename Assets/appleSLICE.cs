using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class appleSLICE : MonoBehaviour
{
    GameObject ChildGameObject1;
    GameObject ChildGameObject2;
    Collider2D applepice1;
    public GameObject ParentGameObject;
    public float appleKnockback;
    // Start is called before the first frame update
    void Start()
    {

        GameObject ChildGameObject1 = ParentGameObject.transform.GetChild(0).gameObject;
        GameObject ChildGameObject2 = ParentGameObject.transform.GetChild(1).gameObject;
        if (ParentGameObject.transform.tag == "horiz")
        {
            ChildGameObject1.GetComponent<Rigidbody2D>().AddForce(Vector2.up * appleKnockback);
            ChildGameObject2.GetComponent<Rigidbody2D>().AddForce(Vector2.down * appleKnockback);
            Destroy(ChildGameObject1, 3);
            Destroy(ChildGameObject2, 3);
        }
        if (ParentGameObject.transform.tag == "vertic")
        {
            ChildGameObject1.GetComponent<Rigidbody2D>().AddForce(Vector2.left * appleKnockback);
            ChildGameObject2.GetComponent<Rigidbody2D>().AddForce(Vector2.right * appleKnockback);
            Destroy(ChildGameObject1, 3);
            Destroy(ChildGameObject2, 3);
            Destroy(gameObject, 3);
        }
    }
    
    
}
