[System.Serializable]
public class Facility
{
    public FacilityData data; // ’è‹`ƒf[ƒ^
    public int count = 0; // Š”

    // Œ»İ‰¿Ši
    public double CurrentPrice
    {
        get
        {
            return data.basePrice * (count + 1);
        }
    }

    // 1•b‚ ‚½‚è‚Ì¶Y—Ê
    public double Production
    {
        get
        {
            return data.baseProduction * count;
        }
    }
}