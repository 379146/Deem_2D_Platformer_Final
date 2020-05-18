using System.Collections;
using System.Collections.Generic;
using UnityEngine;





[RequireComponent(typeof (Collider2D))]
public class CollectItem : MonoBehaviour
{

    private ScoreManager scoreManager;

    private void Start()
    {


        GameObject scoreManagerObject = GameObject.Find("Score Manager");
        scoreManager = scoreManagerObject.GetComponent<ScoreManager>();


    }




    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Collectable"))
        {

            scoreManager.IncrementScore(1);

            Destroy(collision.gameObject);

        }
        //else if (collision.CompareTag("baddiebody"))
        //{
        //    Debug.Log("AAAAAHHHHH");
        //    SceneManager.LoadScene("Death Screen");

        //}






    
    }

}
