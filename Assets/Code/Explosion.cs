using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // ��ƼŬ �ý��� ������Ʈ�� �����ϱ� ���� ����
    private ParticleSystem explosion;

    private void Awake()
    {
        // ���� ���� ������Ʈ�� ��ƼŬ �ý��� ������Ʈ�� ������
        explosion = GetComponent<ParticleSystem>();
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        // ��ƼŬ ��� ������ Ȯ��
        if (explosion.isPlaying == false)
        {
            // ��ƼŬ ����� ������ �ڱ� �ڽ��� �ı�
            Destroy(gameObject);
        }
    }
}
