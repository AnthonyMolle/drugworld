using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionManager : MonoBehaviour
{
    [SerializeField] GameObject gb;

    [SerializeField] ViewDetector leftDetector;
    [SerializeField] ViewDetector rightDetector;
    [SerializeField] ViewDetector upDetector;
    [SerializeField] ViewDetector downDetector;
    [SerializeField] ViewDetector forwardDetector;
    [SerializeField] ViewDetector backwardDetector;

    [SerializeField] GameObject openingLevel;
    [SerializeField] GameObject closingLevel;

    [SerializeField] Door door;

    [SerializeField] private bool transitionStarted = false;
    [SerializeField] private bool outsideSwapped = false;

    [SerializeField] LayerMask openingMask;
    [SerializeField] LayerMask transitionMask;
    [SerializeField] LayerMask closingMask;

    [SerializeField] Camera mainCam;

    [SerializeField] Light sun;

    private void Update() 
    {
        if (transitionStarted)
        {
            if (!rightDetector.inView && !leftDetector.inView && !upDetector.inView && !downDetector.inView && forwardDetector.inView) 
            {
                SwapOutside();
            }
        }
        else if (outsideSwapped)
        {
            if (!rightDetector.inView && !leftDetector.inView && !upDetector.inView && !downDetector.inView && !forwardDetector.inView && backwardDetector.inView)
            {
                SwapWall();
            }
        }
    }

    public void SwapOutside()
    {
        transitionStarted = false;
        outsideSwapped = true;
        sun.gameObject.SetActive(false);

        mainCam.cullingMask = transitionMask;
        //for now, test with set active, but later, make sure to give the gingerbread house its own layer, and to remove the roof, body, and level from the main cams culling mask
        //but not the culling mask of the mirror. then have a separate trigger later to deactivate the outer level on to avoid wonky collision on the rocks

        //make sure to do some changes to rendersettings/lighting settings to set the moooood better
    }

    public void SwapWall()
    {
        mainCam.cullingMask = closingMask;
        openingLevel.SetActive(false);
        gameObject.SetActive(false);
        gb.SetActive(false);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            transitionStarted = true;
            door.Close();
        }    
    }

}
