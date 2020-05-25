using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathMoveTowards : MonoBehaviour
{
    [SerializeField] float currStrength = 10;
    [SerializeField] float maxStrength = 20;
    [SerializeField] float recoveryRate = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

   
    void Update()
    {
        currStrength = Mathf.MoveTowards(currStrength, maxStrength, recoveryRate * Time.deltaTime);
    }
}
