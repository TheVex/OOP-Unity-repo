using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EconomyManager : MonoBehaviour
{
    public TextMeshProUGUI foodText;
    public TextMeshProUGUI cashText;
    public TextMeshProUGUI productionPowerText;
    public TextMeshProUGUI consumptionPowerText;
    public TextMeshProUGUI cashMultiplierText;

    public TextMeshProUGUI fridgeButtonText;
    public TextMeshProUGUI hoodButtonText;
    public TextMeshProUGUI gasRangeButtonText;
    public TextMeshProUGUI ovensButtonText;
    public TextMeshProUGUI tableButtonText;

    private Consumer consumer;
    private GameObject producers;

    // Food that is produced
    public float food;
    // Money for purchasing upgrades
    public float cash;
    // How much money will player receive on consuming one point of food
    public float cashMultiplier;
    private float productionPower;

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
        fridgeButtonText.text = $"Fridge\n Cost: {fridgeCost}";
        hoodButtonText.text = $"Hood\n Cost: {hoodCost}";
        ovensButtonText.text = $"Ovens\n Cost: {ovensCost}";
        gasRangeButtonText.text = $"Gas Range\n Cost: {gasRangeCost}";
        tableButtonText.text = $"Table Upgrade\n Cost: {consumer.levelUpCost}";
    }

    // Update is called once per frame
    void Update()
    {
        foodText.text = $"Food: {food} p";
        cashText.text = $"Cash: {cash}$";
        productionPowerText.text = $"Production Power: {productionPower}/s";
        consumptionPowerText.text = $"Consumption Power: {consumer.consumePower} p in {consumer.consumeTime} sec";
        cashMultiplierText.text = $"Cash multiplier: {cashMultiplier}x";

    }

    public bool BuyObject(string objectName)
    {
        switch (objectName)
        {
            case "Fridge":
                if (fridgeCost > cash) return false;
                cash -= fridgeCost;
                Debug.Log("Нашел холодос");
                break;
            case "Ovens":
                if (ovensCost > cash) return false;
                cash -= ovensCost;
                break;
            case "Gas Range":
                if (gasRangeCost > cash) return false;
                cash -= gasRangeCost;
                break;
            case "Hood":
                if (hoodCost > cash) return false;
                cash -= hoodCost;
                break;
            default:
                Debug.Log("No object is found");
                return false;
        }
        producers.transform.Find(objectName).gameObject.SetActive(true);
        return true;
    }
}
