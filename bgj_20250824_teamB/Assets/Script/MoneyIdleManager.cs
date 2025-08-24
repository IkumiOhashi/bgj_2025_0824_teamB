using UnityEngine;

public class MoneyIdleManager : MonoBehaviour
{
    [SerializeField] double moneyPerSecond = 1;
    [SerializeField] MoneyRepository repository;

    private void Update()
    {
        repository.AddMoney(moneyPerSecond * Time.deltaTime);
    }
}
