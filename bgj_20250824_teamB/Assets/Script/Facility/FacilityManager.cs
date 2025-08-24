using UnityEngine;
using System.Collections.Generic;

// �{�݂��܂Ƃ߂ĊǗ�������
public class FacilityManager : MonoBehaviour
{
    // �����Ǘ��N���X
    public MoneyRepository moneyRepository;

    // �{�݂̃��X�g
    public List<Facility> facilities = new List<Facility>();

    // �{�ݍw������
    public bool BuyFacility(int index)
    {
        // �͈͊O�Ȃ甃���Ȃ�
        if (index < 0 || index >= facilities.Count) return false;

        Facility facility = facilities[index];
        double price = facility.CurrentPrice;

        // ��������Ă���w��
        if (moneyRepository.UseMoney(price))
        {
            facility.count++; // �������A�b�v
            return true;
        }

        // �����Ȃ�����
        return false;
    }
}
