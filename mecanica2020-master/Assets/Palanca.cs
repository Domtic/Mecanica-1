using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Palanca : MonoBehaviour
{

    public TMPro.TMP_InputField monitaINP;
    public TMPro.TMP_InputField atinomINP;
    public TMPro.TMP_InputField moveUnitsINTP;
    
    public Rigidbody monita, atinom;
    float MonitaKg;
    float AtinomKg;
    float moveUnits;


    public void Calculate()
    {
        MonitaKg = float.Parse(monitaINP.text);
        AtinomKg = float.Parse(atinomINP.text);
        moveUnits = float.Parse(moveUnitsINTP.text);

        monita.mass = MonitaKg;
        atinom.mass = AtinomKg;

        float v = (AtinomKg * moveUnits);
        float result = v / MonitaKg;
        Debug.Log(result);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
