using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class Producer : MonoBehaviour
{
    [SerializeField] private float m_FoodIncome;
    public float FoodIncome
    { 
        get { return m_FoodIncome; }
        private set { m_FoodIncome = value; }
    }

    [SerializeField] private float m_ProduceTime;
    public float ProduceTime { get { return m_ProduceTime;  } private set { m_ProduceTime = value; } }

    private EconomyManager economyManager;

    private void Start()
    {
        economyManager = GameObject.FindAnyObjectByType<EconomyManager>();
        StartCoroutine(PassiveIncome());
    }

    // Function that gives income in some period of time
    IEnumerator PassiveIncome()
    {
        while (true)
        {
            yield return new WaitForSeconds(ProduceTime);
            economyManager.food += FoodIncome;
        }
    }
}
