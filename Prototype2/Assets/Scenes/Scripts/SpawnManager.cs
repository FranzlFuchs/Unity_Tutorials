using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] animalPrefabs = new GameObject[3];

    private int minXHor = -10;
    private int maxXHor = 10;
    private int spawnZHor = 25;

    private int maxZVer = 15;
    private int minZVer = 3;
    private int spawnY = 0;
    private int spawnXVer = -15;


    void Start()
    {
        Invoke("SpawnRandomAnimal", 1.5f);
    }

    // Update is called once per frame
    void Update()
    {



    }
    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        int ranNum = Random.Range(0, 2);
        //Vertikal
        if (ranNum == 0)
        {

            int randomX = Random.Range(minXHor, maxXHor);
            Instantiate(animalPrefabs[animalIndex], new Vector3(randomX, spawnY, spawnZHor), animalPrefabs[animalIndex].transform.rotation);


        }
        else
        {
            int randomZ = Random.Range(minZVer, maxZVer);
            Instantiate(animalPrefabs[animalIndex], new Vector3(spawnXVer, spawnY, randomZ), animalPrefabs[animalIndex].transform.rotation * Quaternion.Euler(0f, -90f, 0f));

        }

        Invoke("SpawnRandomAnimal", Random.Range(1.0f, 5.0f));

    }




}

