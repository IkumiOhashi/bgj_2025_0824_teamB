using UnityEngine;

public class MoneyClickManager : MonoBehaviour
{
    [SerializeField] private double clickedAddMoney = 10;
    [SerializeField] MoneyRepository moneyRepository;
 
    public void OnClicked()
    {
        moneyRepository.AddMoney(clickedAddMoney);
    }
}