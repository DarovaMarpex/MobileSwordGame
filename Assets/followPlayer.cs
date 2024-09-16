using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public GameObject player;
    public bool goesUp = false;
    public bool canFollow = false;
    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
{
        if (player.GetComponent<Rigidbody2D>().velocity.y > 0)
        {
            goesUp = true;
            
        }
        else
        {
            goesUp = false;
        }
        if (goesUp)
        {
            if (canFollow)
            {
                if(this.tag == "MainCamera")
                {
                    transform.position = new Vector3(transform.position.x, player.transform.position.y, -100);
                }
                else
                {
                    transform.position = new Vector3(transform.position.x, player.transform.position.y, 100);
                }
                
            }
        }

        
    }
     private void OnTriggerExit2D(Collider2D other)
     {
        if (other.tag == "player")
        {
            canFollow = true;
        }
     }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "player")
        {
            canFollow = false;
        }
    }
}
