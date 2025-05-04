using System;
using UnityEngine;

public class Mirror : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject interactableObject;
    [SerializeField] private GameObject mirrorVolume;
    [SerializeField] private GameObject defaultVolume;
    
    public event Action OnMirrorActivated;

    private void Start()
    {
        interactableObject.SetActive(false);
    }

    public void Interact()
    {
        if (mirrorVolume.activeSelf)
        {
            mirrorVolume.SetActive(false);
            defaultVolume.SetActive(true);
        }
        else
        {
            mirrorVolume.SetActive(true);
            defaultVolume.SetActive(false);
            
        }
        OnMirrorActivated?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interactableObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interactableObject.SetActive(false);
        }
    }
}
