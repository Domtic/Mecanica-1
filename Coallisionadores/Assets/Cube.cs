using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Cube : MonoBehaviour
{
    public MeshRenderer textura;
    public Texture2D text1;
    public Texture2D text2;
    

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
  
            textura.material.mainTexture = text2;
       
      /*  print("Golpee con este:" + collision.gameObject);
        Debug.DrawRay(collision.contacts[0].point, collision.contacts[0].normal, Color.blue, 1f);
        print("Normal:" + collision.contacts[0].normal);*/
    }
    //Solo se llama cuando uno de los objetos involucrados esta en movimiento
    //Excepto si uni tiene collision detection en modo continous
    private void OnCollisionStay(Collision collision)
    {

    }
    private void OnCollisionExit(Collision collision)
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        textura.material.mainTexture = text2;
    }

    private void OnTriggerStay(Collider other)
    {
        textura.material.mainTexture = text2;
    }

    private void OnTriggerExit(Collider other)
    {
        textura.material.mainTexture = text1;
    }
}
