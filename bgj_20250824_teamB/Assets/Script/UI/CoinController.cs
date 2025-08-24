using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField] private AudioClip[] clickSounds;   // �炷���z��@�����_���Ō��肷��
    private AudioSource audioSource;

    // �R�C�����΂��̂Ɏg�����ꂱ��
    [SerializeField] private GameObject coinPrefab;       // Rigidbody2D�t���̃R�C��Prefab
    [SerializeField] private Transform spawnOrigin;       // ���w��Ȃ玩���̈ʒu
    [SerializeField] private int spawnCount = 5;          // ��x�ɔ�΂���
    [SerializeField] private float coinLifetime = 2f;     // �����j������(�b�E0�ȉ��Ŗ���)

    [SerializeField] private Vector2 forceRange = new Vector2(3f, 6f); // �C���p���X�̋���
    [SerializeField] private float angleSpread = 360f;    // �p�x�g�U(�x)�B360�Ȃ�S����
    [SerializeField] private float torqueRange = 180f;    // �p���x�̃����_����(�})


    private int lastIndex = -1; // �O��I�񂾃C���f�b�N�X

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnClicked()
    {
        PlayClickSound();
        SpawnAndShootCoins();
    }


    private void SpawnAndShootCoins()
    {
        if (coinPrefab == null) return;

        // �����ʒu������
        Vector3 spawnPos;
        
        spawnPos = (spawnOrigin != null) ? spawnOrigin.position : transform.position;

        for (int i = 0; i < spawnCount; i++)
        {
            GameObject coin = Instantiate(coinPrefab, spawnPos, Quaternion.identity);

            if (coinLifetime > 0f)
            {
                Destroy(coin, coinLifetime);
            }

            Rigidbody2D rb = coin.GetComponent<Rigidbody2D>();
            if (rb == null) continue;

            // �����_�������i�����Ɂ}�����̃X�v���b�h�j
            float angle = Random.Range(-angleSpread * 0.5f, angleSpread * 0.5f);
            Vector2 dir = Quaternion.Euler(0f, 0f, angle) * Vector2.up; // �g��h���S�̎U��

            float force = Random.Range(forceRange.x, forceRange.y);
            rb.AddForce(dir.normalized * force, ForceMode2D.Impulse);

            // �����_����]�������ă��b�`��
            float torque = Random.Range(-torqueRange, torqueRange);
            rb.AddTorque(torque, ForceMode2D.Impulse);
        }
    }

    // AudioClip�z��̒����烉���_���ōĐ��@�O��Ɠ������͍Đ�����Ȃ�
    private void PlayClickSound()
    {
        if (clickSounds == null || clickSounds.Length == 0) return;

        int index;

        if (clickSounds.Length == 1)
        {
            index = 0;
        }
        else
        {
            // �O��ƈႤ�C���f�b�N�X��I��
            do
            {
                index = Random.Range(0, clickSounds.Length);
            } while (index == lastIndex);
        }

        lastIndex = index;
        audioSource.PlayOneShot(clickSounds[index]);
    }


}
