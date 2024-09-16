using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject sword;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(sword.transform.position.x, sword.transform.position.y, 1);
        if (this.gameObject.tag == "objToMove")
        {
            this.transform.position = new Vector3(sword.transform.position.x, sword.transform.position.y, -50);
        }
    }
}
