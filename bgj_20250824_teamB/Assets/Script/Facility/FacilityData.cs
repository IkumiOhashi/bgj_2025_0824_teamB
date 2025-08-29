using UnityEngine;

public enum FacilityName
{
    OnlineShop,             // �l�l�b�g�V���b�v
    ConvenienceStore,       // �R���r�j
    ShoppingMall,           // �V���b�s���O���[��
    Bank,                   // ��s
    GlobalCorporation,      // �����Њ��
    Nation,                 // ����
    PlanetEarth,            // �n��
    ParallelWorld,          // ���s���E
    GalacticFederation,     // ��͘A��
    TimeBank,               // �����s
}

[CreateAssetMenu(fileName = "FacilityData", menuName = "Clicker/FacilityData")]
public class FacilityData : ScriptableObject
{
    public FacilityName FacilityName;       // �A�C�e�����i��: �H��j
    public double baseProduction; // 1������̊�b���Y��
    public double basePrice;      // �������i
    public double priceIncrease;  // ���i�㏸���i��: 1.15 �� 15%�オ��j
}