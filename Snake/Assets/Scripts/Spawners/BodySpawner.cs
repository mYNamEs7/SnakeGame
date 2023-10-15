using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodySpawner : MonoBehaviour
{
    [SerializeField] private Body bodyPrefab;
    [SerializeField] private Body lastBody;
    [SerializeField] private int bodyCount;

    private void Awake()
    {
        SpawnBodies(bodyCount);
    }

    private void Start()
    {
        Food.OnFoodEaten += AddBody;
    }

    private void SpawnBodies(int count)
    {
        for (int i = 0; i < count; i++)
        {
            lastBody = lastBody.AddBody(bodyPrefab);
        }
    }

    private void AddBody()
    {
        lastBody = lastBody.AddBody(bodyPrefab);
    }

    private void OnDestroy()
    {
        Food.OnFoodEaten -= AddBody;
    }
}
