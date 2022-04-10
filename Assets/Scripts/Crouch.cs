using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : MonoBehaviour
{
    CapsuleCollider playerCol;
    float originalHeight;
    public float reducedHeight;
    private Controls _controls;
    private Animator _animator;
    private Rigidbody rb;
    private static readonly int IsCrouching = Animator.StringToHash("isCrouching");
    private static readonly int IsJumping = Animator.StringToHash("isJumping");

    // Start is called before the first frame update
    void Start()
    {
        playerCol = GetComponent<CapsuleCollider>();
        originalHeight = playerCol.height;
        rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Crouching();
            _animator.SetBool(IsCrouching, true);
            _animator.SetBool(IsJumping, false);
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            GetUp();
            _animator.SetBool(IsCrouching, false);
        }
    }

    void Crouching()
    {
        playerCol.height = reducedHeight;
    }

    void GetUp()
    {
        playerCol.height = originalHeight;
    }
}
