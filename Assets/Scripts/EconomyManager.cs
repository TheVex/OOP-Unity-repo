using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EconomyManager : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;

    // Food that is produced
    public float food;
    // Money for purchasing upgrades
    public float cash;
    // How much money will player receive on consuming one point of food
    public float cashMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        food = 0;
    }

    // Update is called once per frame
    void Update()
    {
        textMeshPro.text = $"Food: {food}";
    }
}
