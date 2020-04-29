using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    //public GameObject[] RAMPS;
    private float g = -9.81f, y1, yf;
    float distance;
    float time;

    public void Start()
    {
        y1 = transform.position.y;

        CastearRayDown();
        time = Mathf.Abs(CalculatTime(distance));
        StartCoroutine(MoveToPlank(transform.position, new Vector3(transform.position.x, transform.position.y + distance, transform.position.z), time));
    }

    void CastearRayDown()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.green);
            distance = Mathf.Abs(hit.distance);
            yf = y1 + distance;
            Debug.Log(yf);
        }
    }

    IEnumerator MoveToPlank(Vector3 a, Vector3 b, float t)
    {
        float lerpValue = 0.0f;
        while (lerpValue < time)        {            this.transform.position = Vector2.Lerp(a, b, lerpValue);            lerpValue += Time.deltaTime;            yield return null;        }        this.transform.position = b;


        yield return null;
    }

    float CalculatTime(float d)
    {

        return distance / g;
    }


}
