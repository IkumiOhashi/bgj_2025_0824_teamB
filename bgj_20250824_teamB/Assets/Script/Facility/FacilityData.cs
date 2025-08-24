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
    public FacilityName FacilityName;       // ƒAƒCƒeƒ€–¼i—á: Hêj
    public double baseProduction; // 1ŒÂ‚ ‚½‚è‚ÌŠî‘b¶Y—Ê
    public double basePrice;      // ‰Šú‰¿Ši
    public double priceIncrease;  // ‰¿Šiã¸—¦i—á: 1.15 ¨ 15%ã‚ª‚éj
}