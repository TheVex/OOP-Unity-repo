using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hamburger : Clickable
{
    private EconomyManager economyManager;

    public float productionClickPower;

    private void Start()
    {
        objTransform = transform;
        economyManager = GameObject.Find("Economy Manager").GetComponent<EconomyManager>();
        productionClickPower = 1;
    }

    private void OnMouseDown()
    {
        base.doOnMouseDown();
        economyManager.food += productionClickPower;
    }
}
