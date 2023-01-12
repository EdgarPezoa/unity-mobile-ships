using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    private void Start()
    {
        ResetScore();
    }

    //CUSTOM METHODS
    public void AddScore(int score)
    {
        scoreText.text = (int.Parse(scoreText.text) + score).ToString("00000");
    }

    public void ResetScore()
    {
        scoreText.text = "00000";
    }
}
