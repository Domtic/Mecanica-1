using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressingButton : MonoBehaviour
{
    float force = 0;
    bool beingPressed;
    float speed = 0.2f;

    public GameObject cilinder;
    private void Update()
    {
        if(beingPressed)
        {
            transform.Translate(Vector3.up * speed);
            cilinder.transform.Translate(Vector3.down * speed);
            cilinder.transform.Translate(Vector3.back * speed);
            force = Vector3.Distance(cilinder.transform.position, transform.position);

            Debug.Log(force);
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

    }
}
