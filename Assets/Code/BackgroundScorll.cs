using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScorll : MonoBehaviour
{
    //���� ���Ϳ�����Ʈ ����
    GameObject gamedirector = null;
    //����� �̵��� ��ǥ ��ġ�� �����ϴ� ����
    [SerializeField]
    private Transform target;
    //����� �̵��� ���� �����ϴ� ����
    [SerializeField]
    private float fscrollRange = 13.95f;
    //����� �̵� ����
    [SerializeField]
    private float fmoveSpeed = 3.0f;
    //����� �̵� ���� ���� ����
    [SerializeField]
    private Vector3 fmoveDirection = Vector3.down;



  
    void Start()
    {

    }

    //�� �����Ӹ��� ����� �̵���Ű�� ������Ʈ �Լ�
    //����� fmoveDirection �������� fmoveSpeed�ӵ��� �̵���Ű�� scrollRange�Ʒ��� ������ ��
    //����� target��ġ�� �ٽ� �̵�
    private void Update()
    {
        transform.position += fmoveDirection * fmoveSpeed * Time.deltaTime;

        if (transform.position.y <= -fscrollRange)
        {
            transform.position = target.position + Vector3.up * fscrollRange;
        }
    }

}