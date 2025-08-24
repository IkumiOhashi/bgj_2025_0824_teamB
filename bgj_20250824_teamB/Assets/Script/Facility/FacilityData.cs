using UnityEngine;

public enum FacilityName
{
    Cursor,
    Grandma,
    Farm,
    Factory,
    Mine
}

[CreateAssetMenu(fileName = "FacilityData", menuName = "Clicker/FacilityData")]
public class FacilityData : ScriptableObject
{
    public FacilityName FacilityName;       // �A�C�e�����i��: �H��j
    public double baseProduction; // 1������̊�b���Y��
    public double basePrice;      // �������i
    public double priceIncrease;  // ���i�㏸���i��: 1.15 �� 15%�オ��j
}