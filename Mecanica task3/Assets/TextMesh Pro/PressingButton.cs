using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressingButton : MonoBehaviour
{
    float gravity = 9.8f;
    float Weight = 1;
    float CWeight = 1;
    float force = 0;
    bool beingPressed;
    float speed = 0.2f;
    bool hitting, startGravity,moveCilinder, ballHitted, touchingGround;
    public GameObject cilinder;
    Vector3 position;
    private void Update()
    {
        position = transform.position;
        if(beingPressed)
        {
            transform.Translate(Vector3.up * speed);
            cilinder.transform.Translate(Vector3.down * speed);
            cilinder.transform.Translate(Vector3.back * speed);
            force = Vector3.Distance(cilinder.transform.position, transform.position);

            Debug.Log(force);
        }


        if(transform.position.y > 1 && ballHitted)
        {
            position.y -= (gravity * Weight) * Time.deltaTime;
            transform.position = position;
        }


        
        if(moveCilinder)
        {
            cilinder.transform.Translate(Vector3.up *force *Time.deltaTime );
        }

        if (ballHitted)
        {

            //position.y -= (gravity * Weight) * Time.deltaTime;
            position.x += (force * Weight) * Time.deltaTime;
           
            transform.position = position;
            //transform.Translate(Vector3.right* (force / Weight) * Time.deltaTime);
        }
    }
    public void AddEP()
    {
        beingPressed = true;
    }
    public void StopAddingEP()
    {
        beingPressed = false;
    }

    public void ApplyEC()
    {
        if(!hitting)
        {
            hitting = true;
            moveCilinder = true;
            //cilinder.GetComponent<Rigidbody>().AddForce(Vector3.right * force* 200);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("golp"))
        {
            startGravity = true;
            moveCilinder = false;
            ballHitted = true;
            //collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        if(collision.gameObject.CompareTag("wall"))
        {
            ballHitted = false;
            moveCilinder = false;
            Debug.Log("La pared se golpeo con una fuerza de: " + collision.relativeVelocity.magnitude);
        }
        if(collision.gameObject.CompareTag("ground"))
        {

            touchingGround = true;
        }
    }
}
