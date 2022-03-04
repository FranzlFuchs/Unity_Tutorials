using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnPropeller : MonoBehaviour
{
  
    private float rotationSpeed = 500.0f;
    private float minVertInput = 0.2f;


    public float horizontalInput;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput <= 0)
        {
            horizontalInput = minVertInput;
        }

        this.transform.Rotate(Vector3.forward, Time.deltaTime * rotationSpeed + horizontalInput);
    }
}
