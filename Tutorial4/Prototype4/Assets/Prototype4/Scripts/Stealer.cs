using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stealer : MonoBehaviour
{ // Start is called before the first frame update

    public float speed;
    public Rigidbody enemyRigidB;
    public GameObject PowerUp;
    public ParticleSystem PowerUpDeath;

    void Start()
    {
        speed = 5;
        enemyRigidB = GetComponent<Rigidbody>();
        PowerUp = GameObject.Find("PowerUp(Clone)");
        if (PowerUp == null)
        {
            PowerUp = GameObject.Find("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (PowerUp == null)
        {
            PowerUp = GameObject.Find("Player");
        }
        Vector3 lookDirection = (PowerUp.transform.position - transform.position).normalized;
        enemyRigidB.AddForce(lookDirection * speed);


        if (transform.position.y < -5)
        {
            Destroy(gameObject);
        }
    }

      private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("PowerUp"))
        {
            
            Destroy(other.gameObject);
            Destroy(gameObject);            
            
        }

    }
}
