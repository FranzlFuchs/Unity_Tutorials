using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject[] dogPrefabs;
    int optDog = 0;

    private float[] SpawnInterval = {1.0f, 1.5f, 2.5f};

    private float timeLastInstants = 0;
    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (timeLastInstants + SpawnInterval[optDog] < Time.time)
            {
                timeLastInstants = Time.time;
                Instantiate(dogPrefabs[optDog], transform.position, dogPrefabs[optDog].transform.rotation);
            }

        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            optDog = (optDog + 1) % dogPrefabs.Length;
            Debug.Log(dogPrefabs[optDog].name);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            optDog = (optDog - 1) % dogPrefabs.Length;
            Debug.Log(dogPrefabs[optDog].name);
        }

    }
}
