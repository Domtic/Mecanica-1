using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MovimientoCircular : MonoBehaviour
{
    public InputField widthInput;
    public InputField heightInput;
    public InputField speedInput;
    public GameObject refs;
    float amount;

    float timeCounter = 0;
    float x, y, z = 0;
    float speed;
    float width;
    float height;

    bool rotate;

    public List<GameObject> balls;   // Start is called before the first frame update
    void Start()
    {
        rotate =false;
        speed = 3;
        width = 4;
        height = 2;
        amount = 1;
    }


    public void Iniciar()
    {
        balls.Clear();
        width = float.Parse(widthInput.text.ToString());
        height = float.Parse(heightInput.text.ToString());
        speed = float.Parse(speedInput.text.ToString());
        rotate = true;
        balls.Add(this.gameObject);
        amount = 1;
    }

    public void IncreaseAmmount()
    {
        balls.Add(GameObject.Instantiate(refs));
        amount++;
    }
    // Update is called once per frame
    void Update()
    {
       
        if (rotate)
        {
            timeCounter += Time.deltaTime * speed;
            Debug.Log(balls.Count);
            for(int o= 0; o < balls.Count; o++)
             {
                 x = Mathf.Cos(timeCounter) * width / amount - o;
                 y = Mathf.Sin(timeCounter) * height / amount- o;
                 z = 0;
                 balls[o].transform.position = new Vector3(x, y, z);
             }

           
        }
       
    }
}
