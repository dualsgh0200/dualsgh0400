using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    
    [SerializeField]
    private float fmaxHP = 10000; // 보스의 최대 체력 변수
    private float fcurrentHP;   // 현재 보스의 체력 변수
    private bool ismovingRight = true; //보스가 현재 오른쪽으로 움직이고 있다는 변수
    private float fmoveSpeed = 2f; //보스의 이동 속도를 나타내는 변수
    private float fminX = -2.2f; // 왼쪽으로 움직일 최소 X 좌표
    private float fmaxX = 2.2f; // 오른쪽으로 움직일 최대 X 좌표
    private Vector3 targetPosition; // 보스가 이동하려는 목표 위치 변수

    private GameDirector gameDirector; // GameDirector 스크립트 참조 변수

    // Start is called before the first frame update
    void Start()
    {
        fcurrentHP = fmaxHP;
        targetPosition = transform.position;

        // GameDirector 스크립트 참조
        gameDirector = FindObjectOfType<GameDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("현재 보스 HP: " + fcurrentHP);

        MoveBoss();
    }

    //보스가 받은 피해만큼 체력을 감소
    public void TakeDamage(float damage)
    {
        fcurrentHP -= damage;
        if (fcurrentHP <= 0)
        {
            // 보스를 처치한 경우의 처리 코드
            Destroy(gameObject);

            // 마지막 스코어 Debug 출력
            Debug.Log("Final Score: " + gameDirector.GetScore());
            // 보스 체력이 0이 될 시 EndScene으로 이동
            SceneManager.LoadScene("EndScene");
        }
    }

    // 보스를 이동시키는 함수
    private void MoveBoss()
    {
        if (ismovingRight)
        {
            // 현재 보스가 오른쪽으로 이동 중인 경우
            // 목표 위치를 오른쪽 끝인 fmaxX로 설정
            targetPosition = new Vector3(fmaxX, transform.position.y, transform.position.z);
        }
        else
        {
            // 현재 보스가 왼쪽으로 이동 중인 경우
            // 목표 위치를 왼쪽 끝인 fminX로 설정
            targetPosition = new Vector3(fminX, transform.position.y, transform.position.z);
        }

        // 보스를 목표 위치로 이동시킵니다.
        // 이동 속도는 fmoveSpeed에 Time.deltaTime을
        // 곱하여 프레임에 독립적인 이동을 구현
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, fmoveSpeed * Time.deltaTime);

        // 보스가 목표 위치에 도달한 경우 이동 방향을 반대로 전환합니다.
        if (transform.position == targetPosition)
        {
            ismovingRight = !ismovingRight;
        }
    }

}
