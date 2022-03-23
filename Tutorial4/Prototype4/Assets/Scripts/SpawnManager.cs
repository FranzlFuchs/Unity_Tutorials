using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject enemyPrefab;
    public GameObject powerUpPrefab;

    private float spawnRange = 9;
    private int waveNumber = 1;

    public int enemieCount;
    void Start()
    {
        SpawnEnemies(waveNumber);
    }

    // Update is called once per frame
    void Update()
    {
        

        enemieCount = FindObjectsOfType<FollowPlayer>().Length;

        if(enemieCount <= 0){

            waveNumber++;
            SpawnEnemies(waveNumber);
        }

    }
    public Vector3 GenerateSpawnPoint()
    {

        return new Vector3(Random.Range(-spawnRange, spawnRange), 0, Random.Range(-spawnRange, spawnRange));

    }

    public void SpawnEnemies(int enemies)
    {
        for (int i = 0; i < enemies; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPoint(), enemyPrefab.transform.rotation);
        }
            Instantiate(powerUpPrefab, GenerateSpawnPoint(), enemyPrefab.transform.rotation);
    }
}

