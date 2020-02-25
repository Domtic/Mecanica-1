using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class esfera : MonoBehaviour
{
    public Rigidbody rigi;
    // Start is called before the first frame update
    void Start()
    {
        rigi = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //AddForce es en jules y velocity en velocidad
        if (Input.GetKeyDown(KeyCode.Space))
        {
           // rigi.AddForce(Vector3.up * 200f);
            rigi.AddForce(transform.up * 200f);
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            //Fisicas ya usan delta time
            rigi.velocity = Vector3.up * 6f;
        }
    }
}
