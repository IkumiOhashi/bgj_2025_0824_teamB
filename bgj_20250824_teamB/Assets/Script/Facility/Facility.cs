[System.Serializable]
public class Facility
{
    public FacilityData data; // ��`�f�[�^
    public int count = 0; // ������

    // ���݉��i
    public double CurrentPrice
    {
        get
        {
            return data.basePrice * (count + 1);
        }
    }

    // 1�b������̐��Y��
    public double Production
    {
        get
        {
            return data.baseProduction * count;
        }
    }
}