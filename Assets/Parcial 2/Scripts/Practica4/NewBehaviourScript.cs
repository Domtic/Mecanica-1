using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    //public GameObject[] RAMPS;
    private float g = 9.81f, y1, yf;
    float distance;
    float time;

    GameObject plank;

    bool useSen;
    public void Start()
    {
        y1 = transform.position.y;

        CastearRayDown();
        time = Mathf.Abs(CalculatTime(distance));
        StartCoroutine(MoveToPlank(transform.position, new Vector3(transform.position.x, transform.position.y - distance, transform.position.z), time));
    }

    void CastearRayDown()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.green);
            distance = Mathf.Abs(hit.distance - transform.localScale.x / 2);
            plank = hit.collider.gameObject;
        }
    }

    IEnumerator MoveToPlank(Vector3 a, Vector3 b, float t)
    {
        float lerpValue = 0.0f;
        float Perc;
       while (lerpValue < time)
        {
            Perc = lerpValue / t;
            this.transform.position = Vector3.Lerp(a, b, Perc);
            lerpValue += Time.deltaTime;
            yield return null;
        }
        this.transform.position = b;

        plank.GetComponent<WayPoints>().WayPointA.transform.position = b;
        CalculateDistanceOfPlank();

       
    }

    float CalculatTime(float d)
    {

        return distance / g;
    }

    float SacarPX( float angle)
    {
        float distance;
        if (plank.GetComponent<WayPoints>().sen)
        {
            //true
            float angle2 = angle;
            angle2 = angle * Mathf.PI / 180;
            float angulodegres = Mathf.Sin(angle2);
            distance = angulodegres * g;
            useSen = false;


        }
        else
        {
            float angle2 = angle;
            angle2 = angle * Mathf.PI / 180; 
            float angulodegres = Mathf.Cos(angle2);
            distance = angulodegres *g;
            useSen = false;
        }

        return distance;
    }

    float SacarPY(float angle)
    {
        float distance;
        if (useSen)
        {
            //true
            distance = Mathf.Sin(angle) * g;
        }
        else
        {
            //false
            distance = Mathf.Cos(angle) * g;
        }

        return Mathf.Abs(distance);
    }

    float getAceleration(float fuerza, float maza)
    {
        return fuerza / maza;
    }


    void CalculateDistanceOfPlank()
    {

        float hipotenusa = plank.transform.localScale.x; //horizontal diustance
        float angle = plank.transform.localEulerAngles.z;
        float height = Mathf.Sin(angle) * hipotenusa; // distnacia de altura
        //float horizontal_height = Mathf.Cos(angle) * hipotenusa;
        float masa = 1;
        // m * g
        //9.81 p
        float peso = masa * g;

    
        float fx = SacarPX( angle);
        float fy = SacarPY(angle);
        float aceleration = getAceleration(fx, 1);


        float a = hipotenusa * 2;
        float b = a / aceleration;
        float time = Mathf.Sqrt(b);
        //0.98 a
        //24.75
        //vf = 4.97
        float vf = Mathf.Sqrt(0 + 2*(aceleration*hipotenusa));
        StartCoroutine(MoveFromAtoB(plank.GetComponent<WayPoints>().WayPointA.transform.position, plank.GetComponent<WayPoints>().WayPointB.transform.position,time, vf));
        //calcular nuevo vector y usar de nuevo el lerp /tiempo
    }
    IEnumerator MoveFromAtoB(Vector3 a, Vector3 b, float t, float vf)
    {
        float lerpValue = 0.0f;
        float Perc;
        while (lerpValue < t)
        {
            Perc = lerpValue / t;
            this.transform.position = Vector3.Lerp(a, b, Perc);

            lerpValue += Time.deltaTime;
            yield return null;
        }

        CalcularMomentum(vf);
        yield return null;
    }

    void calcularTiroParabolico()
    {

    }

    void CalcularMomentum(float vf)
    {
        float vp = (vf - 0) / 2;
        Debug.Log(vf);

        float momentum = 1 * vp;
        Debug.Log(momentum);

        CastearRayDown();
        time = Mathf.Abs(CalculatTime(distance));

        Debug.Log(time);
    }
    

    
}
