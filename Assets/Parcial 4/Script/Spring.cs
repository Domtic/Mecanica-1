using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    public float K;
    public float M;
    public float balanceD =0;
    public float A;
    public float v;
    public float T;
    public float f;
    public float dampening;
    public float acc;


    public Transform spring;
    public Transform cube1, cube2;
    public void Test()
    {
        float displacement = balanceD-A;
        dampening = K * displacement;
        acc += ((K / M) * displacement) - dampening;

        spring.localScale = new Vector3(spring.localScale.x, spring.localScale.y- acc, spring.localScale.z);
    }
}
