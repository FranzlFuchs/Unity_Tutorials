using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    public Rigidbody enemyRigidB;
    public GameObject player;

    void Start()
    {
        enemyRigidB = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = ( player.transform.position - transform.position ).normalized;
        enemyRigidB.AddForce(lookDirection * speed);

        if(transform.position.y < -5){
            Destroy(gameObject);
        }
    }
}
