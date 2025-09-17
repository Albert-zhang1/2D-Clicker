using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    public Text income;
    public Text price;
    public int StartingPrice = 5;
    public float UpgradeMutliplier;
    public float AmountPerUpgrade;
    public Button button;
    public Image character;
    public Text name;
    public string storeName;

    private int level = 0;
    
    public GameManager account;
    private void Start()
    {
        UpdateUI();
    }
    private void Update()
    {
        
    }
    int upgradeCost()
    {
        int price = Mathf.RoundToInt(StartingPrice * Mathf.Pow(UpgradeMutliplier, level));
        return price;
    }
    public void UpdateUI()
    {
        price.text = upgradeCost().ToString();
        income.text = level + "x" + AmountPerUpgrade.ToString() + "/s";
        bool afford = account.count >= upgradeCost();
        button.interactable = afford;

        bool unlock = level > 0;
        character.color = unlock ? Color.white : Color.black;
        name.text = unlock ? storeName : "???";
        //character.IsActive = afford;
    }
    public float gainedIncome()
    {
        /* float Income = 1;
         AmountPerUpgrade = Income / 60;
         return Income;*/
        return AmountPerUpgrade * level;
    }
    public void Click()
    {
        int cost = upgradeCost();
        bool purchase = account.purchases(cost);
        if (purchase)
        {
            //account.Idelupdate();
            level++;
            UpdateUI();
        }
    }
    /*
    private GameManager count;
    public int cost;
    // Start is called before the first frame update
    void Start()
    {
        count = account.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update(int amount)
    {
        amount++;
    }
    void Worker(int amount)
    {
        amount = amount - cost;
        Update(amount);
    }*/
}
