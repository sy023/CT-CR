using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{ 
    public Transform targetA, targetB;
    // float timeCount = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateInput();
        
    }
    
    void RotateInput()
    {
        //if (Input.GetKeyDown(KeyCode.X)) { X = 1 - X;  }
    }

    void LookRotation()
    {
        Vector3 relativePos = targetA.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.rotation = rotation;
    }
}
