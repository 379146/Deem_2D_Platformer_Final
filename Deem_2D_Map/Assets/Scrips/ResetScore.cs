using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ResetScore : MonoBehaviour
{
    private ScoreManager scoreManager;
    void Start()
    {
        GameObject scoreManagerObject = GameObject.Find("Score Manager");
        scoreManager = scoreManagerObject.GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ThePlayer"))
        {
            scoreManager.IncrementScore(-scoreManager.score);
        }
    }
}
