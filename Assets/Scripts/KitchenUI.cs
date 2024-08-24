using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KitchenUI : MonoBehaviour
{
    private EconomyManager economyManager;
    private Consumer consumer;

    // Start is called before the first frame update
    void Start()
    {
        economyManager = GameObject.FindAnyObjectByType<EconomyManager>();
        consumer = GameObject.FindAnyObjectByType<Consumer>();

    }

    public void Buy(string name)
    {
        bool success = economyManager.BuyObject(name);
        if (success)
        {
            Destroy(GameObject.Find($"{name} Button"));
        }
    }

    public void UpgradeTable()
    {
        consumer.Upgrade();
    }

    public void BackToMenu()
    {
        economyManager.TransportData();
        consumer.TransportData();
        SaveManager.instance.Save();
        SceneManager.LoadScene(0);
    }
}
