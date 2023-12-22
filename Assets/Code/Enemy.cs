using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float fspeed = 0.8f; // ���� �̵� �ӵ� ����
    public int score; // ���� ���༱�� ���� ���� ����
    private GameDirector gameDirector;

    private float fmoveDistance = 1f; // �¿�� �̵��� �Ÿ�
    private float fmoveDelay = 1.5f; // �¿� �̵� ����
    private float fmoveTimer = 0f; // �̵� Ÿ�̸�

    private float fminX = -2.58f; // ������ ���� �Ѱ� ��ġ
    private float fmaxX = 2.58f; // ������ ���� �Ѱ� ��ġ
    private float ftargetX; // �̵��� ��ǥ ��ġ

    // Start is called before the first frame update
    void Start()
    {
        gameDirector = FindObjectOfType<GameDirector>();

        // �ʱ� �̵� ��ǥ ��ġ ����
        SetNewTargetX();
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy(); // ���� �̵�

        // ������ ���� ��ġ���� �������� ����
        if (transform.position.y < -5.19f)
        {
            Destroy(gameObject);
        }
    }

    // ���� �̵� �Լ�
    private void MoveEnemy()
    {
        // �¿�� �̵�
        fmoveTimer += Time.deltaTime;
        if (fmoveTimer >= fmoveDelay)
        {
            SetNewTargetX(); // ���ο� �̵� ��ǥ ��ġ ����
            fmoveTimer = 0f;
        }
        // ������ �̵��ؾ� �� �Ÿ� ���
        float step = fspeed * Time.deltaTime;
        // ���� ��ġ���� ��ǥ��ġ�� step��ŭ �̵�
        // MoveTowards �Լ��� ���� ��ġ, ��ǥ ��ġ, �̵� �Ÿ�(step)�� �޾Ƽ�
        // �� ���� �� �Ǵ� ���� ���̿��� ���������� �߰� ���� ���ϴ� ��
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(ftargetX, transform.position.y, transform.position.z), step);

        // �Ʒ��� �̵�
        transform.Translate(Vector3.up * fspeed * Time.deltaTime);
    }

    private void SetNewTargetX()
    {
        // �¿� �̵��� ��ǥ ��ġ�� �����ϰ� ����
        ftargetX = Random.Range(fminX, fmaxX);
    }

    // Player�� �浹 �� ���� ����� shootingGV ȭ������ �̵�
    // Debug�� �׾��� ���� ���� ���
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("���� ����");
            SceneManager.LoadScene("shootingGV");
            Debug.Log("������ ����: " + gameDirector.GetScore());
        }
    }
}
