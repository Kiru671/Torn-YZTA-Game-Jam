using System;
using UnityEngine;

public class Teleportable : MonoBehaviour
{
    private void Start()
    {
        FindAnyObjectByType<Mirror>().OnMirrorActivated += Teleport;
    }

    private void Teleport()
    {
        var position = transform.position;
        position.x = -position.x;
        transform.position = position;
        
        transform.Rotate(0, 180, 0, Space.World);
    }
}
