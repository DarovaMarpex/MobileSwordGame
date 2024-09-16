using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogScript : MonoBehaviour
{
    InputByTouch player;
    private Vector2 direction;
    public float speed = 1;
    
    // Start is called before the first frame update

   
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, 1);
        }
    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player").GetComponent<InputByTouch>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(direction * speed * Time.deltaTime);
        //if (transform.position.y <= -5.5)
        //{
        //    Destroy(this.gameObject);
        //}
    }
    private void OnDestroy()
    {
        if (this.transform.childCount != 0)
        {
            if (this.transform.GetChild(0).tag == "player")
            {
                GameObject sceneEnd = GameObject.FindGameObjectWithTag("DeathLine");
                sceneEnd.GetComponent<deathCap>().deathScreen.SetActive(true);
                GameObject holder = this.transform.GetChild(0).transform.gameObject;
                this.transform.GetChild(0).transform.parent = null;
                holder.GetComponent<InputByTouch>().ableToMove = false;
            }
        }
    }
}
