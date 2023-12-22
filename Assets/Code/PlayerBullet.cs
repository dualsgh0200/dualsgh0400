using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private float fspeed = 7; // 플레이어 이동 속도 변수
    public GameObject explosionPrefab; // 충돌 시 생성되는 프리팹

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Fire(); //총알 발사
    }

    //적과 충돌 시 처리 함수
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            float fscoreToAdd = 0f;
            GameDirector director = GameObject.FindObjectOfType<GameDirector>();
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            fscoreToAdd = enemy.score;
            director.UpdateScore(enemy.score); // 게임디렉터를 통해 점수 업데이트
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            // 폭발 효과 생성
            // 현재 적의 위치에 prefab 일어날 수 있게 함
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }
        else if (collision.gameObject.tag == "Boss")
        {
            // 보스와 충돌한 경우 처리 코드
            Boss boss = collision.gameObject.GetComponent<Boss>();
            boss.TakeDamage(5f); // 보스의 HP를 5 감소시킴
            Destroy(this.gameObject);
        }
    }
    void Fire()
    {
        // 총알을 정해진 속도로 이동시킴
        this.transform.Translate(this.transform.up * this.fspeed * Time.deltaTime);
        // 화면을 벗어난 총알 파괴
        if (this.transform.position.y > 4.81f)
        {
            Destroy(this.gameObject);
        }
    }
}
