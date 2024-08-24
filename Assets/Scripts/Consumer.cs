using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.Universal;
using UnityEngine;

public class Consumer : Clickable
{
    public float consumeTime;
    public float consumePower;

    public int consumeClickPower;

    private int level = 1;
    public float levelUpCost;

    private EconomyManager economyManager;

    // Start is called before the first frame update
    void Start()
    {
        objTransform = transform;

        // Setting up level of table
        level = SaveManager.instance.tableLevel;
        if (level == 0)
            level = 1;

        consumeClickPower += level - 1;
        consumePower += level - 1;

        for (int i = 1; i < level; i++)
        {
            MakeChairVisible(i);
        }

        economyManager = GameObject.Find("Economy Manager").GetComponent<EconomyManager>();

        StartCoroutine(ConsumeAuto());
    }

    // Method that will eat food (for some time period)
    IEnumerator ConsumeAuto()
    {
        while (true)
        {
            yield return new WaitForSeconds(consumeTime);
            Consume(consumePower);   
        }
    }

    // When player clicks on table to consume
    private void OnMouseDown()
    {
        Consume(consumeClickPower);
        base.doOnMouseDown();
    }

    // The consume process
    private void Consume(float consumationValue)
    {
        // if there's no food
        if (economyManager.food <= 0)
        {
            return;
        }

        float foodConsumed;

        // if amount of food is less that we can consume
        if (economyManager.food < consumationValue)
        {
            foodConsumed = economyManager.food;
        }
        else
        {
            foodConsumed = consumationValue;
        }

        economyManager.food -= foodConsumed;
        // Transform consumed food into cash
        economyManager.cash += foodConsumed * economyManager.cashMultiplier;
    }

    void MakeChairVisible(int currentLevel)
    {
        switch (currentLevel)
        {
            case 1:
                transform.Find("Consumer Chair 1").gameObject.SetActive(true);
                break;
            case 2:
                transform.Find("Consumer Chair 2").gameObject.SetActive(true);
                break;
            case 3:
                transform.Find("Consumer Chair 3").gameObject.SetActive(true);
                break;
            default:
                return;
        }
    }

    public void Upgrade()
    {
        if (levelUpCost > economyManager.cash)
        {
            return;
        }
        MakeChairVisible(level);
        economyManager.cash -= levelUpCost;
        consumePower++;
        consumeClickPower++;
        level++;
    }

    // Transport data in SaveManager for future saving
    public void TransportData()
    {
        SaveManager.instance.tableLevel = level;
    }
}
