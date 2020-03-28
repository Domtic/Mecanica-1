using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inercia : MonoBehaviour
{
    int forceLeft;
    int forceRight;

    public Transform limitRight,limitLeft;
    Vector3 currentPos;
    // Start is called before the first frame update
    int speed;
    bool move;

    public Text fuerza1, fuerza2;
    void Start()
    {
        move = false;
        forceLeft = 0;
        forceRight = 0;
        currentPos = transform.position;
    }

   public void AgregarFuerza(bool side)
    {
        move = true;
        if(side)
        {
            forceLeft += 1;

        }
        else
        {
            forceRight += 1;
        }
        fuerza1.text = "Fuerza Izquierda: " + forceRight.ToString();
        fuerza2.text = "Fuerza derecha: " + forceLeft.ToString();
    }

    private void Update()
    {

        if(move)
        {
            if (forceLeft > forceRight)
            {
                speed = forceLeft - forceRight;
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, limitLeft.position, step);
                if (transform.position.x == currentPos.x - forceLeft)
                {
                    move = false;
                    currentPos = transform.position;
                }
            }
            else if (forceRight > forceLeft)
            {
                speed = forceRight - forceLeft;
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, limitRight.position, step);
                if (transform.position.x == currentPos.x + forceRight)
                {
                    move = false;
                    currentPos = transform.position;
                }
            }
        }
 
    }
}
