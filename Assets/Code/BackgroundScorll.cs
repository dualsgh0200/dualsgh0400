using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScorll : MonoBehaviour
{
    //게임 디렉터오브젝트 참조
    GameObject gamedirector = null;
    //배경이 이동할 목표 위치를 지정하는 변수
    [SerializeField]
    private Transform target;
    //배경이 이동할 범위 지정하는 변수
    [SerializeField]
    private float fscrollRange = 13.95f;
    //배경의 이동 범위
    [SerializeField]
    private float fmoveSpeed = 3.0f;
    //배경의 이동 방향 지정 변수
    [SerializeField]
    private Vector3 fmoveDirection = Vector3.down;



  
    void Start()
    {

    }

    //매 프레임마다 배경을 이동시키는 업데이트 함수
    //배경을 fmoveDirection 방향으로 fmoveSpeed속도로 이동시키고 scrollRange아래로 내려갈 시
    //배경을 target위치로 다시 이동
    private void Update()
    {
        transform.position += fmoveDirection * fmoveSpeed * Time.deltaTime;

        if (transform.position.y <= -fscrollRange)
        {
            transform.position = target.position + Vector3.up * fscrollRange;
        }
    }

}