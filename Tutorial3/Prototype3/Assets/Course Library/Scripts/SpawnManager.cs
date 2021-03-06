using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstacle;
    private Vector3 spawnVector = new Vector3(25, 0, 0);

    private float repeatRate = 2;
    private float startDelay = 3;
    private PlayerController playerControllerScript;


    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacles", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnObstacles()
    {
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(obstacle, spawnVector, obstacle.transform.rotation);
        }
    }
}
