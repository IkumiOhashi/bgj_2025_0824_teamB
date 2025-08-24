using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class CoinFlipSpin2D : MonoBehaviour
{
    [Header("Sprites")]
    [SerializeField] private Sprite frontSprite;      // �\��
    [SerializeField] private Sprite backSprite;       // ����

    [Header("Flip Motion")]
    [SerializeField] private float degreesPerSecond = 720f; // �R�C���́g��]���x�h�i��������j
    [SerializeField, Range(0f, 1f)] private float minEdgeScale = 0.08f; // �^���̎��̍ŏ�����
    [SerializeField] private bool useUnscaledTime = false;  // �|�[�Y�����񂵂����Ȃ� true

    private SpriteRenderer sr;
    private Vector3 baseScale;
    private float angleDeg;       // �������̉�]�p�iY��]�����j
    private bool showingBack;     // ���� ���� �\�������H

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        baseScale = transform.localScale;
    }

    private void OnEnable()
    {
        angleDeg = 0f;
        showingBack = false;
        if (frontSprite != null) sr.sprite = frontSprite;
        // �O�̂��ߌ��X�P�[���ɖ߂�
        transform.localScale = baseScale;
    }

    private void Update()
    {
        float dt = useUnscaledTime ? Time.unscaledDeltaTime : Time.deltaTime;
        angleDeg += degreesPerSecond * dt;

        // �R�T�C���� �g���݁h ��\���F�}1 �� 1�A 0�t�߁i�������j�� 0 �ɋ߂Â�
        float cos = Mathf.Cos(angleDeg * Mathf.Deg2Rad);

        // �������Ŋ��S�ɏ����Ȃ��悤����������
        float xScale = Mathf.Max(Mathf.Abs(cos), minEdgeScale);

        // X��������/�������ăR�C���̌��ݕ\��
        Vector3 s = baseScale;
        s.x = baseScale.x * xScale;
        transform.localScale = s;

        // �\���̐ؑցFcos < 0 �̔������͗��ʁA����ȊO�͕\��
        bool nowBack = (cos < 0f);
        if (nowBack != showingBack)
        {
            sr.sprite = nowBack ? backSprite : frontSprite;
            showingBack = nowBack;
        }
    }
}
