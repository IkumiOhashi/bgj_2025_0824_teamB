using UnityEngine;
using System.Collections.Generic;

// 施設をまとめて管理するやつ
public class FacilityManager : MonoBehaviour
{
    // お金管理クラス
    public MoneyRepository moneyRepository;

    // 施設のリスト
    public List<Facility> facilities = new List<Facility>();

    // 施設購入処理
    public bool BuyFacility(int index)
    {
        // 範囲外なら買えない
        if (index < 0 || index >= facilities.Count) return false;

        Facility facility = facilities[index];
        double price = facility.CurrentPrice;

        // お金足りてたら購入
        if (moneyRepository.UseMoney(price))
        {
            facility.count++; // 所持数アップ
            return true;
        }

        // 買えなかった
        return false;
    }
}
