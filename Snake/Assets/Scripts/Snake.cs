using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Snake : MonoBehaviour
{
    [SerializeField] private LayerMask appleLayerMask;
    [SerializeField] private Transform visual;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float gravity;

    private PlayerInput playerInput;
    private Rigidbody rb;
    private Vector3 movementDirection;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Vector2 inputVector = playerInput.GetMuvementVector();

        var forwardVector = transform.forward * inputVector.y;
        var rightVector = transform.right * inputVector.x;

        movementDirection = forwardVector + rightVector;
        movementDirection.Normalize();

        visual.rotation = Quaternion.LookRotation(movementDirection, transform.up);
    }

    private void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, -transform.up, out var hitInfo, 3f, appleLayerMask))
            transform.rotation = Quaternion.FromToRotation(transform.up, hitInfo.normal) * transform.rotation;

        rb.velocity = movementDirection * movementSpeed;

        if (!Physics.Raycast(transform.position, -transform.up, 0.75f, appleLayerMask))
            rb.AddForce(-transform.up * gravity);
    }
}
