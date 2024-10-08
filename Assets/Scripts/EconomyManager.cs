using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EconomyManager : MonoBehaviour
{
    public TextMeshProUGUI foodText;
    public TextMeshProUGUI cashText;
    //public TextMeshProUGUI productionPowerText;
    public TextMeshProUGUI consumptionPowerText;
    //public TextMeshProUGUI cashMultiplierText;

    public TextMeshProUGUI fridgeButtonText;
    public TextMeshProUGUI hoodButtonText;
    public TextMeshProUGUI gasRangeButtonText;
    public TextMeshProUGUI ovensButtonText;
    public TextMeshProUGUI tableButtonText;

    private Consumer consumer;
    private GameObject producers;
    private GameObject canvas;

    // Food that is produced
    public float food;
    // Money for purchasing upgrades
    public float cash;
    // How much money will player receive on consuming one point of food
    public float cashMultiplier;
    private float productionPower;

    bool hasOvens;
    bool hasHood;
    bool hasFridge;
    bool hasGasRange;

    // ENCAPSULATION
    // Properties of buying objects

    [SerializeField] private float m_ovensCost;
    public float ovensCost { get { return m_ovensCost; } private set { m_ovensCost = value; } }

    [SerializeField] private float m_hoodCost;
    public float hoodCost { get { return m_hoodCost; } private set { m_hoodCost = value; } }

    [SerializeField] private float m_fridgeCost;
    public float fridgeCost { get { return m_fridgeCost; } private set { m_fridgeCost = value; } }

    [SerializeField] private float m_gasRangeCost;
    public float gasRangeCost { get { return m_gasRangeCost; } private set { m_gasRangeCost = value; } }


    // Start is called before the first frame update
    void Start()
    { 

        consumer = GameObject.Find("Consumer").GetComponent<Consumer>();
        producers = GameObject.Find("Producers");
        canvas = GameObject.Find("Canvas");

        // ABSTRACTION
        LoadData();
        
        CheckFurniture();

        SetText();
        
    }
    // Set text for buttons
    void SetText()
    {
        fridgeButtonText.text = $"Fridge\n Cost: {fridgeCost}";
        hoodButtonText.text = $"Hood\n Cost: {hoodCost}";
        ovensButtonText.text = $"Ovens\n Cost: {ovensCost}";
        gasRangeButtonText.text = $"Gas Range\n Cost: {gasRangeCost}";
        tableButtonText.text = $"Table Upgrade\n Cost: {consumer.levelUpCost}";
    }
    // Load into variables from SaveManager
    void LoadData()
    {
        hasOvens = SaveManager.instance.hasOvens;
        hasHood = SaveManager.instance.hasHood;
        hasFridge = SaveManager.instance.hasFridge;
        hasGasRange = SaveManager.instance.hasGasRange;
        cash = SaveManager.instance.cash;
        food = SaveManager.instance.food;
    }

    // Check if furniture was bought in previous sessions and activate it
    void CheckFurniture()
    {
        if (hasFridge)
        {
            producers.transform.Find("Fridge").gameObject.SetActive(true);
            canvas.transform.Find("Fridge Button").gameObject.SetActive(false);
        }

        if (hasGasRange) 
        {
            producers.transform.Find("Gas Range").gameObject.SetActive(true);
            canvas.transform.Find("Gas Range Button").gameObject.SetActive(false);
        }
        if (hasHood)
        {
            producers.transform.Find("Hood").gameObject.SetActive(true);
            canvas.transform.Find("Hood Button").gameObject.SetActive(false);
        }
        if (hasOvens)
        {
            producers.transform.Find("Ovens").gameObject.SetActive(true);
            canvas.transform.Find("Ovens Button").gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foodText.text = $"Food: {food} p";
        cashText.text = $"Cash: {cash}$";
        //productionPowerText.text = $"Production Power: {productionPower}/s";
        consumptionPowerText.text = $"Consumption Power: {consumer.consumePower} p in {consumer.consumeTime} sec";
        //cashMultiplierText.text = $"Cash multiplier: {cashMultiplier}x";

    }

    public bool BuyObject(string objectName)
    {
        switch (objectName)
        {
            case "Fridge":
                if (fridgeCost > cash) return false;
                cash -= fridgeCost;
                hasFridge = true;
                break;
            case "Ovens":
                if (ovensCost > cash) return false;
                cash -= ovensCost;
                hasOvens = true;
                break;
            case "Gas Range":
                if (gasRangeCost > cash) return false;
                cash -= gasRangeCost;
                hasGasRange = true;
                break;
            case "Hood":
                if (hoodCost > cash) return false;
                cash -= hoodCost;
                hasHood = true;
                break;
            default:
                Debug.Log("No object is found");
                return false;
        }
        producers.transform.Find(objectName).gameObject.SetActive(true);
        return true;
    }

    // Store data in SaveManager for future saving 
    public void TransportData()
    {
        SaveManager.instance.hasFridge = hasFridge;
        SaveManager.instance.hasGasRange = hasGasRange;
        SaveManager.instance.hasHood = hasHood;
        SaveManager.instance.hasOvens = hasOvens;
        SaveManager.instance.cash = cash;
        SaveManager.instance.food = food;
    }
}
