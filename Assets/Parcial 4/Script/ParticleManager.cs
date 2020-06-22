using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    List<ParticleWithCharge> particleWithCharges;
    List<MoveableParticle> moveableParticles;
    [SerializeField]
    float cycleInterval = 0.01f;
    float multiplier = 100f;
    void Start()
    {
        GetParticles();
        foreach (MoveableParticle particle in moveableParticles)
        {
            StartCoroutine(Cycle(particle));
        }
    }

    IEnumerator Cycle(MoveableParticle particle)
    {
        bool isFirst = true;
        while(true)
        {
            if(isFirst)
            {
                isFirst = !isFirst;
                yield return new WaitForSeconds(Random.Range(0, cycleInterval));
            }
            ApplyForce(particle);
            yield return new WaitForSeconds(cycleInterval);

        }
    }

    private void ApplyForce(MoveableParticle _moveableParticle)
    {
        Vector3 newforce = Vector3.zero;
        foreach(ParticleWithCharge particle in particleWithCharges)
        {
            if(particle == _moveableParticle)
                continue;
            float distance = Vector3.Distance(_moveableParticle.transform.position, particle.transform.position);
            if (distance == 0)
                continue;

            float force =(_moveableParticle.charge * particle.charge * multiplier )/ Mathf.Pow(distance,2) ;
            Vector3 direction = _moveableParticle.transform.position - particle.transform.position;
            direction.Normalize();
            newforce = force * direction * cycleInterval ;
            _moveableParticle.rigidBody.AddForce(newforce);
        }
    }

    public void GetParticles()
    {
        particleWithCharges = new List<ParticleWithCharge>();
        moveableParticles = new List<MoveableParticle>();
        for (int i =0; i <transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<MoveableParticle>() != null)
            {
                moveableParticles.Add(transform.GetChild(i).GetComponent<MoveableParticle>());
            }
            else
            {
                particleWithCharges.Add(transform.GetChild(i).GetComponent<ParticleWithCharge>());
            }
        }
    }
}
