using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private float fspeed = 7; // �÷��̾� �̵� �ӵ� ����
    public GameObject explosionPrefab; // �浹 �� �����Ǵ� ������

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Fire(); //�Ѿ� �߻�
    }

    //���� �浹 �� ó�� �Լ�
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            float fscoreToAdd = 0f;
            GameDirector director = GameObject.FindObjectOfType<GameDirector>();
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            fscoreToAdd = enemy.score;
            director.UpdateScore(enemy.score); // ���ӵ��͸� ���� ���� ������Ʈ
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            // ���� ȿ�� ����
            // ���� ���� ��ġ�� prefab �Ͼ �� �ְ� ��
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }
        else if (collision.gameObject.tag == "Boss")
        {
            // ������ �浹�� ��� ó�� �ڵ�
            Boss boss = collision.gameObject.GetComponent<Boss>();
            boss.TakeDamage(5f); // ������ HP�� 5 ���ҽ�Ŵ
            Destroy(this.gameObject);
        }
    }
    void Fire()
    {
        // �Ѿ��� ������ �ӵ��� �̵���Ŵ
        this.transform.Translate(this.transform.up * this.fspeed * Time.deltaTime);
        // ȭ���� ��� �Ѿ� �ı�
        if (this.transform.position.y > 4.81f)
        {
            Destroy(this.gameObject);
        }
    }
}
