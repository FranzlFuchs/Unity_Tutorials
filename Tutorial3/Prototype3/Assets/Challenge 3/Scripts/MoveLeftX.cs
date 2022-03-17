using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftX : MonoBehaviour
{

    private float speedRaiseTimerUp;
    

    private PlayerControllerX playerControllerScript;
    private SpeedManager speedManager;
    private float leftBound = -10;

    public bool greenPowerUpflag;
    private float powerUpInterval = 10f;
    private float timer;
 

    // Start is called before the first frame update
    void Start()
    {
        timer = powerUpInterval;
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerX>();
        speedManager = GameObject.Find("Speed").GetComponent<SpeedManager>();

        speedRaiseTimerUp = 5;
        
    }

    // Update is called once per frame
    void Update()
    {
        speedManager = GameObject.Find("Speed").GetComponent<SpeedManager>();
        
        timer -= Time.deltaTime;

        // If game is not over, move to the left
        if (!playerControllerScript.gameOver)
        {
            transform.Translate(Vector3.left * speedManager.speed * Time.deltaTime, Space.World);
        }

        // If object goes off screen that is NOT the background, destroy it
        if (transform.position.x < leftBound && !gameObject.CompareTag("Background"))
        {
            Destroy(gameObject);
        }

        if (timer <= 0 && !playerControllerScript.gameOver)
        {
            speedManager.RaiseSpeed(speedRaiseTimerUp);
            timer = powerUpInterval;
            Debug.Log("Speed raised to " + speedManager.speed);
        }

      
           
            
        

    }
}
