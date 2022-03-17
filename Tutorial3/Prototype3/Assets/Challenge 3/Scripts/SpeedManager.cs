using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : MonoBehaviour
{
    public float speed = 10;

    public void RaiseSpeed(float addSpeed){
        speed += addSpeed;
    }
}
