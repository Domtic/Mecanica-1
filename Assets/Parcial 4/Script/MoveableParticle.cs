using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableParticle : ParticleWithCharge
{
    [SerializeField]
    private float masa = 1;

    public Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        UpdateColor();
        rigidBody = gameObject.AddComponent<Rigidbody>();
        rigidBody.mass = masa;
        rigidBody.useGravity = false;
    }

}
