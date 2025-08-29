using UnityEngine;
using UnityEngine.InputSystem;

public class BuyButtonUIController : MonoBehaviour
{
    [SerializeField] private BuyButton[] buyButtons;

    [SerializeField] private double scrollSpeed;

    // �{�^����Transform����ȕϐ�
    private double buttonHeight = 172.5;
    private double buyButtonAreaHeight = 690;

    // �X�N���[���Ɋւ���ϐ�
    private double baseHeight;
    private double addHeight;
    private double scrollHeightMax;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CalclateScrollHeightMax();

        // �{�^���̏����ʒu������
        for (int i = 0; i < buyButtons.Length; i++)
        {
            RectTransform rt = buyButtons[i].GetComponent<RectTransform>();
            float y = (float)(buttonHeight / 2 - buttonHeight * i) - (float)(buttonHeight / 2);
            rt.anchoredPosition = new Vector2(0f, y);
        }

        // ���g�̏���Y���W����̍����Ƃ��ċL�^
        baseHeight = transform.position.y;
        addHeight = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        ScrollButtons();
    }

    // �����Ă���{�^���̍��v�������擾
    double CalculateButtonHeight()
    {
        double result = 0;

        int isVisibleButtonNum = SumVisibleButtonNum();
        result = buttonHeight * (float)isVisibleButtonNum;

        return result;
    }

    // ����̃{�^���̍��v�����v�Z
    private int SumVisibleButtonNum()
    {
        int result = 0;

        foreach (var buyButton in buyButtons)
        {
            if(buyButton.isVisible) result++;
        }

        return result;
    }

    // ���{�^�������������Ƃ�ʒm����
    public void AddVisibleButton()
    {
        CalclateScrollHeightMax();
    }

    // �{�^�����}�E�X�J�[�\���ŃX�N���[������
    private void ScrollButtons()
    {
        // �VInput System�̃X�N���[���l���擾�i1�m�b�` �� 120 ��z�肵�Đ��K���j
        float scrollNotch = 0f;
        if (Mouse.current != null)
        {
            // scroll �̓s�N�Z���P�ʂ��ۂ��l�i�����̊���1�m�b�`=�}120�j
            float raw = Mouse.current.scroll.ReadValue().y;
            scrollNotch = -(raw / 120f);
        }

        if (Mathf.Abs(scrollNotch) > 0.001f)
        {
            // ���Z�l���X�V�idouble �̂܂܌v�Z�j
            addHeight += scrollNotch * (float)scrollSpeed;

            // �㉺�����N�����v�idouble�Ή��BMathf.Clamp �� float �p�j
            addHeight = System.Math.Max(0.0, System.Math.Min(addHeight, scrollHeightMax));

            // �ʒu���f�i� + ���Z�j
            var pos = transform.position;
            pos.y = (float)(baseHeight + addHeight);
            transform.position = pos;
        }
    }

    // �X�N���[���\�ȍ������擾
    private void CalclateScrollHeightMax()
    {
        double allButtonsHeight = CalculateButtonHeight();

        scrollHeightMax = allButtonsHeight - buyButtonAreaHeight;
        scrollHeightMax -= buttonHeight / 2;

        if (scrollHeightMax < 0) scrollHeightMax = 0;

        Debug.Log(scrollHeightMax);
    }
}