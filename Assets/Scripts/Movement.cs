using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private int speed = 10;

    private Camera mainCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("W");
            Move(Vector2.up);
        } else if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("S");
            Move(Vector2.down);
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("A");
            Move(Vector2.left);
        } else if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("D");
            Move(Vector2.right);
        }
        
    }

    private void Move(Vector2 input)
    {
        Vector3 forward = mainCamera.transform.forward;
        Vector3 right = mainCamera.transform.right;

        forward.y = 0;
        right.y = 0;
        
        forward.Normalize();
        right.Normalize();

        Vector3 direction = right * input.x + forward * input.y;
        
        transform.position = transform.position + direction * speed * Time.deltaTime;
    }
}
