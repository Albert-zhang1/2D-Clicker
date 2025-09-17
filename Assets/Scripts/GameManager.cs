using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Upgrade[] upgrade;
    public Text gingerbread;
    public Text income;
    public float count = 0;
    float timeCheck = 1;
    float currentIncome;
    public int refresh = 5;


    private void Start()
    {
        UpdateUI();
    }
    private void Update()
    {
        if(timeCheck < Time.timeSinceLevelLoad)
        {
            IdelUpdate();
            timeCheck = Time.timeSinceLevelLoad + 1f/ refresh;
        }
        
       
    }
    void IdelUpdate()
    {
        float sum = 0;
        foreach (var levelUp in upgrade)
        {
            sum += levelUp.gainedIncome();
            levelUp.UpdateUI();
        }
        count += sum;
        currentIncome = sum / refresh;
        UpdateUI();
        /* Debug.Log("1");
         while(upgrade.AmountPerUpgrade > 0)
         {
             count = count + Mathf.RoundToInt(upgrade.AmountPerUpgrade * Time.deltaTime);
         }*/
    }
    public void ClickAction()
    {
        count++;
        Debug.Log(count);
        UpdateUI();
    }
    void UpdateUI()
    {
        gingerbread.text = Mathf.RoundToInt(count).ToString() + "\n" + "Gingerbreads";
        income.text = currentIncome.ToString() + "/s";
    }
    public bool purchases(int cost)
    {
        if(count >= cost)
        {
            count -= cost;
            UpdateUI();
            return true;
        }
        return false;
    }
}
