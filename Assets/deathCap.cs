using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathCap : MonoBehaviour
{
    public GameObject deathScreen;
    public GameObject player;
    public GameObject logPrefab;
    public GameObject[] ObjectSamples;
    float randNum;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "player" && other.tag != "back")
        {
            // Instantiate(logPrefab, new Vector3(Random.Range(-2f, 2f), player.transform.position.y + (7f + Random.Range(0.5f, 1.5f))), Quaternion.identity);
                randNum = Random.Range(0, 6);
                for (int i = 0; i < ObjectSamples.Length; i++)
                {
                   if (other.tag == "Targets")
                   {
                        if (i == randNum)
                        {
                            Instantiate(ObjectSamples[i], new Vector3(0.4f, player.transform.position.y + 8.3f, 0), Quaternion.identity);
                        }
                    
                    GameObject currParent = other.gameObject.transform.parent.gameObject;
                    Destroy(other.gameObject);
                    Destroy(currParent);
                   }
                }
            Destroy(other.gameObject);
            
        }
        if (other.tag == "player")
        {
            deathScreen.SetActive(true);
            other.GetComponent<InputByTouch>().ableToMove = false;
        }
        
        
    }
}
