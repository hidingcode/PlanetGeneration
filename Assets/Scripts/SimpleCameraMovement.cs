using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCameraMovement : MonoBehaviour
{
    public float camereMoveSpeed = 10;

    // Update is called once per frame
    void Update()
    {   
        // Zoom in and out with mouse scroll
        if (Input.GetKey(KeyCode.R))
        {
            MoveUp();
        }
        else if (Input.GetKey(KeyCode.F))
        {
            MoveDown();
        }
        
        if (Input.GetKey(KeyCode.W))
        {
            MoveForward();
        }
        if (Input.GetKey(KeyCode.S))
        {
            MoveBackward();
        }
        if (Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }
        if (Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }
    }

    void MoveUp()
    {
        transform.position += transform.up * (camereMoveSpeed * Time.deltaTime);
    }

    void MoveDown()
    {
        transform.position -= transform.up * (camereMoveSpeed * Time.deltaTime);
    }
    
    void MoveForward()
    {
        transform.position += transform.forward * (camereMoveSpeed * Time.deltaTime);
    }

    void MoveBackward()
    {
        transform.position -= transform.forward * (camereMoveSpeed* Time.deltaTime);
    }

    void MoveLeft()
    {
        transform.position -= transform.right * (camereMoveSpeed * Time.deltaTime);
    }
    
    void MoveRight()
    {
        transform.position += transform.right * (camereMoveSpeed * Time.deltaTime);
    }
}
