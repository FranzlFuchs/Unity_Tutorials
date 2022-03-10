using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed;
    public float xRange;
    public float zMax;
    public float zMin;

    public int specialUses;

    public GameObject projectilePrefabForward;
    public GameObject projectilePrefabBackward;



    // Start is called before the first frame update
    void Start()
    {
        speed = 20;
        xRange = 10;
        zMax = 15;
        zMin = 0;
        specialUses = 3;
    }

    // Update is called once per frame

    void Update()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }


        if (transform.position.z < zMin)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zMin);
        }

        if (transform.position.z > zMax)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zMax);
        }

        horizontalInput = Input.GetAxis("Horizontal");

        this.transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        verticalInput = Input.GetAxis("Vertical");

        this.transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);







        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(projectilePrefabForward, transform.position, projectilePrefabForward.transform.rotation);
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Instantiate(projectilePrefabBackward, transform.position, projectilePrefabBackward.transform.rotation);
        }

        if (Input.GetKeyDown(KeyCode.Space) && specialUses > 0)
        {
            Instantiate(projectilePrefabForward, transform.position, projectilePrefabForward.transform.rotation );
            Instantiate(projectilePrefabForward, transform.position, projectilePrefabForward.transform.rotation * Quaternion.Euler(0f, -45f, 0f));           
            Instantiate(projectilePrefabForward, transform.position, projectilePrefabForward.transform.rotation * Quaternion.Euler(0f, 45f, 0f));
            Instantiate(projectilePrefabBackward, transform.position, projectilePrefabBackward.transform.rotation);
            Instantiate(projectilePrefabBackward, transform.position, projectilePrefabBackward.transform.rotation* Quaternion.Euler(0f, -45f, 0f));
            Instantiate(projectilePrefabBackward, transform.position, projectilePrefabBackward.transform.rotation* Quaternion.Euler(0f, 45f, 0f));
            specialUses --;
            Debug.Log("Special Uses Left: " + specialUses.ToString());
        }


    }
}
