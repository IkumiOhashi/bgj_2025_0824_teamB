using UnityEngine;

public class MoneyRepository : MonoBehaviour
{
    public double totalAssets; // �����Y

    // ���������Z
    public void AddMoney(double _money)
    {
        totalAssets += _money;
    }

    // �����̎g�p�@�\�Ȃ�true �s�\�Ȃ�false��Ԃ�
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

    // ���݂̑����Y���擾
    public double GetTotalAssets()
    {
        return totalAssets;
    }
}
