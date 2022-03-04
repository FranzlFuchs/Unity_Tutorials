using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    private float speed = 15.0f;
    private float turnSpeed = 50;


    private float horizontalInput;
    private float verticalInput;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Move forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);

        // Move sideward
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);


    }
}
