using System;
using Unity.VisualScripting;
using UnityEngine;

public class LevelEndTrigger : MonoBehaviour
{
    public event Action OnLevelCompleted;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            OnLevelCompleted?.Invoke();
        }
    }
}
