using TMPro;
using UnityEngine;

public class DisplayTotalAssets : MonoBehaviour
{
    [SerializeField] MoneyRepository repository;
    private TextMeshProUGUI moneyText;
    private double value;

    private void Start()
    {
        moneyText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        value = repository.GetTotalAssets();
        moneyText.text = value.ToString("N2");
    }
}
