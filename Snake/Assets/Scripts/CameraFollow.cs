using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float movementSpeed = 5f;

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, movementSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, movementSpeed * Time.deltaTime);
    }
}
