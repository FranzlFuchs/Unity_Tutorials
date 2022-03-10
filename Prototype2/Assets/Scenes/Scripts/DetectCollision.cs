using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{


    public int pointsOnDeath; 


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        ScoreManager.GetInstance().AddPoints(pointsOnDeath);
        Destroy(gameObject);
        Destroy(other.gameObject);
    }


}
