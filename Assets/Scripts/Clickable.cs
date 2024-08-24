using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour
{
    protected Transform objTransform;

    [SerializeField] protected float scaleMultiplier = 1.2f;

    // Call base.OnMouseDown() function, typically from the derived class
    public void doOnMouseDown()
    {
        OnMouseDown();
    }

    private void OnMouseDown()
    {
        objTransform.localScale /= scaleMultiplier;
    }

    private void OnMouseUp()
    {
        objTransform.localScale *= scaleMultiplier;
    }
}
