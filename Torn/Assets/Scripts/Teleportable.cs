using System;
using UnityEngine;

public class Teleportable : MonoBehaviour
{
    private Mirror[] mirrors;
    private void Start()
    {
        mirrors = FindObjectsByType<Mirror>(
            FindObjectsSortMode.None);

        foreach (var mirror in mirrors)
        {
            mirror.OnMirrorActivated += Teleport;
        }
    }
    

    private void Teleport()
    {
        var position = transform.position;
        position.x = -position.x;
        transform.position = position;
        
        transform.Rotate(0, 180, 0, Space.World);
    }
}
