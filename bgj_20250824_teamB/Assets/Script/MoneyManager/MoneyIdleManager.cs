using System.Collections.Generic;
using UnityEngine;

public class MoneyIdleManager : MonoBehaviour
{
    [SerializeField] double moneyPerSecond = 1;
    [SerializeField] MoneyRepository repository;

    [SerializeField] DollarPerSecondDisplay dispValue;  // �b�Ԃ̑�����

    [SerializeField] FacilityManager facilityManager;   // �{�݌Q

    private void Awake()
    {
        ChangeMoneyPerSecond();
    }

    private void Update()
    {
        repository.AddMoney(moneyPerSecond * Time.deltaTime);
    }

    // �b�Ԃ̐��Y�ʂ̕ύX
    public void ChangeMoneyPerSecond()
    {
        //�@FacilityName name;
        moneyPerSecond = 0;

        for (int i = 0; i < facilityManager.facilities.Count; i++)
        {
            double production = facilityManager.facilities[i].Production;
            // double buff = ~~~;

            // moneyPerSecond = production * buff;
            moneyPerSecond += production;
        }

        // �b�Ԑ��Y�ʂ̕\���ʂ�ύX
        dispValue.SetDollarPerSecond(moneyPerSecond);
    }
}