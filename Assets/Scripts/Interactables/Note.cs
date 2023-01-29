using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{
    [SerializeField] Renderer render;

    PlayerController player;

    [SerializeField] Image note;

    public bool playerInRange = false;

    private void Start() 
    {
        player = FindObjectOfType<PlayerController>();
    }

    private void Update() 
    {
        if (!playerInRange)
        {
            render.material.color = Color.white;
            player.interactableAvailable = false;
            player.SetInteractable(null);
        }    
    }

    
    public void Display()
    {
        note.gameObject.SetActive(true);
    }

    public void UnDisplay()
    {
        note.gameObject.SetActive(false);
    }


    private void OnMouseEnter() 
    {
        if (playerInRange)
        {
            player.interactableAvailable = true;
            player.SetInteractable(gameObject.GetComponent<Note>());
            render.material.color = Color.red;
        }
    }

    private void OnMouseExit() 
    {
        player.interactableAvailable = false;
        render.material.color = Color.white;    
    }
}
