using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    
    [SerializeField]
    private float fmaxHP = 10000; // ������ �ִ� ü�� ����
    private float fcurrentHP;   // ���� ������ ü�� ����
    private bool ismovingRight = true; //������ ���� ���������� �����̰� �ִٴ� ����
    private float fmoveSpeed = 2f; //������ �̵� �ӵ��� ��Ÿ���� ����
    private float fminX = -2.2f; // �������� ������ �ּ� X ��ǥ
    private float fmaxX = 2.2f; // ���������� ������ �ִ� X ��ǥ
    private Vector3 targetPosition; // ������ �̵��Ϸ��� ��ǥ ��ġ ����

    private GameDirector gameDirector; // GameDirector ��ũ��Ʈ ���� ����

    // Start is called before the first frame update
    void Start()
    {
        fcurrentHP = fmaxHP;
        targetPosition = transform.position;

        // GameDirector ��ũ��Ʈ ����
        gameDirector = FindObjectOfType<GameDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("���� ���� HP: " + fcurrentHP);

        MoveBoss();
    }

    //������ ���� ���ظ�ŭ ü���� ����
    public void TakeDamage(float damage)
    {
        fcurrentHP -= damage;
        if (fcurrentHP <= 0)
        {
            // ������ óġ�� ����� ó�� �ڵ�
            Destroy(gameObject);

            // ������ ���ھ� Debug ���
            Debug.Log("Final Score: " + gameDirector.GetScore());
            // ���� ü���� 0�� �� �� EndScene���� �̵�
            SceneManager.LoadScene("EndScene");
        }
    }

    // ������ �̵���Ű�� �Լ�
    private void MoveBoss()
    {
        if (ismovingRight)
        {
            // ���� ������ ���������� �̵� ���� ���
            // ��ǥ ��ġ�� ������ ���� fmaxX�� ����
            targetPosition = new Vector3(fmaxX, transform.position.y, transform.position.z);
        }
        else
        {
            // ���� ������ �������� �̵� ���� ���
            // ��ǥ ��ġ�� ���� ���� fminX�� ����
            targetPosition = new Vector3(fminX, transform.position.y, transform.position.z);
        }

        // ������ ��ǥ ��ġ�� �̵���ŵ�ϴ�.
        // �̵� �ӵ��� fmoveSpeed�� Time.deltaTime��
        // ���Ͽ� �����ӿ� �������� �̵��� ����
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, fmoveSpeed * Time.deltaTime);

        // ������ ��ǥ ��ġ�� ������ ��� �̵� ������ �ݴ�� ��ȯ�մϴ�.
        if (transform.position == targetPosition)
        {
            ismovingRight = !ismovingRight;
        }
    }

}
