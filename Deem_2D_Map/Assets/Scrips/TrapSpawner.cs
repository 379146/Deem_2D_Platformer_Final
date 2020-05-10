using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSpawner : MonoBehaviour
{

    [SerializeField] private GameObject trapPrefab;


    void Start()
    {
       StartCoroutine("PerformSpawning");


        //IEnumerator spawnEnumerator = PerformSpawning();
        //StartCoroutine(spawnEnumerator);

        // ...

        //StopCoroutine(spawnEnumerator);


    }

    private void Spawn()
    {

        Instantiate(trapPrefab, transform.position, trapPrefab.transform.rotation, transform);

    }


    IEnumerator PerformSpawning()
    {
        while (true)
        {

            Spawn();
            yield return new WaitForSeconds(0.5f);

            Spawn();
            yield return new WaitForSeconds(0.5f);

            Spawn();
            yield return new WaitForSeconds(2f);

        }
        

    }


}
