using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
public class aplicarfuerza : MonoBehaviour
{
    public TMPro.TMP_InputField FuerzaInput;
    public TMPro.TMP_Text energia;
    float distancia = 12;
    float masa = 3;
    float energiaGenerada;
    Rigidbody myrigid;

    private void Start()
    {
        myrigid = GetComponent<Rigidbody>();
    }
   
    public void AplicarFuerza()
    {
        float fuerza = float.Parse(FuerzaInput.text);

        energiaGenerada = fuerza * distancia;

        energia.text = energiaGenerada.ToString();
        myrigid.AddForce(Vector3.right * fuerza * 1000);
    }
}
