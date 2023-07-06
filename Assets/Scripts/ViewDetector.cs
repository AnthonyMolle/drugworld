using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewDetector : MonoBehaviour
{
    public string objName;
    [SerializeField] Camera mainCam;

    TransitionManager transitionManager;
    
    public bool inView = false;

    Bounds bounds;
    Plane[] frustrum;

    private void Start() 
    {
        mainCam = Camera.main;
        bounds = GetComponent<Collider>().bounds;

        transitionManager = FindObjectOfType<TransitionManager>();
    }

    private void Update() 
    {
        frustrum = GeometryUtility.CalculateFrustumPlanes(mainCam);
        if (GeometryUtility.TestPlanesAABB(frustrum, bounds) && !inView)
        {
            inView = true;
        }
        else if (!GeometryUtility.TestPlanesAABB(frustrum, bounds) && inView)
        {
            inView = false;
        }
    }
}
