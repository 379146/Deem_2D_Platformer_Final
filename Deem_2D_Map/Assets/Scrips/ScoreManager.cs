using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : Singleton<MonoBehaviour>
{

    public int score { get; private set; }

    private void Start()
    {

        score = 0;

    }

    public void IncrementScore(int increment = 1)
    {

        score += increment;

    }

}
