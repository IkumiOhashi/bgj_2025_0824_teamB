using UnityEngine;

public class BuyButton : MonoBehaviour
{
    [SerializeField] FacilityName facilityName;
    [SerializeField] BuyButtonUIController uIController;

    public bool isVisible;
    CanvasGroup cg;

    private FacilityManager manager;
    private MoneyRepository repository;

    private double basePrice;
    private double unlockMultiplier = 0.9;
    private double unlockPrice;

    private void Awake()
    {
        manager = FindFirstObjectByType<FacilityManager>();     // マネージャーの取得
        repository = FindFirstObjectByType<MoneyRepository>();  // リポジトリの取得

        // ベース価格のunlockMultiplier倍の値段なら購入可能
        basePrice = manager.GetBasePrice((int)facilityName);    // ベース価格の取得
        unlockPrice = basePrice * unlockMultiplier;

        isVisible = CanVisible();

        cg = GetComponent<CanvasGroup>();
        VisibleSwitcher();
    }

    private void Update()
    {
        // isVisbleの更新
        if (isVisible == false)
        {
            if (CanVisible())
            {
                isVisible = true;
                uIController.AddVisibleButton();
            }
        }

        VisibleSwitcher();
    }

    public void OnClickBuyFacility()
    {
        manager.BuyFacility((int)facilityName);
    }

    private bool CanVisible()
    {
        return
            repository.maxHeldMoney > unlockPrice ||          // 所持最高額が解放額より高い
            facilityName == FacilityName.OnlineShop ||        // オンラインショップは常に可視
            manager.facilities[(int)facilityName].count > 0;  // 1つ以上所持している
    }

    private void VisibleSwitcher()
    {
        if (isVisible == false)
        {
            cg.alpha = 0f;           // 見た目を消す
            cg.interactable = false; // 押せない
            cg.blocksRaycasts = false; // 当たり判定も無効
        }
        else
        {
            cg.alpha = 1f;           // 見た目を消す
            cg.interactable = true; // 押せない
            cg.blocksRaycasts = true; // 当たり判定も無効
        }
    }

}
