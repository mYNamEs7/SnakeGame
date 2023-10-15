using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private Transform targetBody;
    [SerializeField] private float movementSpeed;

    [Header("To add new body")]
    [SerializeField] private Transform bodyTarget;
    [SerializeField] private Transform bodySpawnPoint;

    private void Update()
    {
        transform.LookAt(targetBody.position);
        transform.position = Vector3.Lerp(transform.position, targetBody.position, movementSpeed * Time.deltaTime);
    }

    public void SetTarget(Transform target)
    {
        targetBody = target;
    }

    public Body AddBody(Body bodyPrefab)
    {
        var spawnedBody = Instantiate(bodyPrefab, bodySpawnPoint.position, Quaternion.identity);
        spawnedBody.SetTarget(bodyTarget);

        return spawnedBody;
    }
}
