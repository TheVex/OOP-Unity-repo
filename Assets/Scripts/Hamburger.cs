using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hamburger : MonoBehaviour
{
    private Transform objTransform;

    private EconomyManager economyManager;

    [SerializeField] private float scaleMultiplier;

    public float foodProduction;

    private void Start()
    {
        economyManager = GameObject.Find("Economy Manager").GetComponent<EconomyManager>();
        
        foodProduction = 1;
        objTransform = transform;
    }

    private void OnMouseDown()
    {
        objTransform.localScale /= scaleMultiplier;

        economyManager.food += foodProduction;
    }

    private void OnMouseUp()
    {
        objTransform.localScale *= scaleMultiplier;
    }
}
