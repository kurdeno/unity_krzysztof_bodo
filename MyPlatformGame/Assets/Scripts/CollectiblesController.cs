﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblesController : MonoBehaviour
{

    public ScoreScript scoreScript;
    public GameObject scoreText;
    public AudioSource collectSound;

    public void Start()
    {
        scoreText = GameObject.Find("ScoreText");
       scoreScript = scoreText.GetComponent<ScoreScript>();
        collectSound = GetComponent<AudioSource>();

    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag.Equals("Collectable") == true)
        {
            collectSound.Play();
            scoreScript.scoreValue += 10;
            Destroy(other.gameObject);
        }
    }

}
