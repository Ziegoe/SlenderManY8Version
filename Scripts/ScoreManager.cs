using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public static int scoreCount;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        scoreText.text = "0" + Mathf.Round(scoreCount);
    }
}
