using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject Alien1; // �ܰ��� 1 ������ ����
    public GameObject Alien2; // �ܰ��� 2 ������ ����
    private float fspan = 0.15f; // �ܰ��� ���� �ֱ� ����
    private float fdelta = 0; // ���� �ð� ����

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemyCome();
    }
    void EnemyCome()
    {
        this.fdelta += Time.deltaTime; // �� �����Ӹ��� ���� �ð��� ������Ʈ
        if (this.fdelta > this.fspan) // ���� �ð��� ���� �ֱ⸦ �ʰ��� �ܰ��� ����
        {
            // �ܰ��� ����
            GameObject prefab;
            if (Random.value < 0.5f)
                prefab = Alien1; // 50%�� Ȯ���� �ܰ��� 1 ����
            else
                prefab = Alien2; // 50%�� Ȯ���� �ܰ��� 2 ����

            var go = Instantiate(prefab); // �������� �ν��Ͻ�ȭ�Ͽ� ���� ������Ʈ ����
            // ������ ��ġ�� ����
            go.transform.position = new Vector3(Random.Range(-2.58f, 2.58f), Random.Range(5.5f, 5.94f), 0);

            this.fdelta = 0; // ���� �ð� �ʱ�ȭ
        }
    }
}
