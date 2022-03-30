using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private int speed = 10;
    [SerializeField] private bool usePhysics = true;

    private Camera mainCamera;
    private Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (usePhysics)
        {
            return;
        }
        
        float yAxis = Input.GetAxis("Vertical");
        float xAxis = Input.GetAxis("Horizontal");
        if (yAxis != 0 || xAxis != 0)
        {
            Vector3 target = HandleInput(new Vector2(xAxis, yAxis));
            Move(target);
        }
    }

    private void FixedUpdate()
    {
        if (!usePhysics)
        {
            return;
        }

        float yAxis = Input.GetAxis("Vertical");
        float xAxis = Input.GetAxis("Horizontal");
        if (yAxis != 0 || xAxis != 0)
        {
            Vector3 target = HandleInput(new Vector2(xAxis, yAxis));
            MovePhysics(target);
        }
    }

    private Vector3 HandleInput(Vector2 input)
    {
        Vector3 forward = mainCamera.transform.forward;
        Vector3 right = mainCamera.transform.right;

        forward.y = 0;
        right.y = 0;
        
        forward.Normalize();
        right.Normalize();

        Vector3 direction = right * input.x + forward * input.y;
        
        return transform.position + direction * speed * Time.deltaTime;
    }

    private void Move(Vector3 target)
    {
        transform.position = target;
    }

    private void MovePhysics(Vector3 target)
    {
        rb.MovePosition(target); 
    }
}
