using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VOID : MonoBehaviour
{


    void Start()
    {
      
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("ThePlayer"))
        {
            SceneManager.LoadScene("Death Screen");

        }

    }


}
