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
        manager = FindFirstObjectByType<FacilityManager>();     // �}�l�[�W���[�̎擾
        repository = FindFirstObjectByType<MoneyRepository>();  // ���|�W�g���̎擾

        // �x�[�X���i��unlockMultiplier�{�̒l�i�Ȃ�w���\
        basePrice = manager.GetBasePrice((int)facilityName);    // �x�[�X���i�̎擾
        unlockPrice = basePrice * unlockMultiplier;

        isVisible = CanVisible();

        cg = GetComponent<CanvasGroup>();
        VisibleSwitcher();
    }

    private void Update()
    {
        // isVisble�̍X�V
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
            repository.maxHeldMoney > unlockPrice ||          // �����ō��z������z��荂��
            facilityName == FacilityName.OnlineShop ||        // �I�����C���V���b�v�͏�ɉ�
            manager.facilities[(int)facilityName].count > 0;  // 1�ȏ㏊�����Ă���
    }

    private void VisibleSwitcher()
    {
        if (isVisible == false)
        {
            cg.alpha = 0f;           // �����ڂ�����
            cg.interactable = false; // �����Ȃ�
            cg.blocksRaycasts = false; // �����蔻�������
        }
        else
        {
            cg.alpha = 1f;           // �����ڂ�����
            cg.interactable = true; // �����Ȃ�
            cg.blocksRaycasts = true; // �����蔻�������
        }
    }

}
