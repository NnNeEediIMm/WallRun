using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRun : MonoBehaviour
{
    public LayerMask wall;
    public Transform playerCamera;
    private cameraMove cmare;
    private PlayerMovement movement;
    private Rigidbody rb;
    public float rotateAngle = 4.5f; 
    int defaultGravity;

    RaycastHit hit;

    private void Start()
    {
        movement = GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody>();
        cmare = playerCamera.GetComponent<cameraMove>();
        defaultGravity = movement.gravityScale;
    }

    private void Update()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, 1f, wall))
        {
            movement.gravityScale = 0;
            rb.useGravity = false;
            cmare.eulerAngle = rotateAngle;
        }
        else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, 1f, wall))
        {
            movement.gravityScale = 0;
            rb.useGravity = false;
            cmare.eulerAngle = -rotateAngle;
        }
        else
        {
            movement.gravityScale = defaultGravity;
            rb.useGravity = true;
            cmare.eulerAngle = 0f;
        }
    }
}