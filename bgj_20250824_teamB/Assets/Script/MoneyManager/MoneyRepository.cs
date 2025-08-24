using UnityEngine;

public class MoneyRepository : MonoBehaviour
{
    public double totalAssets; // 総資産

    // お金を加算
    public void AddMoney(double _money)
    {
        totalAssets += _money;
    }

    // お金の使用　可能ならtrue 不可能ならfalseを返す
    public bool UseMoney(double _money)
    {
        if(totalAssets < _money)
        {
            return false;
        }
        else
        {
            totalAssets -= _money;
            return true;
        }
    }

    // 現在の総資産を取得
    public double GetTotalAssets()
    {
        return totalAssets;
    }
}
