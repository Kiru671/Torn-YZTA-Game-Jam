using System;
using UnityEngine;
using UnityEngine.Rendering;

public class Mirror : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject interactableObject;
    [SerializeField] private Volume mirrorVolume;
    [SerializeField] private Volume defaultVolume;
    private GameObject[] hazard;
    
    public event Action OnMirrorActivated;

    private void Awake()
    {
        interactableObject.SetActive(false);

        mirrorVolume = GameObject.Find("Mirror Volume").GetComponent<Volume>();
        defaultVolume = GameObject.Find("Default Volume").GetComponent<Volume>();;

        mirrorVolume.enabled = false;
        
        hazard = GameObject.FindGameObjectsWithTag("Hazard");
    }

    public void Interact()
    { 
        foreach (var h in hazard)
        {
            h.SetActive(!h.activeSelf);
        }
        
        if (mirrorVolume.enabled)
        {
            mirrorVolume.enabled = false;
            defaultVolume.enabled = true;
        }
        else
        {
            mirrorVolume.enabled = true;
            defaultVolume.enabled = false;
        }
        
        OnMirrorActivated?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Enter");
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
