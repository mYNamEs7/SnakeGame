using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public static event Action OnFoodEaten;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Snake snake))
        {
            OnFoodEaten?.Invoke();
            Destroy(gameObject);
        }
    }
}
