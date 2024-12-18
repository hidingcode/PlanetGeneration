using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{   
    public float rotationSpeed = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            RotateLeft();
        }
        
        if (Input.GetKey(KeyCode.E))
        {
            RotateRight();
        }
    }
    private void RotateLeft()
    {
        transform.rotation *= Quaternion.Euler(0, rotationSpeed * Time.deltaTime, 0);
    }
    private void RotateRight()
    {
        transform.rotation *= Quaternion.Euler(0, -rotationSpeed * Time.deltaTime, 0);  
    }

}
