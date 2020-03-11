using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TiroParabolico : MonoBehaviour
{
    public InputField I_gravity;
    public InputField angle;
    public Transform objective;
    public Vector3 Target;
    public float firingAngle = 45.0f;
    public float gravity = 9.8f;
    private int numPoints = 50;
    public Transform Projectile;
    public Vector3 myTransform;
    public Vector3[] positions = new Vector3[50];
    public LineRenderer lineRenderer;
    Vector3 previousPos = new Vector3();
    //points:
    //transform.position
    //Target.position
    //
    void Awake()
    {
        myTransform = Projectile.transform.position;
        lineRenderer = this.gameObject.GetComponent<LineRenderer>();
    }
    public void ThrowBall()
    {
       
        lineRenderer.positionCount = numPoints;
        firingAngle = float.Parse(angle.text);
        gravity = float.Parse(I_gravity.text);

        
        StartCoroutine(SimulateProjectile());
    }


    IEnumerator SimulateProjectile()
    {
        Target = objective.transform.position;
        yield return new WaitForSeconds(1.5f);
        Projectile.position = myTransform + new Vector3(0, 0.0f, 0);

        float target_Distance = Vector3.Distance(Projectile.position, Target);

        float projectile_Velocity = target_Distance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / gravity);
        float Vx = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
        float Vy = Mathf.Sqrt(projectile_Velocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);
     
        float flightDuration = target_Distance / Vx;
        Projectile.rotation = Quaternion.LookRotation(Target - Projectile.position);
        float elapse_time = 0;
        previousPos = Projectile.transform.position;
        while (elapse_time < flightDuration)
        {
            
            Projectile.Translate(0, (Vy - (gravity * elapse_time)) * Time.deltaTime, Vx * Time.deltaTime);
           

            elapse_time += Time.deltaTime;

            if(Projectile.transform.position.y > previousPos.y)
            {
                previousPos = Projectile.transform.position;
            }
            yield return null;
        }
        DrawCurve();
        //StartCoroutine(SimulateProjectile());
    }

    public void DrawCurve()
    {
        Vector3 p1 = new Vector3();
        float distance = Vector3.Distance(objective.position, transform.position);
        // (Projectile.transform.position.y)*2.5f

        p1 = new Vector3(distance / 2, (previousPos.y), Projectile.transform.position.z);
        /*if(firingAngle > 60)
        {
            p1 = new Vector3(distance / 2, (firingAngle / gravity) * 1.5f, Projectile.transform.position.z);

        }
        else
        {
            p1 = new Vector3(distance / 2, (firingAngle / gravity) / 1.5f, Projectile.transform.position.z);
        }
     
    */
        for (int i = 1; i < numPoints + 1; i++)
        {
            float t = i /(float)numPoints;
            positions[i - 1] = CalculateCurve(t, myTransform, p1, Target);
        }
        lineRenderer.SetPositions(positions);
    }

    public Vector3 CalculateCurve(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        //B(t) = (1-t)2 P0 + 2(1-t)tP1 + t2P2
        //         u             u        tt
        //        uu   * P0 + 2* u * t * P1 + tt * P2
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        Vector3 p = uu * p0;
        p += 2 * u * t * p1;
        p += tt * p2;

        return p;
    }
       
}
