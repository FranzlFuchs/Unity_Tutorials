using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    public Rigidbody playerRb;
    public GameObject focalPoint;
    public GameObject powerUpIndicator;
    public float forwSpeed = 100;
    public float powerUpStrength = 20.0f;
    public float powerUpboost = 5.0f;

    private float growthFactor = 1.2f;


    public bool hasPowerUp;

    private int powerUpCooldown = 7;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
        powerUpIndicator.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float forwInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * forwSpeed * forwInput);
        powerUpIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);


        if (transform.position.y < -5)
        {
            Debug.Log("GAME OVER");
        }

    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            powerUpIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountdownRoutine(powerUpCooldown));
        }

        if (other.CompareTag("PowerUpGreen"))
        {
            transform.localScale = transform.localScale * growthFactor;
            powerUpStrength += powerUpboost;
            Destroy(other.gameObject);

        }

    }
    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("Enemy") && hasPowerUp)
        {

            Rigidbody enemyRb = other.gameObject.GetComponent<Rigidbody>();

            Vector3 knockbackDirection = other.gameObject.transform.position - transform.position;

            enemyRb.AddForce(knockbackDirection * powerUpStrength, ForceMode.Impulse);

        }
    }

    private IEnumerator PowerUpCountdownRoutine(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        powerUpIndicator.gameObject.SetActive(false);
        hasPowerUp = false;
    }
}
