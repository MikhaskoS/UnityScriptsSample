using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathfSample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Set the x position to loop between 0 and 3
        //transform.position = new Vector3(Mathf.PingPong(Time.time, 3),
        //    transform.position.y, transform.position.z);


        // Устанавливаем положение x для цикла от 0 до 3
        // полезно при проходе цикла (см. пример handle - Intro)
        transform.position = new Vector3(Mathf.Repeat(Time.time, 3), 
            transform.position.y, transform.position.z);
    }
}

