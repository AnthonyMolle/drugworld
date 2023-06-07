using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeRandomizer : MonoBehaviour
{
    [SerializeField] GameObject leaves;
    [SerializeField] Renderer leafRenderer;
    [SerializeField] Material[] leafMaterials;


    [SerializeField] float averageScale;
    [SerializeField] float scaleVariation;
    [SerializeField] float maxRotation;

    void Start()
    {
        leafRenderer.material = leafMaterials[Random.Range(0, leafMaterials.Length)];
        gameObject.transform.Rotate(new Vector3(0, Random.Range(0, 360), Random.Range(0, maxRotation)));

        float randomScale = Random.Range(averageScale - scaleVariation, averageScale + scaleVariation);

        gameObject.transform.localScale = new Vector3(randomScale, randomScale, randomScale);
    }

}
