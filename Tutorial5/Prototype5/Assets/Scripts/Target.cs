using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody targetRb;
    private GameManager gameManager;

    public ParticleSystem explosion;

    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -2;
    public int pointsTarget;


    void Start()
    {
        targetRb = GetComponent<Rigidbody>();

        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPosition();

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider coll)
    {

        Destroy(gameObject);
        if (!CompareTag("Bad"))
        {
            gameManager.LiveLost();
        }
    }

    void OnMouseDown()
    {
        if (gameManager.gameIsActive)
        {

            Destroy(gameObject);
            gameManager.UpdateScore(pointsTarget);
          
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    Vector3 RandomSpawnPosition()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }
}
