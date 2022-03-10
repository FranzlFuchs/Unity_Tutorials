using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] animalPrefabs = new GameObject[3];

    private int minX = -10;
    private int maxX = 10;
    private int spawnY = 0;
    private int spawnZ = 25;


    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", 2, 1.5f);

    }

    // Update is called once per frame
    void Update()
    {



    }
    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        int randomX = Random.Range(minX, maxX);


        Instantiate(animalPrefabs[animalIndex], new Vector3(randomX, spawnY, spawnZ), animalPrefabs[animalIndex].transform.rotation);

    }
}
