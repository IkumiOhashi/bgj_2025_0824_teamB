using UnityEngine;

public class MoneyIdleManager : MonoBehaviour
{
    [SerializeField] double moneyPerSecond = 1;
    [SerializeField] MoneyRepository repository;

    [SerializeField] DollarPerSecondDisplay dispValue;

    private void Update()
    {
        repository.AddMoney(moneyPerSecond * Time.deltaTime);

        dispValue.SetDollarPerSecond(moneyPerSecond);
    }
}
