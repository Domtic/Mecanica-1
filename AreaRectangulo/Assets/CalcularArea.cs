using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalcularArea : MonoBehaviour
{
    public float baseA = 4f;
    public float alturaA = 5f;
    public float fondoA = 3f;

    void Start()
    {
        Vector3 nuevaEscala = new Vector3(baseA, alturaA, fondoA);

        print("Tu base es: " + baseA);
        print("Tu altura es: " + alturaA); 
        print("Tu fondo es: " + fondoA);

        this.transform.localScale = nuevaEscala;
        BoxCollider colision = new BoxCollider();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
