using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionManager : MonoBehaviour
{
    [SerializeField] GameObject gbWall;
    [SerializeField] ViewDetector wallDetector;
    [SerializeField] GameObject gbRoof;
    [SerializeField] ViewDetector roofDetector;
    [SerializeField] GameObject gbBody;
    [SerializeField] ViewDetector bodyDetector;
    [SerializeField] GameObject gb;
    [SerializeField] GameObject openingLevel;
    [SerializeField] GameObject closingLevel;

    [SerializeField] Camera mainCam;

    private void Update() 
    {
        if (wallDetector.inView && !roofDetector.inView && !bodyDetector.inView)
        {
            SwapOutside();
        }    
    }

    public void SwapOutside()
    {
        openingLevel.SetActive(false);
        mainCam.cullingMask |= 1 << LayerMask.NameToLayer("Lab");
        gbBody.SetActive(false);
        gbRoof.SetActive(false);
        //for now, test with set active, but later, make sure to give the gingerbread house its own layer, and to remove the roof, body, and level from the main cams culling mask
        //but not the culling mask of the mirror. then have a separate trigger later to deactivate the outer level on to avoid wonky collision on the rocks

        //make sure to do some changes to rendersettings/lighting settings to set the moooood better
    }

    public void SwapWall()
    {
        gbWall.SetActive(false);
    }


}
