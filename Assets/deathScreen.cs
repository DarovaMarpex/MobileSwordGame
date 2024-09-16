using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class deathScreen : MonoBehaviour
{
    public Text score;
    GameObject holder;
    public void Respawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void MainMenu()
    {
        Application.Quit();
    }
    private void Update()
    {
        
        score.text = holder.GetComponent<ScoreCounter>().scoreInt.ToString();
    }
    private void Start()
    {
        holder = GameObject.FindGameObjectWithTag("MainCamera");
    }

}
