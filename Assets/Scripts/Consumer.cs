using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumer : MonoBehaviour
{
    private EconomyManager economyManager;

    [SerializeField] private float consumeTime;
    [SerializeField] private float consumePower;

    // Start is called before the first frame update
    void Start()
    {
        economyManager = GameObject.Find("Economy Manager").GetComponent<EconomyManager>();
        InvokeRepeating("Consume", 1, consumeTime);
    }

    // Method that will eat food
    void Consume()
    {
        if (economyManager.food <= 0) 
        {
            return;
        }
        else if (economyManager.food < consumePower) 
        {
            economyManager.food = 0;
        }
        else {
            economyManager.food -= consumePower;
        }

    }
}
