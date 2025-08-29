using UnityEngine;

public class MoneyRepository : MonoBehaviour
{
    public double totalAssets;      // �����Y
    public double maxHeldMoney;    // �ߋ��̍ō������Y�z

    // ���������Z
    public void AddMoney(double _money)
    {
        totalAssets += _money;
    }

    // �����̎g�p�@�\�Ȃ�true �s�\�Ȃ�false��Ԃ�
    public bool UseMoney(double _money)
    {
        //Debug.Log("������ : " + totalAssets);
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
    public double GetTotalAssets() { return totalAssets; }

    // �ߋ��ō��̑����Y���擾
    public double GetMaxHeldMoney() { return maxHeldMoney; }

    private void Update()
    {
        if(totalAssets > maxHeldMoney) maxHeldMoney = totalAssets;
    }
}
