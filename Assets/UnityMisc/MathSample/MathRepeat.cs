using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathRepeat : MonoBehaviour
{
    private void Start()
    {
        int[] num = new int[] { 0, 1, 2};
        string s = "";
        for (int i = 0; i < 10; i++)
        {
            s += $"{Mathf.Repeat(i, num.Length)} ";   // 0 1 2 0 1 2 0 1 2 0
        }
        print(s);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Repeat(Time.time, 3),
           transform.position.y, transform.position.z);
    }
}
