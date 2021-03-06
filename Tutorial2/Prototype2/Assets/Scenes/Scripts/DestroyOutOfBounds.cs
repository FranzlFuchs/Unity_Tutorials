using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    // Start is called before the first frame update

    private float topBound = 30;
    private float lowerBound = -10;
    private float rightBound = 40;

    public bool projectile;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound)
        {
            Destroy(this.gameObject);
        }
        else if (transform.position.z < lowerBound || transform.position.x > rightBound)
        {
            if (!projectile)
            {
                Debug.Log("Game Over");
            }
            Destroy(this.gameObject);
        }

    }
}
