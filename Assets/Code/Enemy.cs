using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float fspeed = 0.8f; // 적군 이동 속도 변수
    public int score; // 적군 비행선에 따른 점수 변수
    private GameDirector gameDirector;

    private float fmoveDistance = 1f; // 좌우로 이동할 거리
    private float fmoveDelay = 1.5f; // 좌우 이동 간격
    private float fmoveTimer = 0f; // 이동 타이머

    private float fminX = -2.58f; // 적군의 좌측 한계 위치
    private float fmaxX = 2.58f; // 적군의 우측 한계 위치
    private float ftargetX; // 이동할 목표 위치

    // Start is called before the first frame update
    void Start()
    {
        gameDirector = FindObjectOfType<GameDirector>();

        // 초기 이동 목표 위치 설정
        SetNewTargetX();
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy(); // 적군 이동

        // 적군이 일정 위치까지 내려오면 제거
        if (transform.position.y < -5.19f)
        {
            Destroy(gameObject);
        }
    }

    // 적군 이동 함수
    private void MoveEnemy()
    {
        // 좌우로 이동
        fmoveTimer += Time.deltaTime;
        if (fmoveTimer >= fmoveDelay)
        {
            SetNewTargetX(); // 새로운 이동 목표 위치 설정
            fmoveTimer = 0f;
        }
        // 적군이 이동해야 할 거리 계산
        float step = fspeed * Time.deltaTime;
        // 현재 위치에서 목표위치로 step만큼 이동
        // MoveTowards 함수는 시작 위치, 목표 위치, 이동 거리(step)를 받아서
        // 두 개의 값 또는 벡터 사이에서 선형적으로 중간 값을 구하는 것
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(ftargetX, transform.position.y, transform.position.z), step);

        // 아래로 이동
        transform.Translate(Vector3.up * fspeed * Time.deltaTime);
    }

    private void SetNewTargetX()
    {
        // 좌우 이동할 목표 위치를 랜덤하게 설정
        ftargetX = Random.Range(fminX, fmaxX);
    }

    // Player와 충돌 시 게임 종료와 shootingGV 화면으로 이동
    // Debug로 죽었을 때에 점수 출력
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("게임 종료");
            SceneManager.LoadScene("shootingGV");
            Debug.Log("마지막 점수: " + gameDirector.GetScore());
        }
    }
}
