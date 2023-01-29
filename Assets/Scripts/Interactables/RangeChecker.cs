using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeChecker : MonoBehaviour
{
    [SerializeField] Note note;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            note.playerInRange = true;
        }  
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            note.playerInRange = false;
        }
    }
}
