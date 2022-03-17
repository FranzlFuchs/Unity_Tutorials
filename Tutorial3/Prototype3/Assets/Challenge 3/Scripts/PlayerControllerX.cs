using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver;

    public float floatForce = 0.5f;
    public float bounceForce = 200.0f;
    private float gravityModifier = 2f;
    private float score;
    private float speedDownPowerUp;


    private Rigidbody playerRb;


    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;
    public ParticleSystem powerUpParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;
    public AudioClip bounceSound;
    private SpeedManager speedManager;




    // Start is called before the first frame update
    void Start()
    {
        speedDownPowerUp = -1;
        score = 0;


        speedManager = GameObject.Find("Speed").GetComponent<SpeedManager>();
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
        //war nicht da
        playerRb = GetComponent<Rigidbody>();

        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {


        // While space is pressed and player is low enough, float up
        if (Input.GetKey(KeyCode.Space) && !gameOver)
        {
            playerRb.AddForce(Vector3.up * floatForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over! Final Score: " + score);
            Destroy(other.gameObject);
        }

        // if player collides with money, fireworks

        if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);
            score ++;
            Debug.Log("MONEY! Score: " + score);

        }

        if (other.gameObject.CompareTag("Ground") && !gameOver)
        {

            playerAudio.PlayOneShot(bounceSound, 1.0f);
            playerRb.AddForce(Vector3.up * bounceForce);

        }

        if (other.gameObject.CompareTag("Ceiling"))
        {

            playerAudio.PlayOneShot(bounceSound, 1.0f);
            playerRb.AddForce(Vector3.down * bounceForce);

        }


        if (other.gameObject.CompareTag("GreenPowerUp"))
        {

            playerAudio.PlayOneShot(moneySound, 1.0f);
            powerUpParticle.Play();

            if (speedManager.speed > 2 && !gameOver)
            {
                Debug.Log("Power up! " + speedManager.speed + speedDownPowerUp + "= " + (speedManager.speed + speedDownPowerUp));

                speedManager.RaiseSpeed(speedDownPowerUp);
                Destroy(other.gameObject);

            }
            else
            {
                Debug.Log("No Speed Lowering possible, speed is" + speedManager.speed);
            }
        }

    }

}
