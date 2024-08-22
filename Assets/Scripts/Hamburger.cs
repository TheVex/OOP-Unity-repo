using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hamburger : MonoBehaviour
{
    private Transform objTransform;

    private void Start()
    {
        objTransform = transform;
    }
    private void OnMouseDown()
    {
        objTransform.localScale /= 2;
    }

    private void OnMouseUp()
    {
        objTransform.localScale *= 2;
    }
}
