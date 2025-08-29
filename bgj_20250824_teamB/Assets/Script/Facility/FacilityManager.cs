using UnityEngine;
using System.Collections.Generic;

// �{�݂��܂Ƃ߂ĊǗ�������
public class FacilityManager : MonoBehaviour
{
    // �����Ǘ��N���X
    [SerializeField] private MoneyRepository moneyRepository;
    [SerializeField] private MoneyIdleManager moneyIdleManager;

    // �{�݂̃��X�g
    public List<Facility> facilities = new List<Facility>();

    // �{�ݍw������
    public bool BuyFacility(int index)
    {
        //Debug.Log("�� �w���J�n");
        // �͈͊O�Ȃ甃���Ȃ�
        if (index < 0 || index >= facilities.Count) return false;

        Facility facility = facilities[index];
        double price = facility.CurrentPrice;

        //Debug.Log("�A�C�e���̒l�i" + price); 

        // ��������Ă���w��
        if (moneyRepository.UseMoney(price))
        {
            //Debug.Log("�Z �w������");
            facility.count++; // �������A�b�v
            moneyIdleManager.ChangeMoneyPerSecond();
            return true;
        }

        Debug.Log("�~ �w�����s");
        // �����Ȃ�����
        return false;
    }

    // �x�[�X���i���擾
    public double GetBasePrice(int _index)
    {
        return facilities[_index].data.basePrice;
    }
}
