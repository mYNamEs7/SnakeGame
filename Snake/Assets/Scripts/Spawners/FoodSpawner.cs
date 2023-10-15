using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] private MeshFilter appleMesh;
    [SerializeField] private Transform foodPrefab;
    [SerializeField] private int foodCount;

    private void Start()
    {
        Food.OnFoodEaten += SpawnFood;

        for (int i = 0; i < foodCount; i++)
        {
            SpawnFood();
        }
    }

    private void SpawnFood()
    {
        Vector3 randomPoint = GetRandomPointOnMesh(appleMesh.mesh);
        var spawnedFood = Instantiate(foodPrefab, randomPoint, Quaternion.identity);
        spawnedFood.rotation = Quaternion.FromToRotation(spawnedFood.up, randomPoint.normalized) * spawnedFood.rotation;
    }

    private Vector3 GetRandomPointOnMesh(Mesh mesh)
    {
        Vector3[] vertices = mesh.vertices;
        Vector3 randomVertex = vertices[Random.Range(0, vertices.Length)];

        return randomVertex;
    }

    private void OnDestroy()
    {
        Food.OnFoodEaten -= SpawnFood;
    }
}
