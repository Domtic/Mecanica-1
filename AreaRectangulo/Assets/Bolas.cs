using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bolas : MonoBehaviour
{
    public GameObject bola1;
    public GameObject bola2;
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        
        

    }

    // Update is called once per frame
    void Update()
    {
        
        Instantiate(bola1, new Vector3(Random.Range(-20f,20f), Random.Range(-20f, 20f), Random.Range(-20f, 20f)), transform.rotation);
        Instantiate(bola2, new Vector3(Random.Range(-20f, 20f), Random.Range(-20f, 20f), Random.Range(-20f, 20f)), transform.rotation);
    }
}
