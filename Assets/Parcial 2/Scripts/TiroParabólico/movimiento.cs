using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    public float speed = 10.0f;

    float input, input2;
    void Update()
    {
        // Get the horizontal and vertical axis.
        // By default they are mapped to the arrow keys.
        // The value is in the range -1 to 1
        input = Input.GetAxis("Vertical") * speed;
        input2 = Input.GetAxis("Horizontal") * speed;
        if (input > 0 || input < 0)
        {
            input *= Time.deltaTime;
            transform.Translate(0, input, 0);
        }
        else if(input2 > 0 || input2 < 0)
        {
            input2 *= Time.deltaTime;
            transform.Translate(input2, 0, 0);
        }



        // Move translation along the object's z-axis
      
    }
}
