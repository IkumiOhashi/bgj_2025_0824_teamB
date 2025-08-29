using System.Collections.Generic;
using UnityEngine;

public class MoneyIdleManager : MonoBehaviour
{
    [SerializeField] double moneyPerSecond = 1;
    [SerializeField] MoneyRepository repository;

    [SerializeField] DollarPerSecondDisplay dispValue;  // •bŠÔ‚Ì‘‰Á—Ê

    [SerializeField] FacilityManager facilityManager;   // {İŒQ

    private void Awake()
    {
        ChangeMoneyPerSecond();
    }

    private void Update()
    {
        repository.AddMoney(moneyPerSecond * Time.deltaTime);
    }

    // •bŠÔ‚Ì¶Y—Ê‚Ì•ÏX
    public void ChangeMoneyPerSecond()
    {
        //@FacilityName name;
        moneyPerSecond = 0;

        for (int i = 0; i < facilityManager.facilities.Count; i++)
        {
            double production = facilityManager.facilities[i].Production;
            // double buff = ~~~;

            // moneyPerSecond = production * buff;
            moneyPerSecond += production;
        }

        // •bŠÔ¶Y—Ê‚Ì•\¦—Ê‚ğ•ÏX
        dispValue.SetDollarPerSecond(moneyPerSecond);
    }
}