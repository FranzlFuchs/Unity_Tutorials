using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterCooldownX : MonoBehaviour
{
    // Start is called before the first frame update


    private int cooldown = 5;

    void Start()
    {
        StartCoroutine(PowerUpLifetime());

    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator PowerUpLifetime()
    {
        yield return new WaitForSeconds(cooldown);
        Destroy(gameObject);
    }
}
