using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgrounSound : MonoBehaviour
{
    //������ǿ� ���� ��������
    public AudioSource bgm;
    // Start is called before the first frame update
    void Start()
    {
        //bgm�� ���� �ݺ�
        bgm.loop = true;
        //bgm �÷���
        bgm.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
