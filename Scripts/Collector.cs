using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Collector : MonoBehaviour
{
    public AudioSource audioPlayer;
    public int count;
    public Text scoreText;
    public static int scoreCount;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collectable"))
        {
            count++;
            Destroy(collision.gameObject);
            ScoreManager.scoreCount += 1;
            audioPlayer.Play();
        }
    }
}
