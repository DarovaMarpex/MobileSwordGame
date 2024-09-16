using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public float currentScore;
    public int scoreInt;
    public Text score;
    // Update is called once per frame
    void Update()
    {
        currentScore = this.transform.position.y;
        scoreInt = (int)currentScore;
        score.text = scoreInt.ToString();
    }
}
