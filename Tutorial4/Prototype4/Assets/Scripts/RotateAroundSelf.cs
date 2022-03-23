using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundSelf : MonoBehaviour
{
    // Start is called before the first frame update


    private float rotSpeed = 500;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime);
    }
}
